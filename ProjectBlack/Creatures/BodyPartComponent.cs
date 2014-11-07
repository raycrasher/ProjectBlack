using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Creatures
{

    public class BodyPartComponent: ProjectBlack.Combat.HealthComponent
    {
        public BodyPartComponent(string name, CreatureComponent creature, BodyPartComponent parent=null, bool isLimb=false)
        {
            Name = name;
            Creature = creature;
            IsLimb = isLimb;
        }

        public BodyPartComponent Parent { get; set; }
        public bool IsLimb { get; set; }
        public bool IsEssential { get; set; }
        public string Name { get; set; }
        public float Size { get; set; }

        public CreatureComponent Creature { get; set; }
    }
}
