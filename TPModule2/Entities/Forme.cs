using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2.Entities
{
    public abstract class Forme
    {
        public abstract double Aire { get; }
        public abstract double Perimetre { get; }

        public override string ToString()
        {
            return "Aire = " + Aire + "\nPérimètre = " + Perimetre + "\n";
        }
    }
}
