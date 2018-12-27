using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class RenderChildren
    {
        public int RenderChildId { get; set; }
        public int RenderId { get; set; }
        public int? RenderEntityRenderEntityId { get; set; }

        public virtual RenderEntities RenderEntityRenderEntity { get; set; }
    }
}
