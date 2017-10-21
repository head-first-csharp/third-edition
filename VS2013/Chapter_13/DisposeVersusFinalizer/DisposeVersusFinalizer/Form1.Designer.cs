namespace DisposeVersusFinalizer
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
            this.clone1 = new System.Windows.Forms.Button();
            this.clone2 = new System.Windows.Forms.Button();
            this.gc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clone1
            // 
            this.clone1.Location = new System.Drawing.Point(12, 12);
            this.clone1.Name = "clone1";
            this.clone1.Size = new System.Drawing.Size(75, 23);
            this.clone1.TabIndex = 0;
            this.clone1.Text = "Clone #1";
            this.clone1.UseVisualStyleBackColor = true;
            this.clone1.Click += new System.EventHandler(this.clone1_Click);
            // 
            // clone2
            // 
            this.clone2.Location = new System.Drawing.Point(12, 41);
            this.clone2.Name = "clone2";
            this.clone2.Size = new System.Drawing.Size(75, 23);
            this.clone2.TabIndex = 1;
            this.clone2.Text = "Clone #2";
            this.clone2.UseVisualStyleBackColor = true;
            this.clone2.Click += new System.EventHandler(this.clone2_Click);
            // 
            // gc
            // 
            this.gc.Location = new System.Drawing.Point(12, 70);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(75, 23);
            this.gc.TabIndex = 2;
            this.gc.Text = "GC";
            this.gc.UseVisualStyleBackColor = true;
            this.gc.Click += new System.EventHandler(this.gc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 105);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.clone2);
            this.Controls.Add(this.clone1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Clones";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clone1;
        private System.Windows.Forms.Button clone2;
        private System.Windows.Forms.Button gc;
    }
}

