using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack.Scenes
{
    public static class MainMenuScene
    {
        public static LibRocketNet.ElementDocument Document { get; private set; }

        public static void Run() { 
            Document = UI.MainContext.LoadDocument("Data/MainMenu/MainMenu.xml");
            Document.Show();
        }
    }
}
