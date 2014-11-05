using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class GameObject
    {
        public GameObject() {
            Components = new HashSet<Component>();
            Children = new HashSet<GameObject>();
        }

        public GameObject(params Component[] components): this() {
            foreach (var c in components) Components.Add(c);
        }

        public GameObject(string name): this()
        {
            Name = name;
        }

        public GameObject(string name, params Component[] components): this(name) 
        {
            foreach (var c in components) Components.Add(c);
        }

        public void Destroy() {
            if (Node != null)
            {
                foreach (var c in Components) c.Stop();
                Node.List.Remove(Node);
            }
        }

        public HashSet<Component> Components { get; private set; }
        public HashSet<GameObject> Children { get; private set; }
        public LinkedListNode<GameObject> Node { get; set; }
        public string Name { get; set; }
    }
}
