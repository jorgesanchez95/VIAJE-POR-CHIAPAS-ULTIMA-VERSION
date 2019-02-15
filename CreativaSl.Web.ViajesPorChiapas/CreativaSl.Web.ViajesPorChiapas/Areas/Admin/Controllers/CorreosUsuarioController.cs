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
    public class CorreosUsuarioController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/CorreosUsuario/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                CorreosUsuarioModels correosUsuario = new CorreosUsuarioModels();
                CorreosUsuarioDatos correosUsuarioDatos = new CorreosUsuarioDatos();
                correosUsuario.conexion = _conexion;
                correosUsuario = correosUsuarioDatos.ObtenerListaCorreosUsuario(correosUsuario);
                return View(correosUsuario);
            }
            catch (Exception)
            {
                CorreosUsuarioModels correosUsuario = new CorreosUsuarioModels();
                correosUsuario.tablaCorreosUsuario = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(correosUsuario);
            }
        }
        // GET: Admin/CorreosUsuario/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                CorreosUsuarioModels correosUsuario = new CorreosUsuarioModels();
                return View(correosUsuario);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CorreosUsuario/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CorreosUsuarioModels correosUsuario = new CorreosUsuarioModels();
                CorreosUsuarioDatos correosUsuarioDatos = new CorreosUsuarioDatos();
                correosUsuario.conexion = _conexion;
                correosUsuario.nombre = collection["nombre"];
                correosUsuario.correo = collection["correo"];
                correosUsuario.opcion = 1;
                correosUsuario.user = User.Identity.Name;
                correosUsuario = correosUsuarioDatos.AbcCatCorreosUsuario(correosUsuario);

                TempData["typemessage"] = "1";
                TempData["message"] = "El correo se agrego correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CorreosUsuario/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                CorreosUsuarioModels correosUsuario = new CorreosUsuarioModels();
                CorreosUsuarioDatos correosUsuarioDatos = new CorreosUsuarioDatos();
                correosUsuario.conexion = _conexion;
                correosUsuario.id_cliente = id;
                correosUsuario = correosUsuarioDatos.ObtenerDetalleCorreosUsuarioxId(correosUsuario);
                return View(correosUsuario);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CorreosUsuario/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                CorreosUsuarioModels correosUsuario = new CorreosUsuarioModels();
                CorreosUsuarioDatos correosUsuarioDatos = new CorreosUsuarioDatos();
                correosUsuario.conexion = _conexion;
                correosUsuario.id_cliente = id;
                correosUsuario.nombre = collection["nombre"];
                correosUsuario.correo = collection["correo"];
                correosUsuario.opcion = 2;
                correosUsuario.user = User.Identity.Name;

                correosUsuarioDatos.AbcCatCorreosUsuario(correosUsuario);

                TempData["typemessage"] = "1";
                TempData["message"] = "El correo se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CorreosUsuario/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CorreosUsuario/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CorreosUsuarioModels correosUsuario = new CorreosUsuarioModels();
                CorreosUsuarioDatos correosUsuarioDatos = new CorreosUsuarioDatos();
                correosUsuario.conexion = _conexion;
                correosUsuario.id_cliente = id;
                correosUsuario.opcion = 3;
                correosUsuario.user = User.Identity.Name;
                correosUsuarioDatos.AbcCatCorreosUsuario(correosUsuario);
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
