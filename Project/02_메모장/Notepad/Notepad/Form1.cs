using System.IO;        // ���� ��ü Ȱ�� 

namespace Notepad
{
    public partial class Form1 : Form
    {
        private Boolean txtNoteChange;  // ���뺯��üũ 
        private String fWord;           // ã�� ���ڿ� 
        private Form2 frm2;             // ��ü ���� 
        

        public Form1()
        {
            InitializeComponent();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void ��μ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            txtNoteChange = true;
        }

        private void ���θ����NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtNoteChange == true)
            {
                String msg = this.Text + " ������ ������ ����Ǿ����ϴ�. \r\n ����� ������ �����Ͻðڽ��ϱ�?";
                DialogResult dlr =MessageBox.Show(msg, "�޸���", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if(dlr == DialogResult.Yes)
                {
                    textSave();
                    txtNote.ResetText();
                    Text = "���� ����";
                }
                else if(dlr == DialogResult.No)
                {
                    txtNote.ResetText();
                    Text = "���� ����";
                    txtNoteChange = false;
                }
                else if(dlr == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    txtNote.ResetText();
                    Text = "���� ����";
                    txtNoteChange = false;
                }
            }
        }

        private void textSave()
        {
            if(Text == "���� ����")
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