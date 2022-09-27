namespace 구구단
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxResult.Items.Clear();
            String s = cbSelect.SelectedItem.ToString();
            String[] guStr = s.Split(new char[] {' '});    // 구분자로 공백 문자열 사용 
            lboxResult.Items.Add(guStr[0] + "단 실행 결과");
            lboxResult.Items.Add("");
            lboxResult.Items.Add("");
            for (int i = 1; i < 10; i++)
            {
                lboxResult.Items.Add(guStr[0] + " + " + i.ToString() +
                    " = " + (Convert.ToInt32(guStr[0]) * i).ToString());
            }
        }
    }
}