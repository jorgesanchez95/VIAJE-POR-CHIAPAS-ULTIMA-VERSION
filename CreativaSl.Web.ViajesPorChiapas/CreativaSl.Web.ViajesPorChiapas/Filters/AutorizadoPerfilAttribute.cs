using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CreativaSl.Web.ViajesPorChiapas.Filters
{
    public class AutorizadoPerfilAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Session["idCliente"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
            else
            {
                string id_cliente = HttpContext.Current.Session["idCliente"].ToString();
                string nombreCliente = HttpContext.Current.Session["nombreCliente"].ToString();

                HttpContext.Current.Session["idCliente"] = id_cliente;
                HttpContext.Current.Session["nombreCliente"] = nombreCliente;
            }
        }
    }
}