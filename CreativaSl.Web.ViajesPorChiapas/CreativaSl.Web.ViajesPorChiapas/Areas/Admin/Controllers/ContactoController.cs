using System;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class ContactoController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/Contactos
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                ContactoModels contacto = new ContactoModels();
                ContactoDatos contactoDatos = new ContactoDatos();
                contacto.conexion = Conexion;
                contacto = contactoDatos.ObtenerListaContacto(contacto);
                return View(contacto);
            }
            catch (Exception)
            {
                ContactoModels contacto = new ContactoModels();
                contacto.tablaContacto = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(contacto);
            }
        }
        // GET: Admin/Contactos/Responder
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Responder(string id)
        {
            try
            {
                ContactoModels contacto = new ContactoModels();
                ContactoDatos contactoDatos = new ContactoDatos();
                contacto.conexion = Conexion;
                contacto.opcion = 2;
                contacto.id_contacto = id;
                contacto = contactoDatos.ObtenerDetalleContactoXId(contacto);
                return View(contacto);
            }
            catch (Exception)
            {
                ContactoModels contacto = new ContactoModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Contactos/Responder
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Responder(string id, FormCollection collection)
        {
            try
            {
                ContactoModels contacto = new ContactoModels();
                ContactoDatos contactoDatos = new ContactoDatos();
                contacto.conexion = Conexion;
                contacto.id_contacto = collection["id_contacto"];
                contacto.nombre = collection["nombre"];
                contacto.telefono = collection["telefono"];
                contacto.correo = collection["correo"];
                contacto.mensaje = collection["mensaje"];
                contacto.respuesta = collection["respuesta"];
                contacto.asunto = collection["asunto"];
                contacto.horarioContacto = collection["horarioContacto"];
                contacto.opcion = 2;
                contacto.user = User.Identity.Name;
                contactoDatos.AbcContacto(contacto);
                Comun.EnviarCorreo(
                     ConfigurationManager.AppSettings.Get("CorreoTxt")
                    , ConfigurationManager.AppSettings.Get("PasswordTxt")
                    , contacto.correo
                    , "Respuesta Viajes Por Chiapas"
                    , Comun.GenerarHtmlRespuestaContacto(contacto.nombre, contacto.correo, contacto.telefono, contacto.mensaje, contacto.respuesta)
                    , false
                    , ""
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                    , ConfigurationManager.AppSettings.Get("HostTxt")
                    , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                TempData["typemessage"] = "1";
                TempData["message"] = "Respuesta enviada correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "Respuesta no enviada correctamente";
                return RedirectToAction("Index");
            }
        }
        //GET: Admin/Contactos/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Contactos/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                ContactoModels contacto = new ContactoModels();
                ContactoDatos contactoDatos = new ContactoDatos();
                contacto.conexion = Conexion;
                contacto.id_contacto = id;
                contacto.opcion = 3;
                contacto.user = User.Identity.Name;
                contactoDatos.AbcContacto(contacto);
                TempData["typemessage"] = "1";
                TempData["message"] = "Contactos se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
