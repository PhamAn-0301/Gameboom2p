using BombGame;
using BOOM_OFFILNE.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOM_OFFILNE
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            // load đường dẫn dùng chung
            Common.path = Application.StartupPath + @"\Siu";
            // thiết lập âm thanh
            Sound.InitSound(Common.path);

        }
       
        private void ResetPanel()
        {
            frmMenu.Top = 0;
            frmMenu.Left = 0;
            pnAboutUs.Top = 40;
            pnAboutUs.Left = 1000;
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            
           Sound.PlayClickRoomSound();
            this.Hide(); // Ẩn FormMenu

            FormNhanVat gameForm = new FormNhanVat();
            gameForm.ShowDialog(); // Mở FormGame và chờ nó đóng lại

            this.Show(); // Khi FormGame đóng, FormMenu hiện lại
        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();
         

        }
        private void btnAboutUs_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private Point titleClickPoint;
        private int w, h;

        private void picMultiply_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pnTitle_MouseDown(object sender, MouseEventArgs e)
        {
            titleClickPoint.X = MousePosition.X;
            titleClickPoint.Y = MousePosition.Y;
            this.w = e.X;
            this.h = e.Y;
        }

        private void pnTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
                this.Location = new Point(MousePosition.X - w, MousePosition.Y - h);
        }

        private void picMinus_MouseEnter(object sender, EventArgs e)
        {
            this.picMinus.BackColor = Color.Green;

        }

        private void picMinus_MouseLeave(object sender, EventArgs e)
        {
            this.picMinus.BackColor = Color.Transparent;

        }

        private void picMultiply_MouseEnter(object sender, EventArgs e)
        {
            this.picMultiply.BackColor = Color.Red;

        }

        private void picMultiply_MouseLeave(object sender, EventArgs e)
        {
            this.picMultiply.BackColor = Color.Transparent;
    
        }

        private void btnAboutUsMenu_Click(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();

            this.ResetPanel();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();

            this.ResetPanel();

        }

        private void btnAboutUs_Click_1(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();
            pnAboutUs.Top = 29;
            pnAboutUs.Left = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();
            Application.Exit();

        }

        private void picMinus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
