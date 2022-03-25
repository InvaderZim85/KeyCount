namespace KeyCount.Ui
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxCurrent = new System.Windows.Forms.TextBox();
            this.textBoxPrevious = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelToday = new System.Windows.Forms.Label();
            this.labelPrevious = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonShowData = new System.Windows.Forms.Button();
            this.checkBoxOnTop = new System.Windows.Forms.CheckBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.labelLeastUsedKey = new System.Windows.Forms.Label();
            this.labelMostUsedKey = new System.Windows.Forms.Label();
            this.textBoxLeastUsedKey = new System.Windows.Forms.TextBox();
            this.textBoxMostUsedKey = new System.Windows.Forms.TextBox();
            this.textBoxStatsAverage = new System.Windows.Forms.TextBox();
            this.labelAverage = new System.Windows.Forms.Label();
            this.textBoxStatsMax = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.groupBoxStatistics.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCurrent
            // 
            this.textBoxCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrent.Location = new System.Drawing.Point(67, 22);
            this.textBoxCurrent.Name = "textBoxCurrent";
            this.textBoxCurrent.ReadOnly = true;
            this.textBoxCurrent.Size = new System.Drawing.Size(281, 23);
            this.textBoxCurrent.TabIndex = 0;
            // 
            // textBoxPrevious
            // 
            this.textBoxPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrevious.Location = new System.Drawing.Point(67, 51);
            this.textBoxPrevious.Name = "textBoxPrevious";
            this.textBoxPrevious.ReadOnly = true;
            this.textBoxPrevious.Size = new System.Drawing.Size(281, 23);
            this.textBoxPrevious.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(67, 80);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(281, 23);
            this.progressBar.TabIndex = 2;
            // 
            // labelToday
            // 
            this.labelToday.AutoSize = true;
            this.labelToday.Location = new System.Drawing.Point(20, 25);
            this.labelToday.Name = "labelToday";
            this.labelToday.Size = new System.Drawing.Size(41, 15);
            this.labelToday.TabIndex = 3;
            this.labelToday.Text = "Today:";
            // 
            // labelPrevious
            // 
            this.labelPrevious.AutoSize = true;
            this.labelPrevious.Location = new System.Drawing.Point(6, 54);
            this.labelPrevious.Name = "labelPrevious";
            this.labelPrevious.Size = new System.Drawing.Size(55, 15);
            this.labelPrevious.TabIndex = 4;
            this.labelPrevious.Text = "Previous:";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(6, 83);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(55, 15);
            this.labelProgress.TabIndex = 5;
            this.labelProgress.Text = "Progress:";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(276, 10);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonShowData
            // 
            this.buttonShowData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowData.Location = new System.Drawing.Point(195, 10);
            this.buttonShowData.Name = "buttonShowData";
            this.buttonShowData.Size = new System.Drawing.Size(75, 23);
            this.buttonShowData.TabIndex = 7;
            this.buttonShowData.Text = "Show data";
            this.buttonShowData.UseVisualStyleBackColor = true;
            this.buttonShowData.Click += new System.EventHandler(this.buttonShowData_Click);
            // 
            // checkBoxOnTop
            // 
            this.checkBoxOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxOnTop.AutoSize = true;
            this.checkBoxOnTop.Location = new System.Drawing.Point(3, 13);
            this.checkBoxOnTop.Name = "checkBoxOnTop";
            this.checkBoxOnTop.Size = new System.Drawing.Size(101, 19);
            this.checkBoxOnTop.TabIndex = 8;
            this.checkBoxOnTop.Text = "Always on top";
            this.checkBoxOnTop.UseVisualStyleBackColor = true;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(6, 25);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(97, 15);
            this.labelMax.TabIndex = 9;
            this.labelMax.Text = "Max. key strokes:";
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.labelLeastUsedKey);
            this.groupBoxStatistics.Controls.Add(this.labelMostUsedKey);
            this.groupBoxStatistics.Controls.Add(this.textBoxLeastUsedKey);
            this.groupBoxStatistics.Controls.Add(this.textBoxMostUsedKey);
            this.groupBoxStatistics.Controls.Add(this.textBoxStatsAverage);
            this.groupBoxStatistics.Controls.Add(this.labelAverage);
            this.groupBoxStatistics.Controls.Add(this.textBoxStatsMax);
            this.groupBoxStatistics.Controls.Add(this.labelMax);
            this.groupBoxStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatistics.Location = new System.Drawing.Point(5, 123);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(354, 146);
            this.groupBoxStatistics.TabIndex = 10;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // labelLeastUsedKey
            // 
            this.labelLeastUsedKey.AutoSize = true;
            this.labelLeastUsedKey.Location = new System.Drawing.Point(17, 112);
            this.labelLeastUsedKey.Name = "labelLeastUsedKey";
            this.labelLeastUsedKey.Size = new System.Drawing.Size(86, 15);
            this.labelLeastUsedKey.TabIndex = 16;
            this.labelLeastUsedKey.Text = "Least used key:";
            // 
            // labelMostUsedKey
            // 
            this.labelMostUsedKey.AutoSize = true;
            this.labelMostUsedKey.Location = new System.Drawing.Point(17, 83);
            this.labelMostUsedKey.Name = "labelMostUsedKey";
            this.labelMostUsedKey.Size = new System.Drawing.Size(86, 15);
            this.labelMostUsedKey.TabIndex = 15;
            this.labelMostUsedKey.Text = "Most used key:";
            // 
            // textBoxLeastUsedKey
            // 
            this.textBoxLeastUsedKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLeastUsedKey.Location = new System.Drawing.Point(109, 109);
            this.textBoxLeastUsedKey.Name = "textBoxLeastUsedKey";
            this.textBoxLeastUsedKey.ReadOnly = true;
            this.textBoxLeastUsedKey.Size = new System.Drawing.Size(239, 23);
            this.textBoxLeastUsedKey.TabIndex = 14;
            // 
            // textBoxMostUsedKey
            // 
            this.textBoxMostUsedKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMostUsedKey.Location = new System.Drawing.Point(109, 80);
            this.textBoxMostUsedKey.Name = "textBoxMostUsedKey";
            this.textBoxMostUsedKey.ReadOnly = true;
            this.textBoxMostUsedKey.Size = new System.Drawing.Size(239, 23);
            this.textBoxMostUsedKey.TabIndex = 13;
            // 
            // textBoxStatsAverage
            // 
            this.textBoxStatsAverage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatsAverage.Location = new System.Drawing.Point(109, 51);
            this.textBoxStatsAverage.Name = "textBoxStatsAverage";
            this.textBoxStatsAverage.ReadOnly = true;
            this.textBoxStatsAverage.Size = new System.Drawing.Size(239, 23);
            this.textBoxStatsAverage.TabIndex = 12;
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Location = new System.Drawing.Point(6, 54);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(95, 15);
            this.labelAverage.TabIndex = 11;
            this.labelAverage.Text = "Avg. key strokes:";
            // 
            // textBoxStatsMax
            // 
            this.textBoxStatsMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatsMax.Location = new System.Drawing.Point(109, 22);
            this.textBoxStatsMax.Name = "textBoxStatsMax";
            this.textBoxStatsMax.ReadOnly = true;
            this.textBoxStatsMax.Size = new System.Drawing.Size(239, 23);
            this.textBoxStatsMax.TabIndex = 10;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonExit);
            this.panelBottom.Controls.Add(this.buttonShowData);
            this.panelBottom.Controls.Add(this.checkBoxOnTop);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(5, 269);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(354, 36);
            this.panelBottom.TabIndex = 11;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.textBoxCurrent);
            this.groupBoxData.Controls.Add(this.textBoxPrevious);
            this.groupBoxData.Controls.Add(this.progressBar);
            this.groupBoxData.Controls.Add(this.labelProgress);
            this.groupBoxData.Controls.Add(this.labelToday);
            this.groupBoxData.Controls.Add(this.labelPrevious);
            this.groupBoxData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxData.Location = new System.Drawing.Point(5, 5);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(354, 118);
            this.groupBoxData.TabIndex = 12;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 310);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.panelBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyCount";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCurrent;
        private System.Windows.Forms.TextBox textBoxPrevious;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelToday;
        private System.Windows.Forms.Label labelPrevious;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonShowData;
        private System.Windows.Forms.CheckBox checkBoxOnTop;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.TextBox textBoxStatsAverage;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.TextBox textBoxStatsMax;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Label labelLeastUsedKey;
        private System.Windows.Forms.Label labelMostUsedKey;
        private System.Windows.Forms.TextBox textBoxLeastUsedKey;
        private System.Windows.Forms.TextBox textBoxMostUsedKey;
    }
}