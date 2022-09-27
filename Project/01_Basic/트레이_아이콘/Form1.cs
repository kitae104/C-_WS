namespace 트레이_아이콘
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void VisibleChange(Boolean FormVisible, Boolean TrayIconVisible)
        {
            this.Visible = FormVisible;
            this.nyTray.Visible = TrayIconVisible;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            VisibleChange(false, true);
        }

        private void nyTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisibleChange(true, false);
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisibleChange(true, false);
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }
    }
}