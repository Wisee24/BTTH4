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

namespace BTH4
{
    public partial class Form1 : Form
    {
        private string currentFile = "";
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                toolStripComboBoxFont.Items.Add(font.Name);
            }
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18,
                            20, 22, 24, 26, 28, 36, 48, 72 };

            foreach (int s in sizes)
                toolStripComboBoxSize.Items.Add(s.ToString());
            toolStripComboBoxFont.Text = "Tahoma";
            toolStripComboBoxSize.Text = "14";
            richTextBox1.Font = new Font("Tahoma", 14);
        }


        private void menuNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            toolStripComboBoxFont.Text = "Tahoma";
            toolStripComboBoxSize.Text = "14";
            richTextBox1.Font = new Font("Tahoma", 14);
            currentFile = "";
        }
        private void toolNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            toolStripComboBoxFont.Text = "Tahoma";
            toolStripComboBoxSize.Text = "14";
            richTextBox1.Font = new Font("Tahoma", 14);
            currentFile = "";
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Rich Text (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                currentFile = open.FileName;

                if (open.FileName.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
                    richTextBox1.LoadFile(open.FileName);
                else
                    richTextBox1.Text = File.ReadAllText(open.FileName);
            }
        }

        // toolbar Open handler
        private void toolOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Rich Text (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                currentFile = open.FileName;

                if (open.FileName.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
                    richTextBox1.LoadFile(open.FileName);
                else
                    richTextBox1.Text = File.ReadAllText(open.FileName);
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (currentFile == "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Rich Text (*.rtf)|*.rtf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    currentFile = save.FileName;
                    richTextBox1.SaveFile(currentFile);
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFile);
                MessageBox.Show("Lưu văn bản thành công!");
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (currentFile == "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Rich Text (*.rtf)|*.rtf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    currentFile = save.FileName;
                    richTextBox1.SaveFile(currentFile);
                }
            }
            else
            {
                richTextBox1.SaveFile(currentFile);
                MessageBox.Show("Lưu văn bản thành công!");
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font chosen = fontDialog1.Font;
                richTextBox1.SelectionFont = chosen;
                string fontName = chosen.FontFamily.Name;
                if (!toolStripComboBoxFont.Items.Contains(fontName))
                    toolStripComboBoxFont.Items.Add(fontName);
                toolStripComboBoxFont.Text = fontName;
                string sizeText = Math.Round(chosen.Size).ToString("0");
                if (!toolStripComboBoxSize.Items.Contains(sizeText))
                    toolStripComboBoxSize.Items.Add(sizeText);
                toolStripComboBoxSize.Text = sizeText;
            }
        }

        private void toolStripComboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font baseFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
            float size = baseFont.Size;
            FontStyle style = baseFont.Style;
            richTextBox1.SelectionFont = new Font(toolStripComboBoxFont.Text, size, style);


        }

        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font baseFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
            if (baseFont == null)
                return;

            if (float.TryParse(toolStripComboBoxSize.Text, out float newSize))
            {
                richTextBox1.SelectionFont = new Font(baseFont.FontFamily, newSize, baseFont.Style);
            }
        }

        private void toolBold_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void toolItalic_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void toolUnderline_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBox1.SelectionFont == null)
                return;

            Font current = richTextBox1.SelectionFont;
            FontStyle newStyle;

            if (current.Style.HasFlag(style))
                newStyle = current.Style & ~style;
            else
                newStyle = current.Style | style;

            richTextBox1.SelectionFont =
                new Font(current.FontFamily, current.Size, newStyle);
        }
    }
}
