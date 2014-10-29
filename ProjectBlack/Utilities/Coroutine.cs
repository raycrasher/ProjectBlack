using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Utilities
{
    public enum CoroutineStatus { Stopped, Playing, Paused }

    public class Coroutine
    {
        private IEnumerator Routine;
        public TimeSpan DelayTimer;
        public CoroutineStatus Status {get; private set;}

        public Coroutine() {
            Status = CoroutineStatus.Paused;
        }

        public Coroutine(IEnumerable routine)
        {
            // TODO: Complete member initialization
            Status = CoroutineStatus.Paused;
            this.Routine = routine.GetEnumerator();
        }

        public void Stop() {
            if (Status != CoroutineStatus.Stopped)
            {
                Status = CoroutineStatus.Stopped;
            }
        }

        public void Resume()
        {
            if (Status == CoroutineStatus.Paused) {
                Status = CoroutineStatus.Playing;
            }
        }

        public void Paused()
        {
            if (Status == CoroutineStatus.Playing)
            {
                Status = CoroutineStatus.Paused;
            }
        }


        public bool Run()
        {
            Status = CoroutineStatus.Playing;
            return Routine.MoveNext();
        }
    }
}
