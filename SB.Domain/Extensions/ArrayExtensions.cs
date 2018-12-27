namespace SB.Domain.Extensions
{
    using System.IO;
    using System.Text;

    public static class ArrayExtensions
    {
        public static BinaryReader CreateBinaryReaderUtf32(this byte[] segment)
        {
            return new BinaryReader(segment.CreateStream(), Encoding.UTF32);
        }

        public static Stream CreateStream(this byte[] segment)
        {
            return new MemoryStream(segment);
        }

        public static string ToHexString(this byte[] segment, string prefix)
        {
            char[] lookup = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            if (segment == null)
            {
                return "";
            }

            int i = 0, p = prefix.Length, l = segment.Length;
            char[] c = new char[l * 2 + p];
            byte d;
            for (; i < p; ++i)
            {
                c[i] = prefix[i];
            }

            i = -1;
            --l;
            --p;
            while (i < l)
            {
                d = segment[++i];
                c[++p] = lookup[d >> 4];
                c[++p] = lookup[d & 0xF];
            }
            return new string(c, 0, c.Length);
        }
    }
}