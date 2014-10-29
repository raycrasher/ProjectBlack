using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBlack.Utilities;

namespace ProjectBlack
{
    public static class Game
    {
        public static World World;
        public readonly static Random Rng = new Random();

        public static TimeSpan DeltaTime { get; private set; }

        public static void Initialize() {
            System.IO.Directory.SetCurrentDirectory("../../..");
            Graphics.Initialize();
            Graphics.RenderWindow.Closed += (o,e) => Quit();

            UI.Initialize();
        }

        public static Coroutine StartCoroutine(IEnumerable routine) {
            var r = new Coroutine(routine);
            Coroutines.AddLast(r);
            r.Resume();
            return r;
            
        }

        static void Main(string[] args) {
            Initialize();

            Scenes.MainMenuScene.Run();

            GameLoop();
        }

        

        private static void GameLoop() {

            DeltaTime = TimeSpan.FromSeconds(1f / Graphics.Settings.FramerateLimit);
            while (!_exitGame) {
                Graphics.RenderWindow.Clear(SFML.Graphics.Color.Black);

                HandleInput();
                RunCoroutines();

                Graphics.Render();
            }
        }

        private static void RunCoroutines()
        {
            LinkedListNode<Coroutine> node = Coroutines.First;
            while (node != null)
            {
                var thisNode = node;
                node = node.Next;

                if (thisNode.Value.Status == CoroutineStatus.Stopped) {
                    Coroutines.Remove(thisNode);
                    continue;
                }
                else if (thisNode.Value.Status == CoroutineStatus.Paused)
                {
                    continue;
                }
                

                if (thisNode.Value.DelayTimer > TimeSpan.Zero)
                {
                    thisNode.Value.DelayTimer -= DeltaTime;
                    continue;
                }
 
                if (!thisNode.Value.Run())
                {
                    Coroutines.Remove(thisNode);
                }
            }
        }

        private static void HandleInput()
        {
            Graphics.RenderWindow.DispatchEvents();
        }

        public static void Quit() {
            _exitGame = true;
        }

        private static bool _exitGame = false;
        private static LinkedList<Coroutine> Coroutines = new LinkedList<Coroutine>();
        public static float PhysicsScale = 0.01f;
        public static SFML.Graphics.RenderWindow RenderWindow { get { return Graphics.RenderWindow; } }


    }
}
