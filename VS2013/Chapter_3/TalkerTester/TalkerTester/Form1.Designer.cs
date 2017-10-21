﻿namespace TalkerTester
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
             this.textBox1 = new System.Windows.Forms.TextBox();
             this.label1 = new System.Windows.Forms.Label();
             this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
             this.label2 = new System.Windows.Forms.Label();
             this.button1 = new System.Windows.Forms.Button();
             ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
             this.SuspendLayout();
             // 
             // textBox1
             // 
             this.textBox1.Location = new System.Drawing.Point(74, 6);
             this.textBox1.Name = "textBox1";
             this.textBox1.Size = new System.Drawing.Size(221, 20);
             this.textBox1.TabIndex = 0;
             this.textBox1.Text = "Hello!";
             // 
             // label1
             // 
             this.label1.AutoSize = true;
             this.label1.Location = new System.Drawing.Point(12, 9);
             this.label1.Name = "label1";
             this.label1.Size = new System.Drawing.Size(47, 13);
             this.label1.TabIndex = 1;
             this.label1.Text = "Say this:";
             // 
             // numericUpDown1
             // 
             this.numericUpDown1.Location = new System.Drawing.Point(74, 32);
             this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
             this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
             this.numericUpDown1.Name = "numericUpDown1";
             this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
             this.numericUpDown1.TabIndex = 2;
             this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
             // 
             // label2
             // 
             this.label2.AutoSize = true;
             this.label2.Location = new System.Drawing.Point(12, 34);
             this.label2.Name = "label2";
             this.label2.Size = new System.Drawing.Size(56, 13);
             this.label2.TabIndex = 3;
             this.label2.Text = "# of times:";
             // 
             // button1
             // 
             this.button1.Location = new System.Drawing.Point(74, 58);
             this.button1.Name = "button1";
             this.button1.Size = new System.Drawing.Size(168, 23);
             this.button1.TabIndex = 4;
             this.button1.Text = "Speak to me!";
             this.button1.UseVisualStyleBackColor = true;
             this.button1.Click += new System.EventHandler(this.button1_Click);
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(307, 92);
             this.Controls.Add(this.button1);
             this.Controls.Add(this.label2);
             this.Controls.Add(this.numericUpDown1);
             this.Controls.Add(this.label1);
             this.Controls.Add(this.textBox1);
             this.MaximizeBox = false;
             this.MinimizeBox = false;
             this.Name = "Form1";
             this.Text = "Talker Tester";
             ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
             this.ResumeLayout(false);
             this.PerformLayout();

         }

         #endregion

         private System.Windows.Forms.TextBox textBox1;
         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.NumericUpDown numericUpDown1;
         private System.Windows.Forms.Label label2;
         private System.Windows.Forms.Button button1;
     }
 }
