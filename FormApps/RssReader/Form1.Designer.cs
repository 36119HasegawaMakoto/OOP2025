﻿namespace RssReader {
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
            tbUrl = new ComboBox();
            btRssGet = new Button();
            lbTitels = new ListBox();
            mvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btForward = new Button();
            btBack = new Button();
            tbBookMarkName = new TextBox();
            btBookmark = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)mvRssLink).BeginInit();
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
            lbTitels.Location = new Point(12, 93);
            lbTitels.Name = "lbTitels";
            lbTitels.Size = new Size(887, 193);
            lbTitels.TabIndex = 2;
            lbTitels.Click += lbTitels_Click;
            // 
            // webView21
            // 
            mvRssLink.AllowExternalDrop = true;
            mvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mvRssLink.CreationProperties = null;
            mvRssLink.DefaultBackgroundColor = Color.White;
            mvRssLink.Location = new Point(12, 292);
            mvRssLink.Name = "webView21";
            mvRssLink.Size = new Size(887, 393);
            mvRssLink.TabIndex = 3;
            mvRssLink.ZoomFactor = 1D;
            // 
            // btForward
            // 
            btForward.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btForward.Location = new Point(93, 16);
            btForward.Name = "btForward";
            btForward.Size = new Size(78, 31);
            btForward.TabIndex = 4;
            btForward.Text = "進む";
            btForward.UseVisualStyleBackColor = true;
            btForward.Click += btForward_Click;
            // 
            // btBack
            // 
            btBack.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btBack.Location = new Point(12, 16);
            btBack.Name = "btBack";
            btBack.Size = new Size(75, 29);
            btBack.TabIndex = 5;
            btBack.Text = "戻る";
            btBack.UseVisualStyleBackColor = true;
            btBack.Click += btBack_Click;
            // 
            // tbBookMarkName
            // 
            tbBookMarkName.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbBookMarkName.Location = new Point(191, 57);
            tbBookMarkName.Name = "tbBookMarkName";
            tbBookMarkName.Size = new Size(444, 29);
            tbBookMarkName.TabIndex = 6;
            // 
            // btBookmark
            // 
            btBookmark.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btBookmark.Location = new Point(641, 53);
            btBookmark.Name = "btBookmark";
            btBookmark.Size = new Size(121, 34);
            btBookmark.TabIndex = 7;
            btBookmark.Text = "お気に入り登録";
            btBookmark.UseVisualStyleBackColor = true;
            btBookmark.Click += btBookmark_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 65);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 8;
            label1.Text = "お気に入りの名前を登録";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 743);
            Controls.Add(label1);
            Controls.Add(btBookmark);
            Controls.Add(tbBookMarkName);
            Controls.Add(btBack);
            Controls.Add(btForward);
            Controls.Add(mvRssLink);
            Controls.Add(lbTitels);
            Controls.Add(btRssGet);
            Controls.Add(tbUrl);
            Name = "Form1";
            Text = "RSSリーダー";
            ((System.ComponentModel.ISupportInitialize)mvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox tbUrl;
        private Button btRssGet;
        private ListBox lbTitels;
        private Microsoft.Web.WebView2.WinForms.WebView2 mvRssLink;
        private Button btForward;
        private Button btBack;
        private TextBox tbBookMarkName;
        private Button btBookmark;
        private Label label1;
    }
}
