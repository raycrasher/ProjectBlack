﻿using System;
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

        public const int LayerCount = 10;
        public const int DefaultCount = 5;
        public static Dictionary<String, Texture> Textures = new Dictionary<string, Texture>();
        public static Dictionary<String, Sprite> Sprites = new Dictionary<string, Sprite>();
        public static RenderWindow RenderWindow;
        public static VertexArray Vertices = new VertexArray(PrimitiveType.Quads);
        public static GraphicsSettings Settings;

        public static List<LinkedList<RendererComponent>> Layers = new List<LinkedList<RendererComponent>>();
        private static Color BackgroundColor = Color.Black;

        public static void RenderMap()
        {
            RenderWindow.Draw(Vertices);
        }

        public static void Initialize()
        {
            Console.WriteLine("Initializing Graphics...");
            try {
                Settings = JsonUtilities.LoadJson<GraphicsSettings>("GraphicsSettings.json");
            }
            catch {
                Settings = new GraphicsSettings();
            }

            JsonUtilities.WriteJson(Settings, "GraphicsSettings.json");

            for (int i = 0; i < LayerCount; i++) {
                Layers.Add(new LinkedList<RendererComponent>());
            }

            var mode = new SFML.Window.VideoMode(Settings.ScreenWidth, Settings.ScreenHeight, 32);
            
            RenderWindow = new RenderWindow(mode, "project/Black",
                Settings.Fullscreen ? SFML.Window.Styles.Fullscreen : SFML.Window.Styles.Default
                );


            OpenTK.Toolkit.Init();
            var context = new OpenTK.Graphics.GraphicsContext(new OpenTK.ContextHandle(IntPtr.Zero), null);

            RenderWindow.SetVerticalSyncEnabled(Settings.VSync);
            RenderWindow.SetFramerateLimit(Settings.FramerateLimit);
        }

        internal static void Render()
        {
            RenderWindow.Clear(BackgroundColor);
            foreach (var layer in Layers) {
                foreach (var renderable in layer)
                    renderable.Render();
            }
            
            RenderWindow.Display();
        }

        public static void AddRenderComponent(RendererComponent renderComponent, int layer = DefaultCount)
        {
            renderComponent.RenderNode = Layers[layer].AddLast(renderComponent);
        }
    }
}
