﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Creatures
{
    public class CreatureComponent: Component
    {
        public HashSet<BodyPartComponent> BodyParts { get; private set; }

        public CreatureComponent() {
            BodyParts = new HashSet<BodyPartComponent>();
        }


        public float Size { get; set; }
    }
}
