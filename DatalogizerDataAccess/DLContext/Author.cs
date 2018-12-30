using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class Author
    {
        public Author()
        {
            AuthorContent = new HashSet<AuthorContent>();
            Image = new HashSet<Image>();
            Website = new HashSet<Website>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorContent> AuthorContent { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<Website> Website { get; set; }
    }
}
