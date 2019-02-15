using System;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class PreguntasFrecuentesController : Controller
    {
        string conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/PreguntasFrecuentes/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                PreguntasFrecuentesDatos preguntasFrecuentesDatos = new PreguntasFrecuentesDatos();
                preguntasFrecuentes.conexion = conexion;
                preguntasFrecuentes = preguntasFrecuentesDatos.ObtenerListaPreguntasFrecuentes(preguntasFrecuentes);
                return View(preguntasFrecuentes);
            }
            catch (Exception)
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                preguntasFrecuentes.tablaPreguntasFrecuentes = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(preguntasFrecuentes);
            }
        }
        // GET: Admin/PreguntasFrecuentes/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create(string id)
        {
            try
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = conexion;
                preguntasFrecuentes.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(preguntasFrecuentes.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;
                return View(preguntasFrecuentes);
            }
            catch (Exception)
            {
                UsuarioModels usuario = new UsuarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/PreguntasFrecuentes/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                PreguntasFrecuentesDatos preguntasFrecuentesDatos = new PreguntasFrecuentesDatos();
                preguntasFrecuentes.conexion = conexion;
                preguntasFrecuentes.id_seccion = collection["tablaSeccionesCmb"];
                preguntasFrecuentes.pregunta = collection["pregunta"];
                preguntasFrecuentes.respuesta = collection["respuesta"];
                preguntasFrecuentes.preguntaIngles = collection["preguntaIngles"];
                preguntasFrecuentes.respuestaIngles = collection["respuestaIngles"];
                preguntasFrecuentes.opcion = 1;
                preguntasFrecuentes.user = User.Identity.Name;

                preguntasFrecuentesDatos.AbcCatPreguntasFrecuentes(preguntasFrecuentes);

                TempData["typemessage"] = "1";
                TempData["message"] = "Preguntras freacuentes sea ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Usuarios/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                PreguntasFrecuentesDatos preguntasFrecuentesDatos = new PreguntasFrecuentesDatos();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = conexion;
                preguntasFrecuentes.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(preguntasFrecuentes.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                preguntasFrecuentes.conexion = conexion;
                preguntasFrecuentes.id_preguntaFrecuente = id;
                preguntasFrecuentes = preguntasFrecuentesDatos.ObtenerDetallePreguntasFrecuentesXId(preguntasFrecuentes);
                return View(preguntasFrecuentes);
            }
            catch (Exception)
            {
                UsuarioModels usuario = new UsuarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Usuarios/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                PreguntasFrecuentesDatos preguntasFrecuentesDatos = new PreguntasFrecuentesDatos();
                preguntasFrecuentes.conexion = conexion;
                preguntasFrecuentes.id_preguntaFrecuente = id;
                preguntasFrecuentes.id_seccion = collection["tablaSeccionesCmb"];
                preguntasFrecuentes.pregunta = collection["pregunta"];
                preguntasFrecuentes.respuesta = collection["respuesta"];
                preguntasFrecuentes.preguntaIngles = collection["preguntaIngles"];
                preguntasFrecuentes.respuestaIngles = collection["respuestaIngles"];
                preguntasFrecuentes.opcion = 2;
                preguntasFrecuentes.user = User.Identity.Name;

                preguntasFrecuentesDatos.AbcCatPreguntasFrecuentes(preguntasFrecuentes);

                TempData["typemessage"] = "1";
                TempData["message"] = "Preunta frecuente se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Usuarios/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Usuarios/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                PreguntasFrecuentesModels preguntasFrecuentes = new PreguntasFrecuentesModels();
                PreguntasFrecuentesDatos preguntasFrecuentesDatos = new PreguntasFrecuentesDatos();
                preguntasFrecuentes.conexion = conexion;
                preguntasFrecuentes.id_preguntaFrecuente = id;
                preguntasFrecuentes.opcion = 3;
                preguntasFrecuentes.user = User.Identity.Name;
                preguntasFrecuentesDatos.AbcCatPreguntasFrecuentes(preguntasFrecuentes);
                TempData["typemessage"] = "1";
                TempData["message"] = "Usuario se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
