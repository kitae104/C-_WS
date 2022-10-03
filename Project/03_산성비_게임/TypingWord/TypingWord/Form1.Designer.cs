namespace TypingWord
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plMain = new System.Windows.Forms.Panel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtInsert = new System.Windows.Forms.TextBox();
            this.lblLife = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblImg = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtJumsu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaxJumsu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.randomtim = new System.Windows.Forms.Timer(this.components);
            this.btn1tim = new System.Windows.Forms.Timer(this.components);
            this.btn2tim = new System.Windows.Forms.Timer(this.components);
            this.btn3tim = new System.Windows.Forms.Timer(this.components);
            this.btn4tim = new System.Windows.Forms.Timer(this.components);
            this.btn5tim = new System.Windows.Forms.Timer(this.components);
            this.환경설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plMain.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.plMain.Controls.Add(this.button5);
            this.plMain.Controls.Add(this.button4);
            this.plMain.Controls.Add(this.button3);
            this.plMain.Controls.Add(this.button2);
            this.plMain.Controls.Add(this.button1);
            this.plMain.Location = new System.Drawing.Point(12, 37);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(502, 353);
            this.plMain.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.설정ToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(665, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.환경설정ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.종료ToolStripMenuItem});
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.설정ToolStripMenuItem.Text = "설 정";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.lblImg);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(520, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(137, 176);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtMaxJumsu);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtJumsu);
            this.panel3.Controls.Add(this.lblGrade);
            this.panel3.Location = new System.Drawing.Point(520, 222);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(137, 168);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(18, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(114, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(213, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(309, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(401, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 412);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "시 작";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 412);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "정 지";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // txtInsert
            // 
            this.txtInsert.Location = new System.Drawing.Point(185, 412);
            this.txtInsert.Name = "txtInsert";
            this.txtInsert.Size = new System.Drawing.Size(282, 23);
            this.txtInsert.TabIndex = 6;
            this.txtInsert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLife
            // 
            this.lblLife.BackColor = System.Drawing.Color.Red;
            this.lblLife.Location = new System.Drawing.Point(482, 419);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(146, 7);
            this.lblLife.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "사용자 이름";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblImg
            // 
            this.lblImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblImg.Location = new System.Drawing.Point(18, 53);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(100, 100);
            this.lblImg.TabIndex = 1;
            this.lblImg.Text = "이미지 출력";
            this.lblImg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(54, 19);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(14, 15);
            this.lblGrade.TabIndex = 0;
            this.lblGrade.Text = "1";
            // 
            // txtJumsu
            // 
            this.txtJumsu.Location = new System.Drawing.Point(14, 48);
            this.txtJumsu.Name = "txtJumsu";
            this.txtJumsu.Size = new System.Drawing.Size(89, 23);
            this.txtJumsu.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "점";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "최고 점수";
            // 
            // txtMaxJumsu
            // 
            this.txtMaxJumsu.Location = new System.Drawing.Point(14, 109);
            this.txtMaxJumsu.Name = "txtMaxJumsu";
            this.txtMaxJumsu.Size = new System.Drawing.Size(89, 23);
            this.txtMaxJumsu.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "점";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn1tim
            // 
            this.btn1tim.Interval = 1000;
            // 
            // btn2tim
            // 
            this.btn2tim.Interval = 1000;
            // 
            // btn3tim
            // 
            this.btn3tim.Interval = 1000;
            // 
            // btn4tim
            // 
            this.btn4tim.Interval = 1000;
            // 
            // btn5tim
            // 
            this.btn5tim.Interval = 1000;
            // 
            // 환경설정ToolStripMenuItem
            // 
            this.환경설정ToolStripMenuItem.Name = "환경설정ToolStripMenuItem";
            this.환경설정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.환경설정ToolStripMenuItem.Text = "환경 설정";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "사용자 설정";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료ToolStripMenuItem.Text = "종 료";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(665, 447);
            this.Controls.Add(this.lblLife);
            this.Controls.Add(this.txtInsert);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Form1";
            this.Text = "벽돌비";
            this.plMain.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel plMain;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private MenuStrip mainMenu;
        private ToolStripMenuItem 설정ToolStripMenuItem;
        private Panel panel2;
        private Label lblImg;
        private Label label2;
        private Panel panel3;
        private Label label7;
        private TextBox txtMaxJumsu;
        private Label label6;
        private Label label5;
        private TextBox txtJumsu;
        private Label lblGrade;
        private Button btnStart;
        private Button btnStop;
        private TextBox txtInsert;
        private Label lblLife;
        private ImageList imageList1;
        private System.Windows.Forms.Timer randomtim;
        private System.Windows.Forms.Timer btn1tim;
        private System.Windows.Forms.Timer btn2tim;
        private System.Windows.Forms.Timer btn3tim;
        private System.Windows.Forms.Timer btn4tim;
        private System.Windows.Forms.Timer btn5tim;
        private ToolStripMenuItem 환경설정ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem 종료ToolStripMenuItem;
    }
}