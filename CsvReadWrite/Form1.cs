using Csv;          // ���C�u����Csv ���g���̂ɕK�v
using System.Data;  // DataTable���g���̂ɕK�v
using System.Text;  // Encoding���g���̂ɕK�v


namespace CsvReadWrite
{
    public partial class Form1 : Form
    {

        // �����Ńf�[�^��ێ�����e�[�u����p�ӂ��܂��B
        DataTable dataTable = new DataTable();


        public Form1()
        {
            InitializeComponent();
        }


        // CSV�擾�{�^���N���b�N���̏���
        private void ButtonCsvRead_Click(object sender, EventArgs e)
        {
            // �t�@�C�����J���E�B���h�E��CSV�t�@�C����I�����AOK�{�^�����N���b�N�����Ƃ�
            if (OpenFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                // �t�@�C�����J���E�B���h�E�őI��CSV�̃t�@�C�������e�L�X�g�{�b�N�X�ɔ��f
                TextBoxInputCSVFileName.Text = OpenFileDialogCsv.FileName;
                // �t�@�C���̑S���e�𕶎���ɓǍ��݂܂��B���{�ꂪ�ǂݍ��߂�悤�ɁA������ utf-16 �ŃG���R�[�h���܂��B
                string csv = File.ReadAllText(OpenFileDialogCsv.FileName, Encoding.GetEncoding("utf-16"));
                dataTable.TableName = "CSVTable";   // �����Ńe�[�u���𐶐����܂��B
                dataTable.Columns.Clear();          // �����e�[�u���̃w�b�_���������i�Q�A���œǂݍ��񂾎��̑Ή��j
                dataTable.Clear();                  // �����e�[�u���̃f�[�^���������i�Q�A���œǂݍ��񂾎��̑Ή��j

                // CSV����w�b�_�����̃f�[�^���擾���A�����̃e�[�u���̃J�����ɐݒ�
                // csv ����P�s�擾���A���ʂ�line�ϐ��ɓ����
                foreach (ICsvLine line in CsvReader.ReadFromText(csv))
                {
                    // �P�s���̃f�[�^�̃w�b�_�̏������o��
                    foreach (var item in line.Headers)
                    {
                        dataTable.Columns.Add(item);�@// �����̃e�[�u���̃J�����ɐݒ�
                    }
                    break; // �Q��ڈȍ~�̃f�[�^���J�������͓����Ȃ̂�CSV�̓ǂݍ��݂��I��
                }
                // �ǂݍ���csv�̃f�[�^���A�����̃e�[�u���Ɋ��蓖�Ă�
                // ������xcsv ����P�s�擾���A���ʂ�line�ϐ��ɓ����
                foreach (ICsvLine line in CsvReader.ReadFromText(csv))
                {
                    dataTable.Rows.Add(line.Values);    // �P���R�[�h���܂Ƃ߂Đݒ�
                }
                DataGridViewCsv.DataSource = dataTable;�@// �\���p��DatasGridView�ɓ����̃e�[�u�������蓖�Ă�
            }
        }


        // CSV�o�̓{�^���N���b�N���̏���
        private void ButtonCsvWrite_Click_1(object sender, EventArgs e)
        {
            // �t�@�C����ۑ�����E�B���h�E��CSV�t�@�C����I�����AOK�{�^�����N���b�N�����Ƃ�
            if (SaveFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                // �t�@�C����ۑ�����E�B���h�E�őI��CSV�̃t�@�C�������e�L�X�g�{�b�N�X�ɔ��f
                TextBoxOutputCSVFileName.Text = SaveFileDialogCsv.FileName;
                // header �Ƃ����ϐ��ɓ����̃e�[�u���̃J��������ݒ�
                string[] header = new string[dataTable.Columns.Count];
                // �J�����̐��������[�v���ăJ�����̃f�[�^��ݒ�
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    header[i] = dataTable.Columns[i].ColumnName;
                }
                // newLine�Ƃ����ϐ��ɓ����̃e�[�u����\�̃C���[�W�i�Q�����z��j�Őݒ�
                string[][] newLine = new string[dataTable.Rows.Count][];
                // �f�[�^�̐������[�v���āA�f�[�^���擾
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    newLine[i] = new string[dataTable.Columns.Count];
                    // �Y������J�����A��̒l������̃e�[�u������AnewLine�ɐݒ�
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        // null�̏ꍇ�́A�h�h �Ƃ���newLine�ɐݒ�
                        // newLine[i][j] = (string)dataTable.Rows[i][j] ?? "";    // �C���O�R�[�h
                        newLine[i][j] = (dataTable.Rows[i][j] ?? "").ToString();  // �C����R�[�h
                        // �C���̏ڍׂ́A�T�|�[�g�y�[�W�̐���\�����Q�Ƃ��������B
                        // https://www.shuwasystem.co.jp/support/7980html/6833.html#2
                    }
                }
                // �f�[�^����CSV�`���̕�����𐶐����܂�
                CsvOptions csvOptions = new CsvOptions();
                csvOptions.NewLine = "";
                string outcsv = CsvWriter.WriteToText(header, newLine, ',');
                // FileName �Ƃ������O�ŁAoutcsv �̒l��ۑ����܂��B������ utf-16 �ŃG���R�[�h���܂��B
                File.WriteAllText(SaveFileDialogCsv.FileName, outcsv, Encoding.GetEncoding("utf-16"));
            }
        }
    }
}




  



