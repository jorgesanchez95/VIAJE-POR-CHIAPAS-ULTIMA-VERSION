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
    public class RecomendacionesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Recomendaciones
        [Autorizado]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                PreguntasFrecuentesDatos preguntasFrecuentesDatos = new PreguntasFrecuentesDatos();
                preguntasFrecuentes.idioma = Session["locale"] == null ? 1 : 2;
                preguntasFrecuentes.id_seccion = Session["idSeccion"].ToString();
                preguntasFrecuentes.conexion = _conexion;
                preguntasFrecuentes.id_metaTags = "768D8553-2324-4169-87A0-8B06DFD5F79A";
                preguntasFrecuentes.id_tipo = 1;
                preguntasFrecuentes = preguntasFrecuentesDatos.ObtenerConfigRecomendaciones(preguntasFrecuentes);
                return View(preguntasFrecuentes);
            }
            catch
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                preguntasFrecuentes.tablaDatosGenerales = new DataTable();
                preguntasFrecuentes.tablaCaracteristicasEmpresa = new DataTable();
                preguntasFrecuentes.tablaArticulos = new DataTable();
                preguntasFrecuentes.tablaPreguntasFrecuentes = new DataTable();
                preguntasFrecuentes.tablaSeccion = new DataTable();
                preguntasFrecuentes.tablaSecciones = new DataTable();
                preguntasFrecuentes.tablaMetaTags = new DataTable();
                preguntasFrecuentes.TablaPaquetesPopulares = new DataTable();
                preguntasFrecuentes.TablaFormasDePago = new DataTable();
                return View(preguntasFrecuentes);
            }
        }
        //  POST: /Recomendaciones/CambiarIdioma/6
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
        //  POST: /Recomendaciones/MatarSession/6
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
