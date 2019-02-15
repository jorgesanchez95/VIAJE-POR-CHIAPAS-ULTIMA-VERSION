using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CreativaSl.Web.ViajesPorChiapas.Filters
{
    public class AutorizadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Session["locale"] != null)
                HttpContext.Current.Session["locale"] = HttpContext.Current.Session["locale"].ToString();

            if (HttpContext.Current.Session["idSeccion"] != null)
                HttpContext.Current.Session["idSeccion"] = HttpContext.Current.Session["idSeccion"].ToString();
            else
                HttpContext.Current.Session["idSeccion"] = "AF43EC32-02B3-4B57-847D-E872C02217B9";
            
            if (HttpContext.Current.Session["idSeccion"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
            }
        }
    }
}