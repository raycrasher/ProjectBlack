using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class World
    {
        public FarseerPhysics.Dynamics.World Physics;
        public LinkedList<GameObject> Objects = new LinkedList<GameObject>();

        public World() {
            Physics = new FarseerPhysics.Dynamics.World(Vector2.Zero);
        }

        public void AddGameObject(GameObject obj) {
            obj.Node = Objects.AddLast(obj);
            foreach (var c in obj.Components) c.Start();
        }
    }
}
