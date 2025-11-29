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

namespace BTH6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDestination.Text = fbd.SelectedPath;
                }
            }
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text;
            string dest = txtDestination.Text;

            if (!Directory.Exists(source))
            {
                MessageBox.Show("Thư mục nguồn không tồn tại!");
                return;
            }

            if (!Directory.Exists(dest))
            {
                Directory.CreateDirectory(dest);
            }

            string[] files = Directory.GetFiles(source);
            progressBar1.Value = 0;
            progressBar1.Maximum = files.Length;

            toolStripStatusLabel1.Text = "Đang sao chép...";

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destPath = Path.Combine(dest, fileName);

                toolTip1.SetToolTip(progressBar1, "Đang sao chép: " + fileName);

                await Task.Run(() => File.Copy(file, destPath, true));

                progressBar1.Value += 1;
                toolStripStatusLabel1.Text = $"Đang sao chép: {fileName}";
            }

            toolStripStatusLabel1.Text = "Hoàn tất sao chép!";
            MessageBox.Show("Sao chép thành công!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(progressBar1, "Tiến trình sao chép");
        }
    }
}
