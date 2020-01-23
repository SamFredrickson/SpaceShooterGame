using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void play_pic_MouseEnter(object sender, EventArgs e)
        {
            play_pic.Load(@"Resources/buttons/play_button_on.png");
        }

        private void play_pic_MouseLeave(object sender, EventArgs e)
        {
            play_pic.Load(@"Resources/buttons/play_button_off.png");
        }

        private void pic_records_MouseEnter(object sender, EventArgs e)
        {
            pic_records.Load(@"Resources/buttons/record_button_on2.png");
        }

        private void pic_records_MouseLeave(object sender, EventArgs e)
        {
            pic_records.Load(@"Resources/buttons/record_button_off2.png");
        }

        private void about_pic_MouseEnter(object sender, EventArgs e)
        {
            about_pic.Load(@"Resources/buttons/about_button_on.png");
        }

        private void about_pic_MouseLeave(object sender, EventArgs e)
        {
            about_pic.Load(@"Resources/buttons/about_button_off.png");

        }

        private void pic_exit_MouseEnter(object sender, EventArgs e)
        {
            pic_exit.Load(@"Resources/buttons/exit_button_on.png");
        }

        private void pic_exit_MouseLeave(object sender, EventArgs e)
        {
            pic_exit.Load(@"Resources/buttons/exit_button_off.png");
        }

        private void pic_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void play_pic_Click(object sender, EventArgs e)
        {
            var choice = new NameAndDiffChoice();
            this.Hide();
            choice.Show();         
        }
    }
}
