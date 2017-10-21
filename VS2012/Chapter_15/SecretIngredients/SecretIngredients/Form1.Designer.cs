namespace SecretIngredients
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
            this.getSuzanne = new System.Windows.Forms.Button();
            this.getAmy = new System.Windows.Forms.Button();
            this.useIngredient = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            this.SuspendLayout();
            // 
            // getSuzanne
            // 
            this.getSuzanne.Location = new System.Drawing.Point(22, 60);
            this.getSuzanne.Name = "getSuzanne";
            this.getSuzanne.Size = new System.Drawing.Size(288, 42);
            this.getSuzanne.TabIndex = 0;
            this.getSuzanne.Text = "Get Suzanne\'s delegate";
            this.getSuzanne.UseVisualStyleBackColor = true;
            this.getSuzanne.Click += new System.EventHandler(this.getSuzanne_Click);
            // 
            // getAmy
            // 
            this.getAmy.Location = new System.Drawing.Point(22, 108);
            this.getAmy.Name = "getAmy";
            this.getAmy.Size = new System.Drawing.Size(288, 42);
            this.getAmy.TabIndex = 1;
            this.getAmy.Text = "Get Amy\'s delegate";
            this.getAmy.UseVisualStyleBackColor = true;
            this.getAmy.Click += new System.EventHandler(this.getAmy_Click);
            // 
            // useIngredient
            // 
            this.useIngredient.Location = new System.Drawing.Point(22, 12);
            this.useIngredient.Name = "useIngredient";
            this.useIngredient.Size = new System.Drawing.Size(221, 42);
            this.useIngredient.TabIndex = 2;
            this.useIngredient.Text = "Get the ingredient";
            this.useIngredient.UseVisualStyleBackColor = true;
            this.useIngredient.Click += new System.EventHandler(this.useIngredient_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(249, 12);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(61, 31);
            this.amount.TabIndex = 3;
            this.amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 195);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.useIngredient);
            this.Controls.Add(this.getAmy);
            this.Controls.Add(this.getSuzanne);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Secret Ingredients";
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getSuzanne;
        private System.Windows.Forms.Button getAmy;
        private System.Windows.Forms.Button useIngredient;
        private System.Windows.Forms.NumericUpDown amount;
    }
}

