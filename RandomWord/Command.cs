using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomWord
{
    public class Command
    {
        public Boolean commandRunning { get; set; }
        public String currentWord { get; set; }
        public int timeRemaining { get; set; }
    }
}
