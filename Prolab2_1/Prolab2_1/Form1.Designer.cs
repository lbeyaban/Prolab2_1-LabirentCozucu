namespace Prolab2_1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bfsradioButton = new System.Windows.Forms.RadioButton();
            this.dfsradioButton = new System.Windows.Forms.RadioButton();
            this.task1btn = new System.Windows.Forms.Button();
            this.loadMazebtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.boyuttxt = new System.Windows.Forms.TextBox();
            this.solvebtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bfsradioButton2 = new System.Windows.Forms.RadioButton();
            this.dfsradioButton2 = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bfsradioButton);
            this.groupBox1.Controls.Add(this.dfsradioButton);
            this.groupBox1.Controls.Add(this.task1btn);
            this.groupBox1.Controls.Add(this.loadMazebtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task 1";
            // 
            // bfsradioButton
            // 
            this.bfsradioButton.AutoSize = true;
            this.bfsradioButton.Location = new System.Drawing.Point(6, 114);
            this.bfsradioButton.Name = "bfsradioButton";
            this.bfsradioButton.Size = new System.Drawing.Size(45, 17);
            this.bfsradioButton.TabIndex = 3;
            this.bfsradioButton.TabStop = true;
            this.bfsradioButton.Text = "BFS";
            this.bfsradioButton.UseVisualStyleBackColor = true;
            // 
            // dfsradioButton
            // 
            this.dfsradioButton.AutoSize = true;
            this.dfsradioButton.Location = new System.Drawing.Point(6, 91);
            this.dfsradioButton.Name = "dfsradioButton";
            this.dfsradioButton.Size = new System.Drawing.Size(46, 17);
            this.dfsradioButton.TabIndex = 2;
            this.dfsradioButton.TabStop = true;
            this.dfsradioButton.Text = "DFS";
            this.dfsradioButton.UseVisualStyleBackColor = true;
            // 
            // task1btn
            // 
            this.task1btn.Location = new System.Drawing.Point(6, 145);
            this.task1btn.Name = "task1btn";
            this.task1btn.Size = new System.Drawing.Size(128, 34);
            this.task1btn.TabIndex = 1;
            this.task1btn.Text = "Task  1";
            this.task1btn.UseVisualStyleBackColor = true;
            this.task1btn.Click += new System.EventHandler(this.task1btn_Click);
            // 
            // loadMazebtn
            // 
            this.loadMazebtn.Location = new System.Drawing.Point(6, 42);
            this.loadMazebtn.Name = "loadMazebtn";
            this.loadMazebtn.Size = new System.Drawing.Size(128, 34);
            this.loadMazebtn.TabIndex = 0;
            this.loadMazebtn.Text = "Load Maze";
            this.loadMazebtn.UseVisualStyleBackColor = true;
            this.loadMazebtn.Click += new System.EventHandler(this.loadMazebtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate Maze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // boyuttxt
            // 
            this.boyuttxt.Location = new System.Drawing.Point(6, 37);
            this.boyuttxt.Name = "boyuttxt";
            this.boyuttxt.Size = new System.Drawing.Size(128, 20);
            this.boyuttxt.TabIndex = 3;
            // 
            // solvebtn
            // 
            this.solvebtn.Location = new System.Drawing.Point(6, 162);
            this.solvebtn.Name = "solvebtn";
            this.solvebtn.Size = new System.Drawing.Size(128, 34);
            this.solvebtn.TabIndex = 4;
            this.solvebtn.Text = "Solve Maze";
            this.solvebtn.UseVisualStyleBackColor = true;
            this.solvebtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bfsradioButton2);
            this.groupBox2.Controls.Add(this.dfsradioButton2);
            this.groupBox2.Controls.Add(this.boyuttxt);
            this.groupBox2.Controls.Add(this.solvebtn);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 211);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task 2";
            // 
            // bfsradioButton2
            // 
            this.bfsradioButton2.AutoSize = true;
            this.bfsradioButton2.Location = new System.Drawing.Point(6, 133);
            this.bfsradioButton2.Name = "bfsradioButton2";
            this.bfsradioButton2.Size = new System.Drawing.Size(45, 17);
            this.bfsradioButton2.TabIndex = 9;
            this.bfsradioButton2.TabStop = true;
            this.bfsradioButton2.Text = "BFS";
            this.bfsradioButton2.UseVisualStyleBackColor = true;
            // 
            // dfsradioButton2
            // 
            this.dfsradioButton2.AutoSize = true;
            this.dfsradioButton2.Location = new System.Drawing.Point(6, 110);
            this.dfsradioButton2.Name = "dfsradioButton2";
            this.dfsradioButton2.Size = new System.Drawing.Size(46, 17);
            this.dfsradioButton2.TabIndex = 8;
            this.dfsradioButton2.TabStop = true;
            this.dfsradioButton2.Text = "DFS";
            this.dfsradioButton2.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gecen Sure : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Kare : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 754);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button task1btn;
        private System.Windows.Forms.Button loadMazebtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox boyuttxt;
        private System.Windows.Forms.Button solvebtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton bfsradioButton;
        private System.Windows.Forms.RadioButton dfsradioButton;
        private System.Windows.Forms.RadioButton bfsradioButton2;
        private System.Windows.Forms.RadioButton dfsradioButton2;
    }
}

