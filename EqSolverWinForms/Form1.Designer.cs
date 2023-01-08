namespace EqSolverWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nouTextBox = new System.Windows.Forms.TextBox();
            this.confirmnouButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // nouTextBox
            // 
            this.nouTextBox.Location = new System.Drawing.Point(12, 12);
            this.nouTextBox.Name = "nouTextBox";
            this.nouTextBox.Size = new System.Drawing.Size(160, 27);
            this.nouTextBox.TabIndex = 0;
            this.nouTextBox.Text = "Number of Unknowns";
            // 
            // confirmnouButton
            // 
            this.confirmnouButton.Location = new System.Drawing.Point(178, 12);
            this.confirmnouButton.Name = "confirmnouButton";
            this.confirmnouButton.Size = new System.Drawing.Size(94, 29);
            this.confirmnouButton.TabIndex = 1;
            this.confirmnouButton.Text = "Confirm";
            this.confirmnouButton.UseVisualStyleBackColor = true;
            this.confirmnouButton.Click += new System.EventHandler(this.confirmnouButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 391);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirmnouButton);
            this.Controls.Add(this.nouTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox nouTextBox;
        private Button confirmnouButton;
        private Panel panel1;
    }
}