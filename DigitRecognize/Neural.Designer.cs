﻿namespace RozpoznawaniePisma
{
    partial class Neural
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Neural));
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.trainingPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.trainingStateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maximumPhotosNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumNumberOfPhotosLabel = new System.Windows.Forms.Label();
            this.PhotoCountLabel = new System.Windows.Forms.Label();
            this.trainingProgressBar = new System.Windows.Forms.ProgressBar();
            this.learningRateRatioTrackBar = new System.Windows.Forms.TrackBar();
            this.learningRateRatio = new System.Windows.Forms.Label();
            this.betaRatioTrackBar = new System.Windows.Forms.TrackBar();
            this.betaRatio = new System.Windows.Forms.Label();
            this.iterationTrackBar = new System.Windows.Forms.TrackBar();
            this.PhotoCount = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.trainingDataView = new System.Windows.Forms.ListView();
            this.iterationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.effectivenessColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trainButton = new System.Windows.Forms.Button();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.progressPercantegeLabel = new System.Windows.Forms.Label();
            this.recognizePage = new System.Windows.Forms.TabPage();
            this.recognizeProgressBar = new System.Windows.Forms.ProgressBar();
            this.clearButton = new System.Windows.Forms.Button();
            this.recognizeTextBox = new System.Windows.Forms.RichTextBox();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.recogonizeDataView = new System.Windows.Forms.ListView();
            this.exitNeuralHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.trackBarToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabMenu.SuspendLayout();
            this.trainingPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumPhotosNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateRatioTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaRatioTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationTrackBar)).BeginInit();
            this.recognizePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.trainingPage);
            this.tabMenu.Controls.Add(this.recognizePage);
            this.tabMenu.Location = new System.Drawing.Point(3, 3);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(957, 852);
            this.tabMenu.TabIndex = 0;
            // 
            // trainingPage
            // 
            this.trainingPage.Controls.Add(this.label3);
            this.trainingPage.Controls.Add(this.trainingStateLabel);
            this.trainingPage.Controls.Add(this.label1);
            this.trainingPage.Controls.Add(this.label2);
            this.trainingPage.Controls.Add(this.maximumPhotosNumeric);
            this.trainingPage.Controls.Add(this.maximumNumberOfPhotosLabel);
            this.trainingPage.Controls.Add(this.PhotoCountLabel);
            this.trainingPage.Controls.Add(this.trainingProgressBar);
            this.trainingPage.Controls.Add(this.learningRateRatioTrackBar);
            this.trainingPage.Controls.Add(this.learningRateRatio);
            this.trainingPage.Controls.Add(this.betaRatioTrackBar);
            this.trainingPage.Controls.Add(this.betaRatio);
            this.trainingPage.Controls.Add(this.iterationTrackBar);
            this.trainingPage.Controls.Add(this.PhotoCount);
            this.trainingPage.Controls.Add(this.pathLabel);
            this.trainingPage.Controls.Add(this.trainingDataView);
            this.trainingPage.Controls.Add(this.trainButton);
            this.trainingPage.Controls.Add(this.iterationLabel);
            this.trainingPage.Controls.Add(this.selectPathButton);
            this.trainingPage.Controls.Add(this.progressPercantegeLabel);
            this.trainingPage.Location = new System.Drawing.Point(4, 29);
            this.trainingPage.Margin = new System.Windows.Forms.Padding(0);
            this.trainingPage.Name = "trainingPage";
            this.trainingPage.Size = new System.Drawing.Size(949, 819);
            this.trainingPage.TabIndex = 0;
            this.trainingPage.Text = "Training";
            this.trainingPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // trainingStateLabel
            // 
            this.trainingStateLabel.AutoSize = true;
            this.trainingStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.trainingStateLabel.Location = new System.Drawing.Point(722, 695);
            this.trainingStateLabel.Name = "trainingStateLabel";
            this.trainingStateLabel.Size = new System.Drawing.Size(0, 25);
            this.trainingStateLabel.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(547, 695);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Training State:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(740, 695);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 36);
            this.label2.TabIndex = 17;
            // 
            // maximumPhotosNumeric
            // 
            this.maximumPhotosNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.maximumPhotosNumeric.Location = new System.Drawing.Point(659, 405);
            this.maximumPhotosNumeric.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.maximumPhotosNumeric.Name = "maximumPhotosNumeric";
            this.maximumPhotosNumeric.Size = new System.Drawing.Size(160, 37);
            this.maximumPhotosNumeric.TabIndex = 16;
            this.maximumPhotosNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maximumPhotosNumeric.ValueChanged += new System.EventHandler(this.maximumPhotosNumeric_ValueChanged);
            // 
            // maximumNumberOfPhotosLabel
            // 
            this.maximumNumberOfPhotosLabel.AutoSize = true;
            this.maximumNumberOfPhotosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.maximumNumberOfPhotosLabel.Location = new System.Drawing.Point(565, 363);
            this.maximumNumberOfPhotosLabel.Name = "maximumNumberOfPhotosLabel";
            this.maximumNumberOfPhotosLabel.Size = new System.Drawing.Size(348, 25);
            this.maximumNumberOfPhotosLabel.TabIndex = 15;
            this.maximumNumberOfPhotosLabel.Text = "Maximum number of photos for training";
            // 
            // PhotoCountLabel
            // 
            this.PhotoCountLabel.AutoSize = true;
            this.PhotoCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PhotoCountLabel.Location = new System.Drawing.Point(547, 637);
            this.PhotoCountLabel.Name = "PhotoCountLabel";
            this.PhotoCountLabel.Size = new System.Drawing.Size(289, 29);
            this.PhotoCountLabel.TabIndex = 13;
            this.PhotoCountLabel.Text = "Which photo in the epoch:";
            // 
            // trainingProgressBar
            // 
            this.trainingProgressBar.Location = new System.Drawing.Point(10, 755);
            this.trainingProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trainingProgressBar.Name = "trainingProgressBar";
            this.trainingProgressBar.Size = new System.Drawing.Size(870, 42);
            this.trainingProgressBar.TabIndex = 12;
            // 
            // learningRateRatioTrackBar
            // 
            this.learningRateRatioTrackBar.Location = new System.Drawing.Point(536, 275);
            this.learningRateRatioTrackBar.Maximum = 100;
            this.learningRateRatioTrackBar.Name = "learningRateRatioTrackBar";
            this.learningRateRatioTrackBar.Size = new System.Drawing.Size(391, 69);
            this.learningRateRatioTrackBar.TabIndex = 11;
            this.learningRateRatioTrackBar.TickFrequency = 5;
            this.learningRateRatioTrackBar.Value = 15;
            this.learningRateRatioTrackBar.Scroll += new System.EventHandler(this.learningRateRatioTrackBar_Scroll);
            // 
            // learningRateRatio
            // 
            this.learningRateRatio.AutoSize = true;
            this.learningRateRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.learningRateRatio.Location = new System.Drawing.Point(651, 247);
            this.learningRateRatio.Name = "learningRateRatio";
            this.learningRateRatio.Size = new System.Drawing.Size(168, 25);
            this.learningRateRatio.TabIndex = 10;
            this.learningRateRatio.Text = "Learning rate ratio";
            // 
            // betaRatioTrackBar
            // 
            this.betaRatioTrackBar.Location = new System.Drawing.Point(536, 160);
            this.betaRatioTrackBar.Maximum = 20;
            this.betaRatioTrackBar.Name = "betaRatioTrackBar";
            this.betaRatioTrackBar.Size = new System.Drawing.Size(391, 69);
            this.betaRatioTrackBar.TabIndex = 9;
            this.betaRatioTrackBar.TickFrequency = 10;
            this.betaRatioTrackBar.Value = 10;
            this.betaRatioTrackBar.Scroll += new System.EventHandler(this.betaRatioTrackBar_Scroll);
            // 
            // betaRatio
            // 
            this.betaRatio.AutoSize = true;
            this.betaRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.betaRatio.Location = new System.Drawing.Point(692, 132);
            this.betaRatio.Name = "betaRatio";
            this.betaRatio.Size = new System.Drawing.Size(94, 25);
            this.betaRatio.TabIndex = 8;
            this.betaRatio.Text = "Beta ratio";
            // 
            // iterationTrackBar
            // 
            this.iterationTrackBar.Location = new System.Drawing.Point(536, 48);
            this.iterationTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iterationTrackBar.Maximum = 100;
            this.iterationTrackBar.Name = "iterationTrackBar";
            this.iterationTrackBar.Size = new System.Drawing.Size(391, 69);
            this.iterationTrackBar.TabIndex = 7;
            this.iterationTrackBar.TickFrequency = 2;
            this.iterationTrackBar.Value = 10;
            this.iterationTrackBar.Scroll += new System.EventHandler(this.iterationTrackBar_Scroll);
            // 
            // PhotoCount
            // 
            this.PhotoCount.AutoSize = true;
            this.PhotoCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.PhotoCount.Location = new System.Drawing.Point(834, 636);
            this.PhotoCount.Name = "PhotoCount";
            this.PhotoCount.Size = new System.Drawing.Size(32, 36);
            this.PhotoCount.TabIndex = 6;
            this.PhotoCount.Text = "0";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pathLabel.Location = new System.Drawing.Point(8, 20);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(63, 25);
            this.pathLabel.TabIndex = 5;
            this.pathLabel.Text = "Path: ";
            // 
            // trainingDataView
            // 
            this.trainingDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.iterationColumn,
            this.errorColumn,
            this.effectivenessColumn});
            this.trainingDataView.Location = new System.Drawing.Point(8, 163);
            this.trainingDataView.Name = "trainingDataView";
            this.trainingDataView.Size = new System.Drawing.Size(504, 561);
            this.trainingDataView.TabIndex = 4;
            this.trainingDataView.UseCompatibleStateImageBehavior = false;
            this.trainingDataView.View = System.Windows.Forms.View.Details;
            // 
            // iterationColumn
            // 
            this.iterationColumn.Text = "Iteration";
            this.iterationColumn.Width = 97;
            // 
            // errorColumn
            // 
            this.errorColumn.Text = "Error";
            this.errorColumn.Width = 118;
            // 
            // effectivenessColumn
            // 
            this.effectivenessColumn.Text = "Effectivenes";
            this.effectivenessColumn.Width = 116;
            // 
            // trainButton
            // 
            this.trainButton.AutoSize = true;
            this.trainButton.Enabled = false;
            this.trainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.trainButton.Location = new System.Drawing.Point(580, 478);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(316, 100);
            this.trainButton.TabIndex = 3;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iterationLabel.Location = new System.Drawing.Point(639, 18);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(185, 25);
            this.iterationLabel.TabIndex = 2;
            this.iterationLabel.Text = "Number of iterations";
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(10, 65);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(396, 77);
            this.selectPathButton.TabIndex = 0;
            this.selectPathButton.Text = "Select the path to the image folder";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // progressPercantegeLabel
            // 
            this.progressPercantegeLabel.AutoSize = true;
            this.progressPercantegeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPercantegeLabel.Location = new System.Drawing.Point(878, 761);
            this.progressPercantegeLabel.Name = "progressPercantegeLabel";
            this.progressPercantegeLabel.Size = new System.Drawing.Size(48, 29);
            this.progressPercantegeLabel.TabIndex = 20;
            this.progressPercantegeLabel.Text = "0%";
            // 
            // recognizePage
            // 
            this.recognizePage.Controls.Add(this.recognizeProgressBar);
            this.recognizePage.Controls.Add(this.clearButton);
            this.recognizePage.Controls.Add(this.recognizeTextBox);
            this.recognizePage.Controls.Add(this.recognizeButton);
            this.recognizePage.Controls.Add(this.pictureBox);
            this.recognizePage.Controls.Add(this.recogonizeDataView);
            this.recognizePage.Location = new System.Drawing.Point(4, 29);
            this.recognizePage.Name = "recognizePage";
            this.recognizePage.Padding = new System.Windows.Forms.Padding(3);
            this.recognizePage.Size = new System.Drawing.Size(949, 819);
            this.recognizePage.TabIndex = 1;
            this.recognizePage.Text = "Recognize";
            this.recognizePage.UseVisualStyleBackColor = true;
            // 
            // recognizeProgressBar
            // 
            this.recognizeProgressBar.Location = new System.Drawing.Point(10, 755);
            this.recognizeProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recognizeProgressBar.Maximum = 12;
            this.recognizeProgressBar.Name = "recognizeProgressBar";
            this.recognizeProgressBar.Size = new System.Drawing.Size(921, 49);
            this.recognizeProgressBar.Step = 1;
            this.recognizeProgressBar.TabIndex = 11;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(618, 178);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(105, 37);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // recognizeTextBox
            // 
            this.recognizeTextBox.Location = new System.Drawing.Point(328, 360);
            this.recognizeTextBox.Name = "recognizeTextBox";
            this.recognizeTextBox.Size = new System.Drawing.Size(235, 49);
            this.recognizeTextBox.TabIndex = 9;
            this.recognizeTextBox.Text = "";
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(618, 131);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(105, 37);
            this.recognizeButton.TabIndex = 8;
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(294, 28);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(299, 307);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // recogonizeDataView
            // 
            this.recogonizeDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.exitNeuralHeader,
            this.valueHeader});
            this.recogonizeDataView.Location = new System.Drawing.Point(3, 417);
            this.recogonizeDataView.Name = "recogonizeDataView";
            this.recogonizeDataView.Size = new System.Drawing.Size(940, 316);
            this.recogonizeDataView.TabIndex = 5;
            this.recogonizeDataView.UseCompatibleStateImageBehavior = false;
            this.recogonizeDataView.View = System.Windows.Forms.View.Details;
            // 
            // exitNeuralHeader
            // 
            this.exitNeuralHeader.Text = "Value";
            this.exitNeuralHeader.Width = 155;
            // 
            // valueHeader
            // 
            this.valueHeader.Text = "Output";
            this.valueHeader.Width = 146;
            // 
            // fileBrowser
            // 
            this.fileBrowser.FileOk += new System.ComponentModel.CancelEventHandler(this.fileSelected);
            // 
            // Neural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 857);
            this.Controls.Add(this.tabMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Neural";
            this.Text = "DigitRecognize";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Neural_Closed);
            this.Load += new System.EventHandler(this.Neural_Load);
            this.tabMenu.ResumeLayout(false);
            this.trainingPage.ResumeLayout(false);
            this.trainingPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumPhotosNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateRatioTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betaRatioTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationTrackBar)).EndInit();
            this.recognizePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage trainingPage;
        private System.Windows.Forms.TabPage recognizePage;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.ListView trainingDataView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.ColumnHeader iterationColumn;
        private System.Windows.Forms.ColumnHeader errorColumn;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListView recogonizeDataView;
        private System.Windows.Forms.ColumnHeader exitNeuralHeader;
        private System.Windows.Forms.ColumnHeader valueHeader;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.RichTextBox recognizeTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label PhotoCount;
        private System.Windows.Forms.ColumnHeader effectivenessColumn;
        private System.Windows.Forms.TrackBar iterationTrackBar;
        private System.Windows.Forms.Label PhotoCountLabel;
        private System.Windows.Forms.ProgressBar trainingProgressBar;
        private System.Windows.Forms.TrackBar learningRateRatioTrackBar;
        private System.Windows.Forms.Label learningRateRatio;
        private System.Windows.Forms.TrackBar betaRatioTrackBar;
        private System.Windows.Forms.Label betaRatio;
        private System.Windows.Forms.ProgressBar recognizeProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maximumPhotosNumeric;
        private System.Windows.Forms.Label maximumNumberOfPhotosLabel;
        private System.Windows.Forms.ToolTip trackBarToolTip;
        private System.Windows.Forms.Label trainingStateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label progressPercantegeLabel;
    }
}

