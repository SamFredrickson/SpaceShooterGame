using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceShooterGame.EntityModel;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    class DataManager
    {
        public void Fill(DataGridView data)
        {
            using (var ctx = new MyDbContext())
            {
                var all = (from ps in ctx.PlayerScore
                           join p in ctx.Player on ps.id_player equals p.id
                           join s in ctx.Score on ps.id_score equals s.id
                           select new
                           {
                               Имя = p.name,
                               Рекорд = s.hours + " часов, " + s.minutes + " минут, " + s.seconds + " секунд",
                               Сложность = s.difficulty

                           }).ToList();

                data.DataSource = all;
            }
        }

        private string DifficultyConverter(string combo)
        {
            string word = "";

            switch (combo)
            {
                case "Все": word = "Все"; break;
                case "Только легкие": word = "Легко"; break;
                case "Только средние": word = "Средне"; break;
                case "Только сложные": word = "Тяжело"; break;
                case "Только очень сложные": word = "Очень тяжело"; break;
            }

            return word;
        }

        public void Filter(DataGridView data, ComboBox combo)
        {
            string choice = DifficultyConverter(combo.Text);

            using (var ctx = new MyDbContext())
            {
               if(choice == "Все")
                {
                    Fill(data);
                }
                else
                {
                    var all = (from ps in ctx.PlayerScore
                               join p in ctx.Player on ps.id_player equals p.id
                               join s in ctx.Score on ps.id_score equals s.id
                               where s.difficulty == choice
                               select new
                               {
                                   Имя = p.name,
                                   Рекорд = s.hours + " часов, " + s.minutes + " минут, " + s.seconds + " секунд",
                                   Сложность = s.difficulty

                               }).ToList();

                    data.DataSource = all;
                }
            }
        }

    }
}
