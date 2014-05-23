namespace ColorMatrix
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numRotate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.imgSource = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblNumberOfPoints = new System.Windows.Forms.Label();
            this.lblCanvasSize = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRandomWiki = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnFromUrl = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Create Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSuccess.ForeColor = System.Drawing.Color.Green;
            this.lblSuccess.Location = new System.Drawing.Point(14, 194);
            this.lblSuccess.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(92, 13);
            this.lblSuccess.TabIndex = 2;
            this.lblSuccess.Text = "Image created!";
            this.lblSuccess.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Created by Evgeni D |  Contact me:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(191, 494);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(101, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "ur92.ed@gmail.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numRotate);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(12, 268);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(259, 135);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Colors";
            // 
            // numRotate
            // 
            this.numRotate.Location = new System.Drawing.Point(181, 28);
            this.numRotate.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numRotate.Name = "numRotate";
            this.numRotate.Size = new System.Drawing.Size(66, 20);
            this.numRotate.TabIndex = 5;
            this.numRotate.ValueChanged += new System.EventHandler(this.numCanvasWidth_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rotation fator";
            // 
            // txtExpression
            // 
            this.txtExpression.Location = new System.Drawing.Point(6, 19);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExpression.Size = new System.Drawing.Size(244, 285);
            this.txtExpression.TabIndex = 6;
            this.txtExpression.TextChanged += new System.EventHandler(this.numCanvasWidth_ValueChanged);
            this.txtExpression.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExpression_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenImage);
            this.groupBox2.Controls.Add(this.imgSource);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.lblSuccess);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 250);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read and Create";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(17, 19);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(136, 23);
            this.btnOpenImage.TabIndex = 4;
            this.btnOpenImage.Text = "Open source image";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // imgSource
            // 
            this.imgSource.Location = new System.Drawing.Point(17, 48);
            this.imgSource.Name = "imgSource";
            this.imgSource.Size = new System.Drawing.Size(215, 98);
            this.imgSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgSource.TabIndex = 3;
            this.imgSource.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.txtExpression);
            this.groupBox3.Location = new System.Drawing.Point(277, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 473);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Expression";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Controls.Add(this.lblNumberOfPoints);
            this.groupBox7.Controls.Add(this.lblCanvasSize);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Location = new System.Drawing.Point(6, 311);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(244, 156);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Corrections";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Clear text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblNumberOfPoints
            // 
            this.lblNumberOfPoints.AutoSize = true;
            this.lblNumberOfPoints.Location = new System.Drawing.Point(130, 39);
            this.lblNumberOfPoints.Name = "lblNumberOfPoints";
            this.lblNumberOfPoints.Size = new System.Drawing.Size(28, 13);
            this.lblNumberOfPoints.TabIndex = 0;
            this.lblNumberOfPoints.Text = "XXX";
            // 
            // lblCanvasSize
            // 
            this.lblCanvasSize.AutoSize = true;
            this.lblCanvasSize.Location = new System.Drawing.Point(130, 20);
            this.lblCanvasSize.Name = "lblCanvasSize";
            this.lblCanvasSize.Size = new System.Drawing.Size(59, 13);
            this.lblCanvasSize.TabIndex = 0;
            this.lblCanvasSize.Text = "XXX * XXX";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Number of points:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Canvas size:";
            // 
            // btnRandomWiki
            // 
            this.btnRandomWiki.Location = new System.Drawing.Point(17, 24);
            this.btnRandomWiki.Name = "btnRandomWiki";
            this.btnRandomWiki.Size = new System.Drawing.Size(153, 23);
            this.btnRandomWiki.TabIndex = 8;
            this.btnRandomWiki.Text = "Random Wiki article";
            this.btnRandomWiki.UseVisualStyleBackColor = true;
            this.btnRandomWiki.Click += new System.EventHandler(this.btnRandomWiki_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "URL:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnFromUrl);
            this.groupBox10.Controls.Add(this.txtUrl);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.btnRandomWiki);
            this.groupBox10.Location = new System.Drawing.Point(12, 403);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(259, 82);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Internet source";
            // 
            // btnFromUrl
            // 
            this.btnFromUrl.Location = new System.Drawing.Point(204, 52);
            this.btnFromUrl.Name = "btnFromUrl";
            this.btnFromUrl.Size = new System.Drawing.Size(43, 23);
            this.btnFromUrl.TabIndex = 11;
            this.btnFromUrl.Text = "Go";
            this.btnFromUrl.UseVisualStyleBackColor = true;
            this.btnFromUrl.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(53, 54);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(145, 20);
            this.txtUrl.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Color Matrix v10";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRotate)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblNumberOfPoints;
        private System.Windows.Forms.Label lblCanvasSize;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRandomWiki;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnFromUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.PictureBox imgSource;
        private System.Windows.Forms.NumericUpDown numRotate;
        private System.Windows.Forms.Label label5;
    }
}

