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
            this.trainButton = new System.Windows.Forms.Button();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.numberOfIterationTextBox = new System.Windows.Forms.TextBox();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.iterationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabMenu.SuspendLayout();
            this.trainingPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.trainingPage);
            this.tabMenu.Controls.Add(this.tabPage2);
            this.tabMenu.Location = new System.Drawing.Point(2, 3);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(850, 660);
            this.tabMenu.TabIndex = 0;
            // 
            // trainingPage
            // 
            this.trainingPage.Controls.Add(this.pathLabel);
            this.trainingPage.Controls.Add(this.trainingDataView);
            this.trainingPage.Controls.Add(this.trainButton);
            this.trainingPage.Controls.Add(this.iterationLabel);
            this.trainingPage.Controls.Add(this.numberOfIterationTextBox);
            this.trainingPage.Controls.Add(this.selectPathButton);
            this.trainingPage.Location = new System.Drawing.Point(4, 25);
            this.trainingPage.Margin = new System.Windows.Forms.Padding(0);
            this.trainingPage.Name = "trainingPage";
            this.trainingPage.Size = new System.Drawing.Size(842, 631);
            this.trainingPage.TabIndex = 0;
            this.trainingPage.Text = "Trenowanie";
            this.trainingPage.UseVisualStyleBackColor = true;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(337, 23);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(65, 17);
            this.pathLabel.TabIndex = 5;
            this.pathLabel.Text = "Ścieżka: ";
            // 
            // trainingDataView
            // 
            this.trainingDataView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.iterationColumn,
            this.errorColumn});
            this.trainingDataView.Location = new System.Drawing.Point(6, 153);
            this.trainingDataView.Name = "trainingDataView";
            this.trainingDataView.Size = new System.Drawing.Size(828, 473);
            this.trainingDataView.TabIndex = 4;
            this.trainingDataView.UseCompatibleStateImageBehavior = false;
            this.trainingDataView.View = System.Windows.Forms.View.Details;
            // 
            // trainButton
            // 
            this.trainButton.Enabled = false;
            this.trainButton.Location = new System.Drawing.Point(20, 117);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(150, 30);
            this.trainButton.TabIndex = 3;
            this.trainButton.Text = "Trenuj";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Location = new System.Drawing.Point(35, 59);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(94, 17);
            this.iterationLabel.TabIndex = 2;
            this.iterationLabel.Text = "Liczba iteracji";
            // 
            // numberOfIterationTextBox
            // 
            this.numberOfIterationTextBox.Location = new System.Drawing.Point(20, 79);
            this.numberOfIterationTextBox.Name = "numberOfIterationTextBox";
            this.numberOfIterationTextBox.Size = new System.Drawing.Size(129, 22);
            this.numberOfIterationTextBox.TabIndex = 1;
            this.numberOfIterationTextBox.Text = "100";
            this.numberOfIterationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfIterationTextBox.TextChanged += new System.EventHandler(this.numberOfIteration_Changed);
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(20, 16);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(300, 30);
            this.selectPathButton.TabIndex = 0;
            this.selectPathButton.Text = "Wybierz ścieżkę z obrazami do nauczania";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(842, 631);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // Neural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 666);
            this.Controls.Add(this.tabMenu);
            this.Name = "Neural";
            this.Text = "Form1";
            this.tabMenu.ResumeLayout(false);
            this.trainingPage.ResumeLayout(false);
            this.trainingPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage trainingPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.TextBox numberOfIterationTextBox;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.ListView trainingDataView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.ColumnHeader iterationColumn;
        private System.Windows.Forms.ColumnHeader errorColumn;
    }
}

