using FarseerPhysics.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Physics
{
    [Serializable]
    public class ColliderComponent : Component
    {
        public Fixture Fixture;
        
    }
}
