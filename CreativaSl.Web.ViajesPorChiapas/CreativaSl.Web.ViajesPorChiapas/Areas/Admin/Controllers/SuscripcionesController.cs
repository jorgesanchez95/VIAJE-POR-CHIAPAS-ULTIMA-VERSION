using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class SuscripcionesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/Suscripciones/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                SuscripcionModels suscripcion = new SuscripcionModels();
                SuscripcionDatos suscripcionDatos = new SuscripcionDatos();
                suscripcion.conexion = _conexion;
                suscripcion = suscripcionDatos.ObtenerListaSuscripcion(suscripcion);
                return View(suscripcion);
            }
            catch (Exception)
            {
                SuscripcionModels suscripcion = new SuscripcionModels();
                suscripcion.tablaSuscripcion = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(suscripcion);
            }
        }
        // GET: Admin/Suscripciones/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Suscripciones/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SuscripcionDatos suscripcionDatos = new SuscripcionDatos();
                seccion.conexion = _conexion;
                seccion.id_suscripcion = id;
                seccion.opcion = 3;
                seccion.user = User.Identity.Name;
                suscripcionDatos.AbcCatSuscripcion(seccion);
                TempData["typemessage"] = "1";
                TempData["message"] = "El correo se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
