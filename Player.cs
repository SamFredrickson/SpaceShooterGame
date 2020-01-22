using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooterGame
{
    class Player
    {
     
        public string Name { get; private set; }
        public string Diff { get; private set; }
        public int Seconds { get; private set; }
        public int Minutes { get; private set; }
        public int Hours   { get; private set; }


        public Player(string name, string diff, int seconds, int minutes, int hours)
        {
            Name = name;
            Diff = diff;
            Seconds = seconds;
            Minutes = minutes;
            Hours = hours;          
        }
    }
}
