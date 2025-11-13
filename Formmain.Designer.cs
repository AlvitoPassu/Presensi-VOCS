namespace Final_Project
{
    partial class Formmain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formmain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTakeAttendance = new System.Windows.Forms.Button();
            this.btnMemberList = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.btnExitApp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Presensi VOCS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Voice of Computer Science";
            // 
            // btnTakeAttendance
            // 
            this.btnTakeAttendance.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnTakeAttendance.Image")));
            this.btnTakeAttendance.Location = new System.Drawing.Point(99, 126);
            this.btnTakeAttendance.Name = "btnTakeAttendance";
            this.btnTakeAttendance.Size = new System.Drawing.Size(241, 70);
            this.btnTakeAttendance.TabIndex = 3;
            this.btnTakeAttendance.Text = "Take Attendance";
            this.btnTakeAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTakeAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTakeAttendance.UseVisualStyleBackColor = true;
            this.btnTakeAttendance.Click += new System.EventHandler(this.btnTakeAttendance_Click);
            // 
            // btnMemberList
            // 
            this.btnMemberList.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberList.Image = ((System.Drawing.Image)(resources.GetObject("btnMemberList.Image")));
            this.btnMemberList.Location = new System.Drawing.Point(444, 242);
            this.btnMemberList.Name = "btnMemberList";
            this.btnMemberList.Size = new System.Drawing.Size(241, 70);
            this.btnMemberList.TabIndex = 4;
            this.btnMemberList.Text = "Member List";
            this.btnMemberList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMemberList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMemberList.UseVisualStyleBackColor = true;
            this.btnMemberList.Click += new System.EventHandler(this.btnMemberList_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistics.Image")));
            this.btnStatistics.Location = new System.Drawing.Point(444, 126);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(241, 70);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMember.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMember.Image")));
            this.btnAddMember.Location = new System.Drawing.Point(99, 242);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(241, 70);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // btnExitApp
            // 
            this.btnExitApp.Font = new System.Drawing.Font("Poppins SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitApp.Image = ((System.Drawing.Image)(resources.GetObject("btnExitApp.Image")));
            this.btnExitApp.Location = new System.Drawing.Point(275, 351);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(241, 70);
            this.btnExitApp.TabIndex = 7;
            this.btnExitApp.Text = "Exit App";
            this.btnExitApp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExitApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // Formmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExitApp);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnMemberList);
            this.Controls.Add(this.btnTakeAttendance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Formmain";
            this.Text = "Formmain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTakeAttendance;
        private System.Windows.Forms.Button btnMemberList;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnExitApp;
    }
}