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
    public class ContactosController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Contactos
        [Autorizado]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ContactoModels contacto = new ContactoModels();
                ContactoDatos contactoDatos = new ContactoDatos();
                contacto.idioma = Session["locale"] == null ? 1 : 2;
                contacto.id_seccion = Session["idSeccion"].ToString();
                contacto.conexion = _conexion;
                contacto.id_metaTags = "A3D699D4-9EA4-4191-8F5A-D4970677A88A";
                contacto.id_tipo = 1;
                contacto = contactoDatos.ObtenerConfigContacto(contacto);
                return View(contacto);
            }
            catch
            {
                ContactoModels contacto = new ContactoModels();
                contacto.tablaDatosGenerales = new DataTable();
                contacto.tablaCaracteristicasEmpresa = new DataTable();
                contacto.tablaArticulos = new DataTable();
                contacto.tablaSeccion = new DataTable();
                contacto.tablaSecciones = new DataTable();
                contacto.tablaMetaTags = new DataTable();
                contacto.TablaPaquetesPopulares = new DataTable();
                contacto.TablaFormasDePago = new DataTable();
                return View(contacto);
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

        // POST: /Contactanos/Contactar
        [Autorizado]
        [HttpPost]
        public ActionResult Contactar(string nombre, string correo, string telefono, string horarioContacto, string asunto, string mensaje)
        {
            try
            {
                string resultado;
                ContactoModels contacto = new ContactoModels();
                ContactoDatos contactoDatos = new ContactoDatos();
                contacto.conexion = _conexion;
                contacto.id_seccion = Session["idSeccion"].ToString();
                contacto.asunto = asunto;
                contacto.correo = correo;
                contacto.horarioContacto = horarioContacto;
                contacto.mensaje = mensaje;
                contacto.nombre = nombre;
                contacto.telefono = telefono;
                contacto.opcion = 1;
                contacto.user = "pagina";
                contactoDatos.AbcContacto(contacto);
                if (!string.IsNullOrEmpty(contacto.id_contacto))
                {
                    contacto.tablaRedesSociales = contactoDatos.ObtenerRedesSociales(contacto);
                    Comun.EnviarCorreo(
                    ConfigurationManager.AppSettings.Get("CorreoTxt")
                    , ConfigurationManager.AppSettings.Get("PasswordTxt")
                    , ConfigurationManager.AppSettings.Get("CorreoTxt")
                    , "Contacto"
                    , Comun.GenerarHtmlContactos(contacto.nombre, contacto.correo, contacto.telefono, contacto.horarioContacto, contacto.asunto, contacto.mensaje, contacto.tablaRedesSociales, contacto.TablaPaquetesPopulares, contacto.nombre)
                    , false
                    , ""
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                    , ConfigurationManager.AppSettings.Get("HostTxt")
                    , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));

                    resultado = "OK";
                }
                else {
                    resultado = "KO";
                }
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string resultado = "KO";
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}