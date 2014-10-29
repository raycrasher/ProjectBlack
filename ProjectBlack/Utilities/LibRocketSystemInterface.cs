using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Utilities
{
    public class LibRocketSystemInterface: LibRocketNet.SystemInterface
    {
        // public virtual void ActivateKeyboard();
        // public virtual void DeactivateKeyboard();
        // public override sealed void Dispose();
        


        public override float GetElapsedTime()
        {
            return (float)Game.DeltaTime.TotalSeconds;
        }

        //public virtual void JoinPath(ref string translatedPath, string documentPath, string path);
        
        public override bool LogMessage(LibRocketNet.LogType type, string message) {
            Console.WriteLine(message);
            return true;
        }

        //public virtual int TranslateString(ref string translated, string input) { 
        //
        //}
    }
}
