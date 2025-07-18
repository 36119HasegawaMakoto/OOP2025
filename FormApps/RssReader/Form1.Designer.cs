namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tbUrl = new TextBox();
            btRssGet = new Button();
            lbTitels = new ListBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // tbUrl
            // 
            tbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbUrl.Location = new Point(191, 14);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(490, 33);
            tbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(687, 13);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(75, 34);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitels
            // 
            lbTitels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitels.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitels.FormattingEnabled = true;
            lbTitels.ItemHeight = 21;
            lbTitels.Location = new Point(12, 51);
            lbTitels.Name = "lbTitels";
            lbTitels.Size = new Size(887, 193);
            lbTitels.TabIndex = 2;
            lbTitels.Click += lbTitels_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(12, 242);
            webView21.Name = "webView21";
            webView21.Size = new Size(887, 443);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 34);
            button1.TabIndex = 1;
            button1.Text = "取得";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btRssGet_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button2.Location = new Point(93, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 34);
            button2.TabIndex = 1;
            button2.Text = "取得";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btRssGet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 743);
            Controls.Add(webView21);
            Controls.Add(lbTitels);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btRssGet);
            Controls.Add(tbUrl);
            Name = "Form1";
            Text = "RSSリーダー";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUrl;
        private Button btRssGet;
        private ListBox lbTitels;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button button1;
        private Button button2;
    }
}
