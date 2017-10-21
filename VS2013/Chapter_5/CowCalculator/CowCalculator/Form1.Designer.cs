﻿namespace CowCalculator
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
             this.label1 = new System.Windows.Forms.Label();
             this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
             this.calculate = new System.Windows.Forms.Button();
             ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
             this.SuspendLayout();
             // 
             // label1
             // 
             this.label1.AutoSize = true;
             this.label1.Location = new System.Drawing.Point(12, 14);
             this.label1.Name = "label1";
             this.label1.Size = new System.Drawing.Size(33, 13);
             this.label1.TabIndex = 0;
             this.label1.Text = "Cows";
             // 
             // numericUpDown1
             // 
             this.numericUpDown1.Location = new System.Drawing.Point(51, 12);
             this.numericUpDown1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
             this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
             this.numericUpDown1.Name = "numericUpDown1";
             this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
             this.numericUpDown1.TabIndex = 1;
             this.numericUpDown1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
             this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
             // 
             // calculate
             // 
             this.calculate.Location = new System.Drawing.Point(51, 38);
             this.calculate.Name = "calculate";
             this.calculate.Size = new System.Drawing.Size(75, 23);
             this.calculate.TabIndex = 2;
             this.calculate.Text = "Calculate";
             this.calculate.UseVisualStyleBackColor = true;
             this.calculate.Click += new System.EventHandler(this.calculate_Click);
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(221, 69);
             this.Controls.Add(this.calculate);
             this.Controls.Add(this.numericUpDown1);
             this.Controls.Add(this.label1);
             this.MaximizeBox = false;
             this.MinimizeBox = false;
             this.Name = "Form1";
             this.Text = "Cow Calculator";
             ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
             this.ResumeLayout(false);
             this.PerformLayout();

         }

         #endregion

         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.NumericUpDown numericUpDown1;
         private System.Windows.Forms.Button calculate;
     }
 }
