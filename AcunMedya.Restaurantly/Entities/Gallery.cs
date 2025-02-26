using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Time { get; set; }
    }
}