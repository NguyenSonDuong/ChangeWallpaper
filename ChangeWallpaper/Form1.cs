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
        String anh1;
        String anh2;
        bool isChange;
        public Form1()
        {
            InitializeComponent();
            ChangeWallpaper.RegisterHotKey(this.Handle, 1999, (int)ChangeWallpaper.KeyModifier.Alt, Keys.F5.GetHashCode());
            ChangeWallpaper.RegisterHotKey(this.Handle, 2000, (int)ChangeWallpaper.KeyModifier.Shift, Keys.F4.GetHashCode());
            ChangeWallpaper.RegisterHotKey(this.Handle, 2001, (int)ChangeWallpaper.KeyModifier.Control, Keys.F4.GetHashCode());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                
                anh1 = open.FileName;
                textBox1.Text = anh1;
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // thi thoảng mk hay quên mấy giá trị này haha
            // trong này là message trả về từ sự kiện nhấn phím tắt mà bạn đã đăng ký
            // ví dụ như sau
            // trong này bạn có thể làm mọi thứ với bài hôm nay thì mk sẽ đổi ảnh nền desktop
            if(m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                if(id == 1999)
                {
                    if (isChange)
                    {
                        ChangeWallpaper.SetDesktopWallpaper(anh1);
                        isChange = false;
                    }
                    else
                    {
                        ChangeWallpaper.SetDesktopWallpaper(anh2);
                        isChange = true;
                    }
                }else if(id == 2000)
                {
                    Application.Exit();
                }
                else if(id == 2001)
                {
                    Show();
                }
                
                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                anh2 = open.FileName;
                textBox2.Text = anh2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeWallpaper.UnregisterHotKey(this.Handle, 1999);
            ChangeWallpaper.UnregisterHotKey(this.Handle, 2000);
        }
        

        private void đóngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
