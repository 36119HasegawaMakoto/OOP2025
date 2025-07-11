namespace CarReportSystem {
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dtpDate = new DateTimePicker();
            cbAuthor = new ComboBox();
            groupBox1 = new GroupBox();
            rbOther = new RadioButton();
            rbImport = new RadioButton();
            rbSubaru = new RadioButton();
            rbHonda = new RadioButton();
            rbNissan = new RadioButton();
            rbToyota = new RadioButton();
            cbCarName = new ComboBox();
            tbReport = new TextBox();
            dgvRecord = new DataGridView();
            pbPicture = new PictureBox();
            btPicOpen = new Button();
            btPicDelete = new Button();
            btRecordAdd = new Button();
            btRecordModify = new Button();
            btRecordDelete = new Button();
            ofdPicFileOpen = new OpenFileDialog();
            btNewRecord = new Button();
            ssMessageArea = new StatusStrip();
            tsslbMessage = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            ファイルToolStripMenuItem = new ToolStripMenuItem();
            開くToolStripMenuItem = new ToolStripMenuItem();
            保存ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            esmiCollor = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            esmiExit = new ToolStripMenuItem();
            ヘルプHToolStripMenuItem = new ToolStripMenuItem();
            tsmiAbout = new ToolStripMenuItem();
            cdCollar = new ColorDialog();
            sfdReportFileSave = new SaveFileDialog();
            ofdReportFileOpen = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            ssMessageArea.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(28, 45);
            label1.Name = "label1";
            label1.Size = new Size(55, 30);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(7, 93);
            label2.Name = "label2";
            label2.Size = new Size(76, 30);
            label2.TabIndex = 0;
            label2.Text = "記録者";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(12, 156);
            label3.Name = "label3";
            label3.Size = new Size(71, 30);
            label3.TabIndex = 0;
            label3.Text = "メーカー";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(28, 210);
            label4.Name = "label4";
            label4.Size = new Size(55, 30);
            label4.TabIndex = 0;
            label4.Text = "車名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(9, 262);
            label5.Name = "label5";
            label5.Size = new Size(74, 30);
            label5.TabIndex = 0;
            label5.Text = "レポート";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(28, 384);
            label6.Name = "label6";
            label6.Size = new Size(55, 30);
            label6.TabIndex = 0;
            label6.Text = "一覧";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(504, 60);
            label7.Name = "label7";
            label7.Size = new Size(55, 30);
            label7.TabIndex = 0;
            label7.Text = "画像";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(94, 43);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 33);
            dtpDate.TabIndex = 1;
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(94, 94);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(208, 33);
            cbAuthor.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbOther);
            groupBox1.Controls.Add(rbImport);
            groupBox1.Controls.Add(rbSubaru);
            groupBox1.Controls.Add(rbHonda);
            groupBox1.Controls.Add(rbNissan);
            groupBox1.Controls.Add(rbToyota);
            groupBox1.Location = new Point(94, 141);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(373, 53);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Location = new Point(307, 19);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(56, 19);
            rbOther.TabIndex = 5;
            rbOther.TabStop = true;
            rbOther.Text = "その他";
            rbOther.UseVisualStyleBackColor = true;
            // 
            // rbImport
            // 
            rbImport.AutoSize = true;
            rbImport.Location = new Point(240, 19);
            rbImport.Name = "rbImport";
            rbImport.Size = new Size(61, 19);
            rbImport.TabIndex = 4;
            rbImport.TabStop = true;
            rbImport.Text = "輸入車";
            rbImport.UseVisualStyleBackColor = true;
            // 
            // rbSubaru
            // 
            rbSubaru.AutoSize = true;
            rbSubaru.Location = new Point(180, 19);
            rbSubaru.Name = "rbSubaru";
            rbSubaru.Size = new Size(54, 19);
            rbSubaru.TabIndex = 3;
            rbSubaru.TabStop = true;
            rbSubaru.Text = "スバル";
            rbSubaru.UseVisualStyleBackColor = true;
            // 
            // rbHonda
            // 
            rbHonda.AutoSize = true;
            rbHonda.Location = new Point(121, 19);
            rbHonda.Name = "rbHonda";
            rbHonda.Size = new Size(53, 19);
            rbHonda.TabIndex = 2;
            rbHonda.TabStop = true;
            rbHonda.Text = "ホンダ";
            rbHonda.UseVisualStyleBackColor = true;
            // 
            // rbNissan
            // 
            rbNissan.AutoSize = true;
            rbNissan.Location = new Point(66, 19);
            rbNissan.Name = "rbNissan";
            rbNissan.Size = new Size(49, 19);
            rbNissan.TabIndex = 1;
            rbNissan.TabStop = true;
            rbNissan.Text = "日産";
            rbNissan.UseVisualStyleBackColor = true;
            // 
            // rbToyota
            // 
            rbToyota.AutoSize = true;
            rbToyota.Location = new Point(10, 19);
            rbToyota.Name = "rbToyota";
            rbToyota.Size = new Size(50, 19);
            rbToyota.TabIndex = 0;
            rbToyota.TabStop = true;
            rbToyota.Text = "トヨタ";
            rbToyota.UseVisualStyleBackColor = true;
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(94, 211);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(208, 33);
            cbCarName.TabIndex = 2;
            // 
            // tbReport
            // 
            tbReport.Location = new Point(94, 262);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(373, 98);
            tbReport.TabIndex = 4;
            // 
            // dgvRecord
            // 
            dgvRecord.AllowUserToAddRows = false;
            dgvRecord.AllowUserToDeleteRows = false;
            dgvRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecord.Location = new Point(94, 384);
            dgvRecord.MultiSelect = false;
            dgvRecord.Name = "dgvRecord";
            dgvRecord.ReadOnly = true;
            dgvRecord.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecord.Size = new Size(656, 192);
            dgvRecord.TabIndex = 5;
            dgvRecord.Click += dgvRecord_Click;
            // 
            // pbPicture
            // 
            pbPicture.BorderStyle = BorderStyle.FixedSingle;
            pbPicture.Location = new Point(504, 96);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(237, 196);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 6;
            pbPicture.TabStop = false;
            // 
            // btPicOpen
            // 
            btPicOpen.FlatStyle = FlatStyle.Flat;
            btPicOpen.Location = new Point(585, 60);
            btPicOpen.Name = "btPicOpen";
            btPicOpen.Size = new Size(75, 30);
            btPicOpen.TabIndex = 7;
            btPicOpen.Text = "開く...";
            btPicOpen.UseVisualStyleBackColor = true;
            btPicOpen.Click += btPicOpen_Click;
            // 
            // btPicDelete
            // 
            btPicDelete.FlatStyle = FlatStyle.Flat;
            btPicDelete.Location = new Point(666, 60);
            btPicDelete.Name = "btPicDelete";
            btPicDelete.Size = new Size(75, 30);
            btPicDelete.TabIndex = 8;
            btPicDelete.Text = "削除";
            btPicDelete.UseVisualStyleBackColor = true;
            btPicDelete.Click += btPicDelete_Click;
            // 
            // btRecordAdd
            // 
            btRecordAdd.FlatStyle = FlatStyle.Flat;
            btRecordAdd.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordAdd.Location = new Point(504, 314);
            btRecordAdd.Name = "btRecordAdd";
            btRecordAdd.Size = new Size(75, 46);
            btRecordAdd.TabIndex = 7;
            btRecordAdd.Text = "追加";
            btRecordAdd.UseVisualStyleBackColor = true;
            btRecordAdd.Click += btRecordAdd_Click;
            // 
            // btRecordModify
            // 
            btRecordModify.FlatStyle = FlatStyle.Flat;
            btRecordModify.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordModify.Location = new Point(585, 314);
            btRecordModify.Name = "btRecordModify";
            btRecordModify.Size = new Size(75, 46);
            btRecordModify.TabIndex = 7;
            btRecordModify.Text = "修正";
            btRecordModify.UseVisualStyleBackColor = true;
            btRecordModify.Click += btRecordModify_Click;
            // 
            // btRecordDelete
            // 
            btRecordDelete.FlatStyle = FlatStyle.Flat;
            btRecordDelete.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordDelete.Location = new Point(666, 314);
            btRecordDelete.Name = "btRecordDelete";
            btRecordDelete.Size = new Size(75, 46);
            btRecordDelete.TabIndex = 7;
            btRecordDelete.Text = "削除";
            btRecordDelete.UseVisualStyleBackColor = true;
            btRecordDelete.Click += btRecordDelete_Click;
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // btNewRecord
            // 
            btNewRecord.FlatStyle = FlatStyle.Flat;
            btNewRecord.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btNewRecord.Location = new Point(386, 42);
            btNewRecord.Name = "btNewRecord";
            btNewRecord.Size = new Size(112, 34);
            btNewRecord.TabIndex = 9;
            btNewRecord.Text = "項目クリア";
            btNewRecord.UseVisualStyleBackColor = true;
            btNewRecord.Click += btNewRecord_Click;
            // 
            // ssMessageArea
            // 
            ssMessageArea.Items.AddRange(new ToolStripItem[] { tsslbMessage });
            ssMessageArea.Location = new Point(0, 601);
            ssMessageArea.Name = "ssMessageArea";
            ssMessageArea.Size = new Size(768, 22);
            ssMessageArea.TabIndex = 10;
            ssMessageArea.Text = "statusStrip1";
            // 
            // tsslbMessage
            // 
            tsslbMessage.Name = "tsslbMessage";
            tsslbMessage.Size = new Size(0, 17);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, ヘルプHToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(768, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 開くToolStripMenuItem, 保存ToolStripMenuItem, toolStripSeparator1, esmiCollor, toolStripSeparator2, esmiExit });
            ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            ファイルToolStripMenuItem.Size = new Size(67, 20);
            ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 開くToolStripMenuItem
            // 
            開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            開くToolStripMenuItem.Size = new Size(180, 22);
            開くToolStripMenuItem.Text = "開く...";
            開くToolStripMenuItem.Click += 開くToolStripMenuItem_Click;
            // 
            // 保存ToolStripMenuItem
            // 
            保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            保存ToolStripMenuItem.Size = new Size(180, 22);
            保存ToolStripMenuItem.Text = "保存...";
            保存ToolStripMenuItem.Click += 保存ToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // esmiCollor
            // 
            esmiCollor.Name = "esmiCollor";
            esmiCollor.ShowShortcutKeys = false;
            esmiCollor.Size = new Size(180, 22);
            esmiCollor.Text = "色設定...";
            esmiCollor.Click += esmiCollor_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // esmiExit
            // 
            esmiExit.Name = "esmiExit";
            esmiExit.ShortcutKeys = Keys.Alt | Keys.F4;
            esmiExit.Size = new Size(180, 22);
            esmiExit.Text = "終了...";
            esmiExit.Click += esmiExit_Click;
            // 
            // ヘルプHToolStripMenuItem
            // 
            ヘルプHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiAbout });
            ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            ヘルプHToolStripMenuItem.Size = new Size(65, 20);
            ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new Size(164, 22);
            tsmiAbout.Text = "このアプリについて...";
            tsmiAbout.Click += tsmiAbout_Click;
            // 
            // ofdReportFileOpen
            // 
            ofdReportFileOpen.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 623);
            Controls.Add(ssMessageArea);
            Controls.Add(menuStrip1);
            Controls.Add(btNewRecord);
            Controls.Add(btPicDelete);
            Controls.Add(btRecordDelete);
            Controls.Add(btRecordModify);
            Controls.Add(btRecordAdd);
            Controls.Add(btPicOpen);
            Controls.Add(pbPicture);
            Controls.Add(dgvRecord);
            Controls.Add(tbReport);
            Controls.Add(groupBox1);
            Controls.Add(cbCarName);
            Controls.Add(cbAuthor);
            Controls.Add(dtpDate);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "試乗レポート管理システム";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ssMessageArea.ResumeLayout(false);
            ssMessageArea.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpDate;
        private ComboBox cbAuthor;
        private GroupBox groupBox1;
        private RadioButton rbSubaru;
        private RadioButton rbHonda;
        private RadioButton rbNissan;
        private RadioButton rbToyota;
        private RadioButton rbOther;
        private RadioButton rbImport;
        private ComboBox cbCarName;
        private TextBox tbReport;
        private DataGridView dgvRecord;
        private PictureBox pbPicture;
        private Button btPicOpen;
        private Button btPicDelete;
        private Button btRecordAdd;
        private Button btRecordModify;
        private Button btRecordDelete;
        private OpenFileDialog ofdPicFileOpen;
        private Button btNewRecord;
        private StatusStrip ssMessageArea;
        private ToolStripStatusLabel tsslbMessage;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem ヘルプHToolStripMenuItem;
        private ToolStripMenuItem tsmiAbout;
        private ToolStripMenuItem 開くToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem esmiCollor;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem esmiExit;
        private ColorDialog cdCollar;
        private SaveFileDialog sfdReportFileSave;
        private OpenFileDialog ofdReportFileOpen;
    }
}
