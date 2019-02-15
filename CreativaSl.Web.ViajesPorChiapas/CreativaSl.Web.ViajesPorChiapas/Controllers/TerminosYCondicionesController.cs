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
    public class TerminosYCondicionesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");

        [Autorizado]
        [HttpGet]
        //  GET: /TerminosYCondiciones/
        public ActionResult Index()
        {
            try
            {
                TerminosYCondicionesModels terminos = new TerminosYCondicionesModels();
                TerminosYCondiciones_Datos teminos_datos = new TerminosYCondiciones_Datos();
                terminos.idioma = Session["locale"] == null ? 1 : 2;
                terminos.id_seccion = Session["idSeccion"].ToString();
                terminos.conexion = _conexion;
                terminos.id_metaTags = "6A2B4E03-E047-4FC2-BB03-A52E3E080005";
                terminos.id_tipo = 1;
                terminos = teminos_datos.ObtenerConfigTerminosYCondiciones(terminos);
                return View(terminos);
            }
            catch
            {
                TerminosYCondicionesModels terminos = new TerminosYCondicionesModels();
                terminos.tablaDatosGenerales = new DataTable();
                terminos.tablaCaracteristicasEmpresa = new DataTable();
                terminos.tablaArticulos = new DataTable();
                terminos.tablaSeccion = new DataTable();
                terminos.tablaSecciones = new DataTable();
                terminos.tablaMetaTags = new DataTable();
                return View(terminos);
            }
        }
    }
}