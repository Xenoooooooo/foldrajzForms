
namespace foldrajzForms
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
            this.Elkezdes = new System.Windows.Forms.Button();
            this.Elsooldal = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Elkezdes
            // 
            this.Elkezdes.Location = new System.Drawing.Point(132, 229);
            this.Elkezdes.Name = "Elkezdes";
            this.Elkezdes.Size = new System.Drawing.Size(158, 56);
            this.Elkezdes.TabIndex = 0;
            this.Elkezdes.Text = "Elkezdes";
            this.Elkezdes.UseVisualStyleBackColor = true;
            this.Elkezdes.Click += new System.EventHandler(this.Elkezdes_Click);
            // 
            // Elsooldal
            // 
            this.Elsooldal.Location = new System.Drawing.Point(26, 12);
            this.Elsooldal.Name = "Elsooldal";
            this.Elsooldal.Size = new System.Drawing.Size(360, 211);
            this.Elsooldal.TabIndex = 1;
            this.Elsooldal.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 330);
            this.Controls.Add(this.Elsooldal);
            this.Controls.Add(this.Elkezdes);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Elkezdes;
        private System.Windows.Forms.RichTextBox Elsooldal;
    }
}

