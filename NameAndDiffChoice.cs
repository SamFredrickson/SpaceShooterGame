using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class NameAndDiffChoice : Form
    {
        public NameAndDiffChoice()
        {
            InitializeComponent();
        }

        Validation val = new Validation();

        private void NameAndDiffChoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void StartGame()
        {
            string name = Regex.Replace(text_name.Text, @"\s+", " ")
                    .Trim();

            var game = new Game(diff_combo.Text, name);
            game.Show();
            this.Hide();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (!val.ValidateName(text_name.Text))
            {
                MessageBox.Show("Убедитесь, что имя введено верно: 1. Нет лишних пробелов; 2. Длина не меньше 3 и не больше 15; 3. Имя не пустое",
                    "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StartGame();
            }
        }
    }
}
