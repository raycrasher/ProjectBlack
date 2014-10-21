using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class CircularEnumerator<T> : IEnumerator<T>
    {
        IEnumerator<T> enumerator;

        public CircularEnumerator(IEnumerator<T> e)
        {
            enumerator = e;
        }

        public bool MoveNext() {
            if (!enumerator.MoveNext()) {
                enumerator.Reset();
                return enumerator.MoveNext();
            }
            return true;
        }

        public void Reset() {
            enumerator.Reset();
        }

        public T Current {
            get { return enumerator.Current; }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return enumerator.Current; }
        }

        void IDisposable.Dispose() { }
    }
}
