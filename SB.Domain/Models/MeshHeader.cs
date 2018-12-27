namespace SB.Domain.Models
{
    using System.Numerics;

    public struct MeshHeader
    {
        public uint null1; // 4
        public double unixUpdatedTimeStamp; // 8
        public double unk3; // 
        public double unixCreatedTimeStamp;
        public double unk5;
        public Vector3 min;
        public Vector3 max;
        public ushort null2;
    }
}