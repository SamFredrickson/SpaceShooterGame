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
                           orderby s.seconds + s.minutes + s.hours descending
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
                               orderby s.seconds + s.minutes + s.hours descending
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

        private void AddRecordOfExistedPlayer(string playerName, string diff, int sec, int min, int h)
        {
            using (var ctx = new MyDbContext())
            {
                var player_id = ctx.Player.Select(s => s)
                        .Where(i => i.name == playerName)
                        .First();

                var score = new Score
                {
                    difficulty = diff,
                    seconds = sec,
                    minutes = min,
                    hours = h
                };

                ctx.Score.Add(score);
                ctx.SaveChanges();

                var score_id = ctx.Score
                     .Select(s => s.id).Max();

                var playerScore = new PlayerScore
                {
                    id_player = player_id.id,
                    id_score = score_id
                };

                ctx.PlayerScore.Add(playerScore);
                ctx.SaveChanges();
            }
        }

        private void AddRecordOfNotExistingPlayer(string playerName, string diff, int sec, int min, int h)
        {
            using (var ctx = new MyDbContext())
            {
                var player = new EntityModel.Player
                {
                    name = playerName
                };

                ctx.Player.Add(player);
                ctx.SaveChanges();

                var player_id = ctx.Player
                    .Select(s => s.id).Max();


                var score = new Score
                {
                    difficulty = diff,
                    seconds = sec,
                    minutes = min,
                    hours = h
                };

                ctx.Score.Add(score);
                ctx.SaveChanges();

                var score_id = ctx.Score
                     .Select(s => s.id).Max();

                var playerScore = new PlayerScore
                {
                    id_player = player_id,
                    id_score = score_id
                };

                ctx.PlayerScore.Add(playerScore);
                ctx.SaveChanges();
            }
        }

        public void Add(string playerName, string diff, int sec, int min, int h)
        {
            using (var ctx = new MyDbContext())
            {
                var IsPlayerExist = ctx.Player
                    .Select(s => s)
                    .Any(n => n.name == playerName);

                if (
IsPlayerExist)
                    AddRecordOfExistedPlayer(playerName, diff, sec, min, h);
                else AddRecordOfNotExistingPlayer(playerName, diff, sec, min, h);
            }
        }

        public void Search(string playerName, DataGridView data)
        {
            using (var ctx = new MyDbContext())
            {
                var all = (from ps in ctx.PlayerScore
                           join p in ctx.Player on ps.id_player equals p.id
                           join s in ctx.Score on ps.id_score equals s.id
                           where p.name == playerName
                           orderby s.seconds + s.minutes + s.hours descending
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
