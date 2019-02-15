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
    public class CatGruposController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/CatGrupos/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                GrupoModels grupo = new GrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                grupo.conexion = _conexion;
                grupo = grupoDatos.ObtenerListaGrupo(grupo);
                return View(grupo);
            }
            catch (Exception)
            {
                SeccionModels seccion = new SeccionModels();
                seccion.tablaSeccion = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(seccion);
            }
        }
        // GET: Admin/CatGrupos/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create(string id)
        {
            try
            {
                GrupoModels grupo = new GrupoModels();
                return View(grupo);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatGrupos/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                GrupoModels grupo = new GrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                grupo.conexion = _conexion;
                grupo.nombreGrupo = collection["nombreGrupo"];
                grupo.opcion = 1;
                grupo.user = User.Identity.Name;
                grupo = grupoDatos.AbcCatGrupo(grupo);

                TempData["typemessage"] = "1";
                TempData["message"] = "El grupo se creo correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatGrupos/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                GrupoModels grupo = new GrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                grupo.conexion = _conexion;
                grupo.id_grupo = id;
                grupo = grupoDatos.ObtenerDetalleGrupoxId(grupo);
                return View(grupo);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatGrupos/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                GrupoModels grupo = new GrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                grupo.conexion = _conexion;
                grupo.id_grupo = collection["id_grupo"];
                grupo.nombreGrupo = collection["nombreGrupo"];
                grupo.opcion = 2;
                grupo.user = User.Identity.Name;

                grupoDatos.AbcCatGrupo(grupo);

                TempData["typemessage"] = "1";
                TempData["message"] = "El grupo se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatGrupos/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CatGrupos/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                GrupoModels grupo = new GrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                grupo.conexion = _conexion;
                grupo.id_grupo = id;
                grupo.opcion = 3;
                grupo.user = User.Identity.Name;
                grupoDatos.AbcCatGrupo(grupo);
                TempData["typemessage"] = "1";
                TempData["message"] = "El grupo se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Admin/CatGrupos/Clientes
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Clientes(string id)
        {
            try
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                integrantesGrupo.conexion = _conexion;
                integrantesGrupo.id_grupo = id;
                integrantesGrupo = grupoDatos.ObtenerListaIntegrantesGrupoxId(integrantesGrupo);
                return View(integrantesGrupo);
            }
            catch (Exception)
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                integrantesGrupo.tablaIntegranteGrupo = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(integrantesGrupo);
            }
        }
        // GET: Admin/CatGrupos/CreateIntegrante
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult CreateIntegrante(string id)
        {
            try
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();

                ComunDatos comunDatos = new ComunDatos();
                integrantesGrupo.conexion = _conexion;
                integrantesGrupo.id_grupo = id;
                integrantesGrupo.tablaClientesCmb = comunDatos.ObtenerComboIntegrantesGrupo(integrantesGrupo);
                var list = new SelectList(integrantesGrupo.tablaClientesCmb, "id_cliente", "nombre");
                ViewData["cmbIntegrantes"] = list;

                return View(integrantesGrupo);
            }
            catch (Exception)
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                integrantesGrupo.id_grupo = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Clientes", new { id = integrantesGrupo.id_grupo });
            }
        }
        // POSt: Admin/CatGrupos/CreateIntegrante
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult CreateIntegrante(FormCollection collection)
        {
            try
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                integrantesGrupo.conexion = _conexion;
                integrantesGrupo.opcion = 1;
                integrantesGrupo.id_grupo = collection["id_grupo"];
                integrantesGrupo.id_cliente = collection["tablaClientesCmb"];
                integrantesGrupo.user = User.Identity.Name;
                grupoDatos.AbcIntegranteGrupo(integrantesGrupo);
                TempData["typemessage"] = "1";
                TempData["message"] = "Integrantes se agregaron correctamente";
                return RedirectToAction("Clientes", new { id = integrantesGrupo.id_grupo });
            }
            catch (Exception)
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                integrantesGrupo.id_grupo = collection["id_grupo"];
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede guardar correctamente";
                return RedirectToAction("Clientes", new { id = integrantesGrupo.id_grupo });
            }
        }
        // GET: Admin/CatGrupos/EditIntegrante/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult EditIntegrante(string id, string id2)
        {
            try
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();

                ComunDatos comunDatos = new ComunDatos();
                integrantesGrupo.conexion = _conexion;
                integrantesGrupo.id_integranteGrupo = id;
                integrantesGrupo.id_grupo = id2;
                integrantesGrupo.tablaClientesCmb = comunDatos.ObtenerComboIntegrantesGrupo(integrantesGrupo);
                var list = new SelectList(integrantesGrupo.tablaClientesCmb, "id_cliente", "nombre");
                ViewData["cmbIntegrantes"] = list;

                return View(integrantesGrupo);
            }
            catch (Exception)
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                integrantesGrupo.id_grupo = id2;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Clientes", new { id = integrantesGrupo.id_grupo });
            }
        }
        // POSt: Admin/CatGrupos/CreateIntegrante
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult EditIntegrante(FormCollection collection)
        {
            try
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                integrantesGrupo.conexion = _conexion;
                integrantesGrupo.opcion = 2;
                integrantesGrupo.id_integranteGrupo = collection["id_integranteGrupo"];
                integrantesGrupo.id_grupo = collection["id_grupo"];
                integrantesGrupo.id_cliente = collection["tablaClientesCmb"];
                integrantesGrupo.user = User.Identity.Name;
                grupoDatos.AbcIntegranteGrupo(integrantesGrupo);
                TempData["typemessage"] = "1";
                TempData["message"] = "Integrante se edito correctamente";
                return RedirectToAction("Clientes", new { id = integrantesGrupo.id_grupo });
            }
            catch (Exception)
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                integrantesGrupo.id_grupo = collection["id_grupo"];
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede guardar correctamente";
                return RedirectToAction("Clientes", new { id = integrantesGrupo.id_grupo });
            }
        }
        // GET: Admin/CatGrupos/DeleteIntegranteGrupo/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult DeleteIntegranteGrupo(string id)
        {
            return View();
        }
        // POST: Admin/CatGrupos/DeleteIntegranteGrupo/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult DeleteIntegranteGrupo(string id, FormCollection collection)
        {
            try
            {
                IntegrantesGrupoModels integrantesGrupo = new IntegrantesGrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                integrantesGrupo.conexion = _conexion;
                integrantesGrupo.opcion = 3;
                integrantesGrupo.id_integranteGrupo = id;
                integrantesGrupo.user = User.Identity.Name;
                grupoDatos.AbcIntegranteGrupo(integrantesGrupo);
                TempData["typemessage"] = "1";
                TempData["message"] = "Integrante sea elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
