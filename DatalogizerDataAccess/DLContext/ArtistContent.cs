using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class ArtistContent
    {
        public long Id { get; set; }
        public long? ArtistId { get; set; }
        public long? ContentId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Content Content { get; set; }
    }
}
