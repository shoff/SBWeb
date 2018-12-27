namespace SB.Domain
{
    using Extensions;
    using Newtonsoft.Json;

    public class CacheAsset
    {
        // I'm beginning to wonder if Item1 and Item2 are actually Male/Female versions of this
        public CacheIndex CacheIndex1 { get; set; }
        public CacheIndex CacheIndex2 { get; set; }
        public CacheIndex CacheIndex3 { get; set; }

        [JsonIgnore]
        public byte[] Item1 { get; set; }
        public string Item1AsString => Item1.ToHexString(" ");

        [JsonIgnore]
        public byte[] Item2 { get; set; }
        public string Item2AsString => Item2.ToHexString(" ");

        [JsonIgnore]
        public byte[] Item3 { get; set; }
        public string Item3AsString => Item3.ToHexString(" ");

        public long BuildTime { get; set; }

        public override string ToString()
        {
            if (this.CacheIndex2.Identity == 0)
            {
                return this.CacheIndex1.ToString();
            }

            return $"{this.CacheIndex1}\r\n{this.CacheIndex2}";
        }
    }
}