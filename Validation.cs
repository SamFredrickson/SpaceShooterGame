using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooterGame
{
    class Validation
    {

       public bool ValidateName(string name)
        {
            bool flag = true;
            if (name.Length < 3) flag = false;
            if (name.Length > 15) flag = false;
            if (string.IsNullOrWhiteSpace(name)) flag = false;

            return flag;
        }
                    
    }
}
