using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HammingCoding
{
    public partial class MainForm : Form
    {
        private HammingCode coder = new HammingCode();
        public MainForm()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        var sb = new StringBuilder();
                        StreamReader sr;
                        using (sr = new StreamReader(openFileDialog.FileName))
                        {
                            Int64 length = 0;
                            String line;
                            while (sr.Peek() >= 0)
                            {
                                line = sr.ReadLine();
                                sb.AppendLine(line);
                                length += line.Length;
                            }
                            sr.Close();
                        }
                        richTextBox_data.Text = sb.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось прочитать файл. Подробная информация об ошибке: " + ex.Message);
                }
            }
        }

        private void построитьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_data.Text = coder.EncodeFromText(richTextBox_data.Text);
        }

        private void декодироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_data.Text = coder.DecodeFromText(richTextBox_data.Text);
        }
    }
}
