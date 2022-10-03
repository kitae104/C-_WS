namespace Notepad
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnDown = new System.Windows.Forms.RadioButton();
            this.rdBtnUp = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "찾을 내용 ";
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(83, 13);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(240, 23);
            this.txtWord.TabIndex = 1;
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(341, 13);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "다음 찾기";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(341, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취    소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.Location = new System.Drawing.Point(14, 62);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(107, 19);
            this.chkCase.TabIndex = 4;
            this.chkCase.Text = "대/소문자 구문";
            this.chkCase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnDown);
            this.groupBox1.Controls.Add(this.rdBtnUp);
            this.groupBox1.Location = new System.Drawing.Point(127, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 48);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "방향";
            // 
            // rdBtnDown
            // 
            this.rdBtnDown.AutoSize = true;
            this.rdBtnDown.Checked = true;
            this.rdBtnDown.Location = new System.Drawing.Point(101, 18);
            this.rdBtnDown.Name = "rdBtnDown";
            this.rdBtnDown.Size = new System.Drawing.Size(61, 19);
            this.rdBtnDown.TabIndex = 1;
            this.rdBtnDown.TabStop = true;
            this.rdBtnDown.Text = "아래쪽";
            this.rdBtnDown.UseVisualStyleBackColor = true;
            // 
            // rdBtnUp
            // 
            this.rdBtnUp.AutoSize = true;
            this.rdBtnUp.Location = new System.Drawing.Point(19, 18);
            this.rdBtnUp.Name = "rdBtnUp";
            this.rdBtnUp.Size = new System.Drawing.Size(49, 19);
            this.rdBtnUp.TabIndex = 0;
            this.rdBtnUp.Text = "위쪽";
            this.rdBtnUp.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 102);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "찾  기";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnCancel;
        private GroupBox groupBox1;
        public TextBox txtWord;
        public Button btnOk;
        public CheckBox chkCase;
        internal RadioButton rdBtnDown;
        internal RadioButton rdBtnUp;
    }
}