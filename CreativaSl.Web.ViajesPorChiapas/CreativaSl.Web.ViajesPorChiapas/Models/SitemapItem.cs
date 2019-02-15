using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class SitemapItem
    {
        public DateTime? DateAdded { get; set; } // fecha
        public string ChangeFreq { get; set; } //“never”, “yearly”, “monthly”, “weekly”, "daily”, “hourly”, “always”
        public string URL { get; set; } // url
        public string Priority { get; set; } // 0.8-1.0: Homepage, subdomains, product info, major features, 0.4-0.7: Articles and blog entries, category pages, FAQs, 0.0-0.3: Outdated news, info that has become irrelevant

    }
}