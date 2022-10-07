using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;    // OleDbConnection, OleDbCommand 클래스 등 사용

namespace HumanList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string StrSQL = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=human_list.accdb;Mode=ReadWrite"; //데이터베이스 연결 문자열
        private int num = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            lvList_OleDb_View();
        }

        private void lvList_OleDb_View()
        {
            lvList.Items.Clear();
            var Conn = new OleDbConnection(StrSQL);
            Conn.Open();

            var Comm = new OleDbCommand("SELECT * FROM t_info", Conn);
            var myRead = Comm.ExecuteReader();

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
            Conn.Close();
        }
    }
}
