namespace SB.Domain
{
    using System;
    using System.Text;

    public class CacheIndex : IComparable<CacheIndex>, IEquatable<CacheIndex>
    {
        //    Junk1 = reader.ReadUInt32(),
        //    Identity = reader.ReadInt32(),
        //    Offset = reader.ReadUInt32(),
        //    UnCompressedSize = reader.ReadUInt32(),
        //    CompressedSize = reader.ReadUInt32()
        public CacheIndex(
            int index,
            uint junk1,
            uint identity,
            uint offset,
            uint uncompressedSize,
            uint compressedSize,
            ushort order,
            string name,
            uint flag)
        {
            this.Index = index;
            this.Identity = identity;
            this.Junk1 = junk1;
            this.Offset = offset;
            this.UnCompressedSize = uncompressedSize;
            this.CompressedSize = compressedSize;
            this.Order = order;
            this.Name = name;
            this.Flag = flag;
        }
        public int Index { get; }
        public uint Identity { get; }
        public uint Junk1 { get; }
        public uint Offset { get; }
        public uint UnCompressedSize { get; }
        public uint CompressedSize { get; }
        public ushort Order { get; } // not really part of the index
        public string Name { get; }
        public uint Flag { get; } // this is ALWAYS 0

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("CacheIndex Object\r\n");
            sb.AppendFormat("identity {0}\r\n", this.Identity);
            sb.AppendFormat("junk1 {0}\r\n", this.Junk1);
            sb.AppendFormat("offset {0}\r\n", this.Offset);
            sb.AppendFormat("unCompressedSize {0}\r\n", this.UnCompressedSize);
            sb.AppendFormat("compressedSize {0}\r\n", this.CompressedSize);
            sb.AppendFormat("order {0}\r\n", this.Order);
            sb.AppendFormat("name {0}\r\n", this.Name ?? "no name");
            sb.AppendFormat("flag {0}\r\n", this.Flag);
            return sb.ToString();
        }

        public int CompareTo(CacheIndex other)
        {
            if (this.Flag == other.Flag)
            {
                return 0;
            }

            if (this.Flag > other.Flag)
            {
                return 1;
            }

            return -1;
        }

        /// <summary>
        ///     Determines if a <see cref="CacheIndex" /> item is the same.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(CacheIndex other)
        {
            if (other.Identity != this.Identity)
            {
                return false;
            }

            if (other.Offset != this.Offset)
            {
                return false;
            }

            if (other.Flag != this.Flag)
            {
                return false;
            }

            if (other.Order != this.Order)
            {
                return false;
            }

            return true;
        }
    }
}