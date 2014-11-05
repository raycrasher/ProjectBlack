using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Combat
{
    public class DamageProfile
    {

        public DamageProfile() { }

        public DamageProfile(DamageType type, float min, float max)
        {
            Type = type;
            MinDamage = min;
            MaxDamage = max;
        }

        public DamageType Type;
        public float MinDamage;
        public float MaxDamage;
    }
}
