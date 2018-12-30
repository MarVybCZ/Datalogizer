using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class Content
    {
        public Content()
        {
            ArtistContent = new HashSet<ArtistContent>();
            AuthorContent = new HashSet<AuthorContent>();
            ContentType = new HashSet<ContentType>();
            Image = new HashSet<Image>();
            Tag = new HashSet<Tag>();
            Website = new HashSet<Website>();
        }

        public long Id { get; set; }
        public string IsFolder { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? Rating { get; set; }
        public string Date { get; set; }

        public virtual ICollection<ArtistContent> ArtistContent { get; set; }
        public virtual ICollection<AuthorContent> AuthorContent { get; set; }
        public virtual ICollection<ContentType> ContentType { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual ICollection<Website> Website { get; set; }
    }
}
