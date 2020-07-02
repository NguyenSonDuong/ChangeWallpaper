using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeWallpaper
{
    public partial class Form1 : Form
    {
        String macdinh;
        String chuyen;
        bool isChange = false;
        enum KeyFirst
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8
        }

        public Form1()
        {
            InitializeComponent();
            Wallpaper.RegisterHotKey(this.Handle, 1999, (int)KeyFirst.Shift, Keys.F3.GetHashCode());
            Wallpaper.RegisterHotKey(this.Handle, 2000, (int)KeyFirst.Shift, Keys.F9.GetHashCode());
            Wallpaper.RegisterHotKey(this.Handle, 2001, (int)KeyFirst.Shift, Keys.F10.GetHashCode());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if(m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                if (id == 1999)
                {
                    if (isChange)
                    {
                        Wallpaper.ChangerWallpaper(macdinh);
                        isChange = false;
                    }else
                    {
                        Wallpaper.ChangerWallpaper(chuyen);
                        isChange = true;
                    }
                   
                }else if(id == 2000)
                {
                    Wallpaper.ShowWindow(this.Handle, 0);
                }else if(id == 2001) {
                    Wallpaper.ShowWindow(this.Handle, 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                macdinh = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                chuyen = open.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Wallpaper.UnregisterHotKey(this.Handle, 1999);
        }
        
    }
}
