using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooterGame
{
    class Difficulty
    {
        public string Diff { get; private set; }
        public int NumberOfDestroyers { get; private set; }
        public int EnemyDamage { get; private set; }

        public Difficulty(string diff)
        {
            Diff = diff;
        }

       

    }
}
