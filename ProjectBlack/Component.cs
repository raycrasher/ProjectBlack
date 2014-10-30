using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class Component
    {
        public GameObject GameObject { get; set; }

        public virtual void Start(){}
        public virtual void Stop(){}

        public IEnumerable<T> GetComponents<T>() where T: Component {
            return GameObject.Components.OfType<T>();
        }

        public T GetComponent<T>() where T : Component
        {
            if (GameObject == null) return default(T);
            return GameObject.Components.OfType<T>().FirstOrDefault();
        }
    }
}
