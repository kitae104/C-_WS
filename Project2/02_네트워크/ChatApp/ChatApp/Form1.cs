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

        // 지정된 레지스트리의 값을 가져오는 작업을 수행
        private void Form1_Load(object sender, EventArgs e)
        {
            // 레지스트리의 키 값이 설정되어 있지 않다면 Text 속성값을 가져와 변수에 값을 저장하는 작업을 수행 
            if ((string)key.GetValue("Message_name") == "")
            {
                myName = txtId.Text;
                myPort = Convert.ToInt32(txtPort.Text);
            }
            // 레지스트리의 키값이 설정되어 있을 때 변수에 값을 저장하는 작업을 수행, 이름과 포트를 가져온다. 
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
            // 각 입력 컨트롤의 .Text 속성값에 대한 유호성 검사
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
                    
                    // 지정된 이름 레지스트에 값 쌍을 설정
                    key.SetValue("Message_name", name);         // 키값 설정 
                    key.SetValue("Message_port", port);

                    // Visible과 Enable 속성 값 설정 
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

        // 서버/클라이언트 어플리케이션으로 모드 변환이 있을 때 Enable 
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

        // txtMessage 컨트롤을 더블클릭해서 생성하는 핸들러
        // 상대방이 데이터 입력 창에 문자를 입력하는지를 체크하여 상대방에게 정보를 보내줌
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            // TextChange 컨트롤에 문자가 입력되면 상대방에게 정보를 보내는 작업 수행
            if(TextChange == false)
            {
                TextChange = true;

                // 구분자 &를 이용하여 구분 코드와 문자를 생성
                // 일반 메시지 : 명칭, 문자열, 일시 
                // 상대방의 메시지 입력 정보를 나타내는 것으로 구분 코드'S001'을 입력하여 메시지를 받을 때 tsslblTime에 출력
                myWrite.WriteLine("S001" + "&" + "상대방이 메시지 입력중입니다." + "&" + " ");
                myWrite.Flush();
            }
            else if(txtMessage.Text == "" && TextChange == true)
            {
                TextChange = false;
            }
        }

        // 델리게이트를 초기화 하고지정된 로컬 IP와 포트 번호에서 들어오는 연결 시도를 
        // 수신하는 TcpListener 클래스 개체를 초기화
        private void tsbtnConn_Click(object sender, EventArgs e)
        {
            AddText = new AddTextDelegate(MessageView);     // 델리게이트 메소드 등록 
            if(cbServer.Checked == true)                    // 서버로 어플리케이션
            {
                var addr = new IPAddress(0);                // 로컬 단말의 이미지를 가져옮
                
                //레지스트의 매칭 값을 가져와 이름과 포트 변수에 저장하거나 
                // 입력 컨트롤에 입력된 값을 저장한다. 
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
                        // 지정된 로컬 IP 주소와 포트 변수에서 들오오는 연결시도를 수신하는 
                        // TcpListener 클래스의 객체 Server를 초기화 한다
                        Server = new TcpListener(addr, myPort);

                        // 연결 요청 수신 시작
                        Server.Start();

                        Start = true;
                        txtMessage.Enabled = true;
                        btnSend.Enabled = true;
                        txtMessage.Focus();
                        tsbtnDisconn.Enabled = true;
                        tsbtnConn.Enabled = false;
                        cbServer.Enabled = false;

                        // 대리자 지정 
                        // 클라이언트 수신과 네트워크 스트림의 값을 수신을 새로운 스레드에서 수행 
                        myServer = new Thread(ServerStart);
                        myServer.Start();

                        설정ToolStripMenuItem.Enabled = false;
                    }
                    catch
                    {
                        // 객체에서 작업하는 메소드와 속성에 대한 엑세스 제공 
                        Invoke(AddText, "서버를 실행할 수 없습니다.");
                    }
                }
                else
                {
                    ServerStop();
                }
            }

            // 변수에 레지스트리 값을 가져오고 ClientConnection() 메소드를 호출
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

        // ServerStart()와 유사한 구조 
        //클라이언트 모드에서 수행되는 메소드 
        private void ClientConnection()
        {
            try
            {
                client = new TcpClient(txtIp.Text, myPort);     // 지정된 IP와 포트로 접속 - 레지스트리에 등록된 값 사용
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

        // 서버 모드 종료
        private void ServerStop()
        {
            Start = false;
            txtMessage.Enabled = false;
            txtMessage.Clear();
            btnSend.Enabled = false;
            tsbtnConn.Enabled = true;
            tsbtnDisconn.Enabled = false;
            cbServer.Enabled = true;
            ClientCon = false;

            if (!(myRead == null))
            {
                myRead.Close(); //StreamReader 클래스 개체 리소스 해제
            }
            if (!(myWrite == null))
            {
                myWrite.Close(); //StreamWriter 클래스 개체 리소스 해제
            }
            if (!(myStream == null))
            {
                myStream.Close(); //NetworkStream 클래스 개체 리소스 해제
            }
            if (!(SerClient == null))
            {
                SerClient.Close(); //TcpClient 클래스 개체 리소스 해제
            }
            if (!(Server == null))
            {
                Server.Stop(); //TcpListen 클래스 개체 리소스 해제
            }
            if (!(myReader == null))
            {
                myReader.Abort(); //외부 스레드 종료
            }
            if (!(myServer == null))
            {
                myServer.Abort(); //외부 스레드 종료
            }
            if (!(AddText == null))
            {
                Invoke(AddText, "연결이 끊어졌습니다.");
            }
        }

        // 생성한 스레드에서 실행되는 메소드
        // 클라이언트의 접속과 클라이언트에서 보낸 데이터를 수신하는 작업 수행
        private void ServerStart()
        {
            // 대리자를 실행시켜 화면에 메시지를 출력하는 작업 수행 
            Invoke(AddText, "서버 실행 : 챗 상대의 접속을 기다립니다...");
            
            while(Start)
            {
                try
                {
                    // 클라이언트의 접속을 기다림
                    SerClient = Server.AcceptTcpClient();   // 보류중인 연결 요청을 받아들여 
                    Invoke(AddText, "챗 상대 접속..");      // 클라이언트가 접속된 것으로 간주 - 메시지 출력 
                    myStream = SerClient.GetStream();       // 데이터를 보내고 받는데 사용한 NetworkStream을 반환 

                    // 네트워크 스트림에서 데이터를 주고 받기 작업을 담당하는 클래스의 개체 생성
                    myRead = new StreamReader(myStream);    // myStream에 저장된 데이터를 읽어
                    myWrite = new StreamWriter(myStream);   // 쓰는 역할 
                    ClientCon = true;

                    // 데이터를 읽어와 출력하는 작업을 수행하는 Receive() 메소드 지정 - 대리자 역할 
                    myReader = new Thread(Receive);         // 외부 스레드에 데이터를 받는 메소드를 대입
                    myReader.Start();
                }
                catch { }
            }
        }

        // 데이터를 읽어와 출력하는 작업을 수행하는 Receive() 메소드 지정 - 대리자 역할 
        // 서버/클라이언트 모드에서 myReader 스레드 객체에서 실행되는 메소드 
        // 받은 데이터를 화면에 출력하는 작업 수행 
        private void Receive()
        {
            try
            {
                while (ClientCon)                       // 클라이언트가 연결된 경우 
                {
                    if (myStream.CanRead)               // 읽기 지원 여부 확인 - 메시지 수신
                    {
                        var msg = myRead.ReadLine();    // 행단위로 읽어와서 변수에 저장 
                        var Smsg = msg.Split('&');
                        if (Smsg[0] == "S001")          // 첫 구분자가 S001이면 
                        {
                            tsslblTime.Text = Smsg[1];  // 상대방의 입력 여부 정보를 tsslblTime에 출력
                        }
                        else
                        {
                            if(msg.Length > 0)
                            {
                                // MessageView() 메소드 호출 대신 델리게이트 실행 
                                Invoke(AddText, Smsg[0] + " : " + Smsg[1]); // 명칭과 메시지를  화면에 출력 
                            }
                            tsslblTime.Text = "마지막으로 받은 시각:" + Smsg[2]; // 날짜 출력 
                        }
                    }
                }
            }
            catch { }
        }

        // rtbText 에 메시지를 출력하고 델리게이트된 메소드 
        private void MessageView(string strText)
        {
            rtbText.AppendText(strText + "\r\n");
            rtbText.Focus();
            rtbText.ScrollToCaret();                // 캐럿 위치까지 스크롤 
            txtMessage.Focus();
            FlashWindow(this.Handle, true);         // 메시지를 수신할 때 상태바에 최소화 되어 있는 폼을 깜빡이게 함
        }

        private void btnSend_Click(object sender, EventArgs e)
        {            
            if(txtMessage.Text == "")
            {
                txtMessage.Focus(); // txtMessage 컨트롤에 포커스를 설정
            }
            else
            {
                Msg_send();
            }
        }

        // txtMessage 컨트롤에 입력된 데이터를 myWrite 개체에 쓰는 작업 수행 
        private void Msg_send()
        {
            try
            {
                var dt = Convert.ToString(DateTime.Now);

                // 명칭 , 메시지, 일시 
                myWrite.WriteLine(this.myName + "&" + this.txtMessage.Text + "&" + dt);
                myWrite.Flush();    // writer의 모든 버퍼를 지우면 버퍼링된 모든 데이터가 내부 스트림에 기록
                MessageView(myName + ": " + txtMessage.Text);  
                txtMessage.Clear();
            }
            catch
            {
                Invoke(AddText, "데이터를 보내는 동안 오류가 발생하였습니다.");
                this.txtMessage.Clear();
            }
        }

        // 생성된 핸들러로 연결된 객체를 끊는 작업 수행 
        private void tsbtnDisconn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbServer.Checked)
                {
                    if (SerClient.Connected)        // 연결 여부 확인 
                    {
                        var dt = Convert.ToString(DateTime.Now);
                        myWrite.WriteLine(myName + "&" + "채팅 APP가 종료되었습니다." + "&" + dt);
                        myWrite.Flush();
                    }
                }
                else
                {
                    if (client.Connected)           // 클라이언트 접속여부 확인 - 서버에 알림
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ServerStop();
            }
            catch
            {
                Disconnection();
            }
        }

        // 별칭, 포트 번호를 입력하는 설정창
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
