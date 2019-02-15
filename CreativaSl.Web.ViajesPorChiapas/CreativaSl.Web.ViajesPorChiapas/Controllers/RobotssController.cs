using CreativaSl.Web.ViajesPorChiapas.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    [Compress]
    public class RobotssController : Controller
    {
        public FileContentResult RobotsText()
        {
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("User-agent: *");
            contentBuilder.AppendLine("Disallow: /Content");
            contentBuilder.AppendLine("Disallow: /Scripts");
            contentBuilder.AppendLine("Disallow: /admin");
            contentBuilder.AppendLine("Disallow: /Admin");
            contentBuilder.AppendLine("Sitemap: http://www.viajeporchiapas.com/sitemap.xml");
            return File(Encoding.UTF8.GetBytes(contentBuilder.ToString()), "text/plain");
        }
    }
}