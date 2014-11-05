using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Combat
{
    public class HealthComponent : Component, IDamageable
    {
        public float CurrentHealth { get; set; }
        public float MaxHealth { get; set; }

        public void ApplyDamage(DamageProfile damage) {
            if(IsEnabled)
                CurrentHealth = (CurrentHealth - Game.Rng.NextFloat(damage.MinDamage, damage.MaxDamage)).Clamp(0, MaxHealth);
        }
    }
}
