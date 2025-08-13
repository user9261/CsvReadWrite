using Csv;          // ライブラリCsv を使うのに必要
using System.Data;  // DataTableを使うのに必要
using System.Text;  // Encodingを使うのに必要


namespace CsvReadWrite
{
    public partial class Form1 : Form
    {

        // 内部でデータを保持するテーブルを用意します。
        DataTable dataTable = new DataTable();


        public Form1()
        {
            InitializeComponent();
        }


        // CSV取得ボタンクリック時の処理
        private void ButtonCsvRead_Click(object sender, EventArgs e)
        {
            // ファイルを開くウィンドウでCSVファイルを選択し、OKボタンをクリックしたとき
            if (OpenFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                // ファイルを開くウィンドウで選んだCSVのファイル名をテキストボックスに反映
                TextBoxInputCSVFileName.Text = OpenFileDialogCsv.FileName;
                // ファイルの全内容を文字列に読込みます。日本語が読み込めるように、文字は utf-16 でエンコードします。
                string csv = File.ReadAllText(OpenFileDialogCsv.FileName, Encoding.GetEncoding("utf-16"));
                dataTable.TableName = "CSVTable";   // 内部でテーブルを生成します。
                dataTable.Columns.Clear();          // 内部テーブルのヘッダを初期化（２連続で読み込んだ時の対応）
                dataTable.Clear();                  // 内部テーブルのデータを初期化（２連続で読み込んだ時の対応）

                // CSVからヘッダ部分のデータを取得し、内部のテーブルのカラムに設定
                // csv から１行取得し、結果をline変数に入れる
                foreach (ICsvLine line in CsvReader.ReadFromText(csv))
                {
                    // １行分のデータのヘッダの情報を取り出す
                    foreach (var item in line.Headers)
                    {
                        dataTable.Columns.Add(item);　// 内部のテーブルのカラムに設定
                    }
                    break; // ２列目以降のデータもカラム名は同じなのでCSVの読み込みを終了
                }
                // 読み込んだcsvのデータを、内部のテーブルに割り当てる
                // もう一度csv から１行取得し、結果をline変数に入れる
                foreach (ICsvLine line in CsvReader.ReadFromText(csv))
                {
                    dataTable.Rows.Add(line.Values);    // １レコード分まとめて設定
                }
                DataGridViewCsv.DataSource = dataTable;　// 表示用のDatasGridViewに内部のテーブルを割り当てる
            }
        }


        // CSV出力ボタンクリック時の処理
        private void ButtonCsvWrite_Click_1(object sender, EventArgs e)
        {
            // ファイルを保存するウィンドウでCSVファイルを選択し、OKボタンをクリックしたとき
            if (SaveFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                // ファイルを保存するウィンドウで選んだCSVのファイル名をテキストボックスに反映
                TextBoxOutputCSVFileName.Text = SaveFileDialogCsv.FileName;
                // header という変数に内部のテーブルのカラム名を設定
                string[] header = new string[dataTable.Columns.Count];
                // カラムの数だけループしてカラムのデータを設定
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    header[i] = dataTable.Columns[i].ColumnName;
                }
                // newLineという変数に内部のテーブルを表のイメージ（２次元配列）で設定
                string[][] newLine = new string[dataTable.Rows.Count][];
                // データの数分ループして、データを取得
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    newLine[i] = new string[dataTable.Columns.Count];
                    // 該当するカラム、列の値を内部のテーブルから、newLineに設定
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        // nullの場合は、”” としてnewLineに設定
                        // newLine[i][j] = (string)dataTable.Rows[i][j] ?? "";    // 修正前コード
                        newLine[i][j] = (dataTable.Rows[i][j] ?? "").ToString();  // 修正後コード
                        // 修正の詳細は、サポートページの正誤表をご参照ください。
                        // https://www.shuwasystem.co.jp/support/7980html/6833.html#2
                    }
                }
                // データからCSV形式の文字列を生成します
                CsvOptions csvOptions = new CsvOptions();
                csvOptions.NewLine = "";
                string outcsv = CsvWriter.WriteToText(header, newLine, ',');
                // FileName という名前で、outcsv の値を保存します。文字は utf-16 でエンコードします。
                File.WriteAllText(SaveFileDialogCsv.FileName, outcsv, Encoding.GetEncoding("utf-16"));
            }
        }
    }
}




  



