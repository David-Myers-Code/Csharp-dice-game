using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pig
{
    class player
    {
        public string name { get; set; }
        public int score { get; set; }
        public play play { get; set; }

    }

    enum play
    {
        hold,
        roll
    }
}
