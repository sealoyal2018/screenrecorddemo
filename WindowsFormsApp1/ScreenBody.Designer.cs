namespace WindowsFormsApp1
{
    partial class ScreenBody
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
            this.SuspendLayout();
            // 
            // ScreenBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenBody";
            this.Text = "ScreenBody";
            this.Load += new System.EventHandler(this.ScreenBody_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScreenBody_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenBody_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenBody_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenBody_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}