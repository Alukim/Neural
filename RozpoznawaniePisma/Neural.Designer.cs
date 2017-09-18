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
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.trainingPage = new System.Windows.Forms.TabPage();
            this.pathLabel = new System.Windows.Forms.Label();
            this.trainingDataView = new System.Windows.Forms.ListView();
            this.iterationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trainButton = new System.Windows.Forms.Button();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.numberOfIterationTextBox = new System.Windows.Forms.TextBox();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.recognizePage = new System.Windows.Forms.TabPage();
            this.clearButton = new System.Windows.Forms.Button();
            this.recognizeTextBox = new System.Windows.Forms.RichTextBox();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.readPicture = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.recogonizeDataView = new System.Windows.Forms.ListView();
            this.exitNeuralHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.iterationsNumber = new System.Windows.Forms.Label();
            this.tabMenu.SuspendLayout();
            this.trainingPage.SuspendLayout();
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
            this.tabMenu.Size = new System.Drawing.Size(957, 825);
            this.tabMenu.TabIndex = 0;
            // 
            // trainingPage
            // 
            this.trainingPage.Controls.Add(this.iterationsNumber);
            this.trainingPage.Controls.Add(this.pathLabel);
            this.trainingPage.Controls.Add(this.trainingDataView);
            this.trainingPage.Controls.Add(this.trainButton);
            this.trainingPage.Controls.Add(this.iterationLabel);
            this.trainingPage.Controls.Add(this.numberOfIterationTextBox);
            this.trainingPage.Controls.Add(this.selectPathButton);
            this.trainingPage.Location = new System.Drawing.Point(4, 29);
            this.trainingPage.Margin = new System.Windows.Forms.Padding(0);
            this.trainingPage.Name = "trainingPage";
            this.trainingPage.Size = new System.Drawing.Size(949, 792);
            this.trainingPage.TabIndex = 0;
            this.trainingPage.Text = "Trenowanie";
            this.trainingPage.UseVisualStyleBackColor = true;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(380, 29);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(73, 20);
            this.pathLabel.TabIndex = 5;
            this.pathLabel.Text = "Ścieżka: ";
            // 
            // trainingDataView
            // 
            this.trainingDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.iterationColumn,
            this.errorColumn});
            this.trainingDataView.Location = new System.Drawing.Point(6, 191);
            this.trainingDataView.Name = "trainingDataView";
            this.trainingDataView.Size = new System.Drawing.Size(931, 590);
            this.trainingDataView.TabIndex = 4;
            this.trainingDataView.UseCompatibleStateImageBehavior = false;
            this.trainingDataView.View = System.Windows.Forms.View.Details;
            // 
            // iterationColumn
            // 
            this.iterationColumn.Text = "Iteracja";
            this.iterationColumn.Width = 155;
            // 
            // errorColumn
            // 
            this.errorColumn.Text = "Błąd";
            this.errorColumn.Width = 146;
            // 
            // trainButton
            // 
            this.trainButton.Enabled = false;
            this.trainButton.Location = new System.Drawing.Point(22, 146);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(168, 37);
            this.trainButton.TabIndex = 3;
            this.trainButton.Text = "Trenuj";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Location = new System.Drawing.Point(39, 74);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(104, 20);
            this.iterationLabel.TabIndex = 2;
            this.iterationLabel.Text = "Liczba iteracji";
            // 
            // numberOfIterationTextBox
            // 
            this.numberOfIterationTextBox.Location = new System.Drawing.Point(22, 98);
            this.numberOfIterationTextBox.Name = "numberOfIterationTextBox";
            this.numberOfIterationTextBox.Size = new System.Drawing.Size(145, 26);
            this.numberOfIterationTextBox.TabIndex = 1;
            this.numberOfIterationTextBox.Text = "100";
            this.numberOfIterationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfIterationTextBox.TextChanged += new System.EventHandler(this.numberOfIteration_Changed);
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(22, 20);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(338, 37);
            this.selectPathButton.TabIndex = 0;
            this.selectPathButton.Text = "Wybierz ścieżkę z obrazami do nauczania";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // recognizePage
            // 
            this.recognizePage.Controls.Add(this.clearButton);
            this.recognizePage.Controls.Add(this.recognizeTextBox);
            this.recognizePage.Controls.Add(this.recognizeButton);
            this.recognizePage.Controls.Add(this.readPicture);
            this.recognizePage.Controls.Add(this.pictureBox);
            this.recognizePage.Controls.Add(this.recogonizeDataView);
            this.recognizePage.Location = new System.Drawing.Point(4, 29);
            this.recognizePage.Name = "recognizePage";
            this.recognizePage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.recognizePage.Size = new System.Drawing.Size(949, 792);
            this.recognizePage.TabIndex = 1;
            this.recognizePage.Text = "Rozpoznawanie";
            this.recognizePage.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(183, 126);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(105, 37);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Wyczyść";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // recognizeTextBox
            // 
            this.recognizeTextBox.Location = new System.Drawing.Point(372, 17);
            this.recognizeTextBox.Name = "recognizeTextBox";
            this.recognizeTextBox.Size = new System.Drawing.Size(235, 49);
            this.recognizeTextBox.TabIndex = 9;
            this.recognizeTextBox.Text = "";
            // 
            // recognizeButton
            // 
            this.recognizeButton.Location = new System.Drawing.Point(183, 78);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(105, 37);
            this.recognizeButton.TabIndex = 8;
            this.recognizeButton.Text = "Rozpoznaj";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // readPicture
            // 
            this.readPicture.Location = new System.Drawing.Point(183, 29);
            this.readPicture.Name = "readPicture";
            this.readPicture.Size = new System.Drawing.Size(105, 37);
            this.readPicture.TabIndex = 7;
            this.readPicture.Text = "Wczytaj obraz";
            this.readPicture.UseVisualStyleBackColor = true;
            this.readPicture.Click += new System.EventHandler(this.readPicture_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(8, 9);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(167, 171);
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
            this.recogonizeDataView.Location = new System.Drawing.Point(3, 194);
            this.recogonizeDataView.Name = "recogonizeDataView";
            this.recogonizeDataView.Size = new System.Drawing.Size(940, 590);
            this.recogonizeDataView.TabIndex = 5;
            this.recogonizeDataView.UseCompatibleStateImageBehavior = false;
            this.recogonizeDataView.View = System.Windows.Forms.View.Details;
            // 
            // exitNeuralHeader
            // 
            this.exitNeuralHeader.Text = "Neuron wyjściowy";
            this.exitNeuralHeader.Width = 155;
            // 
            // valueHeader
            // 
            this.valueHeader.Text = "Wartość";
            this.valueHeader.Width = 146;
            // 
            // fileBrowser
            // 
            this.fileBrowser.FileOk += new System.ComponentModel.CancelEventHandler(this.fileSelected);
            // 
            // iterationsNumber
            // 
            this.iterationsNumber.AutoSize = true;
            this.iterationsNumber.Location = new System.Drawing.Point(236, 104);
            this.iterationsNumber.Name = "iterationsNumber";
            this.iterationsNumber.Size = new System.Drawing.Size(18, 20);
            this.iterationsNumber.TabIndex = 6;
            this.iterationsNumber.Text = "0";
            // 
            // Neural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 832);
            this.Controls.Add(this.tabMenu);
            this.Name = "Neural";
            this.Text = "Form1";
            this.tabMenu.ResumeLayout(false);
            this.trainingPage.ResumeLayout(false);
            this.trainingPage.PerformLayout();
            this.recognizePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage trainingPage;
        private System.Windows.Forms.TabPage recognizePage;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.TextBox numberOfIterationTextBox;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.ListView trainingDataView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.ColumnHeader iterationColumn;
        private System.Windows.Forms.ColumnHeader errorColumn;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.Button readPicture;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListView recogonizeDataView;
        private System.Windows.Forms.ColumnHeader exitNeuralHeader;
        private System.Windows.Forms.ColumnHeader valueHeader;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.RichTextBox recognizeTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label iterationsNumber;
    }
}

