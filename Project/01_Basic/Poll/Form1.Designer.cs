namespace Poll
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.gbSports = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gbHobby = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSprots = new System.Windows.Forms.Label();
            this.lblHobby = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbSports.SuspendLayout();
            this.gbHobby.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.gbSports);
            this.panel1.Controls.Add(this.gbHobby);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 208);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(164, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "제출하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbSports
            // 
            this.gbSports.Controls.Add(this.checkBox2);
            this.gbSports.Controls.Add(this.checkBox1);
            this.gbSports.Location = new System.Drawing.Point(12, 80);
            this.gbSports.Name = "gbSports";
            this.gbSports.Size = new System.Drawing.Size(237, 58);
            this.gbSports.TabIndex = 1;
            this.gbSports.TabStop = false;
            this.gbSports.Text = "좋아하는 스포츠는?";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(124, 25);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(50, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "농구";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "축구";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // gbHobby
            // 
            this.gbHobby.Controls.Add(this.radioButton2);
            this.gbHobby.Controls.Add(this.radioButton1);
            this.gbHobby.Location = new System.Drawing.Point(12, 13);
            this.gbHobby.Name = "gbHobby";
            this.gbHobby.Size = new System.Drawing.Size(239, 61);
            this.gbHobby.TabIndex = 0;
            this.gbHobby.TabStop = false;
            this.gbHobby.Text = "취미는?";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(124, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "영화보기";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "독서하기";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.panel2.Controls.Add(this.lblSprots);
            this.panel2.Controls.Add(this.lblHobby);
            this.panel2.Location = new System.Drawing.Point(0, 214);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 101);
            this.panel2.TabIndex = 0;
            // 
            // lblSprots
            // 
            this.lblSprots.AutoSize = true;
            this.lblSprots.Location = new System.Drawing.Point(28, 58);
            this.lblSprots.Name = "lblSprots";
            this.lblSprots.Size = new System.Drawing.Size(62, 15);
            this.lblSprots.TabIndex = 1;
            this.lblSprots.Text = "스포츠는 :";
            // 
            // lblHobby
            // 
            this.lblHobby.AutoSize = true;
            this.lblHobby.Location = new System.Drawing.Point(28, 22);
            this.lblHobby.Name = "lblHobby";
            this.lblHobby.Size = new System.Drawing.Size(54, 15);
            this.lblHobby.TabIndex = 0;
            this.lblHobby.Text = "취미는 : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 317);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "설문조사";
            this.panel1.ResumeLayout(false);
            this.gbSports.ResumeLayout(false);
            this.gbSports.PerformLayout();
            this.gbHobby.ResumeLayout(false);
            this.gbHobby.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button1;
        private GroupBox gbSports;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private GroupBox gbHobby;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel2;
        private Label lblSprots;
        private Label lblHobby;
    }
}