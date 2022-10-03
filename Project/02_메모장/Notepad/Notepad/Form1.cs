using System.IO;        // ���� ��ü Ȱ�� 

namespace Notepad
{
    public partial class Form1 : Form
    {
        private Boolean txtNoteChange;  // ���뺯��üũ 
        private String fWord;           // ã�� ���ڿ� 
        private Form2 frm2;             // ã�� ��  


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
            txtNote.SelectAll(); //�޸����� �ؽ�Ʈ ��� ����
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            txtNoteChange = true;       //������ �߰�, ���� ���� 
        }

        private void ���θ����NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteChange == true)
            {
                String msg = this.Text + " ������ ������ ����Ǿ����ϴ�. \r\n ����� ������ �����Ͻðڽ��ϱ�?";
                DialogResult dlr = MessageBox.Show(msg, "�޸���", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dlr == DialogResult.Yes)
                {
                    textSave();
                    txtNote.ResetText();
                    Text = "���� ����";
                }
                else if (dlr == DialogResult.No)
                {
                    txtNote.ResetText();
                    Text = "���� ����";
                    txtNoteChange = false;
                }
                else if (dlr == DialogResult.Cancel)
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
            if (Text == "���� ����")
            {
                DialogResult dlr = saveFileDialog1.ShowDialog();
                if (dlr != DialogResult.Cancel)
                {
                    String str = saveFileDialog1.FileName;      // ���� �̸� 
                    
                    // ������ ���ڵ��� �⺻ ���� ũ�⸦ ����Ͽ� ���� ����� ���� ���Ͽ� ���� ��ü �ʱ�ȭ 
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

        private void ����SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textSave();
        }

        private void ����OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteChange == true)   // [txtNote] ��Ʈ���� �Է� �����Ͱ� ���� �� �߰��Ǿ��� ��
            {
                var msg = Text + " ������ ������ ����Ǿ����ϴ�. \r\n ����� ������ �����Ͻðڽ��ϱ�?";
                var dlr = MessageBox.Show(msg, "�޸���", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dlr == DialogResult.Yes)
                {
                    textSave();     // ������ ���� �޼��� ȣ��
                    textOpen();     // ���� ���� �޼��� ȣ��
                }
                else if (dlr == DialogResult.No)
                {
                    textOpen(); //�������� �ʰ� ���� ���� �޼��� ȣ��
                }
                else if (dlr == DialogResult.Cancel)
                {
                    return; //���� �� ���� ���� �ʰ� ��� �۾��� ����Ѵ�.
                }
            }
            else
            {
                textOpen(); // [txtNote] ��Ʈ���� �Է� �����Ͱ� ���� �� �߰� ���� �ʾҴ�.
            }
        }


        private void textOpen()
        {
            var dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                var str = openFileDialog1.FileName;
                var sr = new StreamReader(str, System.Text.Encoding.Default);
                txtNote.Text = sr.ReadToEnd();
                sr.Close();

                var f = new FileInfo(str);
                Text = f.Name;
                txtNoteChange = false;
            }
        }

        // ���� ���� �� �߻��ϴ� �̺�Ʈ 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;        // ���� ���Ḧ ���

            if (txtNoteChange == true)
            {
                var msg = this.Text + " ������ ������ ����Ǿ����ϴ�. \r\n ����� ������ �����Ͻðڽ��ϱ�?";
                var dlr = MessageBox.Show(msg, "�޸���", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    if (this.Text == "���� ����")
                    {
                        var dr = saveFileDialog1.ShowDialog();
                        if (dr != DialogResult.Cancel)
                        {
                            var str = saveFileDialog1.FileName;
                            var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                            sw.Write(txtNote.Text);
                            sw.Flush();
                            sw.Close();
                            this.txtNoteChange = false;
                        }
                    }
                    // ���� �̸��� �ִ� ��� 
                    else
                    {
                        var str = this.Text;
                        var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                        sw.Write(this.txtNote.Text);
                        sw.Flush();
                        sw.Close();
                        this.txtNoteChange = false;
                    }
                    this.Dispose();
                }
                else if (dlr == DialogResult.No)
                {
                    this.Dispose();
                }
                else if (dlr == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void �ٸ��̸���������AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlr = this.saveFileDialog1.ShowDialog();    //[�ٸ� �̸����� ����] ��ȭ���� ȣ��
            if (dlr != DialogResult.Cancel)
            {
                var str = saveFileDialog1.FileName; //���� ��� 
                var sw = new StreamWriter(str, false, System.Text.Encoding.Default); //StreamWriter �����ڸ� �̿��Ͽ� ��ü ����
                sw.Write(txtNote.Text); // Write �޼��带 �̿��Ͽ� ������ ��ο� txtNote ��Ʈ���� �Է� ���ڿ� ����
                sw.Flush();
                sw.Close();

                var f = new FileInfo(str);
                Text = f.Name;              // ���� ���� ���� ���� 
                txtNoteChange = false;      //�Է� ������ �Է� �� ���� �ʱ�ȭ
            }
        }

        private void ������XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();       // �� ����
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Undo(); //�ؽ�Ʈ �ڽ��� ��������� ����ϰ� ���� ���·� �ǵ�����
        }

        private void �߶󳻱�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Cut(); //���õ� �ؽ�Ʈ�� �߶󳽴�.
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Copy(); //���õ� �ؽ�Ʈ�� �����Ѵ�.
        }

        private void �ٿ��ֱ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Paste(); //�ؽ�Ʈ ������ �ٿ��ֱ�
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectedText = ""; //���õ� �ؽ�Ʈ �����
        }

        private void ã��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ã�� ���� �����ϴ� ��� 
            if (!(frm2 == null || !frm2.Visible))
            {
                frm2.Focus();
                return;
            }

            //ã�� ���� �������� �ʴ� ���
            frm2 = new Form2();

            // ���õ� ���ڿ��� �ִ��� Ȯ�� �Ͽ� ó���ϴ� �κ� 
            if (txtNote.SelectionLength == 0)
            {
                //frm2.txtWord.Text = fWord;
            }
            else
            {
                frm2.txtWord.Text = txtNote.SelectedText;
            }
            frm2.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            frm2.Show();
        }

        private void ����ã��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ã�� ���� �����ϴ� ��� 
            if (!(frm2 == null || !frm2.Visible))
            {
                frm2.txtWord.Text = this.fWord;
                this.btnOk_Click(this, null);       // ��ư Ŭ�� �̺�Ʈ 
            }
        }

        private void �ð���¥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToShortTimeString(); //���� �ð� ���
            var date = DateTime.Today.ToShortDateString(); //���� ��¥ ���
            this.txtNote.AppendText(time + "/" + date); //�Է� ������ �ǵڿ� �̾ �ð�/��¥ ���� �߰�
        }

        private void �ڵ��ٹٲ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.WordWrap = !(txtNote.WordWrap); // ���� ���¸� �ݴ�� ���� 
            �ڵ��ٹٲ�ToolStripMenuItem.Checked = !(�ڵ��ٹٲ�ToolStripMenuItem.Checked);
        }

        private void �۲�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)  // ��Ʈ ��ȭ���� ȣ��
            {
                txtNote.Font = fontDialog1.Font;    // �ؽ�Ʈ �ڽ��� ��Ʈ ����
            }
        }

        private void �޸�������AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(); //Form3 ��ü �ʱ�ȭ ����
            frm3.ShowDialog(); //��3 ȣ��
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var updown = -1;
            var str = txtNote.Text;             // ���� ����
            var findWord = frm2.txtWord.Text;   // ã�� ���ڿ� ����

            if (!frm2.chkCase.Checked)
            {
                str = str.ToUpper();            //����� ������ �빮�ڷ� ��ȯ
                findWord = findWord.ToUpper();
            }

            if (frm2.rdBtnUp.Checked)           // �������� ���ý� 
            {                                   // ������ ���� ��ġ���� �ڷ� �˻�
                if (txtNote.SelectionStart != 0)
                {   // LastIndexOf() ������ ���� ��ġ���� �˻��� �����ϰ� ���ڿ��� ���� �κ��� ���� �ڷ� �˻��� ���� 
                    // ���������� �߰ߵǴ� ������ ���ڿ��� �ε���(0���� ����) ��ġ�� ��ȯ 
                    updown = str.LastIndexOf(findWord, txtNote.SelectionStart -1);  // ��ġ�Ǵ� ������ ��ġ�� ������
                }
            }
            else  // �Ʒ� ���� ���ý� IndexOf�� �̿��Ͽ� ������ ���� ��ġ���� ������ �˻� ���� 
            {
                // IndexOf() �˻��� ������ ���� ��ġ���� ���۵Ǹ�, �� ó�� �߰ߵǴ� ������ ���ڿ���
                // �ε��� ��ġ�� ��ȯ�Ѵ�.
                updown = str.IndexOf(findWord, txtNote.SelectionStart + txtNote.SelectionLength);
            }

            // LastIndexOf() �޼ҵ�� IndexOf() �޼ҵ��� ��ȯ ���� -1�� ��, �� ���� �����Ͱ� ������ �޽��� ��� 
            if(updown == -1)
            {
                MessageBox.Show("�� �̻� ã�� ���ڿ��� �����ϴ�.", "�޸���", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Select() �ؽ�Ʈ ������ �ؽ�Ʈ ������ �����Ѵ�. 
            txtNote.Select(updown, findWord.Length);    // ������ ���� ���� ���� 
            fWord = frm2.txtWord.Text;  
            txtNote.Focus();
            txtNote.ScrollToCaret();                    // ���õ� ���� ��ġ���� ��ũ���Ͽ� ���� ��Ÿ��.
        }
    }
}