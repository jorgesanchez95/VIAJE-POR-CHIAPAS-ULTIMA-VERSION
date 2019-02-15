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
    public class GaleriasController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Galerias
        [Autorizado]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.idioma = Session["locale"] == null ? 1 : 2;
                multimedia.id_seccion = Session["idSeccion"].ToString();
                multimedia.conexion = _conexion;
                multimedia.id_metaTags = "5E092047-DCA2-4304-BD9B-3C347E886532";
                multimedia.id_tipo = 1;
                multimedia = multimediaDatos.ObtenerConfigGalerias(multimedia);
                return View(multimedia);
            }
            catch
            {
                MultimediaModels multimedia = new MultimediaModels();
                multimedia.tablaDatosGenerales = new DataTable();
                multimedia.tablaCaracteristicasEmpresa = new DataTable();
                multimedia.tablaArticulos = new DataTable();
                multimedia.tablaTipoGaleria = new DataTable();
                multimedia.tablaGaleria = new DataTable();
                multimedia.tablaSeccion = new DataTable();
                multimedia.tablaSecciones = new DataTable();
                multimedia.tablaMetaTags = new DataTable();
                return View(multimedia);
            }
        }
        //  POST: /Galerias/CambiarIdioma/6
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
        //  POST: /Galerias/MatarSession/6
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
