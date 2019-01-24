namespace SB.Data.Entities
{
    public class RenderChildren
    {
        public int RenderChildId { get; set; }
        public int RenderId { get; set; }
        public int? RenderEntityRenderEntityId { get; set; }

        public virtual RenderEntities RenderEntityRenderEntity { get; set; }
    }
}
