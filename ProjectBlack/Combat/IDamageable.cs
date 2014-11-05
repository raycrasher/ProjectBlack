using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBlack.Combat
{
    public interface IDamageable
    {
        void ApplyDamage(DamageProfile damage);
    }
}
