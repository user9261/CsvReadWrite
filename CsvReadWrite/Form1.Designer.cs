namespace CsvReadWrite
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBoxInputCSVFileName = new TextBox();
            ButtonCsvRead = new Button();
            TextBoxOutputCSVFileName = new TextBox();
            ButtonCsvWrite = new Button();
            DataGridViewCsv = new DataGridView();
            OpenFileDialogCsv = new OpenFileDialog();
            SaveFileDialogCsv = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)DataGridViewCsv).BeginInit();
            SuspendLayout();
            // 
            // TextBoxInputCSVFileName
            // 
            TextBoxInputCSVFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxInputCSVFileName.ForeColor = SystemColors.WindowFrame;
            TextBoxInputCSVFileName.Location = new Point(26, 26);
            TextBoxInputCSVFileName.Name = "TextBoxInputCSVFileName";
            TextBoxInputCSVFileName.Size = new Size(644, 27);
            TextBoxInputCSVFileName.TabIndex = 0;
            TextBoxInputCSVFileName.Text = "（取得するファイル名（フルパス名））";
            // 
            // ButtonCsvRead
            // 
            ButtonCsvRead.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonCsvRead.Location = new Point(676, 26);
            ButtonCsvRead.Name = "ButtonCsvRead";
            ButtonCsvRead.Size = new Size(94, 29);
            ButtonCsvRead.TabIndex = 1;
            ButtonCsvRead.Text = "CSV取得";
            ButtonCsvRead.UseVisualStyleBackColor = true;
            ButtonCsvRead.Click += ButtonCsvRead_Click;
            // 
            // TextBoxOutputCSVFileName
            // 
            TextBoxOutputCSVFileName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxOutputCSVFileName.ForeColor = SystemColors.WindowFrame;
            TextBoxOutputCSVFileName.Location = new Point(26, 405);
            TextBoxOutputCSVFileName.Name = "TextBoxOutputCSVFileName";
            TextBoxOutputCSVFileName.Size = new Size(644, 27);
            TextBoxOutputCSVFileName.TabIndex = 2;
            TextBoxOutputCSVFileName.Text = "（出力するファイル名（フルパス名））";
            // 
            // ButtonCsvWrite
            // 
            ButtonCsvWrite.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonCsvWrite.Location = new Point(676, 404);
            ButtonCsvWrite.Name = "ButtonCsvWrite";
            ButtonCsvWrite.Size = new Size(94, 29);
            ButtonCsvWrite.TabIndex = 3;
            ButtonCsvWrite.Text = "CSV出力";
            ButtonCsvWrite.UseVisualStyleBackColor = true;
            ButtonCsvWrite.Click += ButtonCsvWrite_Click;
            // 
            // DataGridViewCsv
            // 
            DataGridViewCsv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridViewCsv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewCsv.Location = new Point(26, 67);
            DataGridViewCsv.Name = "DataGridViewCsv";
            DataGridViewCsv.RowHeadersWidth = 51;
            DataGridViewCsv.Size = new Size(744, 312);
            DataGridViewCsv.TabIndex = 4;
            // 
            // OpenFileDialogCsv
            // 
            OpenFileDialogCsv.FileName = "*.csv";
            OpenFileDialogCsv.InitialDirectory = ".\\";
            // 
            // SaveFileDialogCsv
            // 
            SaveFileDialogCsv.Filter = "CSVファイル|*.CSV|すべてのファイル|*.*";
            SaveFileDialogCsv.InitialDirectory = ".\\";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(DataGridViewCsv);
            Controls.Add(ButtonCsvWrite);
            Controls.Add(TextBoxOutputCSVFileName);
            Controls.Add(ButtonCsvRead);
            Controls.Add(TextBoxInputCSVFileName);
            Name = "Form1";
            Text = "CSVの読み書き";
            ((System.ComponentModel.ISupportInitialize)DataGridViewCsv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxInputCSVFileName;
        private Button ButtonCsvRead;
        private TextBox TextBoxOutputCSVFileName;
        private Button ButtonCsvWrite;
        private DataGridView DataGridViewCsv;
        private OpenFileDialog OpenFileDialogCsv;
        private SaveFileDialog SaveFileDialogCsv;
    }
}
