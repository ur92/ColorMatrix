namespace ColorMatrix
{
    partial class ProcessWindow
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
            this.imgResult = new System.Windows.Forms.PictureBox();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.btnFullScr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // imgResult
            // 
            this.imgResult.Location = new System.Drawing.Point(130, 0);
            this.imgResult.Name = "imgResult";
            this.imgResult.Size = new System.Drawing.Size(861, 714);
            this.imgResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgResult.TabIndex = 11;
            this.imgResult.TabStop = false;
            // 
            // txtPreview
            // 
            this.txtPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPreview.Location = new System.Drawing.Point(0, 0);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.Size = new System.Drawing.Size(100, 714);
            this.txtPreview.TabIndex = 12;
            // 
            // btnFullScr
            // 
            this.btnFullScr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFullScr.Location = new System.Drawing.Point(12, 660);
            this.btnFullScr.Name = "btnFullScr";
            this.btnFullScr.Size = new System.Drawing.Size(75, 42);
            this.btnFullScr.TabIndex = 13;
            this.btnFullScr.Text = "launch full screen";
            this.btnFullScr.UseVisualStyleBackColor = true;
            this.btnFullScr.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProcessWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(999, 714);
            this.Controls.Add(this.btnFullScr);
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.imgResult);
            this.DoubleBuffered = true;
            this.Name = "ProcessWindow";
            this.Text = "ProcessWindow";
            this.ResizeEnd += new System.EventHandler(this.ProcessWindow_ResizeEnd);
            this.ClientSizeChanged += new System.EventHandler(this.ProcessWindow_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProcessWindow_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.imgResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgResult;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.Button btnFullScr;
    }
}