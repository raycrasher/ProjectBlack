using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class Scene
    {
        public LinkedList<GameObject> Objects = new LinkedList<GameObject>();

        public void Add(GameObject obj) {
            obj.Node = Objects.AddLast(obj);

            foreach (var comp in obj.Components)
                comp.Start();
        }
    }
}
