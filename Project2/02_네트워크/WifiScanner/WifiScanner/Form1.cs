using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NativeWifi;
using System.Threading;

namespace WifiScanner
{
    public partial class Form1 : Form
    {
        WlanClient wlanClient = new WlanClient();
        Thread thrAP = null;

        private delegate void OnWifiViewDelegate(bool flags, object[] AddWifi); //델리게이트 개체 생성
        private OnWifiViewDelegate OnView = null;                               //델리게이트 개체 생성

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnView = new OnWifiViewDelegate(OnWifiList);
            thrAP = new Thread(ThreadList);
            thrAP.Start();
        }

        private void ThreadList()
        {
            throw new NotImplementedException();
        }

        private void OnWifiList(bool flags, object[] AddWifi)
        {
            throw new NotImplementedException();
        }
    }
}
