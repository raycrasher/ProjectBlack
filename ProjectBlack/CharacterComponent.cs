using FarseerPhysics.Dynamics;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBlack.Utilities;

namespace ProjectBlack
{
    public class CharacterComponent : Component
    {
        public Transformable Transform;
        public Body PhysicsBody;

        public override void Start()
        {
            PhysicsBody = new Body(Game.World.Physics, Transform.Position.ToPhysics(), 0, this);
        }

        protected void Update() { 
            
        }
    }
}
