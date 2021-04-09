using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomWord.Models
{
    public class CommandLog
    {
        public int Id { get; set; }
        public string Commands { get; set; }
        public string State { get; set; }
        public int TimeRemaining { get; set; }
    }
}
