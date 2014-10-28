using LibRocketNet;
using SFML.Window;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public static class UI
    {
        static public LibRocketNet.Context Context;


        static SFML.Graphics.RenderTexture RenderTexture;
        static Utilities.LibRocketRenderInterface RenderInterface;
        static Utilities.LibRocketSystemInterface SystemInterface;

        public static void Initialize() {
            RenderTexture = new SFML.Graphics.RenderTexture(Graphics.Settings.ScreenWidth, Graphics.Settings.ScreenHeight);
            RenderInterface = new Utilities.LibRocketRenderInterface(RenderTexture);
            SystemInterface = new Utilities.LibRocketSystemInterface();
            LibRocketNet.Core.RenderInterface = RenderInterface;
            LibRocketNet.Core.SystemInterface = SystemInterface;
            LibRocketNet.Core.Initialize();

            Game.RenderWindow.KeyPressed += KeyDownHandler;
            Game.RenderWindow.KeyReleased += KeyUpHandler;
            Game.RenderWindow.MouseButtonPressed +=
                (o, e) => Context.ProcessMouseButtonDown((int)e.Button, GetKeyModifiers());

            Game.RenderWindow.MouseButtonReleased +=
                (o, e) => Context.ProcessMouseButtonUp((int)e.Button, GetKeyModifiers());

            Game.RenderWindow.MouseWheelMoved += (o, e) => Context.ProcessMouseWheel(-e.Delta, GetKeyModifiers());

            Game.RenderWindow.MouseMoved += (o, e) => Context.ProcessMouseMove(e.X, e.Y, GetKeyModifiers());

            Context = LibRocketNet.Core.CreateContext("main", new LibRocketNet.Vector2i((int)Graphics.Settings.ScreenWidth, (int)Graphics.Settings.ScreenHeight));

            Game.StartCoroutine(UpdateAndRender());
        }

        private static void KeyUpHandler(object sender, KeyEventArgs e)
        {
            Context.ProcessKeyUp(TranslateKey(e.Code), GetKeyModifiers());
        }

        private static void KeyDownHandler(object sender, SFML.Window.KeyEventArgs e)
        {
            Context.ProcessKeyDown(TranslateKey(e.Code), GetKeyModifiers());
        }

        public static IEnumerable UpdateAndRender()
        {
            while (true) {
                Context.Update();
                Context.Render();
                yield return null;
            }
            
        }

        private static KeyModifier GetKeyModifiers()
        {
            KeyModifier modifiers = 0;

            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) ||
                Keyboard.IsKeyPressed(Keyboard.Key.RShift))
                modifiers |= KeyModifier.Shift;

            if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) ||
                Keyboard.IsKeyPressed(Keyboard.Key.RControl))
                modifiers |= KeyModifier.Control;

            if (Keyboard.IsKeyPressed(Keyboard.Key.LAlt) ||
                Keyboard.IsKeyPressed(Keyboard.Key.RAlt))
                modifiers |= KeyModifier.Alt;

            return modifiers;
        }

        private static KeyIdentifiers TranslateKey(Keyboard.Key key)
        {
            switch (key)
            {
                case Keyboard.Key.A:
                    return KeyIdentifiers.A;
                case Keyboard.Key.B:
                    return KeyIdentifiers.B;

                case Keyboard.Key.C:
                    return KeyIdentifiers.C;

                case Keyboard.Key.D:
                    return KeyIdentifiers.D;

                case Keyboard.Key.E:
                    return KeyIdentifiers.E;

                case Keyboard.Key.F:
                    return KeyIdentifiers.F;

                case Keyboard.Key.G:
                    return KeyIdentifiers.G;

                case Keyboard.Key.H:
                    return KeyIdentifiers.H;

                case Keyboard.Key.I:
                    return KeyIdentifiers.I;

                case Keyboard.Key.J:
                    return KeyIdentifiers.J;

                case Keyboard.Key.K:
                    return KeyIdentifiers.K;

                case Keyboard.Key.L:
                    return KeyIdentifiers.L;

                case Keyboard.Key.M:
                    return KeyIdentifiers.M;

                case Keyboard.Key.N:
                    return KeyIdentifiers.N;

                case Keyboard.Key.O:
                    return KeyIdentifiers.O;

                case Keyboard.Key.P:
                    return KeyIdentifiers.P;

                case Keyboard.Key.Q:
                    return KeyIdentifiers.Q;

                case Keyboard.Key.R:
                    return KeyIdentifiers.R;

                case Keyboard.Key.S:
                    return KeyIdentifiers.S;

                case Keyboard.Key.T:
                    return KeyIdentifiers.T;

                case Keyboard.Key.U:
                    return KeyIdentifiers.U;

                case Keyboard.Key.V:
                    return KeyIdentifiers.V;

                case Keyboard.Key.W:
                    return KeyIdentifiers.W;

                case Keyboard.Key.X:
                    return KeyIdentifiers.X;

                case Keyboard.Key.Y:
                    return KeyIdentifiers.Y;

                case Keyboard.Key.Z:
                    return KeyIdentifiers.Z;

                case Keyboard.Key.Num0:
                    return KeyIdentifiers.Num0;

                case Keyboard.Key.Num1:
                    return KeyIdentifiers.Num1;

                case Keyboard.Key.Num2:
                    return KeyIdentifiers.Num2;

                case Keyboard.Key.Num3:
                    return KeyIdentifiers.Num3;

                case Keyboard.Key.Num4:
                    return KeyIdentifiers.Num4;

                case Keyboard.Key.Num5:
                    return KeyIdentifiers.Num5;

                case Keyboard.Key.Num6:
                    return KeyIdentifiers.Num6;

                case Keyboard.Key.Num7:
                    return KeyIdentifiers.Num7;

                case Keyboard.Key.Num8:
                    return KeyIdentifiers.Num8;

                case Keyboard.Key.Num9:
                    return KeyIdentifiers.Num9;

                case Keyboard.Key.Numpad0:
                    return KeyIdentifiers.Numpad0;

                case Keyboard.Key.Numpad1:
                    return KeyIdentifiers.Numpad1;

                case Keyboard.Key.Numpad2:
                    return KeyIdentifiers.Numpad2;

                case Keyboard.Key.Numpad3:
                    return KeyIdentifiers.Numpad3;

                case Keyboard.Key.Numpad4:
                    return KeyIdentifiers.Numpad4;

                case Keyboard.Key.Numpad5:
                    return KeyIdentifiers.Numpad5;

                case Keyboard.Key.Numpad6:
                    return KeyIdentifiers.Numpad6;

                case Keyboard.Key.Numpad7:
                    return KeyIdentifiers.Numpad7;

                case Keyboard.Key.Numpad8:
                    return KeyIdentifiers.Numpad8;

                case Keyboard.Key.Numpad9:
                    return KeyIdentifiers.Numpad9;

                case Keyboard.Key.Left:
                    return KeyIdentifiers.Left;

                case Keyboard.Key.Right:
                    return KeyIdentifiers.Right;

                case Keyboard.Key.Up:
                    return KeyIdentifiers.Up;

                case Keyboard.Key.Down:
                    return KeyIdentifiers.Down;

                case Keyboard.Key.Add:
                    return KeyIdentifiers.Add;

                case Keyboard.Key.Back:
                    return KeyIdentifiers.Back;

                case Keyboard.Key.Delete:
                    return KeyIdentifiers.Delete;

                case Keyboard.Key.Divide:
                    return KeyIdentifiers.Divide;

                case Keyboard.Key.End:
                    return KeyIdentifiers.End;

                case Keyboard.Key.Escape:
                    return KeyIdentifiers.Escape;

                case Keyboard.Key.F1:
                    return KeyIdentifiers.F1;

                case Keyboard.Key.F2:
                    return KeyIdentifiers.F2;

                case Keyboard.Key.F3:
                    return KeyIdentifiers.F3;

                case Keyboard.Key.F4:
                    return KeyIdentifiers.F4;

                case Keyboard.Key.F5:
                    return KeyIdentifiers.F5;

                case Keyboard.Key.F6:
                    return KeyIdentifiers.F6;

                case Keyboard.Key.F7:
                    return KeyIdentifiers.F7;

                case Keyboard.Key.F8:
                    return KeyIdentifiers.F8;

                case Keyboard.Key.F9:
                    return KeyIdentifiers.F9;

                case Keyboard.Key.F10:
                    return KeyIdentifiers.F10;

                case Keyboard.Key.F11:
                    return KeyIdentifiers.F11;

                case Keyboard.Key.F12:
                    return KeyIdentifiers.F12;

                case Keyboard.Key.F13:
                    return KeyIdentifiers.F13;

                case Keyboard.Key.F14:
                    return KeyIdentifiers.F14;

                case Keyboard.Key.F15:
                    return KeyIdentifiers.F15;

                case Keyboard.Key.Home:
                    return KeyIdentifiers.Home;

                case Keyboard.Key.Insert:
                    return KeyIdentifiers.Insert;

                case Keyboard.Key.LControl:
                    return KeyIdentifiers.LControl;

                case Keyboard.Key.LShift:
                    return KeyIdentifiers.LShift;

                case Keyboard.Key.Multiply:
                    return KeyIdentifiers.Multiply;

                case Keyboard.Key.Pause:
                    return KeyIdentifiers.Pause;

                case Keyboard.Key.RControl:
                    return KeyIdentifiers.RControl;

                case Keyboard.Key.Return:
                    return KeyIdentifiers.Return;

                case Keyboard.Key.RShift:
                    return KeyIdentifiers.RShift;

                case Keyboard.Key.Space:
                    return KeyIdentifiers.Space;

                case Keyboard.Key.Subtract:
                    return KeyIdentifiers.Subtract;

                case Keyboard.Key.Tab:
                    return KeyIdentifiers.Tab;
            }


            return KeyIdentifiers.Unknown;
        }
    }
}
