namespace SrinivasToolkit
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            //this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            //this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnCanarysPayslip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageImages = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            //this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            //this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            //this.shapeContainer1.Name = "shapeContainer1";
            ////this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            ////this.lineShape1});
            //this.shapeContainer1.Size = new System.Drawing.Size(984, 461);
            //this.shapeContainer1.TabIndex = 1;
            //this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            //this.lineShape1.BorderColor = System.Drawing.Color.DarkRed;
            //this.lineShape1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            //this.lineShape1.Name = "lineShape1";
            //this.lineShape1.SelectionColor = System.Drawing.Color.DarkRed;
            //this.lineShape1.X1 = 8;
            //this.lineShape1.X2 = 961;
            //this.lineShape1.Y1 = 69;
            //this.lineShape1.Y2 = 69;
            // 
            // btnCanarysPayslip
            // 
            this.btnCanarysPayslip.BackColor = System.Drawing.Color.PeachPuff;
            this.btnCanarysPayslip.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanarysPayslip.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCanarysPayslip.Image = global::SrinivasToolkit.Properties.Resources.canarys_logo;
            this.btnCanarysPayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCanarysPayslip.Location = new System.Drawing.Point(233, 115);
            this.btnCanarysPayslip.Name = "btnCanarysPayslip";
            this.btnCanarysPayslip.Size = new System.Drawing.Size(202, 65);
            this.btnCanarysPayslip.TabIndex = 2;
            this.btnCanarysPayslip.Text = "Parse eCanarys Pay-slip";
            this.btnCanarysPayslip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCanarysPayslip.UseVisualStyleBackColor = false;
            this.btnCanarysPayslip.Click += new System.EventHandler(this.btnCanarysPayslip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Srinivas Software Toolkit";
            // 
            // btnManageImages
            // 
            this.btnManageImages.BackColor = System.Drawing.Color.PeachPuff;
            this.btnManageImages.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageImages.ForeColor = System.Drawing.Color.DarkRed;
            this.btnManageImages.Image = global::SrinivasToolkit.Properties.Resources.ManageImages;
            this.btnManageImages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageImages.Location = new System.Drawing.Point(386, 213);
            this.btnManageImages.Name = "btnManageImages";
            this.btnManageImages.Size = new System.Drawing.Size(206, 65);
            this.btnManageImages.TabIndex = 3;
            this.btnManageImages.Text = "Manage Images";
            this.btnManageImages.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageImages.UseVisualStyleBackColor = false;
            this.btnManageImages.Click += new System.EventHandler(this.btnManageImages_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Image = global::SrinivasToolkit.Properties.Resources.CalInterest_64;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(543, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate Interest";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::SrinivasToolkit.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnManageImages);
            this.Controls.Add(this.btnCanarysPayslip);
            this.Controls.Add(this.label1);
            //this.Controls.Add(this.shapeContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Srinivas Software Toolkit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btnCanarysPayslip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageImages;
        private System.Windows.Forms.Button button1;
    }
}

