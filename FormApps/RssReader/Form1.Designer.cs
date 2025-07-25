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
            tbUrl = new ComboBox();
            btRssGet = new Button();
            lbTitels = new ListBox();
            mvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btForward = new Button();
            btBack = new Button();
            tbBookMarkName = new TextBox();
            btBookmark = new Button();
            label1 = new Label();
            btHome = new Button();
            btDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)mvRssLink).BeginInit();
            SuspendLayout();
            // 
            // tbUrl
            // 
            tbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbUrl.Location = new Point(217, 15);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(490, 33);
            tbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(713, 15);
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
            // mvRssLink
            // 
            mvRssLink.AllowExternalDrop = true;
            mvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mvRssLink.CreationProperties = null;
            mvRssLink.DefaultBackgroundColor = Color.White;
            mvRssLink.Location = new Point(12, 292);
            mvRssLink.Name = "mvRssLink";
            mvRssLink.Size = new Size(887, 393);
            mvRssLink.TabIndex = 3;
            mvRssLink.ZoomFactor = 1D;
            mvRssLink.SourceChanged += mvRssLink_SourceChanged;
            // 
            // btForward
            // 
            btForward.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btForward.Location = new Point(93, 14);
            btForward.Name = "btForward";
            btForward.Size = new Size(78, 29);
            btForward.TabIndex = 4;
            btForward.Text = "進む";
            btForward.UseVisualStyleBackColor = true;
            btForward.Click += btForward_Click;
            // 
            // btBack
            // 
            btBack.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btBack.Location = new Point(12, 15);
            btBack.Name = "btBack";
            btBack.Size = new Size(75, 28);
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
            label1.Location = new Point(17, 65);
            label1.Name = "label1";
            label1.Size = new Size(154, 15);
            label1.TabIndex = 8;
            label1.Text = "お気に入りの名前を登録/削除";
            // 
            // btHome
            // 
            btHome.BackColor = SystemColors.Control;
            btHome.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btHome.Location = new Point(177, 14);
            btHome.Name = "btHome";
            btHome.Size = new Size(34, 32);
            btHome.TabIndex = 10;
            btHome.Text = "⌂﻿";
            btHome.UseVisualStyleBackColor = false;
            btHome.Click += btHome_Click;
            // 
            // btDelete
            // 
            btDelete.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDelete.Location = new Point(777, 53);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(53, 36);
            btDelete.TabIndex = 11;
            btDelete.Text = "削除";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 743);
            Controls.Add(btDelete);
            Controls.Add(btHome);
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
            Load += Form1_Load;
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
        private Button btHome;
        private Button btDelete;
    }
}
