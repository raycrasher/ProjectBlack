using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public class RendererComponent : Component
    {
        public LinkedListNode<RendererComponent> RenderNode;

        public override void Start()
        {
            base.Start();
        }

        protected virtual void Draw() { }

        public void Render() {
            if (OnBeforeRender != null) OnBeforeRender(this);
            Draw();
            if (OnAfterRender != null) OnAfterRender(this);
        }
        public event Action<RendererComponent> OnBeforeRender, OnAfterRender;
    }
}
