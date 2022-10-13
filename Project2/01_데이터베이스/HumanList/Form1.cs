using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void lvList_DataSet_View()
        {
            /*this.lvList.Items.Clear();
            var Conn = new OleDbConnection(StrSQL);
            Conn.Open();

            var OleAdapter = new OleDbDataAdapter("SELECT * FROM t_info", Conn);

            DataSet ds = new DataSet();

            /// 테이블 이름을 dsTable로 하여 데이터소스 테이블을 추가하는 작업 수행 
            DataTable dt = ds.Tables.Add("dsTable");

            /// 테이블에서 가져온 내용을 데이터 셋에 채움
            OleAdapter.Fill(ds, "dsTable"); 

            IEnumerable<DataRow> query = from HumanInfo in dt.AsEnumerable() select HumanInfo;

            foreach (DataRow HumData in query)
            {
                var strArray = new String[]
                {
                    HumData.Field<int>("m_id").ToString(),
                    HumData.Field<string>("m_name"),
                    HumData.Field<int>("m_age").ToString(),
                    HumData.Field<string>("m_phone"),
                    HumData.Field<string>("m_job")
                };
                lvList.Items.Add(new ListViewItem(strArray));
            }
            Conn.Close();*/
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
    }
}
