using System.IO;        // 파일 개체 활용 

namespace Notepad
{
    public partial class Form1 : Form
    {
        private Boolean txtNoteChange;  // 내용변경체크 
        private String fWord;           // 찾기 문자열 
        private Form2 frm2;             // 객체 생성 
        

        public Form1()
        {
            InitializeComponent();
        }

        private void 도움말ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void 모두선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            txtNoteChange = true;
        }

        private void 새로만들기NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtNoteChange == true)
            {
                String msg = this.Text + " 파일의 내용이 변경되었습니다. \r\n 변경된 내용을 저장하시겠습니까?";
                DialogResult dlr =MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if(dlr == DialogResult.Yes)
                {
                    textSave();
                    txtNote.ResetText();
                    Text = "제목 없음";
                }
                else if(dlr == DialogResult.No)
                {
                    txtNote.ResetText();
                    Text = "제목 없음";
                    txtNoteChange = false;
                }
                else if(dlr == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    txtNote.ResetText();
                    Text = "제목 없음";
                    txtNoteChange = false;
                }
            }
        }

        private void textSave()
        {
            if(Text == "제목 없음")
            {
                DialogResult dlr = saveFileDialog1.ShowDialog();
                if(dlr == DialogResult.Cancel)
                {
                    String str = saveFileDialog1.FileName;
                    StreamWriter sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                    sw.Write(txtNote.Text);
                    sw.Flush();
                    sw.Close();

                    FileInfo f = new FileInfo(str);
                    Text = f.Name;
                    txtNoteChange = false;
                }
            }
            else
            {
                string strt = Text;
                StreamWriter sw = new StreamWriter(strt, false, System.Text.Encoding.Default);

                sw.Write(txtNote.Text);
                sw.Flush();
                sw.Close();

                Text = strt;
                txtNoteChange = false;
            }
        }
    }
}