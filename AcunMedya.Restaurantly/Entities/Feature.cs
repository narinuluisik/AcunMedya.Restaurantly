using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string  SubTitle { get; set; }
        public string  Title { get; set; }
        public string  VideoUrl { get; set; }
        public string  ImageUrl { get; set; }
    }
}