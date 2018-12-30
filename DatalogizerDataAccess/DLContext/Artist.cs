using System;
using System.Collections.Generic;

namespace DatalogizerDataAccess.DLContext
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistContent = new HashSet<ArtistContent>();
            Image = new HashSet<Image>();
            Website = new HashSet<Website>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Aka { get; set; }

        public virtual ICollection<ArtistContent> ArtistContent { get; set; }
        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<Website> Website { get; set; }
    }
}
