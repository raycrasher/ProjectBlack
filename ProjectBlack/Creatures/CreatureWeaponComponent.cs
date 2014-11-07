using ProjectBlack.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Creatures
{
    public class CreatureWeaponComponent : Component
    {
        public IWeapon LinkedWeapon;
        public BodyPartComponent BodyPart;
        public CreatureComponent Creature;

    }
}
