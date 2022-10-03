using System.IO;        // 파일 개체 활용 

namespace Notepad
{
    public partial class Form1 : Form
    {
        private Boolean txtNoteChange;  // 내용변경체크 
        private String fWord;           // 찾기 문자열 
        private Form2 frm2;             // 찾기 폼  


        public Form1()
        {
            InitializeComponent();
        }

        private void 도움말ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void 모두선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectAll(); //메모장의 텍스트 모두 선택
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            txtNoteChange = true;       //데이터 추가, 변경 여부 
        }

        private void 새로만들기NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteChange == true)
            {
                String msg = this.Text + " 파일의 내용이 변경되었습니다. \r\n 변경된 내용을 저장하시겠습니까?";
                DialogResult dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dlr == DialogResult.Yes)
                {
                    textSave();
                    txtNote.ResetText();
                    Text = "제목 없음";
                }
                else if (dlr == DialogResult.No)
                {
                    txtNote.ResetText();
                    Text = "제목 없음";
                    txtNoteChange = false;
                }
                else if (dlr == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    txtNote.ResetText();
                    Text = "제목 없음";
                    txtNoteChange = false;
                }
            }
        }

        private void textSave()
        {
            if (Text == "제목 없음")
            {
                DialogResult dlr = saveFileDialog1.ShowDialog();
                if (dlr != DialogResult.Cancel)
                {
                    String str = saveFileDialog1.FileName;      // 파일 이름 
                    
                    // 지정된 인코딩과 기본 버퍼 크기를 사용하여 지정 경로의 지정 파일에 대한 객체 초기화 
                    StreamWriter sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                    
                    sw.Write(txtNote.Text);
                    sw.Flush();
                    sw.Close();

                    FileInfo f = new FileInfo(str);
                    Text = f.Name;
                    txtNoteChange = false;
                }
            }
            else
            {
                string strt = Text;
                StreamWriter sw = new StreamWriter(strt, false, System.Text.Encoding.Default);

                sw.Write(txtNote.Text);
                sw.Flush();
                sw.Close();

                Text = strt;
                txtNoteChange = false;
            }
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textSave();
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteChange == true)   // [txtNote] 컨트롤의 입력 데이터가 수정 및 추가되었을 때
            {
                var msg = Text + " 파일의 내용이 변경되었습니다. \r\n 변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dlr == DialogResult.Yes)
                {
                    textSave();     // 데이터 저장 메서드 호출
                    textOpen();     // 파일 열기 메서드 호출
                }
                else if (dlr == DialogResult.No)
                {
                    textOpen(); //저장하지 않고 파일 열기 메서드 호출
                }
                else if (dlr == DialogResult.Cancel)
                {
                    return; //저장 및 열기 하지 않고 모든 작업을 취소한다.
                }
            }
            else
            {
                textOpen(); // [txtNote] 컨트롤의 입력 데이터가 수정 및 추가 되지 않았다.
            }
        }


        private void textOpen()
        {
            var dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                var str = openFileDialog1.FileName;
                var sr = new StreamReader(str, System.Text.Encoding.Default);
                txtNote.Text = sr.ReadToEnd();
                sr.Close();

                var f = new FileInfo(str);
                Text = f.Name;
                txtNoteChange = false;
            }
        }

        // 폼이 닫힐 때 발생하는 이벤트 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;        // 폼의 종료를 취소

            if (txtNoteChange == true)
            {
                var msg = this.Text + " 파일의 내용이 변경되었습니다. \r\n 변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    if (this.Text == "제목 없음")
                    {
                        var dr = saveFileDialog1.ShowDialog();
                        if (dr != DialogResult.Cancel)
                        {
                            var str = saveFileDialog1.FileName;
                            var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                            sw.Write(txtNote.Text);
                            sw.Flush();
                            sw.Close();
                            this.txtNoteChange = false;
                        }
                    }
                    // 파일 이름이 있는 경우 
                    else
                    {
                        var str = this.Text;
                        var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                        sw.Write(this.txtNote.Text);
                        sw.Flush();
                        sw.Close();
                        this.txtNoteChange = false;
                    }
                    this.Dispose();
                }
                else if (dlr == DialogResult.No)
                {
                    this.Dispose();
                }
                else if (dlr == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void 다른이름으로저장AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlr = this.saveFileDialog1.ShowDialog();    //[다른 이름으로 저장] 대화상자 호출
            if (dlr != DialogResult.Cancel)
            {
                var str = saveFileDialog1.FileName; //파일 경로 
                var sw = new StreamWriter(str, false, System.Text.Encoding.Default); //StreamWriter 생성자를 이용하여 개체 생성
                sw.Write(txtNote.Text); // Write 메서드를 이용하여 지정된 경로에 txtNote 컨트롤의 입력 문자열 저장
                sw.Flush();
                sw.Close();

                var f = new FileInfo(str);
                Text = f.Name;              // 폼에 대한 제목 변경 
                txtNoteChange = false;      //입력 데이터 입력 및 수정 초기화
            }
        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();       // 폼 종료
        }

        private void 실행취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Undo(); //텍스트 박스의 변경사항을 취소하고 이전 상태로 되돌려줌
        }

        private void 잘라내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Cut(); //선택된 텍스트를 잘라낸다.
        }

        private void 복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Copy(); //선택된 텍스트를 복사한다.
        }

        private void 붙여넣기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Paste(); //텍스트 데이터 붙여넣기
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectedText = ""; //선택된 텍스트 지우기
        }

        private void 찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 찾기 폼이 존재하는 경우 
            if (!(frm2 == null || !frm2.Visible))
            {
                frm2.Focus();
                return;
            }

            //찾기 폼이 존재하지 않는 경우
            frm2 = new Form2();

            // 선택된 문자열이 있는지 확인 하여 처리하는 부분 
            if (txtNote.SelectionLength == 0)
            {
                //frm2.txtWord.Text = fWord;
            }
            else
            {
                frm2.txtWord.Text = txtNote.SelectedText;
            }
            frm2.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            frm2.Show();
        }

        private void 다음찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 찾기 폼이 존재하는 경우 
            if (!(frm2 == null || !frm2.Visible))
            {
                frm2.txtWord.Text = this.fWord;
                this.btnOk_Click(this, null);       // 버튼 클릭 이벤트 
            }
        }

        private void 시간날짜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToShortTimeString(); //현재 시간 얻기
            var date = DateTime.Today.ToShortDateString(); //오늘 날짜 얻기
            this.txtNote.AppendText(time + "/" + date); //입력 데이터 맨뒤에 이어서 시간/날짜 정보 추가
        }

        private void 자동줄바꿈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.WordWrap = !(txtNote.WordWrap); // 기존 상태를 반대로 설정 
            자동줄바꿈ToolStripMenuItem.Checked = !(자동줄바꿈ToolStripMenuItem.Checked);
        }

        private void 글꼴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)  // 폰트 대화상자 호출
            {
                txtNote.Font = fontDialog1.Font;    // 텍스트 박스의 폰트 변경
            }
        }

        private void 메모장정보AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(); //Form3 객체 초기화 선언
            frm3.ShowDialog(); //폼3 호출
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var updown = -1;
            var str = txtNote.Text;             // 본문 내용
            var findWord = frm2.txtWord.Text;   // 찾을 문자열 저장

            if (!frm2.chkCase.Checked)
            {
                str = str.ToUpper();            //저장된 본문을 대문자로 변환
                findWord = findWord.ToUpper();
            }

            if (frm2.rdBtnUp.Checked)           // 윗쪽으로 선택시 
            {                                   // 지정된 문자 위치에서 뒤로 검색
                if (txtNote.SelectionStart != 0)
                {   // LastIndexOf() 지정된 문자 위치에서 검색을 시작하고 문자열의 시작 부분을 향해 뒤로 검색을 수행 
                    // 마지막으로 발견되는 지정된 문자열의 인덱스(0부터 시작) 위치를 반환 
                    updown = str.LastIndexOf(findWord, txtNote.SelectionStart -1);  // 일치되는 문자의 위치를 가져옴
                }
            }
            else  // 아래 방향 선택시 IndexOf를 이용하여 지정된 문자 위치에서 앞으로 검색 수행 
            {
                // IndexOf() 검색은 지정된 문자 위치에서 시작되며, 맨 처음 발견되는 지정된 문자열의
                // 인덱스 위치를 반환한다.
                updown = str.IndexOf(findWord, txtNote.SelectionStart + txtNote.SelectionLength);
            }

            // LastIndexOf() 메소드와 IndexOf() 메소드의 반환 값이 -1일 때, 즉 선택 데이터가 없으면 메시지 출력 
            if(updown == -1)
            {
                MessageBox.Show("더 이상 찾는 문자열이 없습니다.", "메모장", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Select() 텍스트 상자의 텍스트 범위를 선택한다. 
            txtNote.Select(updown, findWord.Length);    // 지정된 문자 범위 선택 
            fWord = frm2.txtWord.Text;  
            txtNote.Focus();
            txtNote.ScrollToCaret();                    // 선택된 문자 위치까지 스크롤하여 내용 나타냄.
        }
    }
}