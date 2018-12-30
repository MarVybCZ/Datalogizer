using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? ContentId { get; set; }

        public virtual Content Content { get; set; }
    }
}
