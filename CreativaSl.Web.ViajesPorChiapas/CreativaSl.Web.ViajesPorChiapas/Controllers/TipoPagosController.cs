using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    [Compress]
    public class TipoPagosController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: TipoPagos
        [Autorizado]
        [HttpGet]
        public ActionResult Index(string id)
        {
            try
            {
                TipoPagosDetalleModels tipoPago = new TipoPagosDetalleModels();
                TipoPagosDetalleDatos tipoPagoDatos = new TipoPagosDetalleDatos();
                tipoPago.idioma = Session["locale"] == null ? 1 : 2;
                tipoPago.id_seccion = Session["idSeccion"].ToString();
                tipoPago.id_tipoPago = Convert.ToInt32(id);
                tipoPago.conexion = _conexion;
                tipoPago.id_metaTags = "0880D926-F339-41E6-BE00-085550F9C843";
                tipoPago.id_tipo = 1;
                tipoPago = tipoPagoDatos.ObtenerConfigTipoPago(tipoPago);
                return View(tipoPago);
            }
            catch
            {
                TipoPagosDetalleModels tipoPago = new TipoPagosDetalleModels();
                tipoPago.tablaDatosGenerales = new DataTable();
                tipoPago.tablaCaracteristicasEmpresa = new DataTable();
                tipoPago.tablaArticulos = new DataTable();
                tipoPago.tablaSeccion = new DataTable();
                tipoPago.tablaSecciones = new DataTable();
                tipoPago.tablaMetaTags = new DataTable();
                tipoPago.TablaPaquetesPopulares = new DataTable();
                tipoPago.TablaFormasDePago = new DataTable();
                return View(tipoPago);
            }
        }
        //  POST: /TipoPagos/CambiarIdioma/6
        [HttpPost]
        public ActionResult CambiarIdioma(string lang)
        {
            try
            {
                if (lang == "mx")
                    Session["locale"] = null;
                else
                    Session["locale"] = lang;
                string resultado = "OK";

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //  POST: /TipoPagos/MatarSession/6
        [HttpPost]
        public ActionResult MatarSession()
        {
            try
            {
                Session["idSeccion"] = null;
                string resultado = "OK";

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
