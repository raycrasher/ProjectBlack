using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Combat
{
    public enum AttackType { 
        Melee, Ranged, Death, Special
    }

    public enum DamageType { 
        Piercing, Slashing, Impact, Blast,    // area of damage: point (0d), edge(1d), surface(2d), whole body(3d) damage 
        Melee, Ballistic, Thermal, Electric
    }

    public interface IWeapon
    {
        string Name { get; set; }
        string Description { get; set; }
        AttackMode[] AttackModes { get; set; }
        int CurrentAttackMode { get; set; }

        void Attack(IDamageable obj);
    }
}
