using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using Newtonsoft.Json;
using ProjectBlack.Utilities;

namespace ProjectBlack
{
    public class GraphicsSettings {
        public uint ScreenWidth = 1024, ScreenHeight = 768;
        public bool Fullscreen = false;
        public bool VSync = true;
        public uint FramerateLimit = 30;
    }

    public static class Graphics {

        
        public static List<Texture> Textures = new List<Texture>();
        public static List<Sprite> Sprites = new List<Sprite>();
        public static RenderWindow RenderWindow;
        public static VertexArray Vertices = new VertexArray(PrimitiveType.Quads);
        public static GraphicsSettings Settings;



        public static void RenderMap()
        {
            RenderWindow.Draw(Vertices);
        }

        public static void Initialize()
        {
            try {
                Settings = JsonUtilities.LoadJson<GraphicsSettings>("GraphicsSettings.json");
            }
            catch {
                Settings = new GraphicsSettings();
            }

            JsonUtilities.WriteJson(Settings, "GraphicsSettings.json");

            var mode = new SFML.Window.VideoMode(Settings.ScreenWidth, Settings.ScreenHeight, 32);

            RenderWindow = new RenderWindow(mode, "project/Black",
                Settings.Fullscreen ? SFML.Window.Styles.Fullscreen : SFML.Window.Styles.Default
                );

            RenderWindow.SetVerticalSyncEnabled(Settings.VSync);
            RenderWindow.SetFramerateLimit(Settings.FramerateLimit);
        }

        internal static void Render()
        {
            RenderWindow.Display();
        }


    }
}
