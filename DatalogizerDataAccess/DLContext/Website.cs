using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class Website
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public long? ArtistId { get; set; }
        public long? AuthorId { get; set; }
        public long? ContentId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Author Author { get; set; }
        public virtual Content Content { get; set; }
    }
}
