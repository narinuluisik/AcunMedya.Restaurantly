using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public DateTime Time{ get; set; }
        public string Icon{ get; set; }
        public string Iconcolor{ get; set; }
        public string IsRead{ get; set; }
    }
}