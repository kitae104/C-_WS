using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace HumanList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //접속query
        string connStr = "Server=localhost;Database=human;Uid=root;Pwd=1234;";
        private int num = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            lvList_Db_View();
        }

        /// <summary>
        /// DB 내용 불러와서 리스트 뷰에 표시하기 
        /// </summary>
        private void lvList_Db_View()
        {
            lvList.Items.Clear();                       // 초기화 

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();                
                string sql = "SELECT * FROM t_info";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader myRead = cmd.ExecuteReader();

                while (myRead.Read())
                {
                    lvList.Items.Add(new ListViewItem(new String[]
                    {
                        myRead[0].ToString(),
                        myRead[1].ToString(),
                        myRead[2].ToString(),
                        myRead[3].ToString(),
                        myRead[4].ToString()
                     }));
                }

                myRead.Close();
                conn.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCheck() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string Sql = "INSERT INTO t_info(m_name, m_age, m_phone, m_job) VALUES('";
                    Sql += this.txtName.Text + "'," + Convert.ToInt32(this.txtAge.Text) + ", '" +
                        this.txtPhone.Text + "', '" + this.txtJob.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(Sql, conn);
                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("정상적으로 데이터가 저장되었습니다.", "알림",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lvList_DataSet_View();
                        txtClear();
                    }
                    else
                    {
                        MessageBox.Show("정상적으로 데이터가 저장되지 않았습니다.", "에러",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }               
            }
        }

        /// <summary>
        /// 입력창들 지우기 
        /// </summary>
        private void txtClear()
        {
            this.txtName.Clear();
            this.txtAge.Clear();
            this.txtPhone.Clear();
            this.txtJob.Clear();
        }

        /// <summary>
        /// 리스트 뷰의 데이터 셋 보기 
        /// </summary>
        private void lvList_DataSet_View()
        {
            lvList.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM t_info";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader myRead = cmd.ExecuteReader();

                while (myRead.Read())
                {
                    lvList.Items.Add(new ListViewItem(new String[]
                    {
                        myRead[0].ToString(),
                        myRead[1].ToString(),
                        myRead[2].ToString(),
                        myRead[3].ToString(),
                        myRead[4].ToString()
                     }));
                }

                myRead.Close();
                conn.Close();
            }
        }


        /// <summary>
        /// 입력창이 비었는지 확인 하는 메소드
        /// </summary>
        /// <returns></returns>
        private bool txtCheck()
        {
            if (this.txtName.Text == "")
            {
                this.txtName.Focus();
                return false;
            }
            if (this.txtAge.Text == "")
            {
                this.txtAge.Focus();
                return false;
            }
            if (this.txtPhone.Text == "")
            {
                this.txtPhone.Focus();
                return false;
            }
            if (this.txtJob.Text == "")
            {
                this.txtJob.Focus();
                return false;
            }
            return true;
        }

        private void lvList_Click(object sender, EventArgs e)
        {
            if(lvList.SelectedItems.Count > 0)
            {
                num = Convert.ToInt32(lvList.SelectedItems[0].SubItems[0].Text);    // 번호 
                this.txtName.Text = this.lvList.SelectedItems[0].SubItems[1].Text;
                this.txtAge.Text = this.lvList.SelectedItems[0].SubItems[2].Text;
                this.txtPhone.Text = this.lvList.SelectedItems[0].SubItems[3].Text;
                this.txtJob.Text = this.lvList.SelectedItems[0].SubItems[4].Text;
            } 
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(txtCheck() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string Sql = "UPDATE t_info SET m_name ='" + this.txtName.Text + "', m_age=" + Convert.ToInt32(this.txtAge.Text);
                    Sql += ", m_phone='" + this.txtPhone.Text + "', m_job= '" + this.txtJob.Text + "' WHERE m_id =" + num + "";
                    
                    MySqlCommand msc = new MySqlCommand(Sql, conn);
                    int i = msc.ExecuteNonQuery();
                    conn.Close();

                    if (i == 1)
                    {
                        MessageBox.Show("정상적으로 데이터가 수정되었습니다.", "알림",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lvList_DataSet_View();
                        txtClear();
                    }
                    else
                    {
                        MessageBox.Show("정상적으로 데이터가 수정되지 않았습니다.", "에러",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.lvList.SelectedItems.Count > 0)
            {
                DialogResult dlr = MessageBox.Show("선택한 데이터를 삭제할까요?", "알림",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dlr)
                {
                    case DialogResult.Yes:
                        using (MySqlConnection conn = new MySqlConnection(connStr))
                        {
                            conn.Open();
                            string Sql = "DELETE FROM t_info WHERE m_id =" + num + "";
                            MySqlCommand msc = new MySqlCommand(Sql, conn);
                            int i = msc.ExecuteNonQuery();
                            conn.Close();

                            if (i == 1)
                            {
                                MessageBox.Show("정상적으로 데이터가 삭제되었습니다.", "알림",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lvList_DataSet_View();
                                txtClear();
                            }
                            else
                            {
                                MessageBox.Show("정상적으로 데이터가 삭제되지 않았습니다.", "에러",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
    }
}
