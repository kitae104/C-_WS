using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;   // 이미지 제어를 위한 네임스페이스

namespace ScreenCapture
{
    public partial class Form1 : Form
    {
        Point orgLocalPoint;            // 폼의 원래 위치
        Size orgLocalSize;              // 폼의 원래 크기 
        bool orgbool = true;            // 화면 캡쳐 여부 확인 
        bool capbool = false;
        Graphics ScreenG;
        Bitmap CaptWin;
               
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(); // .wav 파일 재생

        public Form1()
        {
            InitializeComponent();
        }

        // 자판의 키를 눌렀을 때 발생하는 이벤트 제어 
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 화면 캡쳐 
            if (e.KeyChar == 'c' || e.KeyChar == 'C')
            {
                orgbool = false;
                capbool = true;

                this.Opacity = 0.0;      // 불투명도 기본은 1.0
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.Bounds.Size;   // 화면 전체 
                var fullScreen = Screen.PrimaryScreen.Bounds;   // 

                // 화면 캡쳐를 위해 비트맵 클래스 객체 생성 - 크기는 화면 전체 사이즈 
                CaptWin = new Bitmap(fullScreen.Width, fullScreen.Height);

                // 지정된 이미지에서 새 그래픽 객체를 초기화 수행 
                ScreenG = Graphics.FromImage(CaptWin);

                // 범위로 지정된 사각형에 해당하는 색 데이터, 즉, 현재 캡쳐된 화면의 색 데이터를 그리는 작업 
                ScreenG.CopyFromScreen(PointToScreen(new Point(0, 0)), new Point(0, 0), fullScreen.Size);

                this.picbScreen.Image = CaptWin;

                player.SoundLocation = @"..\..\wav\capture.wav";
                player.Play();

                this.Opacity = 100.0;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Location = orgLocalPoint;
                this.Size = orgLocalSize;
                orgbool = true;
            }
            // 캡쳐된 화면 지우기 
            else if (e.KeyChar == 'e' || e.KeyChar == 'E')
            {
                player.SoundLocation = @"..\..\wav\ereser.wav";     // 효과음
                player.Play();
                capbool = false;                    // 캡쳐 활동을 초기화 
                this.picbScreen.Image = null;
            }
            // 이미지 파일로 저장하는 작업 수행 
            else if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                if (capbool == true)
                {
                    using (var SFile = new SaveFileDialog())
                    {
                        SFile.OverwritePrompt = true;
                        SFile.FileName = "화면캡쳐";
                        SFile.Filter = "이미지 파일(*.jpg)|*.jpg";
                        DialogResult result = SFile.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            CaptWin.Save(SFile.FileName, ImageFormat.Jpeg);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("캡쳐한 화면이 없습니다.", "알림",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 폼의 위치가 변경하면 발생하는 이벤트
        // 화면 캡쳐 작업이 끝나면 폼의 위치와 사이즈를 원래대로 재설정함.
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if(orgbool == true)
            {
                orgLocalPoint = Location;
                orgLocalSize = Size;
            }
        }
    }
}
