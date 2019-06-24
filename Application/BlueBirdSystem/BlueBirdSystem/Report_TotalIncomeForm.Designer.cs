namespace BlueBirdSystem
{
    partial class Report_TotalIncomeForm
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.filteByCb = new System.Windows.Forms.ComboBox();
            this.result2Tb = new System.Windows.Forms.TextBox();
            this.result1Tb = new System.Windows.Forms.TextBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(193, 169);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(81, 22);
            this.textBox2.TabIndex = 29;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 121);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 22);
            this.textBox1.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(80, 473);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "Rp";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(80, 389);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "Rp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(79, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Result 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(79, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Result 1";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(193, 169);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(81, 22);
            this.dateTimePicker2.TabIndex = 23;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(193, 121);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(81, 22);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // filteByCb
            // 
            this.filteByCb.BackColor = System.Drawing.SystemColors.Control;
            this.filteByCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filteByCb.FormattingEnabled = true;
            this.filteByCb.Items.AddRange(new object[] {
            "-- Choose Filter --",
            "MONTH",
            "YEAR"});
            this.filteByCb.Location = new System.Drawing.Point(193, 59);
            this.filteByCb.Margin = new System.Windows.Forms.Padding(4);
            this.filteByCb.Name = "filteByCb";
            this.filteByCb.Size = new System.Drawing.Size(153, 24);
            this.filteByCb.TabIndex = 21;
            this.filteByCb.SelectedIndexChanged += new System.EventHandler(this.FilteByCb_SelectedIndexChanged);
            // 
            // result2Tb
            // 
            this.result2Tb.BackColor = System.Drawing.SystemColors.Control;
            this.result2Tb.Location = new System.Drawing.Point(143, 473);
            this.result2Tb.Margin = new System.Windows.Forms.Padding(4);
            this.result2Tb.Name = "result2Tb";
            this.result2Tb.Size = new System.Drawing.Size(360, 22);
            this.result2Tb.TabIndex = 20;
            // 
            // result1Tb
            // 
            this.result1Tb.BackColor = System.Drawing.SystemColors.Control;
            this.result1Tb.Location = new System.Drawing.Point(143, 389);
            this.result1Tb.Margin = new System.Windows.Forms.Padding(4);
            this.result1Tb.Name = "result1Tb";
            this.result1Tb.Size = new System.Drawing.Size(360, 22);
            this.result1Tb.TabIndex = 19;
            // 
            // generateBtn
            // 
            this.generateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(164)))));
            this.generateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.generateBtn.ForeColor = System.Drawing.Color.White;
            this.generateBtn.Location = new System.Drawing.Point(143, 232);
            this.generateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(307, 87);
            this.generateBtn.TabIndex = 18;
            this.generateBtn.Text = "GENERATE REPORT";
            this.generateBtn.UseVisualStyleBackColor = false;
            this.generateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(80, 436);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Result 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(79, 347);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Result 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(79, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Filter By";
            // 
            // Report_TotalIncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 537);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.filteByCb);
            this.Controls.Add(this.result2Tb);
            this.Controls.Add(this.result1Tb);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Report_TotalIncomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Bird - Report: Total Income";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox filteByCb;
        private System.Windows.Forms.TextBox result2Tb;
        private System.Windows.Forms.TextBox result1Tb;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}