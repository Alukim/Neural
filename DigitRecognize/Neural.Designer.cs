namespace RozpoznawaniePisma
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
            this.tabMenu.Location = new System.Drawing.Point(2, 2);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(638, 554);
            this.tabMenu.TabIndex = 0;
            // 
            // trainingPage
            // 
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
            this.trainingPage.Location = new System.Drawing.Point(4, 22);
            this.trainingPage.Margin = new System.Windows.Forms.Padding(0);
            this.trainingPage.Name = "trainingPage";
            this.trainingPage.Size = new System.Drawing.Size(630, 528);
            this.trainingPage.TabIndex = 0;
            this.trainingPage.Text = "Training";
            this.trainingPage.UseVisualStyleBackColor = true;
            // 
            // PhotoCountLabel
            // 
            this.PhotoCountLabel.AutoSize = true;
            this.PhotoCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PhotoCountLabel.Location = new System.Drawing.Point(359, 452);
            this.PhotoCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhotoCountLabel.Name = "PhotoCountLabel";
            this.PhotoCountLabel.Size = new System.Drawing.Size(193, 20);
            this.PhotoCountLabel.TabIndex = 13;
            this.PhotoCountLabel.Text = "Which photo in the epoch:";
            // 
            // trainingProgressBar
            // 
            this.trainingProgressBar.Location = new System.Drawing.Point(7, 491);
            this.trainingProgressBar.Name = "trainingProgressBar";
            this.trainingProgressBar.Size = new System.Drawing.Size(591, 27);
            this.trainingProgressBar.TabIndex = 12;
            // 
            // learningRateRatioTrackBar
            // 
            this.learningRateRatioTrackBar.Location = new System.Drawing.Point(357, 279);
            this.learningRateRatioTrackBar.Maximum = 100;
            this.learningRateRatioTrackBar.Name = "learningRateRatioTrackBar";
            this.learningRateRatioTrackBar.Size = new System.Drawing.Size(270, 45);
            this.learningRateRatioTrackBar.TabIndex = 11;
            this.learningRateRatioTrackBar.TickFrequency = 5;
            this.learningRateRatioTrackBar.Value = 1;
            this.learningRateRatioTrackBar.Scroll += new System.EventHandler(this.learningRateRatioTrackBar_Scroll);
            // 
            // learningRateRatio
            // 
            this.learningRateRatio.AutoSize = true;
            this.learningRateRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.learningRateRatio.Location = new System.Drawing.Point(434, 258);
            this.learningRateRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.learningRateRatio.Name = "learningRateRatio";
            this.learningRateRatio.Size = new System.Drawing.Size(125, 17);
            this.learningRateRatio.TabIndex = 10;
            this.learningRateRatio.Text = "Learning rate ratio";
            // 
            // betaRatioTrackBar
            // 
            this.betaRatioTrackBar.Location = new System.Drawing.Point(357, 178);
            this.betaRatioTrackBar.Maximum = 20;
            this.betaRatioTrackBar.Name = "betaRatioTrackBar";
            this.betaRatioTrackBar.Size = new System.Drawing.Size(270, 45);
            this.betaRatioTrackBar.TabIndex = 9;
            this.betaRatioTrackBar.Scroll += new System.EventHandler(this.betaRatioTrackBar_Scroll);
            // 
            // betaRatio
            // 
            this.betaRatio.AutoSize = true;
            this.betaRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.betaRatio.Location = new System.Drawing.Point(461, 158);
            this.betaRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.betaRatio.Name = "betaRatio";
            this.betaRatio.Size = new System.Drawing.Size(69, 17);
            this.betaRatio.TabIndex = 8;
            this.betaRatio.Text = "Beta ratio";
            // 
            // iterationTrackBar
            // 
            this.iterationTrackBar.Location = new System.Drawing.Point(357, 77);
            this.iterationTrackBar.Maximum = 100;
            this.iterationTrackBar.Name = "iterationTrackBar";
            this.iterationTrackBar.Size = new System.Drawing.Size(270, 45);
            this.iterationTrackBar.TabIndex = 7;
            this.iterationTrackBar.TickFrequency = 2;
            this.iterationTrackBar.Value = 1;
            this.iterationTrackBar.Scroll += new System.EventHandler(this.iterationTrackBar_Scroll);
            // 
            // PhotoCount
            // 
            this.PhotoCount.AutoSize = true;
            this.PhotoCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.PhotoCount.Location = new System.Drawing.Point(550, 451);
            this.PhotoCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhotoCount.Name = "PhotoCount";
            this.PhotoCount.Size = new System.Drawing.Size(23, 25);
            this.PhotoCount.TabIndex = 6;
            this.PhotoCount.Text = "0";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pathLabel.Location = new System.Drawing.Point(5, 13);
            this.pathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(45, 17);
            this.pathLabel.TabIndex = 5;
            this.pathLabel.Text = "Path: ";
            // 
            // trainingDataView
            // 
            this.trainingDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.iterationColumn,
            this.errorColumn,
            this.effectivenessColumn});
            this.trainingDataView.Location = new System.Drawing.Point(5, 106);
            this.trainingDataView.Margin = new System.Windows.Forms.Padding(2);
            this.trainingDataView.Name = "trainingDataView";
            this.trainingDataView.Size = new System.Drawing.Size(337, 366);
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
            this.trainButton.Location = new System.Drawing.Point(387, 356);
            this.trainButton.Margin = new System.Windows.Forms.Padding(2);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(211, 65);
            this.trainButton.TabIndex = 3;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.iterationLabel.Location = new System.Drawing.Point(426, 57);
            this.iterationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(136, 17);
            this.iterationLabel.TabIndex = 2;
            this.iterationLabel.Text = "Number of iterations";
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(7, 42);
            this.selectPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(264, 50);
            this.selectPathButton.TabIndex = 0;
            this.selectPathButton.Text = "Select the path to the image folder";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // recognizePage
            // 
            this.recognizePage.Controls.Add(this.recognizeProgressBar);
            this.recognizePage.Controls.Add(this.clearButton);
            this.recognizePage.Controls.Add(this.recognizeTextBox);
            this.recognizePage.Controls.Add(this.recognizeButton);
            this.recognizePage.Controls.Add(this.pictureBox);
            this.recognizePage.Controls.Add(this.recogonizeDataView);
            this.recognizePage.Location = new System.Drawing.Point(4, 22);
            this.recognizePage.Margin = new System.Windows.Forms.Padding(2);
            this.recognizePage.Name = "recognizePage";
            this.recognizePage.Padding = new System.Windows.Forms.Padding(2);
            this.recognizePage.Size = new System.Drawing.Size(630, 528);
            this.recognizePage.TabIndex = 1;
            this.recognizePage.Text = "Recognize";
            this.recognizePage.UseVisualStyleBackColor = true;
            // 
            // recognizeProgressBar
            // 
            this.recognizeProgressBar.Location = new System.Drawing.Point(7, 491);
            this.recognizeProgressBar.Maximum = 12;
            this.recognizeProgressBar.Name = "recognizeProgressBar";
            this.recognizeProgressBar.Size = new System.Drawing.Size(614, 32);
            this.recognizeProgressBar.Step = 1;
            this.recognizeProgressBar.TabIndex = 11;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(412, 116);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(70, 24);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // recognizeTextBox
            // 
            this.recognizeTextBox.Location = new System.Drawing.Point(219, 234);
            this.recognizeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.recognizeTextBox.Name = "recognizeTextBox";
            this.recognizeTextBox.Size = new System.Drawing.Size(158, 33);
            this.recognizeTextBox.TabIndex = 9;
            this.recognizeTextBox.Text = "";
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(412, 85);
            this.recognizeButton.Margin = new System.Windows.Forms.Padding(2);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(70, 24);
            this.recognizeButton.TabIndex = 8;
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(196, 18);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 200);
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
            this.recogonizeDataView.Location = new System.Drawing.Point(2, 271);
            this.recogonizeDataView.Margin = new System.Windows.Forms.Padding(2);
            this.recogonizeDataView.Name = "recogonizeDataView";
            this.recogonizeDataView.Size = new System.Drawing.Size(628, 207);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 557);
            this.Controls.Add(this.tabMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Neural";
            this.Text = "DigitRecognize";
            this.Load += new System.EventHandler(this.Neural_Load);
            this.tabMenu.ResumeLayout(false);
            this.trainingPage.ResumeLayout(false);
            this.trainingPage.PerformLayout();
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
        private System.Windows.Forms.ToolTip trackBarToolTip;
    }
}

