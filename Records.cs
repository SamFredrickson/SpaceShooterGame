using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceShooterGame.EntityModel;

namespace SpaceShooterGame
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();

        }

        DataManager d = new DataManager();

        private void btn_back_Click(object sender, EventArgs e)
        {
            var menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            d.Fill(data);
        }

        private void Records_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            d.Filter(data, combo_choice);
        }
    }
}
