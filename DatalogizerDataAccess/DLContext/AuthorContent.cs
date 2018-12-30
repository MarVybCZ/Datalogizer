using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class AuthorContent
    {
        public long Id { get; set; }
        public long? AuthorId { get; set; }
        public long? ContentId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Content Content { get; set; }
    }
}
