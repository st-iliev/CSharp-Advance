using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public  class Cargo
    {
        private string type;
        private int weigh;

        public Cargo(string type, int weigh)
        {
            Type = type;
            Weigh = weigh;
        }

        public string Type { get { return type; } set { type = value; } }
        public int Weigh { get { return weigh; }  set { weigh = value; } }
    }
}
