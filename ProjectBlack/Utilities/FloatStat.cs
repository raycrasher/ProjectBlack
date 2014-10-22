using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class FloatStat
    {
        public FloatStat() { }
        public FloatStat(FloatStat copy) {
            Base    = copy.Base;
            Mod     = copy.Mod;
            BaseMax = copy.BaseMax;
            BaseMin = copy.BaseMin;
            ModMax  = copy.ModMax;
            ModMin  = copy.ModMin;
            MinCap  = copy.MinCap;
            MaxCap  = copy.MaxCap;
        }


        public float Base { get; set; }
        public float Mod { get; set; }
        
        public float BaseMax { get; set; }
        public float BaseMin { get; set; }

        public float ModMax { get; set; }
        public float ModMin { get; set; }

        public float MinCap { get; set; }
        public float MaxCap { get; set; }

        public static implicit operator float(FloatStat s) {
            return s.Base + s.Mod;
        }
    }
}
