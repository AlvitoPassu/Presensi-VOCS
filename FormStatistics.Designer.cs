namespace Final_Project
{
    partial class FormStatistics
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStatistics;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(14, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(127, 52);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(56, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attendance Statistics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label2.Location = new System.Drawing.Point(61, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "View and manage all meeting attendance records";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStatistics);
            this.groupBox1.Location = new System.Drawing.Point(0, 212);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1035, 389);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colMeeting,
            this.colPresent,
            this.colLate,
            this.colAbsent});
            this.dgvStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatistics.Location = new System.Drawing.Point(3, 23);
            this.dgvStatistics.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.RowHeadersWidth = 51;
            this.dgvStatistics.RowTemplate.Height = 24;
            this.dgvStatistics.Size = new System.Drawing.Size(1029, 362);
            this.dgvStatistics.TabIndex = 0;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 8;
            this.colDate.Name = "colDate";
            this.colDate.Width = 150;
            // 
            // colMeeting
            // 
            this.colMeeting.HeaderText = "Meeting Description";
            this.colMeeting.MinimumWidth = 8;
            this.colMeeting.Name = "colMeeting";
            this.colMeeting.Width = 150;
            // 
            // colPresent
            // 
            this.colPresent.HeaderText = "Present";
            this.colPresent.MinimumWidth = 8;
            this.colPresent.Name = "colPresent";
            this.colPresent.Width = 150;
            // 
            // colLate
            // 
            this.colLate.HeaderText = "Late";
            this.colLate.MinimumWidth = 8;
            this.colLate.Name = "colLate";
            this.colLate.Width = 150;
            // 
            // colAbsent
            // 
            this.colAbsent.HeaderText = "Absent";
            this.colAbsent.MinimumWidth = 8;
            this.colAbsent.Name = "colAbsent";
            this.colAbsent.Width = 150;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 704);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStatistics";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeeting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbsent;
    }
}
