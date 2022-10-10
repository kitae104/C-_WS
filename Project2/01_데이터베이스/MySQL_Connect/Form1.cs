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

namespace MySQL_Connect
{
    public partial class Form1 : Form
    {
        //접속query
        string Conn = "Server=localhost;Database=csharp_test;Uid=root;Pwd=1234;";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("내용을 입력하세요.");
            }
            else
            {
                //삽입구문
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    MySqlCommand msc = new MySqlCommand("INSERT INTO person_info(name, age) values('" 
                        + textBox1.Text + "'," + textBox2.Text + ")" , conn);
                    msc.ExecuteNonQuery();
                }
            }
        }
    }
}
