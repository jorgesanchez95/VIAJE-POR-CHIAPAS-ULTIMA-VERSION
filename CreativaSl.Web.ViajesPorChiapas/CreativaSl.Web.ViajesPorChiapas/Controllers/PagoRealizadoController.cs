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
    public class PagoRealizadoController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: PagoRealizado
        [Autorizado]
        [HttpGet]
        public ActionResult Index(string id_pagoOnline, string id_solicitud)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.id_pagoOnline = id_pagoOnline;
                cliente.id_solicitud = id_solicitud;
                cliente.conexion = _conexion;
                cliente.opcion = 2;
                cliente.id_metaTags = "69681047-20E4-4A9C-A65C-6628E954DD28";
                cliente.id_tipo = 1;
                cliente = clienteDatos.RegistrarPagoComprarCotizacionesSolicitudPaypal(cliente);
                cliente = clienteDatos.ObtenerConfigPagoRealizado(cliente);
                return View(cliente);
            }
            catch
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                cliente.tablaMetaTags = new DataTable();
                cliente.TablaFormasDePago = new DataTable();
                cliente.TablaPaquetesPopulares = new DataTable();
                return View(cliente);
            }
        }
        //  POST: /Contactanos/CambiarIdioma/6
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

        //  POST: /Contactanos/MatarSession/6
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