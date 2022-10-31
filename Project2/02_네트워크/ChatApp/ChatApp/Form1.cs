using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 관련 라이브러리 네임스페이스 추가 
using System.Net;                       // IPAddress
using System.Net.Sockets;               //TcpListener 클래스사용
using System.Threading;                 //스레드 클래스 사용
using System.IO;                        //파일 클래스 사용
using Microsoft.Win32;                  //레지스트리 클래스 사용
using System.Runtime.InteropServices;   //폼 깜박임 구현

namespace ChatApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 멤버 변수 추가 
        /// </summary>
        private TcpListener Server;             //CP 네트워크 클라이언트에서 연결 수신
        private TcpClient SerClient, client;    //TCP 네트워크 서비스에 대한 클라이언트 연결 제공
        private NetworkStream myStream;         //네트워크 스트림
        private StreamReader myRead;            //스트림 읽기
        private StreamWriter myWrite;           //스트림 쓰기
        private Boolean Start = false;          //서버 시작
        private Boolean ClientCon = false;      //클라이언트 시작
        private int myPort;                     //포트
        private string myName;                  //별칭
        private Thread myReader, myServer;      //스레드
        private Boolean TextChange = false;     //입력 컨트롤의 데이터입력 체크

        //레지스트리 쓰기,읽기
        private RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework", true);

        private delegate void AddTextDelegate(string strText);  // 델리게이트 선언

        private AddTextDelegate AddText = null;                 // 델리게이트 개체 생성 

        [DllImport("User32.dll")]   // 어트리뷰트 
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        private void Form1_Load(object sender, EventArgs e)
        {
            if ((string)key.GetValue("Message_name") == "")
            {
                myName = txtId.Text;
                myPort = Convert.ToInt32(txtPort.Text);
            }
            else
            {
                try
                {
                    myName = (string)key.GetValue("Message_name");
                    myPort = Convert.ToInt32(key.GetValue("Message_port"));
                } 
                catch
                {
                    myName = txtId.Text;
                    myPort = Convert.ToInt32(txtPort.Text);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbServer.Checked == true)    //서버 모드 실행
            {
                ControlCheck();
            } 
            else
            {
                if(txtId.Text == "")
                {
                    txtIp.Focus();
                }
                else
                {
                    ControlCheck();
                }
            }
        }

        private void ControlCheck()
        {
            if (this.txtId.Text == "")
            {
                this.txtId.Focus();
            }
            else if (this.txtPort.Text == "")
            {
                this.txtPort.Focus();
            }
            else
            {
                try
                {
                    var name = txtId.Text;
                    var port = txtPort.Text;
                    key.SetValue("Message_name", name);         // 키값 설정 
                    key.SetValue("Message_port", port);
                    plOption.Visible = false;                   // 설정 패널 숨기기
                    설정ToolStripMenuItem.Enabled = true;       // 설정 버튼 활성화 
                    tsbtnConn.Enabled = true;                   // 연결 버튼 활성화
                }
                catch
                {
                    MessageBox.Show("설정이 저장되지 않았습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.설정ToolStripMenuItem.Enabled = true;  //설정 메뉴 활성화
            this.plOption.Visible = false;              //입력창 닫기
            this.txtMessage.Focus();
        }

        private void cbServer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbServer.Checked)          //서버 또는 클라이언트 체크 해제
            {
                this.txtIp.Enabled = false;     //서버 모드 전환
            }
            else
            {
                this.txtIp.Enabled = true;      //클라이언트 모드 전환
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if(TextChange == false)
            {
                TextChange = true;
                myWrite.WriteLine("S001" + "&" + "상대방이 메시지 입력중입니다." + "&" + " ");
                myWrite.Flush();
            }
            else if(txtMessage.Text == "" && TextChange == true)
            {
                TextChange = false;
            }
        }

        private void tsbtnConn_Click(object sender, EventArgs e)
        {
            AddText = new AddTextDelegate(MessageView);     // 델리게이트 메소드 등록 
            if(cbServer.Checked == true)
            {
                var addr = new IPAddress(0);
                try
                {
                    myName = (string)key.GetValue("Message_name");          //별칭 설정
                    myPort = Convert.ToInt32(key.GetValue("Message_port")); //서버측 포트 설정
                }
                catch
                {
                    myName = txtId.Text;
                    myPort = Convert.ToInt32(txtPort.Text);
                }

                if (!(Start))
                {
                    try
                    {
                        Server = new TcpListener(addr, myPort);
                        Server.Start();

                        Start = true;
                        txtMessage.Enabled = true;
                        btnSend.Enabled = true;
                        txtMessage.Focus();
                        tsbtnDisconn.Enabled = true;
                        tsbtnConn.Enabled = false;
                        cbServer.Enabled = false;

                        myServer = new Thread(ServerStart);
                        myServer.Start();

                        설정ToolStripMenuItem.Enabled = false;
                    }
                    catch
                    {
                        Invoke(AddText, "서버를 실행할 수 없습니다.");
                    }
                }
                else
                {
                    ServerStop();
                }
            }
            else
            {
                if (!(ClientCon))
                {
                    myName = (string)key.GetValue("Message_name");          // 별칭 설정
                    myPort = Convert.ToInt32(key.GetValue("Message_port")); // 서버측 포트 설정
                    ClientConnection();                                     // 클라이언트 연결 
                }
                else
                {
                    txtMessage.Enabled = false;
                    btnSend.Enabled = false;
                    Disconnection();                                        // 연결 끊기
                }
            }
        }

        private void Disconnection()
        {
            ClientCon = false;
            try
            {
                if(!(myRead == null))
                {
                    myRead.Close();         //StreamReader 클래스 개체 리소스 해제
                }
                if (!(myWrite == null))
                {
                    myWrite.Close();        //StreamWriter 클래스 개체 리소스 해제
                }
                if (!(myStream == null))
                {
                    myStream.Close();       //NetworkStream 클래스 개체 리소스 해제
                }
                if (!(client == null))
                {
                    client.Close();         //TcpClient 클래스 개체 리소스 해제
                }
                if (!(myReader == null))
                {
                    myReader.Abort();       //외부 스레드 종료
                }
            }
            catch
            {
                return;
            }
        }

        private void ClientConnection()
        {
            try
            {
                client = new TcpClient(txtIp.Text, myPort);
                Invoke(AddText, "서버에 접속 했습니다.");
                myStream = client.GetStream();

                myRead = new StreamReader(myStream);
                myWrite = new StreamWriter(myStream);

                this.ClientCon = true;
                this.tsbtnConn.Enabled = false;
                this.tsbtnDisconn.Enabled = true;
                this.txtMessage.Enabled = true;
                this.btnSend.Enabled = true;
                this.txtMessage.Focus();

                myReader = new Thread(Receive);
                myReader.Start();
            }
            catch
            {
                ClientCon = false;
                Invoke(AddText, "서버에 접속하지 못했습니다.");
            }
        }

        private void ServerStop()
        {
            throw new NotImplementedException();
        }

        private void ServerStart()
        {
            Invoke(AddText, "서버 실행 : 챗 상대의 접속을 기다립니다...");
            while(Start)
            {
                try
                {
                    SerClient = Server.AcceptTcpClient();
                    Invoke(AddText, "챗 상대 접속..");
                    myStream = SerClient.GetStream();

                    myRead = new StreamReader(myStream);
                    myWrite = new StreamWriter(myStream);
                    ClientCon = true;

                    myReader = new Thread(Receive);
                    myReader.Start();
                }
                catch { }
            }
        }

        private void Receive()
        {
            try
            {
                while (ClientCon)       // 클라이언트가 연결된 경우 
                {
                    if (myStream.CanRead)
                    {
                        var msg = myRead.ReadLine();
                        var Smsg = msg.Split('&');
                        if (Smsg[0] == "S001")
                        {
                            tsslblTime.Text = Smsg[1];
                        }
                        else
                        {
                            if(msg.Length > 0)
                            {
                                Invoke(AddText, Smsg[0] + " : " + Smsg[1]);
                            }
                            tsslblTime.Text = "마지막으로 받은 시각:" + Smsg[2];
                        }
                    }
                }
            }
            catch { }
        }

        private void MessageView(string strText)
        {
            rtbText.AppendText(strText + "\r\n");
            rtbText.Focus();
            rtbText.ScrollToCaret();                // 캐럿 위치까지 스크롤 
            txtMessage.Focus();
            FlashWindow(this.Handle, true);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text == "")
            {
                txtMessage.Focus();
            }
            else
            {
                Msg_send();
            }
        }

        private void Msg_send()
        {
            try
            {
                var dt = Convert.ToString(DateTime.Now);
                myWrite.WriteLine(this.myName + "&" + this.txtMessage.Text + "&" + dt);
                myWrite.Flush();
                MessageView(myName + ": " + txtMessage.Text);  
                txtMessage.Clear();
            }
            catch
            {
                Invoke(AddText, "데이터를 보내는 동안 오류가 발생하였습니다.");
                this.txtMessage.Clear();
            }
        }

        private void tsbtnDisconn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbServer.Checked)
                {
                    if (SerClient.Connected)
                    {
                        var dt = Convert.ToString(DateTime.Now);
                        myWrite.WriteLine(myName + "&" + "채팅 APP가 종료되었습니다." + "&" + dt);
                        myWrite.Flush();
                    }
                }
                else
                {
                    if (client.Connected)
                    {
                        var dt = Convert.ToString(DateTime.Now);
                        myWrite.WriteLine(this.myName + "&" + "채팅 APP가 종료되었습니다." + "&" + dt);
                        myWrite.Flush();
                    }
                }
            }
            catch { }
            ServerStop();
            설정ToolStripMenuItem.Enabled = true;
        }

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            설정ToolStripMenuItem.Enabled = false;    // 툴팁 메뉴 사용 막기 
            plOption.Visible = true;                  // 설정 패널 보이기 
            txtId.Focus();

            // 지정된 Registry 키에 지정된 이름에 연결된 값을 검색 
            // 지정된 키에 해당 이름이 없으면 사용자가 제공한 기본값이 반환 
            txtId.Text = (String)key.GetValue("Message_name");      // 별칭 입력 
            txtPort.Text = (String)key.GetValue("Message_port");    // 포트입력 
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //폼 닫기
        }
    }
}
