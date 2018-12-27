namespace SB.Domain.Models
{
    public class Vertex
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Vertex" /> struct.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="textureCoordinate">The position.</param>
        /// <param name="normal"></param>
        public Vertex(int position, int textureCoordinate, int normal)
        {
            this.Position = position;
            this.TextureCoordinate = textureCoordinate;
            this.Normal = normal;
        }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public int Position { get; set; }

        /// <summary>
        ///     Gets or sets the normal.
        /// </summary>
        /// <value>
        ///     The normal.
        /// </value>
        public int Normal { get; set; }

        /// <summary>
        ///     Gets or sets the TextureCoordinate.
        /// </summary>
        /// <value>
        ///     The TextureCoordinate.
        /// </value>
        public int TextureCoordinate { get; set; }
    }
}