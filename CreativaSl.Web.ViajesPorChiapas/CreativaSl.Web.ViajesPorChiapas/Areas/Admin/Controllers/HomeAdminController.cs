using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
