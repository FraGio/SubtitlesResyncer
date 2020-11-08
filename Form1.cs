using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SubtitlesResyncer
{
    public partial class Form1 : Form
    {
        private string REGEX_TIME_SUBTITLES = @"^([0-9]+):([0-9]+):([0-9]+),([0-9]+)\s+-->\s+([0-9]+):([0-9]+):([0-9]+),([0-9]+)";

        public Form1()
        {
            InitializeComponent();
        }

        #region EventHandlers

        private void subtitlesTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "subtitles files (*.srt)|*.srt";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadSubtitlesFile(openFileDialog.FileName);
                }
            }
        }

        private void subtitlesTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0) 
                {
                    LoadSubtitlesFile(files[0]);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Errore durante l'apertura del file." + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void subtitlesTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        private void LoadSubtitlesFile(string filePath)
        {
            okIcon.Visible = false;
            subtitlesTextBox.Clear();
            string fileContent = File.ReadAllText(filePath, Encoding.Default);
            subtitlesTextBox.Text = fileContent;
        }

        private void buttonResync_Click(object sender, EventArgs e)
        {
            string subtitlesContent = subtitlesTextBox.Text;
            bool parseOk = int.TryParse(textBoxSyncMs.Text, out int resyncMs);
            if (parseOk && !string.IsNullOrWhiteSpace(subtitlesContent))
            {
                Resync(subtitlesTextBox.Text, resyncMs);
            }
            else if(!string.IsNullOrWhiteSpace(subtitlesContent))
            {
                MessageBox.Show("Valore non valido (deve essere numero intero, positivo o negativo)", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("File sottotitoli non caricato correttamente.\nTrascinare file nella schermata superiore, o fare doppio click sulla schermata superiore.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Resync(string subtitlesContent, int resyncMs)
        {
            string[] lines = subtitlesContent.Split('\n');
            List<string> linesResynced = new List<string>();
            int count = 0;
            bool isValid = false;

            foreach (string fullLine in lines)
            {
                string line = fullLine.Trim();

                Match match = Regex.Match(line, REGEX_TIME_SUBTITLES);

                if (match.Success)
                {
                    // Riga contenente i timestamp dei sottotitoli

                    TimeSpan timeSpanInitial = new TimeSpan(0, int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));
                    TimeSpan timeSpanFinal = new TimeSpan(0, int.Parse(match.Groups[5].Value), int.Parse(match.Groups[6].Value), int.Parse(match.Groups[7].Value), int.Parse(match.Groups[8].Value));

                    // Riadattamento timestamp
                    TimeSpan timeSpanInitialResynced = timeSpanInitial.Add(new TimeSpan(0, 0, 0, 0, resyncMs));
                    TimeSpan timeSpanFinalResynced = timeSpanFinal.Add(new TimeSpan(0, 0, 0, 0, resyncMs));

                    // Queste righe di sottotitolo devono essere presenti nel file finale, quelle con timestamp negativi no
                    if (timeSpanInitialResynced.TotalMilliseconds >= 0 && timeSpanFinalResynced.TotalMilliseconds >= 0)
                    {
                        isValid = true;

                        // Aggiungo una riga con il numero del sottotitolo
                        count += 1;
                        linesResynced.Add(count.ToString());

                        string timestampFormat = @"hh\:mm\:ss\,fff";
                        line = timeSpanInitialResynced.ToString(timestampFormat) + " --> " + timeSpanFinalResynced.ToString(timestampFormat);
                    }
                }

                // Aggiungo riga solo se ho individuato un timestamp valido per il sottotitolo
                if (isValid)
                {
                    linesResynced.Add(line);

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // Aggiungo la linea vuota di fine sottotitolo e resetto flag validità
                        isValid = false;
                    }
                }
            }

            //MessageBox.Show("Operazione completata. Salvare il nuovo file.", "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "subtitles files (*.srt)|*.srt";
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, String.Join(Environment.NewLine, linesResynced), Encoding.Default);
                    okIcon.Visible = true;
                }
            }
        }
    }
}
