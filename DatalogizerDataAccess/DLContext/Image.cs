using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class Image
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public long? Order { get; set; }
        public long? ContentId { get; set; }
        public long? ArtistId { get; set; }
        public long? AuthorId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Author Author { get; set; }
        public virtual Content Content { get; set; }
    }
}
