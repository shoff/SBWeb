﻿using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class Cobjects
    {
        public int CobjectsId { get; set; }
        public int Identity { get; set; }
        public int Junk1 { get; set; }
        public int Offset { get; set; }
        public int UnCompressedSize { get; set; }
        public int CompressedSize { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
