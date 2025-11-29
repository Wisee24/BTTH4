using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTH1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_MBUTTONDOWN = 0x0207;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {

                case WM_LBUTTONDOWN:
                    {
                        int x = m.LParam.ToInt32() & 0xFFFF;
                        int y = (m.LParam.ToInt32() >> 16);
                        MessageBox.Show($"Left Click tại ({x}, {y})");
                        break;
                    }

                case WM_RBUTTONDOWN:
                    {
                        int x = m.LParam.ToInt32() & 0xFFFF;
                        int y = (m.LParam.ToInt32() >> 16);
                        MessageBox.Show($"Right Click tại ({x}, {y})");
                        break;
                    }

                case WM_MBUTTONDOWN:
                    {
                        int x = m.LParam.ToInt32() & 0xFFFF;
                        int y = (m.LParam.ToInt32() >> 16);
                        MessageBox.Show($"Middle Click tại ({x}, {y})");
                        break;
                    }

                case WM_KEYDOWN:
                case WM_SYSKEYDOWN:
                    {
                        int keyCode = m.WParam.ToInt32();
                        char ascii = (char)keyCode;

                        MessageBox.Show(
                            $"Bạn nhấn phím: {ascii}\n" +
                            $"Key Code: {keyCode}\n" +
                            $"ASCII: {(int)ascii}"
                        );

                        break;
                    }
            }

            base.WndProc(ref m);
        }
    }
}
