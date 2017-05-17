namespace CekanjeSlobodnogTermina
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
            this.headPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.colorButton = new CekanjeSlobodnogTermina.RoundButton();
            this.headPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.Controls.Add(this.closeButton);
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(400, 40);
            this.headPanel.TabIndex = 0;
            this.headPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImage = global::CekanjeSlobodnogTermina.Properties.Resources.close;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.Location = new System.Drawing.Point(370, 10);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 1;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseHover += new System.EventHandler(this.closeButton_MouseHover);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Carme", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(99, 55);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(202, 24);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "The last available date";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel
            // 
            this.dateLabel.Font = new System.Drawing.Font("Carme", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.White;
            this.dateLabel.Location = new System.Drawing.Point(15, 80);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateLabel.Size = new System.Drawing.Size(370, 80);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "00/00/0000";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Carme", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(49, 160);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(320, 21);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Searching for available appointments.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Transparent;
            this.colorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorButton.BackgroundImage")));
            this.colorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorButton.CornerRadius = 100;
            this.colorButton.Font = new System.Drawing.Font("Carme", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorButton.ForeColor = System.Drawing.Color.White;
            this.colorButton.Location = new System.Drawing.Point(100, 220);
            this.colorButton.Name = "colorButton";
            this.colorButton.RoundCorners = ((CekanjeSlobodnogTermina.Corners)((((CekanjeSlobodnogTermina.Corners.TopLeft | CekanjeSlobodnogTermina.Corners.TopRight) 
            | CekanjeSlobodnogTermina.Corners.BottomLeft) 
            | CekanjeSlobodnogTermina.Corners.BottomRight)));
            this.colorButton.Size = new System.Drawing.Size(200, 40);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "I want another color!";
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.headPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Cekanje Slobodnog Termina";
            this.headPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private RoundButton colorButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.PictureBox closeButton;
    }
}

