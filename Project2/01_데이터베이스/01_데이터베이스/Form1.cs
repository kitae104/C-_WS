using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace _01_데이터베이스
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FileInfo fi = null;     //파일 정보 가져오기
        string FsPath = "";     //파일 경로 저장

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var f in openFileDialog1.FileNames)
                {
                    listViewFile.Items.Add(new ListViewItem(new String[]
                    {
                        fi.Name, fi.LastWriteTime.ToString(), fi.Extension.Split('.')[1],
                        GetFileSize(fi.Length), fi.FullName
                    }));
                }
            }
        }

        private string GetFileSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";

            return size;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(listViewFile.Items.Count == 0)
            {
                MessageBox.Show("저장할 파일 정보가 없습니다.", "알림", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }

            if(rbTxt.Checked == true)
            {
                saveFileDialog1.Filter = "텍스트 파일(*.txt) | *.txt";
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FsPath = saveFileDialog1.FileName;
                    TxtSave();
                }
            }
            else
            {
                saveFileDialog1.Filter = "엑셀 파일(*.xlsx) | *.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FsPath = saveFileDialog1.FileName;
                    ExcelSave();
                }
            }
        }

        private void ExcelSave()
        {
            
        }

        private void TxtSave()
        {
            using(StreamWriter sw = new StreamWriter(FsPath))
            {
                sw.WriteLine("이름" + "\t" + "수정한 날짜" + "\t"
                    + "유형" + "\t" + "크기" + "\t" + "경로" + "\t");

                for (int i = 0; i < listViewFile.Items.Count; i++)
                {
                    String FInfo = "";
                    for (int j = 0; j < listViewFile.Items[i].SubItems.Count; j++)
                    {
                        FInfo += listViewFile.Items[i].SubItems[j].Text + "\t";
                    }
                    sw.WriteLine(FInfo);
                }
                sw.Close();
            }
        }



    }
}