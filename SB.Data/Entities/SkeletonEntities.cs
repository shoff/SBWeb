using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class SkeletonEntities
    {
        public SkeletonEntities()
        {
            MotionEntities = new HashSet<MotionEntities>();
        }

        public int SkeletonEntityId { get; set; }
        public string SkeletonText { get; set; }
        public int MotionIdCounter { get; set; }
        public int DistinctMotionCounter { get; set; }

        public virtual ICollection<MotionEntities> MotionEntities { get; set; }
    }
}
