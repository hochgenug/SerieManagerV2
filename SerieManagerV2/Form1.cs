using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

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

        /*****************************
         * 
         *       Cleaning name functions
         * 
         *****************************/

        // pattern propre : Nom Serie S01E01 - Nom Episode [VOSTFR][720p].mkv
        private string cleanName(string name)
        {
            string cleanedName = name.Replace('.', ' ').ToLower().Replace("subfrench", "vostfr");
            Console.WriteLine("name" + name.ToString());
            Console.WriteLine("cleanname" + cleanedName.ToString());
            cleanedName = cleanedName.First().ToString().ToUpper() + cleanedName.Substring(1);

            Regex myRegex = new Regex(@"^(?<serie>.*)s(?<saison>[\d]{2})e(?<episode>[\d]{2})(.*)(?<lang>(vostfr|french|multi))(.*)(?<quality>360p|720p|1080p)(.*)(?<extension>mkv|avi|mp4)$");
            GroupCollection groups = myRegex.Match(cleanedName.ToString()).Groups;

            string goodFormat = "";
            goodFormat = cleanEpisode(groups, goodFormat);
            Console.WriteLine("episode" + goodFormat.ToString());
            goodFormat = cleanSeason(groups, goodFormat);
            Console.WriteLine("saison" + goodFormat.ToString()); ;
            goodFormat = cleanLang(groups, goodFormat);
            Console.WriteLine("lang" + goodFormat.ToString());
            goodFormat = cleanQuality(name, groups, goodFormat);
            Console.WriteLine("qualite" + goodFormat.ToString());
            goodFormat = cleanExtension(groups, goodFormat);
            cleanedName = goodFormat;
            if (goodFormat == "") {
                cleanedName = name;
            }

            return cleanedName;
        }

        private static string cleanEpisode(GroupCollection groups, string goodFormat) {
            if (groups["serie"].ToString() != "") {
                goodFormat = goodFormat + groups["serie"].ToString();
            }
            return goodFormat;
        }

        private static string cleanSeason(GroupCollection groups, string goodFormat) {
            if (groups["saison"].ToString() != "" && (groups["episode"].ToString() != "")) {
                goodFormat = goodFormat + "S" + groups["saison"].ToString() + "E" + groups["episode"].ToString();
            }
            return goodFormat;
        }

        private static string cleanLang(GroupCollection groups, string goodFormat) {
            if (groups["lang"].ToString() != "") {
                goodFormat = goodFormat + " [" + groups["lang"].ToString().ToUpper() + "]";
            }
            return goodFormat;
        }

        private static string cleanExtension(GroupCollection groups, string goodFormat) {
            if (groups["extension"].ToString() != "") {
                goodFormat = goodFormat + "." + groups["extension"].ToString();
            }
            return goodFormat;
        }

        private string cleanQuality(string name, GroupCollection groups, string goodFormat) {
            Console.WriteLine(goodFormat.ToString());
            if (groups["quality"].ToString() != "") {
                goodFormat = goodFormat + " [" + groups["quality"].ToString().ToLower() + "]";
                goodFormat = goodFormat.Replace("] [", "][");
            } else {
                var mediaPlayer = new MediaPlayer();
                var defaultQualityText = "Entrez la qualité. Ex : 720p";
                var defaultQualityTitle = "Qualité manquante.";
                mediaPlayer.Open(new Uri(folderBrowserDialog_rename_inputFolder.SelectedPath + '\\' + name));
                Thread.Sleep(200);
                if (mediaPlayer.NaturalVideoHeight != 0) {
                    defaultQualityText = mediaPlayer.NaturalVideoHeight.ToString() + "p";
                    defaultQualityTitle = "Confirmez la qualité détecté";
                }
                string test;
                test = Interaction.InputBox("Definir la qualité pour le fichier : " + name, defaultQualityTitle, defaultQualityText);
                // if(test != null)
                //  {
                goodFormat =  goodFormat.Replace(".", "[" + test +"].");
                   // Console.WriteLine(goodFormat.ToString());
             //   }
             //   Console.WriteLine("zezeze");
             //   Console.WriteLine(test);


            }
            return goodFormat;
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
