namespace 폰트_바꾸기
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsbFont_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbText.SelectionFont = fontDialog1.Font;
            }
        }

        private void tsbColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbText.SelectionColor = colorDialog1.Color;
            }
        }
    }
}