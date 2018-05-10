using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarhyPlot
{
    public class Stavka
    {
        public string eKod { get; set; }

        public string Vrska { get; set; }

        public int? Kod { get; set; }

        public bool isProccesed { get; set; }

        public override string ToString()
        {
            return $"{eKod}, {Vrska}, {Kod}, {isProccesed}";
        }
    }
}
