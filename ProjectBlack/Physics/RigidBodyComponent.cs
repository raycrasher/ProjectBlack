using FarseerPhysics.Dynamics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Physics
{
    public class RigidBodyComponent : Component
    {
        public Body Body;

        public SFML.Graphics.Transformable Transform;

        public override void Start()
        {
            Transform = GetComponent<TransformComponent>().Transform;
            Body = new Body(Game.World.Physics, Transform.Position.ToPhysics(), Transform.Rotation.ToRadians(), this);
        }

        public void UpdateTransform() {
            Transform.Position = Body.Position.ToSfml();
            Transform.Rotation = Body.Rotation.ToDegrees();
        }
    }
}
