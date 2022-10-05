using System.IO; //파일 클래스 사용
using System.Collections; //ArrayList 클래스 사용

namespace TypingWord
{
    public partial class Form1 : Form
    {
        private string kind = "";       // 한글 또는 영어
        int array = 0;                  // 랜덤 수 지정 
        int jumsu = 0;                  // 점수 
        int selectlbl;                  // 1 ~ 6 랜덤 수(랜덤벽돌 지정)
        int maxjumsu = 0;               // 최종점수

        private string[] word;          // 배열에 워드 지정
        private string[] TempKorWord = new string[] { "가나다", "라마바", "아자차", "카파하", "도레미", "파솔라" };   // 배열에 워드 지정  
        private String[] TempEngWord = new string[] { "abc", "def", "ghi", "jkl", "mno", "pqr" }; //배열에 워드 지정
        private ArrayList ArrayWord = new ArrayList();      // 맞춰질 문자 저장 

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}