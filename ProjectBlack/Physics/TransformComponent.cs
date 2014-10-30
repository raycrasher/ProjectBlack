using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class TransformComponent : Component
    {
        public Vector2f Position { 
            get { return Transform.Position; } 
            set { Transform.Position = value; }
        }

        public float Rotation { 
            get { return Transform.Rotation; } 
            set { Transform.Rotation = value; }
        }

        public Vector2f Scale { 
            get { return Transform.Scale; } 
            set { Transform.Scale = value; }
        }

        public Vector2f Origin { 
            get { return Transform.Origin; } 
            set { Transform.Origin = value; }
        }

        public SFML.Graphics.Transformable Transform = new SFML.Graphics.Transformable();
    }
}
