namespace RpiCar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOverview = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.tabPageFrontCamera = new System.Windows.Forms.TabPage();
            this.pictureBoxFrontCamera = new System.Windows.Forms.PictureBox();
            this.tabPageRearCamera = new System.Windows.Forms.TabPage();
            this.pictureBoxRearCamera = new System.Windows.Forms.PictureBox();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.timerVideoFeed = new System.Windows.Forms.Timer(this.components);
            this.timerInformation = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGearUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.timerDetections = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabPageOverview.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.tabPageFrontCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrontCamera)).BeginInit();
            this.tabPageRearCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRearCamera)).BeginInit();
            this.tabPageLog.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOverview);
            this.tabControl.Controls.Add(this.tabPageFrontCamera);
            this.tabControl.Controls.Add(this.tabPageRearCamera);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(881, 469);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageOverview
            // 
            this.tabPageOverview.Controls.Add(this.tableLayoutPanel1);
            this.tabPageOverview.Controls.Add(this.pictureBoxMain);
            this.tabPageOverview.Location = new System.Drawing.Point(4, 25);
            this.tabPageOverview.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOverview.Name = "tabPageOverview";
            this.tabPageOverview.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageOverview.Size = new System.Drawing.Size(873, 440);
            this.tabPageOverview.TabIndex = 0;
            this.tabPageOverview.Text = "Overview";
            this.tabPageOverview.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxRight, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 432);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeft.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(426, 426);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRight.Location = new System.Drawing.Point(435, 3);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(427, 426);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRight.TabIndex = 1;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(865, 432);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            // 
            // tabPageFrontCamera
            // 
            this.tabPageFrontCamera.Controls.Add(this.pictureBoxFrontCamera);
            this.tabPageFrontCamera.Location = new System.Drawing.Point(4, 25);
            this.tabPageFrontCamera.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageFrontCamera.Name = "tabPageFrontCamera";
            this.tabPageFrontCamera.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageFrontCamera.Size = new System.Drawing.Size(873, 440);
            this.tabPageFrontCamera.TabIndex = 1;
            this.tabPageFrontCamera.Text = "Front camera";
            this.tabPageFrontCamera.UseVisualStyleBackColor = true;
            // 
            // pictureBoxFrontCamera
            // 
            this.pictureBoxFrontCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxFrontCamera.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxFrontCamera.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxFrontCamera.Name = "pictureBoxFrontCamera";
            this.pictureBoxFrontCamera.Size = new System.Drawing.Size(865, 432);
            this.pictureBoxFrontCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFrontCamera.TabIndex = 0;
            this.pictureBoxFrontCamera.TabStop = false;
            this.pictureBoxFrontCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // tabPageRearCamera
            // 
            this.tabPageRearCamera.Controls.Add(this.pictureBoxRearCamera);
            this.tabPageRearCamera.Location = new System.Drawing.Point(4, 25);
            this.tabPageRearCamera.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageRearCamera.Name = "tabPageRearCamera";
            this.tabPageRearCamera.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageRearCamera.Size = new System.Drawing.Size(873, 440);
            this.tabPageRearCamera.TabIndex = 2;
            this.tabPageRearCamera.Text = "Rear camera";
            this.tabPageRearCamera.UseVisualStyleBackColor = true;
            // 
            // pictureBoxRearCamera
            // 
            this.pictureBoxRearCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRearCamera.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxRearCamera.Name = "pictureBoxRearCamera";
            this.pictureBoxRearCamera.Size = new System.Drawing.Size(865, 432);
            this.pictureBoxRearCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRearCamera.TabIndex = 0;
            this.pictureBoxRearCamera.TabStop = false;
            this.pictureBoxRearCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.richTextBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 25);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageLog.Size = new System.Drawing.Size(873, 440);
            this.tabPageLog.TabIndex = 4;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.DetectUrls = false;
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(4, 4);
            this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(865, 432);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // timerVideoFeed
            // 
            this.timerVideoFeed.Interval = 20;
            this.timerVideoFeed.Tick += new System.EventHandler(this.TimerVideoFeed_Tick);
            // 
            // timerInformation
            // 
            this.timerInformation.Interval = 200;
            this.timerInformation.Tick += new System.EventHandler(this.TimerInformation_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButtonReset,
            this.toolStripButtonGearUp,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(881, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 24);
            this.toolStripButton1.Text = "Play";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(114, 24);
            this.toolStripButton3.Text = "Switch cams";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // toolStripButtonReset
            // 
            this.toolStripButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReset.Image")));
            this.toolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReset.Name = "toolStripButtonReset";
            this.toolStripButtonReset.Size = new System.Drawing.Size(69, 24);
            this.toolStripButtonReset.Text = "Reset";
            this.toolStripButtonReset.Click += new System.EventHandler(this.ToolStripButtonReset_Click);
            // 
            // toolStripButtonGearUp
            // 
            this.toolStripButtonGearUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGearUp.Image")));
            this.toolStripButtonGearUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGearUp.Name = "toolStripButtonGearUp";
            this.toolStripButtonGearUp.Size = new System.Drawing.Size(85, 24);
            this.toolStripButtonGearUp.Text = "Gear up";
            this.toolStripButtonGearUp.Click += new System.EventHandler(this.ToolStripButtonGearUp_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(105, 24);
            this.toolStripButton4.Text = "Gear down";
            this.toolStripButton4.Click += new System.EventHandler(this.ToolStripButton4_Click);
            // 
            // timerDetections
            // 
            this.timerDetections.Interval = 500;
            this.timerDetections.Tick += new System.EventHandler(this.TimerDetections_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 496);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "RpiCar";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabPageOverview.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.tabPageFrontCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrontCamera)).EndInit();
            this.tabPageRearCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRearCamera)).EndInit();
            this.tabPageLog.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOverview;
        private System.Windows.Forms.TabPage tabPageFrontCamera;
        private System.Windows.Forms.TabPage tabPageRearCamera;
        private System.Windows.Forms.PictureBox pictureBoxFrontCamera;
        private System.Windows.Forms.Timer timerVideoFeed;
        private System.Windows.Forms.Timer timerInformation;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButtonReset;
        private System.Windows.Forms.ToolStripButton toolStripButtonGearUp;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Timer timerDetections;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxRearCamera;
    }
}

