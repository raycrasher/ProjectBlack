using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Combat
{
    public class MeleeWeaponComponent: Component, IWeapon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AttackMode[] AttackModes { get; set; }
        public int CurrentAttackMode { get; set; }

        public void Attack(IDamageable obj) { 
            
        }
    }
}
