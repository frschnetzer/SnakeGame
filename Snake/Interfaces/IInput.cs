using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Interfaces
{
    internal interface IInput
    {
        public bool KeyPress(Keys key);

        public void ChangeState(Keys key, bool state);
    }
}