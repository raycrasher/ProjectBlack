using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Creatures
{
    public static class CreatureFactory
    {
        public static GameObject CreateHuman(string name) {

            var creature = new CreatureComponent();
            

            var body = new BodyPartComponent("body", creature) { Size = 10, IsEssential=true };
            var head = new BodyPartComponent("head", creature, body, true) { Size = 50, IsEssential=true };
            var rightarm = new BodyPartComponent("right arm", creature, body, true) { Size = 20 };
            var leftarm = new BodyPartComponent("left arm", creature, body, true) { Size = 20 };
            var righthand = new BodyPartComponent("right hand", creature, rightarm, true) { Size = 5 };
            var lefthand = new BodyPartComponent("left hand", creature, leftarm, true) { Size = 5 };
            var rightleg = new BodyPartComponent("right leg", creature, body, true) { Size = 25 };
            var leftleg = new BodyPartComponent("left leg", creature, body, true) { Size = 25 };
            var rightfoot = new BodyPartComponent("right foot", creature, rightleg, true) { Size = 7.5f };
            var leftfoot = new BodyPartComponent("left foot", creature, leftleg, true) { Size = 7.5f };

            var human = new GameObject(name, creature,
                body, head, rightarm, leftarm, righthand, lefthand, rightleg, leftleg, rightfoot, leftfoot
                );

            creature.Size = creature.BodyParts.Sum(s => s.Size);
            
            
            return human;
        }
    }
}
