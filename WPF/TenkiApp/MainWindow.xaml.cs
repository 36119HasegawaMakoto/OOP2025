using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TenkiApp.Models;


namespace TenkiApp {
    public partial class MainWindow : Window {
        private readonly HttpClient _http = new();
        private List<Prefecture> _prefs = new();
        private Dictionary<string, List<Municipality>> _municipalities = new();
        private JsonDocument _areaDoc;
        private Dictionary<string, (double lat, double lon)> _coordinates = new();
        private ObservableCollection<string> _favorites = new();
        private Dictionary<string, (string prefCode, string cityCode)> _favoriteLocations = new();
        private const string FAVORITES_FILE = "favorites.json";

        public MainWindow() {
            InitializeComponent();
            LstFavorites.ItemsSource = _favorites;
            Loaded += async (_, __) => {
                await LoadFavoritesAsync();
                await LoadPrefCityAsync();
            };
        }

        private async Task LoadPrefCityAsync() {
            try {
                ShowLoading(true);

                string xyUrl = "https://www.jma.go.jp/bosai/common/const/xy.json";
                string xyJson = await _http.GetStringAsync(xyUrl);
                var xyDoc = JsonDocument.Parse(xyJson);

                if (xyDoc.RootElement.TryGetProperty("class20s", out var class20Coords)) {
                    foreach (var coord in class20Coords.EnumerateObject()) {
                        var code = coord.Name;
                        if (coord.Value.ValueKind == JsonValueKind.Array) {
                            var arr = coord.Value.EnumerateArray().ToArray();
                            if (arr.Length >= 2) {
                                double lat = arr[0].GetDouble();
                                double lon = arr[1].GetDouble();
                                _coordinates[code] = (lat, lon);
                            }
                        }
                    }
                }

                string url = "https://www.jma.go.jp/bosai/common/const/area.json";
                string json = await _http.GetStringAsync(url);
                _areaDoc = JsonDocument.Parse(json);

                if (_areaDoc.RootElement.TryGetProperty("offices", out var offices)) {
                    foreach (var office in offices.EnumerateObject()) {
                        var code = office.Name;
                        var officeData = office.Value;

                        if (officeData.TryGetProperty("parent", out var _)) {
                            var name = officeData.GetProperty("name").GetString();
                            _prefs.Add(new Prefecture { Code = code, Name = name });
                            _municipalities[code] = new List<Municipality>();
                        }
                    }
                }

                if (_areaDoc.RootElement.TryGetProperty("class20s", out var class20s)) {
                    foreach (var city in class20s.EnumerateObject()) {
                        var cityCode = city.Name;
                        var cityData = city.Value;

                        string cityName = cityData.GetProperty("name").GetString();

                        double lat = 0, lon = 0;
                        if (_coordinates.TryGetValue(cityCode, out var coords)) {
                            lat = coords.lat;
                            lon = coords.lon;
                        }

                        if (lat == 0 || lon == 0) continue;

                        string officeCode = FindOfficeForClass20(cityCode);

                        if (!string.IsNullOrEmpty(officeCode) && _municipalities.ContainsKey(officeCode)) {
                            _municipalities[officeCode].Add(new Municipality {
                                Code = cityCode,
                                Name = cityName,
                                Latitude = lat,
                                Longitude = lon
                            });
                        }
                    }
                }

                CmbPref.ItemsSource = _prefs.OrderBy(p => p.Name);
            }
            catch (Exception ex) {
                MessageBox.Show("地域データ読み込みエラー: " + ex.Message);
            }
            finally {
                ShowLoading(false);
            }
        }

        private string FindOfficeForClass20(string class20Code) {
            try {
                if (_areaDoc.RootElement.TryGetProperty("class20s", out var class20s)) {
                    if (class20s.TryGetProperty(class20Code, out var class20)) {
                        if (class20.TryGetProperty("parent", out var class15CodeProp)) {
                            string class15Code = class15CodeProp.GetString();

                            if (_areaDoc.RootElement.TryGetProperty("class15s", out var class15s)) {
                                if (class15s.TryGetProperty(class15Code, out var class15)) {
                                    if (class15.TryGetProperty("parent", out var class10CodeProp)) {
                                        string class10Code = class10CodeProp.GetString();

                                        if (_areaDoc.RootElement.TryGetProperty("class10s", out var class10s)) {
                                            if (class10s.TryGetProperty(class10Code, out var class10)) {
                                                if (class10.TryGetProperty("parent", out var officeCodeProp)) {
                                                    return officeCodeProp.GetString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return "";
        }

        private async void CmbPref_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CmbPref.SelectedItem is not Prefecture sel) return;

            var cities = _municipalities.TryGetValue(sel.Code, out var list)
                ? list.OrderBy(c => c.Name).ToList()
                : new List<Municipality>();

            CmbCity.ItemsSource = cities;
            CmbCity.SelectedIndex = -1;

            ClearWeatherDisplay();
        }

        private async void CmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CmbCity.SelectedItem is not Municipality city) return;
            await LoadWeatherForLocation(city.Latitude, city.Longitude);
        }

        private async Task LoadWeatherForLocation(double lat, double lon) {
            try {
                ShowLoading(true);

                string latStr = lat.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = lon.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);

                string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latStr}&longitude={lonStr}&current_weather=true&daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=Asia/Tokyo";

                string json = await _http.GetStringAsync(apiUrl);
                var weather = JsonSerializer.Deserialize<OpenMeteoResponse>(json);

                if (weather?.Current != null) {
                    TxtTime.Text = $"⏰ {weather.Current.Time}";
                    TxtTemp.Text = $"🌡️ {weather.Current.Temperature:F1}°C";
                    TxtWind.Text = $"💨 {weather.Current.WindSpeed:F1} km/h";
                    TxtWeather.Text = $"{GetWeatherEmoji(weather.Current.WeatherCode)} {GetWeatherDescription(weather.Current.WeatherCode)}";
                }

                if (weather?.Daily != null) {
                    var forecasts = new List<DayForecast>();
                    for (int i = 0; i < Math.Min(7, weather.Daily.Time.Length); i++) {
                        forecasts.Add(new DayForecast {
                            Date = DateTime.Parse(weather.Daily.Time[i]).ToString("M月d日 (ddd)"),
                            WeatherEmoji = GetWeatherEmoji(weather.Daily.WeatherCode[i]),
                            Description = GetWeatherDescription(weather.Daily.WeatherCode[i]),
                            MaxTemp = $"{weather.Daily.TemperatureMax[i]:F1}°C",
                            MinTemp = $"{weather.Daily.TemperatureMin[i]:F1}°C"
                        });
                    }
                    WeeklyForecast.ItemsSource = forecasts;
                }
            }
            catch (HttpRequestException ex) {
                MessageBox.Show($"ネットワークエラー: インターネット接続を確認してください。\n{ex.Message}");
            }
            catch (JsonException ex) {
                MessageBox.Show($"データ解析エラー: {ex.Message}");
            }
            catch (Exception ex) {
                MessageBox.Show($"天気情報取得エラー: {ex.Message}");
            }
            finally {
                ShowLoading(false);
            }
        }

        private async void BtnCurrentLocation_Click(object sender, RoutedEventArgs e) {
            try {
                ShowLoading(true);
                var (lat, lon) = await GetLocationByIP();
                await LoadWeatherForLocation(lat, lon);
                CmbPref.SelectedIndex = -1;
                CmbCity.SelectedIndex = -1;
            }
            catch (Exception ex) {
                MessageBox.Show($"現在地（IP）取得エラー: {ex.Message}");
            }
            finally {
                ShowLoading(false);
            }
        }

        private void BtnAddFavorite_Click(object sender, RoutedEventArgs e) {
            if (CmbPref.SelectedItem is not Prefecture pref || CmbCity.SelectedItem is not Municipality city) {
                MessageBox.Show("都道府県と市町村を選択してください。");
                return;
            }

            string favName = $"{pref.Name} - {city.Name}";
            if (!_favorites.Contains(favName)) {
                _favorites.Add(favName);
                _favoriteLocations[favName] = (pref.Code, city.Code);
                SaveFavoritesAsync();
            }
        }

        private void BtnRemoveFavorite_Click(object sender, RoutedEventArgs e) {
            if (sender is Button btn && btn.Tag is string favName) {
                _favorites.Remove(favName);
                _favoriteLocations.Remove(favName);
                SaveFavoritesAsync();
            }
        }

        private async void LstFavorites_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LstFavorites.SelectedItem is not string favName) return;

            if (_favoriteLocations.TryGetValue(favName, out var location)) {
                var pref = _prefs.FirstOrDefault(p => p.Code == location.prefCode);
                if (pref != null) {
                    CmbPref.SelectedItem = pref;

                    var cities = _municipalities[location.prefCode];
                    var city = cities.FirstOrDefault(c => c.Code == location.cityCode);
                    if (city != null) {
                        CmbCity.SelectedItem = city;
                    }
                }
            }

            LstFavorites.SelectedIndex = -1;
        }

        // =======================================
        // お気に入りの永続化
        // =======================================
        private async Task LoadFavoritesAsync() {
            try {
                if (File.Exists(FAVORITES_FILE)) {
                    string json = await File.ReadAllTextAsync(FAVORITES_FILE);
                    var savedFavorites = JsonSerializer.Deserialize<Dictionary<string, (string prefCode, string cityCode)>>(json);

                    if (savedFavorites != null) {
                        _favoriteLocations = savedFavorites;
                        foreach (var fav in savedFavorites) {
                            _favorites.Add(fav.Key);
                        }
                    }
                }
            }
            catch (Exception ex) {
                // エラーが出てもアプリは続行
                System.Diagnostics.Debug.WriteLine($"お気に入り読み込みエラー: {ex.Message}");
            }
        }

        private async void SaveFavoritesAsync() {
            try {
                var json = JsonSerializer.Serialize(_favoriteLocations, new JsonSerializerOptions {
                    WriteIndented = true
                });
                await File.WriteAllTextAsync(FAVORITES_FILE, json);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"お気に入り保存エラー: {ex.Message}");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            SaveFavoritesAsync();
        }

        // =======================================
        // ローディングインジケーター
        // =======================================
        private void ShowLoading(bool show) {
            LoadingOverlay.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ClearWeatherDisplay() {
            TxtTime.Text = "";
            TxtTemp.Text = "";
            TxtWind.Text = "";
            TxtWeather.Text = "";
            WeeklyForecast.ItemsSource = null;
        }

        private string GetWeatherEmoji(int code) {
            return code switch {
                0 => "☀️",
                1 => "🌤️",
                2 or 3 => "☁️",
                45 or 48 => "🌫️",
                51 or 53 or 55 or 61 or 63 or 65 or 80 or 81 or 82 => "🌧️",
                71 or 73 or 75 or 85 or 86 => "🌨️",
                77 => "🌨️",
                95 or 96 or 99 => "⛈️",
                _ => "🌡️"
            };
        }

        private string GetWeatherDescription(int code) {
            return code switch {
                0 => "快晴",
                1 => "晴れ",
                2 => "一部曇り",
                3 => "曇り",
                45 or 48 => "霧",
                51 or 53 or 55 => "霧雨",
                61 or 63 or 65 => "雨",
                71 or 73 or 75 => "雪",
                77 => "みぞれ",
                80 or 81 or 82 => "にわか雨",
                85 or 86 => "にわか雪",
                95 => "雷雨",
                96 or 99 => "雹を伴う雷雨",
                _ => $"不明 ({code})"
            };
        }

        private async Task<(double lat, double lon)> GetLocationByIP() {
            try {
                string url = "https://ipapi.co/json/";
                string json = await _http.GetStringAsync(url);

                using var doc = JsonDocument.Parse(json);

                double lat = doc.RootElement.GetProperty("latitude").GetDouble();
                double lon = doc.RootElement.GetProperty("longitude").GetDouble();

                return (lat, lon);
            }
            catch {
                throw new Exception("IP位置情報の取得に失敗しました。");
            }
        }
    }
}