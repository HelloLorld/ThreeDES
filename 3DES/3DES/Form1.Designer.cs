namespace _3DES
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InMsgLabel = new System.Windows.Forms.Label();
            this.InMsg = new System.Windows.Forms.TextBox();
            this.Key1Label = new System.Windows.Forms.Label();
            this.Key2Label = new System.Windows.Forms.Label();
            this.Key3Label = new System.Windows.Forms.Label();
            this.Key1 = new System.Windows.Forms.TextBox();
            this.Key2 = new System.Windows.Forms.TextBox();
            this.Key3 = new System.Windows.Forms.TextBox();
            this.OutMsgLabel = new System.Windows.Forms.Label();
            this.OutMsg = new System.Windows.Forms.TextBox();
            this.EncodeBtn = new System.Windows.Forms.Button();
            this.HistoryLabel = new System.Windows.Forms.Label();
            this.RecordInfoLabel = new System.Windows.Forms.Label();
            this.RecKey1Label = new System.Windows.Forms.Label();
            this.RecKey2Label = new System.Windows.Forms.Label();
            this.RecKey3Label = new System.Windows.Forms.Label();
            this.RecKey1 = new System.Windows.Forms.TextBox();
            this.RecKey2 = new System.Windows.Forms.TextBox();
            this.RecKey3 = new System.Windows.Forms.TextBox();
            this.RecInMsg = new System.Windows.Forms.TextBox();
            this.RecOutMsg = new System.Windows.Forms.TextBox();
            this.History = new System.Windows.Forms.ListBox();
            this.UpperMenuDesMode = new System.Windows.Forms.ToolStripMenuItem();
            this.EncodeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.DecodeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.UpperMenu = new System.Windows.Forms.MenuStrip();
            this.UpperMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // InMsgLabel
            // 
            this.InMsgLabel.AutoSize = true;
            this.InMsgLabel.Location = new System.Drawing.Point(24, 47);
            this.InMsgLabel.Name = "InMsgLabel";
            this.InMsgLabel.Size = new System.Drawing.Size(112, 13);
            this.InMsgLabel.TabIndex = 0;
            this.InMsgLabel.Text = "Введите сообщение:";
            // 
            // InMsg
            // 
            this.InMsg.Location = new System.Drawing.Point(27, 63);
            this.InMsg.Multiline = true;
            this.InMsg.Name = "InMsg";
            this.InMsg.Size = new System.Drawing.Size(250, 185);
            this.InMsg.TabIndex = 1;
            // 
            // Key1Label
            // 
            this.Key1Label.AutoSize = true;
            this.Key1Label.Location = new System.Drawing.Point(300, 67);
            this.Key1Label.Name = "Key1Label";
            this.Key1Label.Size = new System.Drawing.Size(42, 13);
            this.Key1Label.TabIndex = 2;
            this.Key1Label.Text = "Ключ1:";
            // 
            // Key2Label
            // 
            this.Key2Label.AutoSize = true;
            this.Key2Label.Location = new System.Drawing.Point(300, 102);
            this.Key2Label.Name = "Key2Label";
            this.Key2Label.Size = new System.Drawing.Size(42, 13);
            this.Key2Label.TabIndex = 3;
            this.Key2Label.Text = "Ключ2:";
            // 
            // Key3Label
            // 
            this.Key3Label.AutoSize = true;
            this.Key3Label.Location = new System.Drawing.Point(300, 137);
            this.Key3Label.Name = "Key3Label";
            this.Key3Label.Size = new System.Drawing.Size(42, 13);
            this.Key3Label.TabIndex = 4;
            this.Key3Label.Text = "Ключ3:";
            // 
            // Key1
            // 
            this.Key1.Location = new System.Drawing.Point(348, 63);
            this.Key1.Name = "Key1";
            this.Key1.Size = new System.Drawing.Size(100, 20);
            this.Key1.TabIndex = 5;
            // 
            // Key2
            // 
            this.Key2.Location = new System.Drawing.Point(348, 99);
            this.Key2.Name = "Key2";
            this.Key2.Size = new System.Drawing.Size(100, 20);
            this.Key2.TabIndex = 6;
            // 
            // Key3
            // 
            this.Key3.Location = new System.Drawing.Point(348, 134);
            this.Key3.Name = "Key3";
            this.Key3.Size = new System.Drawing.Size(100, 20);
            this.Key3.TabIndex = 7;
            // 
            // OutMsgLabel
            // 
            this.OutMsgLabel.AutoSize = true;
            this.OutMsgLabel.Location = new System.Drawing.Point(476, 47);
            this.OutMsgLabel.Name = "OutMsgLabel";
            this.OutMsgLabel.Size = new System.Drawing.Size(155, 13);
            this.OutMsgLabel.TabIndex = 8;
            this.OutMsgLabel.Text = "Закодированное сообщение:";
            // 
            // OutMsg
            // 
            this.OutMsg.Location = new System.Drawing.Point(479, 63);
            this.OutMsg.Multiline = true;
            this.OutMsg.Name = "OutMsg";
            this.OutMsg.Size = new System.Drawing.Size(250, 185);
            this.OutMsg.TabIndex = 9;
            // 
            // EncodeBtn
            // 
            this.EncodeBtn.Location = new System.Drawing.Point(303, 173);
            this.EncodeBtn.Name = "EncodeBtn";
            this.EncodeBtn.Size = new System.Drawing.Size(145, 75);
            this.EncodeBtn.TabIndex = 10;
            this.EncodeBtn.Text = "Закодировать";
            this.EncodeBtn.UseVisualStyleBackColor = true;
            this.EncodeBtn.Click += new System.EventHandler(this.EncodeBtn_Click);
            // 
            // HistoryLabel
            // 
            this.HistoryLabel.AutoSize = true;
            this.HistoryLabel.Location = new System.Drawing.Point(24, 266);
            this.HistoryLabel.Name = "HistoryLabel";
            this.HistoryLabel.Size = new System.Drawing.Size(53, 13);
            this.HistoryLabel.TabIndex = 12;
            this.HistoryLabel.Text = "История:";
            // 
            // RecordInfoLabel
            // 
            this.RecordInfoLabel.AutoSize = true;
            this.RecordInfoLabel.Location = new System.Drawing.Point(164, 265);
            this.RecordInfoLabel.Name = "RecordInfoLabel";
            this.RecordInfoLabel.Size = new System.Drawing.Size(124, 13);
            this.RecordInfoLabel.TabIndex = 14;
            this.RecordInfoLabel.Text = "Информация о записи:";
            // 
            // RecKey1Label
            // 
            this.RecKey1Label.AutoSize = true;
            this.RecKey1Label.Location = new System.Drawing.Point(172, 288);
            this.RecKey1Label.Name = "RecKey1Label";
            this.RecKey1Label.Size = new System.Drawing.Size(42, 13);
            this.RecKey1Label.TabIndex = 15;
            this.RecKey1Label.Text = "Ключ1:";
            // 
            // RecKey2Label
            // 
            this.RecKey2Label.AutoSize = true;
            this.RecKey2Label.Location = new System.Drawing.Point(172, 323);
            this.RecKey2Label.Name = "RecKey2Label";
            this.RecKey2Label.Size = new System.Drawing.Size(42, 13);
            this.RecKey2Label.TabIndex = 16;
            this.RecKey2Label.Text = "Ключ2:";
            // 
            // RecKey3Label
            // 
            this.RecKey3Label.AutoSize = true;
            this.RecKey3Label.Location = new System.Drawing.Point(172, 360);
            this.RecKey3Label.Name = "RecKey3Label";
            this.RecKey3Label.Size = new System.Drawing.Size(42, 13);
            this.RecKey3Label.TabIndex = 17;
            this.RecKey3Label.Text = "Ключ3:";
            // 
            // RecKey1
            // 
            this.RecKey1.Location = new System.Drawing.Point(220, 285);
            this.RecKey1.Name = "RecKey1";
            this.RecKey1.Size = new System.Drawing.Size(100, 20);
            this.RecKey1.TabIndex = 18;
            // 
            // RecKey2
            // 
            this.RecKey2.Location = new System.Drawing.Point(220, 320);
            this.RecKey2.Name = "RecKey2";
            this.RecKey2.Size = new System.Drawing.Size(100, 20);
            this.RecKey2.TabIndex = 19;
            // 
            // RecKey3
            // 
            this.RecKey3.Location = new System.Drawing.Point(220, 357);
            this.RecKey3.Name = "RecKey3";
            this.RecKey3.Size = new System.Drawing.Size(100, 20);
            this.RecKey3.TabIndex = 20;
            // 
            // RecInMsg
            // 
            this.RecInMsg.Location = new System.Drawing.Point(348, 285);
            this.RecInMsg.Multiline = true;
            this.RecInMsg.Name = "RecInMsg";
            this.RecInMsg.Size = new System.Drawing.Size(178, 251);
            this.RecInMsg.TabIndex = 21;
            // 
            // RecOutMsg
            // 
            this.RecOutMsg.Location = new System.Drawing.Point(551, 285);
            this.RecOutMsg.Multiline = true;
            this.RecOutMsg.Name = "RecOutMsg";
            this.RecOutMsg.Size = new System.Drawing.Size(178, 251);
            this.RecOutMsg.TabIndex = 22;
            // 
            // History
            // 
            this.History.FormattingEnabled = true;
            this.History.Location = new System.Drawing.Point(27, 285);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(109, 251);
            this.History.TabIndex = 23;
            this.History.SelectedIndexChanged += new System.EventHandler(this.History_SelectedIndexChanged);
            // 
            // UpperMenuDesMode
            // 
            this.UpperMenuDesMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EncodeMode,
            this.DecodeMode});
            this.UpperMenuDesMode.Name = "UpperMenuDesMode";
            this.UpperMenuDesMode.Size = new System.Drawing.Size(57, 20);
            this.UpperMenuDesMode.Text = "Режим";
            // 
            // EncodeMode
            // 
            this.EncodeMode.Name = "EncodeMode";
            this.EncodeMode.Size = new System.Drawing.Size(180, 22);
            this.EncodeMode.Text = "Закодировать";
            this.EncodeMode.Click += new System.EventHandler(this.EncodeMode_Click);
            // 
            // DecodeMode
            // 
            this.DecodeMode.Name = "DecodeMode";
            this.DecodeMode.Size = new System.Drawing.Size(180, 22);
            this.DecodeMode.Text = "Раскодировать";
            this.DecodeMode.Click += new System.EventHandler(this.DecodeMode_Click);
            // 
            // UpperMenu
            // 
            this.UpperMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpperMenuDesMode});
            this.UpperMenu.Location = new System.Drawing.Point(0, 0);
            this.UpperMenu.Name = "UpperMenu";
            this.UpperMenu.Size = new System.Drawing.Size(759, 24);
            this.UpperMenu.TabIndex = 11;
            this.UpperMenu.Text = "Menu";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(759, 561);
            this.Controls.Add(this.History);
            this.Controls.Add(this.RecOutMsg);
            this.Controls.Add(this.RecInMsg);
            this.Controls.Add(this.RecKey3);
            this.Controls.Add(this.RecKey2);
            this.Controls.Add(this.RecKey1);
            this.Controls.Add(this.RecKey3Label);
            this.Controls.Add(this.RecKey2Label);
            this.Controls.Add(this.RecKey1Label);
            this.Controls.Add(this.RecordInfoLabel);
            this.Controls.Add(this.HistoryLabel);
            this.Controls.Add(this.EncodeBtn);
            this.Controls.Add(this.OutMsg);
            this.Controls.Add(this.OutMsgLabel);
            this.Controls.Add(this.Key3);
            this.Controls.Add(this.Key2);
            this.Controls.Add(this.Key1);
            this.Controls.Add(this.Key3Label);
            this.Controls.Add(this.Key2Label);
            this.Controls.Add(this.Key1Label);
            this.Controls.Add(this.InMsg);
            this.Controls.Add(this.InMsgLabel);
            this.Controls.Add(this.UpperMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "3DES";
            this.UpperMenu.ResumeLayout(false);
            this.UpperMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InMsgLabel;
        private System.Windows.Forms.TextBox InMsg;
        private System.Windows.Forms.Label Key1Label;
        private System.Windows.Forms.Label Key2Label;
        private System.Windows.Forms.Label Key3Label;
        private System.Windows.Forms.TextBox Key1;
        private System.Windows.Forms.TextBox Key2;
        private System.Windows.Forms.TextBox Key3;
        private System.Windows.Forms.Label OutMsgLabel;
        private System.Windows.Forms.TextBox OutMsg;
        private System.Windows.Forms.Button EncodeBtn;
        private System.Windows.Forms.Label HistoryLabel;
        private System.Windows.Forms.Label RecordInfoLabel;
        private System.Windows.Forms.Label RecKey1Label;
        private System.Windows.Forms.Label RecKey2Label;
        private System.Windows.Forms.Label RecKey3Label;
        private System.Windows.Forms.TextBox RecKey1;
        private System.Windows.Forms.TextBox RecKey2;
        private System.Windows.Forms.TextBox RecKey3;
        private System.Windows.Forms.TextBox RecInMsg;
        private System.Windows.Forms.TextBox RecOutMsg;
        private System.Windows.Forms.ListBox History;
        private System.Windows.Forms.ToolStripMenuItem UpperMenuDesMode;
        private System.Windows.Forms.MenuStrip UpperMenu;
        private System.Windows.Forms.ToolStripMenuItem EncodeMode;
        private System.Windows.Forms.ToolStripMenuItem DecodeMode;
    }
}

