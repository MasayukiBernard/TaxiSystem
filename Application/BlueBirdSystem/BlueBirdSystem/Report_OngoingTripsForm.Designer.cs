namespace BlueBirdSystem
{
    partial class Report_OngoingTripsForm
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
            this.txtOngoing = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOngoing = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOngoing)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOngoing
            // 
            this.txtOngoing.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOngoing.Location = new System.Drawing.Point(208, 29);
            this.txtOngoing.Name = "txtOngoing";
            this.txtOngoing.Size = new System.Drawing.Size(100, 34);
            this.txtOngoing.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ongoing Trips:";
            // 
            // dgvOngoing
            // 
            this.dgvOngoing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOngoing.Location = new System.Drawing.Point(12, 92);
            this.dgvOngoing.Name = "dgvOngoing";
            this.dgvOngoing.RowHeadersWidth = 51;
            this.dgvOngoing.RowTemplate.Height = 24;
            this.dgvOngoing.Size = new System.Drawing.Size(1198, 364);
            this.dgvOngoing.TabIndex = 3;
            // 
            // Report_OngoingTripsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 480);
            this.Controls.Add(this.txtOngoing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOngoing);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Report_OngoingTripsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Bird - Report: Ongoing Trips";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOngoing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOngoing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOngoing;
    }
}