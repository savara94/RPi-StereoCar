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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOverview = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLeftMosaicCamera = new System.Windows.Forms.PictureBox();
            this.pictureBoxRightMosaicCamera = new System.Windows.Forms.PictureBox();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.tabPageLeftCamera = new System.Windows.Forms.TabPage();
            this.pictureBoxLeftCamera = new System.Windows.Forms.PictureBox();
            this.tabPageRightCamera = new System.Windows.Forms.TabPage();
            this.pictureBoxRightCamera = new System.Windows.Forms.PictureBox();
            this.tabPageTopView = new System.Windows.Forms.TabPage();
            this.chartTopView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerVideoFeedLeft = new System.Windows.Forms.Timer(this.components);
            this.timerInformation = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGearUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.timerDetections = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRearDistance = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLeftLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRightLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelGear = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerVideoFeedRight = new System.Windows.Forms.Timer(this.components);
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabControl.SuspendLayout();
            this.tabPageOverview.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftMosaicCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightMosaicCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.tabPageLeftCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftCamera)).BeginInit();
            this.tabPageRightCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightCamera)).BeginInit();
            this.tabPageTopView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOverview);
            this.tabControl.Controls.Add(this.tabPageLeftCamera);
            this.tabControl.Controls.Add(this.tabPageRightCamera);
            this.tabControl.Controls.Add(this.tabPageTopView);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(881, 439);
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
            this.tabPageOverview.Size = new System.Drawing.Size(873, 410);
            this.tabPageOverview.TabIndex = 0;
            this.tabPageOverview.Text = "Overview";
            this.tabPageOverview.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxLeftMosaicCamera, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxRightMosaicCamera, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 402);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBoxLeftMosaicCamera
            // 
            this.pictureBoxLeftMosaicCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeftMosaicCamera.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLeftMosaicCamera.Name = "pictureBoxLeftMosaicCamera";
            this.pictureBoxLeftMosaicCamera.Size = new System.Drawing.Size(426, 396);
            this.pictureBoxLeftMosaicCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeftMosaicCamera.TabIndex = 0;
            this.pictureBoxLeftMosaicCamera.TabStop = false;
            this.pictureBoxLeftMosaicCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // pictureBoxRightMosaicCamera
            // 
            this.pictureBoxRightMosaicCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRightMosaicCamera.Location = new System.Drawing.Point(435, 3);
            this.pictureBoxRightMosaicCamera.Name = "pictureBoxRightMosaicCamera";
            this.pictureBoxRightMosaicCamera.Size = new System.Drawing.Size(427, 396);
            this.pictureBoxRightMosaicCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRightMosaicCamera.TabIndex = 1;
            this.pictureBoxRightMosaicCamera.TabStop = false;
            this.pictureBoxRightMosaicCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(865, 402);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            // 
            // tabPageLeftCamera
            // 
            this.tabPageLeftCamera.Controls.Add(this.pictureBoxLeftCamera);
            this.tabPageLeftCamera.Location = new System.Drawing.Point(4, 25);
            this.tabPageLeftCamera.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageLeftCamera.Name = "tabPageLeftCamera";
            this.tabPageLeftCamera.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageLeftCamera.Size = new System.Drawing.Size(873, 440);
            this.tabPageLeftCamera.TabIndex = 1;
            this.tabPageLeftCamera.Text = "Left camera";
            this.tabPageLeftCamera.UseVisualStyleBackColor = true;
            // 
            // pictureBoxLeftCamera
            // 
            this.pictureBoxLeftCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeftCamera.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxLeftCamera.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxLeftCamera.Name = "pictureBoxLeftCamera";
            this.pictureBoxLeftCamera.Size = new System.Drawing.Size(865, 432);
            this.pictureBoxLeftCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeftCamera.TabIndex = 0;
            this.pictureBoxLeftCamera.TabStop = false;
            this.pictureBoxLeftCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // tabPageRightCamera
            // 
            this.tabPageRightCamera.Controls.Add(this.pictureBoxRightCamera);
            this.tabPageRightCamera.Location = new System.Drawing.Point(4, 25);
            this.tabPageRightCamera.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageRightCamera.Name = "tabPageRightCamera";
            this.tabPageRightCamera.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageRightCamera.Size = new System.Drawing.Size(873, 440);
            this.tabPageRightCamera.TabIndex = 2;
            this.tabPageRightCamera.Text = "Right camera";
            this.tabPageRightCamera.UseVisualStyleBackColor = true;
            // 
            // pictureBoxRightCamera
            // 
            this.pictureBoxRightCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRightCamera.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxRightCamera.Name = "pictureBoxRightCamera";
            this.pictureBoxRightCamera.Size = new System.Drawing.Size(865, 432);
            this.pictureBoxRightCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRightCamera.TabIndex = 0;
            this.pictureBoxRightCamera.TabStop = false;
            this.pictureBoxRightCamera.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // tabPageTopView
            // 
            this.tabPageTopView.Controls.Add(this.chartTopView);
            this.tabPageTopView.Location = new System.Drawing.Point(4, 25);
            this.tabPageTopView.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTopView.Name = "tabPageTopView";
            this.tabPageTopView.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTopView.Size = new System.Drawing.Size(873, 440);
            this.tabPageTopView.TabIndex = 4;
            this.tabPageTopView.Text = "Top View";
            this.tabPageTopView.UseVisualStyleBackColor = true;
            // 
            // chartTopView
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTopView.ChartAreas.Add(chartArea2);
            this.chartTopView.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartTopView.Legends.Add(legend2);
            this.chartTopView.Location = new System.Drawing.Point(4, 4);
            this.chartTopView.Name = "chartTopView";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.Name = "Signs";
            this.chartTopView.Series.Add(series2);
            this.chartTopView.Size = new System.Drawing.Size(865, 432);
            this.chartTopView.TabIndex = 2;
            this.chartTopView.Text = "chart1";
            // 
            // timerVideoFeedLeft
            // 
            this.timerVideoFeedLeft.Interval = 15;
            this.timerVideoFeedLeft.Tag = "0";
            this.timerVideoFeedLeft.Tick += new System.EventHandler(this.TimerVideoFeed_Tick);
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
            this.toolStripButton4,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(881, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::RpiCar.Properties.Resources.play_flat;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 24);
            this.toolStripButton1.Text = "Play";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::RpiCar.Properties.Resources.switch_flip_512;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(114, 24);
            this.toolStripButton3.Text = "Switch cams";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // toolStripButtonReset
            // 
            this.toolStripButtonReset.Image = global::RpiCar.Properties.Resources.reset_hover_1303831;
            this.toolStripButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReset.Name = "toolStripButtonReset";
            this.toolStripButtonReset.Size = new System.Drawing.Size(69, 24);
            this.toolStripButtonReset.Text = "Reset";
            this.toolStripButtonReset.Click += new System.EventHandler(this.ToolStripButtonReset_Click);
            // 
            // toolStripButtonGearUp
            // 
            this.toolStripButtonGearUp.Image = global::RpiCar.Properties.Resources._24215;
            this.toolStripButtonGearUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGearUp.Name = "toolStripButtonGearUp";
            this.toolStripButtonGearUp.Size = new System.Drawing.Size(85, 24);
            this.toolStripButtonGearUp.Text = "Gear up";
            this.toolStripButtonGearUp.Click += new System.EventHandler(this.ToolStripButtonGearUp_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::RpiCar.Properties.Resources.down;
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
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRearDistance,
            this.toolStripStatusLabelLeftLine,
            this.toolStripStatusLabelRightLine,
            this.toolStripStatusLabelGear});
            this.statusStrip1.Location = new System.Drawing.Point(0, 466);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(881, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRearDistance
            // 
            this.toolStripStatusLabelRearDistance.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelRearDistance.Name = "toolStripStatusLabelRearDistance";
            this.toolStripStatusLabelRearDistance.Size = new System.Drawing.Size(176, 24);
            this.toolStripStatusLabelRearDistance.Text = "Rear clearance: 00.00 cm";
            // 
            // toolStripStatusLabelLeftLine
            // 
            this.toolStripStatusLabelLeftLine.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelLeftLine.Name = "toolStripStatusLabelLeftLine";
            this.toolStripStatusLabelLeftLine.Size = new System.Drawing.Size(108, 24);
            this.toolStripStatusLabelLeftLine.Text = "Left line: Black";
            // 
            // toolStripStatusLabelRightLine
            // 
            this.toolStripStatusLabelRightLine.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelRightLine.Name = "toolStripStatusLabelRightLine";
            this.toolStripStatusLabelRightLine.Size = new System.Drawing.Size(118, 24);
            this.toolStripStatusLabelRightLine.Text = "Right line: Black";
            // 
            // toolStripStatusLabelGear
            // 
            this.toolStripStatusLabelGear.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelGear.Name = "toolStripStatusLabelGear";
            this.toolStripStatusLabelGear.Size = new System.Drawing.Size(59, 24);
            this.toolStripStatusLabelGear.Text = "Gear: 0";
            // 
            // timerVideoFeedRight
            // 
            this.timerVideoFeedRight.Interval = 15;
            this.timerVideoFeedRight.Tag = "1";
            this.timerVideoFeedRight.Tick += new System.EventHandler(this.TimerVideoFeed_Tick);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(117, 24);
            this.toolStripButton2.Text = "Line tracking";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 496);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftMosaicCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightMosaicCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.tabPageLeftCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftCamera)).EndInit();
            this.tabPageRightCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightCamera)).EndInit();
            this.tabPageTopView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOverview;
        private System.Windows.Forms.TabPage tabPageLeftCamera;
        private System.Windows.Forms.TabPage tabPageRightCamera;
        private System.Windows.Forms.PictureBox pictureBoxLeftCamera;
        private System.Windows.Forms.Timer timerVideoFeedLeft;
        private System.Windows.Forms.Timer timerInformation;
        private System.Windows.Forms.TabPage tabPageTopView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButtonReset;
        private System.Windows.Forms.ToolStripButton toolStripButtonGearUp;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Timer timerDetections;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxLeftMosaicCamera;
        private System.Windows.Forms.PictureBox pictureBoxRightMosaicCamera;
        private System.Windows.Forms.PictureBox pictureBoxRightCamera;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRearDistance;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLeftLine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRightLine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGear;
        private System.Windows.Forms.Timer timerVideoFeedRight;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

