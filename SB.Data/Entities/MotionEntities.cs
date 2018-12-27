using System;
using System.Collections.Generic;

namespace SB.Data.Entities
{
    public partial class MotionEntities
    {
        public int MotionEntityId { get; set; }
        public long CacheIdentity { get; set; }
        public int? SkeletonEntitySkeletonEntityId { get; set; }

        public virtual SkeletonEntities SkeletonEntitySkeletonEntity { get; set; }
    }
}
