using System.IO; //���� Ŭ���� ���
using System.Collections; //ArrayList Ŭ���� ���

namespace TypingWord
{
    public partial class Form1 : Form
    {
        private string kind = "";       // �ѱ� �Ǵ� ����
        int array = 0;                  // ���� �� ���� 
        int jumsu = 0;                  // ���� 
        int selectlbl;                  // 1 ~ 6 ���� ��(�������� ����)
        int maxjumsu = 0;               // ��������

        private string[] word;          // �迭�� ���� ����
        private string[] TempKorWord = new string[] { "������", "�󸶹�", "������", "ī����", "������", "�ļֶ�" };   // �迭�� ���� ����  
        private String[] TempEngWord = new string[] { "abc", "def", "ghi", "jkl", "mno", "pqr" }; //�迭�� ���� ����
        private ArrayList ArrayWord = new ArrayList();      // ������ ���� ���� 

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}