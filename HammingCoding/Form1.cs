using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HammingCoding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Code coder = new Code();
            string codeString = this.textBox1.Text;

            var code = Helpers.prettyStringToBoolArray(codeString);
            var encoded = coder.Encode(code);

            this.textBox1.Text = Helpers.boolArrayToPrettyString(encoded);
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
                        textBox1.Text = sb.ToString();
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
            Code coder = new Code();
            String asciiCode = coder.ConstructCodeFromText(textBox1.Text);
            textBox1.Text = asciiCode;
            //var code = Helpers.prettyStringToBoolArray(codeString);
        }

        private void декодироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Code coder = new Code();
            String asciiCode = coder.DecodeFromText(textBox1.Text);
            textBox1.Text = asciiCode;
        }
    }
}
