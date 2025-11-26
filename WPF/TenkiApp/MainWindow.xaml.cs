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
using System.Windows.Input;
using TenkiApp.Models;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private readonly HttpClient _http = new();
        private List<Prefecture> _prefs = new();
        private Dictionary<string, List<Municipality>> _municipalities = new();
        private JsonDocument _areaDoc;
        private Dictionary<string, (double lat, double lon)> _coordinates = new();
        private ObservableCollection<string> _favorites = new();
        private Dictionary<string, FavoriteLocation> _favoriteLocations = new();
        private const string FAVORITES_FILE = "favorites.json";

        public MainWindow() {
            InitializeComponent();

            // タイムアウトを設定
            _http.Timeout = TimeSpan.FromSeconds(30);

            LstFavorites.ItemsSource = _favorites;

            // 最初は無効化
            LstFavorites.IsEnabled = false;

            // TextChanged イベントを追加
            CmbPref.AddHandler(TextBox.TextChangedEvent, new TextChangedEventHandler(CmbPref_TextChanged));
            CmbCity.AddHandler(TextBox.TextChangedEvent, new TextChangedEventHandler(CmbCity_TextChanged));

            Loaded += async (_, __) => {
                await LoadPrefCityAsync();
                await LoadFavoritesAsync();

                // 読み込み完了後に有効化
                LstFavorites.IsEnabled = true;
            };
        }

        private async Task LoadPrefCityAsync() {
            JsonDocument newAreaDoc = null;
            try {
                ShowLoading(true);

                // 座標データの取得
                string xyUrl = "https://www.jma.go.jp/bosai/common/const/xy.json";
                string xyJson = await _http.GetStringAsync(xyUrl);
                using var xyDoc = JsonDocument.Parse(xyJson);

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

                // 地域データの取得
                string url = "https://www.jma.go.jp/bosai/common/const/area.json";
                string json = await _http.GetStringAsync(url);

                newAreaDoc = JsonDocument.Parse(json);

                // 成功した場合のみ古いドキュメントを破棄
                _areaDoc?.Dispose();
                _areaDoc = newAreaDoc;

                // 都道府県（offices）の読み込み
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

                // 市町村（class20s）の読み込み
                if (_areaDoc.RootElement.TryGetProperty("class20s", out var class20s)) {
                    foreach (var city in class20s.EnumerateObject()) {
                        var cityCode = city.Name;
                        var cityData = city.Value;

                        string cityName = cityData.GetProperty("name").GetString();

                        // 座標の取得
                        if (!_coordinates.TryGetValue(cityCode, out var coords)) {
                            continue;
                        }

                        if (coords.lat == 0 || coords.lon == 0) continue;

                        // 所属する都道府県の特定
                        string officeCode = FindOfficeForClass20(cityCode);

                        if (!string.IsNullOrEmpty(officeCode) && _municipalities.ContainsKey(officeCode)) {
                            _municipalities[officeCode].Add(new Municipality {
                                Code = cityCode,
                                Name = cityName,
                                Latitude = coords.lat,
                                Longitude = coords.lon
                            });
                        }
                    }
                }

                CmbPref.ItemsSource = _prefs.OrderBy(p => p.Name);
            }
            catch (HttpRequestException ex) {
                newAreaDoc?.Dispose();
                MessageBox.Show($"ネットワークエラー: インターネット接続を確認してください。\n詳細: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (JsonException ex) {
                newAreaDoc?.Dispose();
                MessageBox.Show($"データ解析エラー: 気象庁のデータ形式が変更された可能性があります。\n詳細: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                newAreaDoc?.Dispose();
                MessageBox.Show($"地域データ読み込みエラー: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                ShowLoading(false);
            }
        }

        private string FindOfficeForClass20(string class20Code) {
            try {
                if (!_areaDoc.RootElement.TryGetProperty("class20s", out var class20s)) {
                    return "";
                }

                if (!class20s.TryGetProperty(class20Code, out var class20)) {
                    return "";
                }

                if (!class20.TryGetProperty("parent", out var class15CodeProp)) {
                    return "";
                }

                string class15Code = class15CodeProp.GetString();

                if (!_areaDoc.RootElement.TryGetProperty("class15s", out var class15s)) {
                    return "";
                }

                if (!class15s.TryGetProperty(class15Code, out var class15)) {
                    return "";
                }

                if (!class15.TryGetProperty("parent", out var class10CodeProp)) {
                    return "";
                }

                string class10Code = class10CodeProp.GetString();

                if (!_areaDoc.RootElement.TryGetProperty("class10s", out var class10s)) {
                    return "";
                }

                if (!class10s.TryGetProperty(class10Code, out var class10)) {
                    return "";
                }

                if (class10.TryGetProperty("parent", out var officeCodeProp)) {
                    return officeCodeProp.GetString();
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"FindOfficeForClass20 エラー: {ex.Message}");
            }

            return "";
        }

        private void CmbPref_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CmbPref.SelectedItem is not Prefecture sel) return;

            var cities = _municipalities.TryGetValue(sel.Code, out var list)
                ? list.OrderBy(c => c.Name).ToList()
                : new List<Municipality>();

            CmbCity.ItemsSource = cities;
            CmbCity.SelectedIndex = -1;

            // 天気表示をクリア（お気に入りからの選択時以外）
            if (e.AddedItems.Count > 0) {
                ClearWeatherDisplay();
            }
        }

        private void CmbPref_TextChanged(object sender, TextChangedEventArgs e) {
            if (sender is not ComboBox combo) return;
            if (_prefs.Count == 0) return;

            if (!combo.IsDropDownOpen) combo.IsDropDownOpen = true;

            string filter = combo.Text?.ToLower() ?? "";

            if (string.IsNullOrWhiteSpace(filter)) {
                combo.ItemsSource = _prefs.OrderBy(p => p.Name);
                return;
            }

            var filtered = _prefs.Where(p => p.Name.ToLower().Contains(filter))
                                 .OrderBy(p => p.Name)
                                 .ToList();

            combo.ItemsSource = filtered;
        }

        private async void CmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CmbCity.SelectedItem is not Municipality city) return;

            await LoadWeatherForLocation(city.Latitude, city.Longitude);
        }

        private void CmbCity_TextChanged(object sender, TextChangedEventArgs e) {
            if (sender is not ComboBox combo) return;
            if (CmbPref.SelectedItem is not Prefecture pref) return;

            if (!combo.IsDropDownOpen) combo.IsDropDownOpen = true;

            string filter = combo.Text?.ToLower() ?? "";

            if (!_municipalities.TryGetValue(pref.Code, out var allCities)) return;

            if (string.IsNullOrWhiteSpace(filter)) {
                combo.ItemsSource = allCities.OrderBy(c => c.Name);
                return;
            }

            var filtered = allCities.Where(c => c.Name.ToLower().Contains(filter))
                                   .OrderBy(c => c.Name)
                                   .ToList();

            combo.ItemsSource = filtered;
        }

        private async Task LoadWeatherForLocation(double lat, double lon) {
            try {
                ShowLoading(true);

                string latStr = lat.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = lon.ToString("F6", System.Globalization.CultureInfo.InvariantCulture);

                string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latStr}&longitude={lonStr}&current_weather=true&hourly=temperature_2m,precipitation,weathercode&daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=Asia/Tokyo";

                string json = await _http.GetStringAsync(apiUrl);
                var weather = JsonSerializer.Deserialize<OpenMeteoResponse>(json);

                if (weather?.Current != null) {
                    TxtTime.Text = $"⏰ {weather.Current.Time}";
                    TxtTemp.Text = $"🌡️ {weather.Current.Temperature:F1}°C";
                    TxtWind.Text = $"💨 {weather.Current.WindSpeed:F1} km/h";
                    TxtWeather.Text = $"{GetWeatherEmoji(weather.Current.WeatherCode)} {GetWeatherDescription(weather.Current.WeatherCode)}";
                }

                // 今日の時間ごとの天気
                if (weather?.Hourly != null) {
                    var hourlyForecasts = new List<HourlyForecast>();
                    var now = DateTime.Now;
                    int count = 0;
                    int maxItems = 12; // 最大12時間分表示

                    for (int i = 0; i < weather.Hourly.Time.Length && count < maxItems; i++) {
                        if (DateTime.TryParse(weather.Hourly.Time[i], out var time)) {
                            // 現在時刻以降のデータを表示
                            if (time >= now) {
                                hourlyForecasts.Add(new HourlyForecast {
                                    Time = time.ToString("HH:mm"),
                                    WeatherEmoji = GetWeatherEmoji(weather.Hourly.WeatherCode[i]),
                                    Temperature = $"{weather.Hourly.Temperature[i]:F1}°C",
                                    Precipitation = $"{weather.Hourly.Precipitation[i]:F1}mm"
                                });
                                count++;
                            }
                        }
                    }

                    if (hourlyForecasts.Count == 0) {
                        // データがない場合のメッセージ
                        hourlyForecasts.Add(new HourlyForecast {
                            Time = "---",
                            WeatherEmoji = "ℹ️",
                            Temperature = "データなし",
                            Precipitation = "---"
                        });
                    }

                    HourlyForecast.ItemsSource = hourlyForecasts;
                }

                if (weather?.Daily != null) {
                    var forecasts = new List<DayForecast>();
                    int days = Math.Min(7, weather.Daily.Time.Length);

                    for (int i = 0; i < days; i++) {
                        if (DateTime.TryParse(weather.Daily.Time[i], out var date)) {
                            forecasts.Add(new DayForecast {
                                Date = date.ToString("M月d日 (ddd)"),
                                WeatherEmoji = GetWeatherEmoji(weather.Daily.WeatherCode[i]),
                                Description = GetWeatherDescription(weather.Daily.WeatherCode[i]),
                                MaxTemp = $"{weather.Daily.TemperatureMax[i]:F1}°C",
                                MinTemp = $"{weather.Daily.TemperatureMin[i]:F1}°C"
                            });
                        }
                    }
                    WeeklyForecast.ItemsSource = forecasts;
                }
            }
            catch (HttpRequestException ex) {
                MessageBox.Show($"ネットワークエラー: インターネット接続を確認してください。\n詳細: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (JsonException ex) {
                MessageBox.Show($"データ解析エラー: 天気データの形式が変更された可能性があります。\n詳細: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) {
                MessageBox.Show($"天気情報取得エラー: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
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

                // コンボボックスをクリア
                CmbPref.SelectedIndex = -1;
                CmbCity.SelectedIndex = -1;
            }
            catch (HttpRequestException ex) {
                MessageBox.Show($"位置情報の取得に失敗しました。\nインターネット接続を確認してください。\n詳細: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) {
                MessageBox.Show($"現在地取得エラー: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                ShowLoading(false);
            }
        }

        private void BtnAddFavorite_Click(object sender, RoutedEventArgs e) {
            if (CmbPref.SelectedItem is not Prefecture pref || CmbCity.SelectedItem is not Municipality city) {
                MessageBox.Show("都道府県と市町村を選択してください。",
                    "お知らせ", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string favName = $"{pref.Name} - {city.Name}";
            if (_favorites.Contains(favName)) {
                MessageBox.Show("この地域は既にお気に入りに登録されています。",
                    "お知らせ", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            _favorites.Add(favName);
            _favoriteLocations[favName] = new FavoriteLocation {
                PrefCode = pref.Code,
                CityCode = city.Code
            };
            _ = SaveFavoritesAsync();

            MessageBox.Show($"「{favName}」をお気に入りに追加しました！",
                "成功", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnRemoveFavorite_Click(object sender, RoutedEventArgs e) {
            if (sender is Button btn && btn.Tag is string favName) {
                _favorites.Remove(favName);
                _favoriteLocations.Remove(favName);
                _ = SaveFavoritesAsync();
            }
        }

        private async void LstFavorites_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LstFavorites.SelectedItem is not string favName) return;

            try {
                ShowLoading(true);

                // 地域データがまだ読み込まれていない場合
                if (_prefs.Count == 0) {
                    MessageBox.Show("地域データを読み込み中です。\nしばらくお待ちください。",
                        "お知らせ", MessageBoxButton.OK, MessageBoxImage.Information);
                    LstFavorites.SelectedIndex = -1;
                    return;
                }

                if (_favoriteLocations.TryGetValue(favName, out var location)) {
                    var pref = _prefs.FirstOrDefault(p => p.Code == location.PrefCode);
                    if (pref != null) {
                        // 都道府県を設定
                        CmbPref.SelectedItem = pref;

                        // 市町村リストを更新
                        if (_municipalities.TryGetValue(location.PrefCode, out var cities)) {
                            CmbCity.ItemsSource = cities.OrderBy(c => c.Name).ToList();

                            var city = cities.FirstOrDefault(c => c.Code == location.CityCode);
                            if (city != null) {
                                // 市町村を設定
                                CmbCity.SelectedItem = city;

                                // 天気情報を読み込み
                                await LoadWeatherForLocation(city.Latitude, city.Longitude);
                            } else {
                                MessageBox.Show($"市町村が見つかりませんでした: {location.CityCode}",
                                    "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        } else {
                            MessageBox.Show($"都道府県データが見つかりませんでした: {location.PrefCode}",
                                "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    } else {
                        MessageBox.Show($"都道府県が見つかりませんでした: {location.PrefCode}\n" +
                            "お気に入りのデータが古い可能性があります。",
                            "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"お気に入りの読み込みエラー: {ex.Message}",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                ShowLoading(false);
                // 選択状態をクリア
                LstFavorites.SelectedIndex = -1;
            }
        }

        // =======================================
        // お気に入りの永続化
        // =======================================
        private async Task LoadFavoritesAsync() {
            try {
                if (!File.Exists(FAVORITES_FILE)) {
                    return;
                }

                string json = await File.ReadAllTextAsync(FAVORITES_FILE);

                var options = new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                };

                var savedFavorites = JsonSerializer.Deserialize<Dictionary<string, FavoriteLocation>>(json, options);

                if (savedFavorites != null && savedFavorites.Count > 0) {
                    _favoriteLocations = savedFavorites;
                    foreach (var fav in savedFavorites) {
                        // 空のデータはスキップ
                        if (string.IsNullOrEmpty(fav.Value?.PrefCode) || string.IsNullOrEmpty(fav.Value?.CityCode)) {
                            System.Diagnostics.Debug.WriteLine($"スキップ: {fav.Key} (データが空)");
                            continue;
                        }
                        _favorites.Add(fav.Key);
                    }
                }
            }
            catch (JsonException ex) {
                System.Diagnostics.Debug.WriteLine($"お気に入り読み込みエラー（JSON）: {ex.Message}");

                var result = MessageBox.Show(
                    "お気に入りデータが破損しています。\n初期化しますか？",
                    "エラー",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) {
                    try {
                        File.Delete(FAVORITES_FILE);
                    }
                    catch { }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"お気に入り読み込みエラー: {ex.Message}");
            }
        }

        private async Task SaveFavoritesAsync() {
            try {
                var options = new JsonSerializerOptions {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                var json = JsonSerializer.Serialize(_favoriteLocations, options);
                await File.WriteAllTextAsync(FAVORITES_FILE, json, System.Text.Encoding.UTF8);

                System.Diagnostics.Debug.WriteLine("お気に入り保存成功");
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"お気に入り保存エラー: {ex.Message}");
                MessageBox.Show("お気に入りの保存に失敗しました。",
                    "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // 保存を待つ
            await SaveFavoritesAsync();

            // リソースのクリーンアップ
            _areaDoc?.Dispose();
            _http?.Dispose();
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
            HourlyForecast.ItemsSource = null;
            WeeklyForecast.ItemsSource = null;
        }

        // =======================================
        // 天気コードの変換
        // =======================================
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

        // =======================================
        // IP位置情報の取得
        // =======================================
        private async Task<(double lat, double lon)> GetLocationByIP() {
            try {
                string url = "https://ipapi.co/json/";
                string json = await _http.GetStringAsync(url);

                using var doc = JsonDocument.Parse(json);

                if (!doc.RootElement.TryGetProperty("latitude", out var latProp) ||
                    !doc.RootElement.TryGetProperty("longitude", out var lonProp)) {
                    throw new Exception("位置情報が取得できませんでした。");
                }

                double lat = latProp.GetDouble();
                double lon = lonProp.GetDouble();

                return (lat, lon);
            }
            catch (HttpRequestException) {
                throw new Exception("IP位置情報サービスに接続できませんでした。");
            }
            catch (JsonException) {
                throw new Exception("位置情報データの解析に失敗しました。");
            }
        }
    }
}