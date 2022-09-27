namespace Poll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.checkBox1.Checked != false || this.checkBox2.Checked != false)
            {
                foreach(RadioButton c in gbHobby.Controls)
                {
                    if(c.Checked == true)
                    {
                        lblHobby.Text = c.Text;
                    }
                }
                lblSprots.Text = "";
                foreach (CheckBox c in gbSports.Controls)
                {
                    if(c.Checked == true)
                    {
                        lblSprots.Text += c.Text + "";
                    }
                }
            }
        }
    }
}