using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class DrawableRendererComponent: RendererComponent
    {
        public Drawable Drawable;
        public RenderTarget Target;

        public TransformComponent Transform;

        public DrawableRendererComponent(RenderTarget target, Drawable drawable) {
            Drawable = drawable;
            Target = target;
        }

        public override void Start()
        {
            base.Start();
            Transform = GetComponent<TransformComponent>();
        }

        protected override void Draw()
        {
            if (Transform != null)
                Target.Draw(Drawable, new RenderStates(Transform.Transform.Transform));
            else Target.Draw(Drawable);
        }
    }
}
