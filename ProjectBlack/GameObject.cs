using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class GameObject
    {
        public GameObject() { }

        public GameObject(params Component[] components) {
            foreach (var c in components) Components.Add(c);
        }

        public void Destroy() {
            if (Node != null)
            {
                foreach (var c in Components) c.Stop();
                Node.List.Remove(Node);
            }
        }

        public HashSet<Component> Components = new HashSet<Component>();
        public LinkedListNode<GameObject> Node;
    }
}
