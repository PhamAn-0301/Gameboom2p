using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using BOOM_OFFILNE.General;
using BombGame;

namespace BOOM_OFFILNE
{
    public partial class FormNhanVat : Form
    {
        public FormNhanVat()
        { // load đường dẫn dùng chung
            Common.path = Application.StartupPath + @"\Siu";
            // thiết lập âm thanh
            Sound.InitSound(Common.path);
            InitializeComponent();
            MakePictureBoxRounded(picChar1);
            MakePictureBoxRounded(picChar2);

        }

        private void ResetPanel()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Lấy kích thước của Form
            int formWidth = this.Width;
            int formHeight = this.Height;

            // Tính toán vị trí để Form xuất hiện ở giữa màn hình
            this.Left = (screenWidth - formWidth) / 2;
            this.Top = (screenHeight - formHeight) / 2;
           
            pnInstructions.Top = 40;
            pnInstructions.Left = 1000;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Sound.PlayStartSound();
            string ten1 = txtSonTinh.Text.Trim();
            string ten2 = txtThuyTinh.Text.Trim();

            if (ten1 == placeholderSonTinh || string.IsNullOrWhiteSpace(ten1) ||
                ten2 == placeholderThuyTinh || string.IsNullOrWhiteSpace(ten2))
            {
                MessageBox.Show("Bạn phải nhập tên cho cả 2 người chơi!", "Thiếu tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormGame gameForm = new FormGame(ten1, ten2);
            gameForm.Owner = this;   // Gán chủ sở hữu là FormNhanVat

            this.Hide();             // Ẩn FormNhanVat
            gameForm.ShowDialog();
        }
        private string placeholderSonTinh = "Vui lòng nhập tên !";
        private string placeholderThuyTinh = "Vui lòng nhập tên !";

        private void FormNhanVat_Load(object sender, EventArgs e)
        {
            // Set placeholder khi form load
            SetPlaceholder(txtSonTinh, placeholderSonTinh);
            SetPlaceholder(txtThuyTinh, placeholderThuyTinh);
        }

        // Hàm set placeholder
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void RestorePlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        // Sự kiện Enter
        private void txtSonTinh_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtSonTinh, placeholderSonTinh);
        }

        private void txtThuyTinh_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtThuyTinh, placeholderThuyTinh);
        }

        // Sự kiện Leave
        private void txtSonTinh_Leave(object sender, EventArgs e)
        {
            RestorePlaceholder(txtSonTinh, placeholderSonTinh);
        }

        private void txtThuyTinh_Leave(object sender, EventArgs e)
        {
            RestorePlaceholder(txtThuyTinh, placeholderThuyTinh);
        }

        private void picMultiply_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInstructions_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MakePictureBoxRounded(PictureBox pic)
        {
         
            int radius = pic.Width / 4; // Tính radius theo tỷ lệ, giảm để bo sát
            if (radius < 10) radius = 10; // Đảm bảo radius không quá nhỏ

            GraphicsPath gp = new GraphicsPath();
            // Bo các góc với radius nhỏ hơn để bo sát gần hơn
            gp.AddArc(0, 0, radius, radius, 180, 90); // Góc trên trái
            gp.AddArc(pic.Width - radius, 0, radius, radius, 270, 90); // Góc trên phải
            gp.AddArc(pic.Width - radius, pic.Height - radius, radius, radius, 0, 90); // Góc dưới phải
            gp.AddArc(0, pic.Height - radius, radius, radius, 90, 90); // Góc dưới trái
            gp.CloseFigure();

            // Áp dụng vùng để bo góc
            pic.Region = new Region(gp);
        }

        private void pnInstructions_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();

            pnInstructions.Top = 7;
            pnInstructions.Left = 173;
        }

        private void Instruction_menu_Click(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();

            this.ResetPanel();

        }

        private void picMinus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void picMinus_MouseEnter(object sender, EventArgs e)
        {
            this.picMinus.BackColor = Color.Transparent;

        }

        private void picMinus_MouseLeave(object sender, EventArgs e)
        {
            this.picMinus.BackColor = Color.Teal;

        }

        private void picMultiply_MouseEnter(object sender, EventArgs e)
        {
            this.picMultiply.BackColor = Color.Red;

        }

        private void picMultiply_MouseLeave(object sender, EventArgs e)
        {
            this.picMultiply.BackColor = Color.Teal;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Sound.PlayClickRoomSound();

            FormMenu formMenu = new FormMenu();
            formMenu.Show();
            this.Close(); 
        }
    }
}
