﻿namespace Chapter_2___Program_4
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
             this.changeText = new System.Windows.Forms.Button();
             this.enableCheckbox = new System.Windows.Forms.CheckBox();
             this.labelToChange = new System.Windows.Forms.Label();
             this.SuspendLayout();
             // 
             // changeText
             // 
             this.changeText.Location = new System.Drawing.Point(12, 12);
             this.changeText.Name = "changeText";
             this.changeText.Size = new System.Drawing.Size(169, 23);
             this.changeText.TabIndex = 0;
             this.changeText.Text = "Change the label if checked";
             this.changeText.UseVisualStyleBackColor = true;
             this.changeText.Click += new System.EventHandler(this.changeText_Click);
             // 
             // enableCheckbox
             // 
             this.enableCheckbox.AutoSize = true;
             this.enableCheckbox.Checked = true;
             this.enableCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
             this.enableCheckbox.Location = new System.Drawing.Point(341, 16);
             this.enableCheckbox.Name = "enableCheckbox";
             this.enableCheckbox.Size = new System.Drawing.Size(131, 17);
             this.enableCheckbox.TabIndex = 1;
             this.enableCheckbox.Text = "Enable label changing";
             this.enableCheckbox.UseVisualStyleBackColor = true;
             // 
             // labelToChange
             // 
             this.labelToChange.Location = new System.Drawing.Point(-2, 59);
             this.labelToChange.Name = "labelToChange";
             this.labelToChange.Size = new System.Drawing.Size(489, 23);
             this.labelToChange.TabIndex = 2;
             this.labelToChange.Text = "Press the button to change my text";
             this.labelToChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(484, 91);
             this.Controls.Add(this.labelToChange);
             this.Controls.Add(this.enableCheckbox);
             this.Controls.Add(this.changeText);
             this.Name = "Form1";
             this.Text = "My Desktop App";
             this.ResumeLayout(false);
             this.PerformLayout();

         }

         #endregion

         private System.Windows.Forms.Button changeText;
         private System.Windows.Forms.CheckBox enableCheckbox;
         private System.Windows.Forms.Label labelToChange;
     }
 }