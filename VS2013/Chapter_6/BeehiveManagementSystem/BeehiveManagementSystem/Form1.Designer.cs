﻿namespace BeehiveManagementSystem
 {
     partial class Form1
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
             this.groupBox1 = new System.Windows.Forms.GroupBox();
             this.label1 = new System.Windows.Forms.Label();
             this.workerBeeJob = new System.Windows.Forms.ComboBox();
             this.shifts = new System.Windows.Forms.NumericUpDown();
             this.label2 = new System.Windows.Forms.Label();
             this.assignJob = new System.Windows.Forms.Button();
             this.nextShift = new System.Windows.Forms.Button();
             this.report = new System.Windows.Forms.TextBox();
             this.groupBox1.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.shifts)).BeginInit();
             this.SuspendLayout();
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.assignJob);
             this.groupBox1.Controls.Add(this.label2);
             this.groupBox1.Controls.Add(this.shifts);
             this.groupBox1.Controls.Add(this.workerBeeJob);
             this.groupBox1.Controls.Add(this.label1);
             this.groupBox1.Location = new System.Drawing.Point(13, 13);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(255, 94);
             this.groupBox1.TabIndex = 0;
             this.groupBox1.TabStop = false;
             this.groupBox1.Text = "Worker Bee Assignments";
             // 
             // label1
             // 
             this.label1.AutoSize = true;
             this.label1.Location = new System.Drawing.Point(6, 16);
             this.label1.Name = "label1";
             this.label1.Size = new System.Drawing.Size(24, 13);
             this.label1.TabIndex = 0;
             this.label1.Text = "Job";
             // 
             // workerBeeJob
             // 
             this.workerBeeJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.workerBeeJob.FormattingEnabled = true;
             this.workerBeeJob.Items.AddRange(new object[] {
            "Baby bee tutoring",
            "Egg care",
            "Hive maintenance",
            "Honey manufacturing",
            "Nectar collector",
            "Sting patrol"});
             this.workerBeeJob.Location = new System.Drawing.Point(9, 32);
             this.workerBeeJob.Name = "workerBeeJob";
             this.workerBeeJob.Size = new System.Drawing.Size(145, 21);
             this.workerBeeJob.TabIndex = 1;
             // 
             // shifts
             // 
             this.shifts.Location = new System.Drawing.Point(160, 33);
             this.shifts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
             this.shifts.Name = "shifts";
             this.shifts.Size = new System.Drawing.Size(86, 20);
             this.shifts.TabIndex = 2;
             this.shifts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
             // 
             // label2
             // 
             this.label2.AutoSize = true;
             this.label2.Location = new System.Drawing.Point(157, 16);
             this.label2.Name = "label2";
             this.label2.Size = new System.Drawing.Size(33, 13);
             this.label2.TabIndex = 3;
             this.label2.Text = "Shifts";
             // 
             // assignJob
             // 
             this.assignJob.Location = new System.Drawing.Point(9, 59);
             this.assignJob.Name = "assignJob";
             this.assignJob.Size = new System.Drawing.Size(237, 23);
             this.assignJob.TabIndex = 4;
             this.assignJob.Text = "Assign this job to a bee";
             this.assignJob.UseVisualStyleBackColor = true;
             this.assignJob.Click += new System.EventHandler(this.assignJob_Click);
             // 
             // nextShift
             // 
             this.nextShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.nextShift.Location = new System.Drawing.Point(275, 18);
             this.nextShift.Name = "nextShift";
             this.nextShift.Size = new System.Drawing.Size(138, 89);
             this.nextShift.TabIndex = 1;
             this.nextShift.Text = "Work the next shift";
             this.nextShift.UseVisualStyleBackColor = true;
             this.nextShift.Click += new System.EventHandler(this.nextShift_Click);
             // 
             // report
             // 
             this.report.Location = new System.Drawing.Point(13, 113);
             this.report.Multiline = true;
             this.report.Name = "report";
             this.report.Size = new System.Drawing.Size(400, 188);
             this.report.TabIndex = 2;
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(425, 313);
             this.Controls.Add(this.report);
             this.Controls.Add(this.nextShift);
             this.Controls.Add(this.groupBox1);
             this.MaximizeBox = false;
             this.MinimizeBox = false;
             this.Name = "Form1";
             this.Text = "Beehive Management System";
             this.groupBox1.ResumeLayout(false);
             this.groupBox1.PerformLayout();
             ((System.ComponentModel.ISupportInitialize)(this.shifts)).EndInit();
             this.ResumeLayout(false);
             this.PerformLayout();

         }

         #endregion

         private System.Windows.Forms.GroupBox groupBox1;
         private System.Windows.Forms.Button assignJob;
         private System.Windows.Forms.Label label2;
         private System.Windows.Forms.NumericUpDown shifts;
         private System.Windows.Forms.ComboBox workerBeeJob;
         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.Button nextShift;
         private System.Windows.Forms.TextBox report;
     }
 }

