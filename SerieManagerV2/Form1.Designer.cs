namespace SerieManagerV2
{
    partial class SerieManagerV2
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerieManagerV2));
            this.folderBrowserDialog_rename_inputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.button_rename_changeInputFolder = new System.Windows.Forms.Button();
            this.label_rename_inputFolder = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labell_rename_countSelectedTo = new System.Windows.Forms.Label();
            this.label_rename_countSelectedFrom = new System.Windows.Forms.Label();
            this.button_rename_convertFiles = new System.Windows.Forms.Button();
            this.checkedListBox_rename_cleanedFiles = new System.Windows.Forms.CheckedListBox();
            this.listBox_rename_folderFiles = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog_rename_inputFolder
            // 
            this.folderBrowserDialog_rename_inputFolder.SelectedPath = "C:\\Users\\Maf\\Downloads";
            // 
            // button_rename_changeInputFolder
            // 
            this.button_rename_changeInputFolder.Location = new System.Drawing.Point(8, 22);
            this.button_rename_changeInputFolder.Name = "button_rename_changeInputFolder";
            this.button_rename_changeInputFolder.Size = new System.Drawing.Size(75, 23);
            this.button_rename_changeInputFolder.TabIndex = 0;
            this.button_rename_changeInputFolder.Text = "Changer";
            this.button_rename_changeInputFolder.UseVisualStyleBackColor = true;
            this.button_rename_changeInputFolder.Click += new System.EventHandler(this.button_rename_clickChangeInputFolder);
            // 
            // label_rename_inputFolder
            // 
            this.label_rename_inputFolder.AutoSize = true;
            this.label_rename_inputFolder.Location = new System.Drawing.Point(3, 3);
            this.label_rename_inputFolder.Name = "label_rename_inputFolder";
            this.label_rename_inputFolder.Size = new System.Drawing.Size(188, 13);
            this.label_rename_inputFolder.TabIndex = 1;
            this.label_rename_inputFolder.Text = "Répertoire : C:\\Users\\Maf\\Downloads";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1131, 576);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1123, 550);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ranger";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labell_rename_countSelectedTo);
            this.tabPage2.Controls.Add(this.label_rename_countSelectedFrom);
            this.tabPage2.Controls.Add(this.button_rename_convertFiles);
            this.tabPage2.Controls.Add(this.checkedListBox_rename_cleanedFiles);
            this.tabPage2.Controls.Add(this.listBox_rename_folderFiles);
            this.tabPage2.Controls.Add(this.button_rename_changeInputFolder);
            this.tabPage2.Controls.Add(this.label_rename_inputFolder);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1123, 550);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Renommer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labell_rename_countSelectedTo
            // 
            this.labell_rename_countSelectedTo.AutoSize = true;
            this.labell_rename_countSelectedTo.Location = new System.Drawing.Point(657, 510);
            this.labell_rename_countSelectedTo.Name = "labell_rename_countSelectedTo";
            this.labell_rename_countSelectedTo.Size = new System.Drawing.Size(66, 13);
            this.labell_rename_countSelectedTo.TabIndex = 6;
            this.labell_rename_countSelectedTo.Text = "Sélection : 0";
            // 
            // label_rename_countSelectedFrom
            // 
            this.label_rename_countSelectedFrom.AutoSize = true;
            this.label_rename_countSelectedFrom.Location = new System.Drawing.Point(86, 510);
            this.label_rename_countSelectedFrom.Name = "label_rename_countSelectedFrom";
            this.label_rename_countSelectedFrom.Size = new System.Drawing.Size(66, 13);
            this.label_rename_countSelectedFrom.TabIndex = 5;
            this.label_rename_countSelectedFrom.Text = "Sélection : 0";
            // 
            // button_rename_convertFiles
            // 
            this.button_rename_convertFiles.BackColor = System.Drawing.Color.PaleGreen;
            this.button_rename_convertFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rename_convertFiles.Location = new System.Drawing.Point(531, 236);
            this.button_rename_convertFiles.Name = "button_rename_convertFiles";
            this.button_rename_convertFiles.Size = new System.Drawing.Size(123, 56);
            this.button_rename_convertFiles.TabIndex = 4;
            this.button_rename_convertFiles.Text = "Renommer";
            this.button_rename_convertFiles.UseVisualStyleBackColor = false;
            this.button_rename_convertFiles.Click += new System.EventHandler(this.button_rename_convertFilesClick);
            // 
            // checkedListBox_rename_cleanedFiles
            // 
            this.checkedListBox_rename_cleanedFiles.FormattingEnabled = true;
            this.checkedListBox_rename_cleanedFiles.Location = new System.Drawing.Point(660, 22);
            this.checkedListBox_rename_cleanedFiles.Name = "checkedListBox_rename_cleanedFiles";
            this.checkedListBox_rename_cleanedFiles.Size = new System.Drawing.Size(437, 484);
            this.checkedListBox_rename_cleanedFiles.TabIndex = 3;
            // 
            // listBox_rename_folderFiles
            // 
            this.listBox_rename_folderFiles.FormattingEnabled = true;
            this.listBox_rename_folderFiles.HorizontalScrollbar = true;
            this.listBox_rename_folderFiles.Location = new System.Drawing.Point(89, 22);
            this.listBox_rename_folderFiles.Name = "listBox_rename_folderFiles";
            this.listBox_rename_folderFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_rename_folderFiles.Size = new System.Drawing.Size(436, 485);
            this.listBox_rename_folderFiles.Sorted = true;
            this.listBox_rename_folderFiles.TabIndex = 2;
            this.listBox_rename_folderFiles.SelectedIndexChanged += new System.EventHandler(this.rename_fillSuggestionList);
            // 
            // SerieManagerV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1131, 576);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerieManagerV2";
            this.Text = "Serie Manager V2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_rename_inputFolder;
        private System.Windows.Forms.Button button_rename_changeInputFolder;
        private System.Windows.Forms.Label label_rename_inputFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox_rename_folderFiles;
        private System.Windows.Forms.CheckedListBox checkedListBox_rename_cleanedFiles;
        private System.Windows.Forms.Button button_rename_convertFiles;
        private System.Windows.Forms.Label labell_rename_countSelectedTo;
        private System.Windows.Forms.Label label_rename_countSelectedFrom;
    }
}

