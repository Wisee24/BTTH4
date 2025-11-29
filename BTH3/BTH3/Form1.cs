using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BTH3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            statusLabel.Text =
    "Hôm nay là ngày " + DateTime.Now.ToString("dd/MM/yyyy") +
    " - Bây giờ là " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Media Files|*.mp3;*.mp4;*.wav;*.wma;*.wmv;*.avi;*.mkv|All Files|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = open.FileName;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusLabel.Text =
                "Hôm nay là ngày " + DateTime.Now.ToString("dd/MM/yyyy") +
                " - Bây giờ là " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
