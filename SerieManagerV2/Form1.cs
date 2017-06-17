using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SerieManagerV2
{
    public partial class SerieManagerV2 : Form
    {
        const string defaultInputFolderText = "Répertoire : ";
        IDictionary<string, string> mappingCleanAndOldFilenames = new Dictionary<string, string>();

 
        public SerieManagerV2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.reload_ListBox_rename_folderFiles();
        }
        
        /*****************************
         * 
         *        Rename Functions
         * 
         *****************************/

        // When the user update the selection of the selected files
        private void rename_fillSuggestionList(object sender, EventArgs e)
        {
            this.reload_checkedListBox_rename_cleanedFiles();
            label_rename_countSelectedFrom.Text = "Sélection : " + listBox_rename_folderFiles.SelectedItems.Count;
            labell_rename_countSelectedTo.Text = "Sélection : " + checkedListBox_rename_cleanedFiles.CheckedItems.Count;
        }

        // Reload the list of the folder files 
        private void reload_ListBox_rename_folderFiles()
        {
            listBox_rename_folderFiles.Items.Clear();
            var files = Directory.EnumerateFiles(folderBrowserDialog_rename_inputFolder.SelectedPath, "*.*").Where(s => s.EndsWith(".avi") || s.EndsWith(".mp4") || s.EndsWith(".mkv"));
            foreach (string file in files)
            {
                listBox_rename_folderFiles.Items.Add(Path.GetFileName(file));
            }
        }

        // Reload the list of the cleaned files
        private void reload_checkedListBox_rename_cleanedFiles()
        {
            mappingCleanAndOldFilenames.Clear();
            checkedListBox_rename_cleanedFiles.Items.Clear();
            foreach (string file in listBox_rename_folderFiles.SelectedItems)
            {
                string cleanname = this.cleanName(file);
                if (mappingCleanAndOldFilenames.ContainsKey(cleanname))
                {
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show("Doublons détecter : " + file + "\nLe supprimer ?", "Fichier existant.", button);
                    if(result == DialogResult.Yes)
                    {
                        File.Delete(folderBrowserDialog_rename_inputFolder.SelectedPath + "\\" + file);
                        reload_ListBox_rename_folderFiles();
                        reload_checkedListBox_rename_cleanedFiles();
                        break;
                    }
                }
                else
                {
                    mappingCleanAndOldFilenames.Add(cleanname, file);
                }
                checkedListBox_rename_cleanedFiles.Items.Add(cleanname);
                if(cleanname != file)
                {
                    checkedListBox_rename_cleanedFiles.SetItemChecked(checkedListBox_rename_cleanedFiles.Items.Count - 1, true);
                }
               
            }
        }

        // pattern propre : Nom Serie S01E01 - Nom Episode [VOSTFR][720p].avi
        private string cleanName(string name)
        {
            string cleanedName = name.Replace('.', ' ').ToLower().Replace("subfrench", "vostfr");
            cleanedName = cleanedName.First().ToString().ToUpper() + cleanedName.Substring(1);

            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^(?<serie>.*)s(?<saison>[\d]{2})e(?<episode>[\d]{2})(.*)(?<lang>(vostfr|french))(.*)(?<quality>360p|720p|1080p)(.*)(?<format>mkv|avi|mp4)$");

            GroupCollection groups = myRegex.Match(cleanedName.ToString()).Groups;

            string goodFormat = "";
            if (groups["serie"].ToString() != "")
            {
                goodFormat = goodFormat + groups["serie"].ToString();
            }
            if (groups["saison"].ToString() != "" && (groups["episode"].ToString() != ""))
            {
                goodFormat = goodFormat + "S" + groups["saison"].ToString() + "E" + groups["episode"].ToString();
            }
            if (groups["lang"].ToString() != "")
            {
                goodFormat = goodFormat + " [" + groups["lang"].ToString().ToUpper() + "]";
            }
            if (groups["quality"].ToString() != "")
            {
                goodFormat = goodFormat + " [" + groups["quality"].ToString().ToLower() + "]";
                goodFormat = goodFormat.Replace("] [", "][");
            }
            if (groups["format"].ToString() != "")
            {
                goodFormat = goodFormat + "." + groups["format"].ToString();
            }
            cleanedName = goodFormat;
            if (goodFormat == "")
            {
               // MessageBox.Show("Pas de nom propre trouvé pour le fichier : " + name);
                cleanedName = name;
            }

            return cleanedName;
        }

        /*****************************
         * 
         *        Buttons Actions
         * 
         *****************************/
        
        // Rename the selected files with a cleaned name
        private void button_rename_convertFilesClick(object sender, EventArgs e)
        {
            foreach (object itemChecked in checkedListBox_rename_cleanedFiles.CheckedItems)
            {
                string to = itemChecked.ToString();
                string from = mappingCleanAndOldFilenames[to].ToString();
                if(File.Exists(folderBrowserDialog_rename_inputFolder.SelectedPath + "\\" + to))
                {
                    MessageBox.Show("Le fichier de destination existe déjà.", "Fichier existant.");
                } else
                {
                    File.Move(folderBrowserDialog_rename_inputFolder.SelectedPath + "\\" + from, folderBrowserDialog_rename_inputFolder.SelectedPath + "\\" + to);
                }

            }

            this.reload_ListBox_rename_folderFiles();
            this.reload_checkedListBox_rename_cleanedFiles();

        }

        // Change the input folder
        private void button_rename_clickChangeInputFolder(object sender, EventArgs e)
        {
            folderBrowserDialog_rename_inputFolder.ShowDialog();
            this.reload_ListBox_rename_folderFiles();
            this.changeInputFolderLabel();
        }

        /*****************************
         * 
         *       Labels Update
         * 
         *****************************/
        private void changeInputFolderLabel()
        {
            this.label_rename_inputFolder.Text = defaultInputFolderText + folderBrowserDialog_rename_inputFolder.SelectedPath;
        }
    }

}
