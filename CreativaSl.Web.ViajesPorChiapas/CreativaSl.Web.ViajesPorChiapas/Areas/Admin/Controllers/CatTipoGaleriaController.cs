using System;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class CatTipoGaleriaController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/CatTipoGaleria/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                TipoGaleriaModels tipoGaleria = new TipoGaleriaModels();
                TipoGaleriaDatos tipoGaleriaDatos = new TipoGaleriaDatos();
                tipoGaleria.conexion = _conexion;
                tipoGaleria = tipoGaleriaDatos.ObtenerListaCatTipoGaleria(tipoGaleria);
                return View(tipoGaleria);
            }
            catch (Exception)
            {
                TipoGaleriaModels tipoGaleria = new TipoGaleriaModels();
                tipoGaleria.tablaTipoGaleria = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(tipoGaleria);
            }
        }
        // GET: Admin/CatTipoGaleria/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                TipoGaleriaModels tipoGaleria = new TipoGaleriaModels();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                tipoGaleria.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(tipoGaleria.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                return View(tipoGaleria);
            }
            catch (Exception es)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatTipoGaleria/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TipoGaleriaModels tipoGaleria = new TipoGaleriaModels();
                TipoGaleriaDatos tipoGaleriaDatos = new TipoGaleriaDatos();
                tipoGaleria.conexion = _conexion;
                tipoGaleria.descripcion = collection["descripcion"];
                tipoGaleria.descripcionIngles = collection["descripcionIngles"];
                tipoGaleria.id_seccion = collection["tablaSeccionesCmb"];
                tipoGaleria.opcion = 1;
                tipoGaleria.user = User.Identity.Name;
                tipoGaleriaDatos.AbcCatTipoGaleria(tipoGaleria);

                TempData["typemessage"] = "1";
                TempData["message"] = "El tipo galeria sea creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatTipoGaleria/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                TipoGaleriaModels tipoGaleria = new TipoGaleriaModels();
                TipoGaleriaDatos tipoGaleriaDatos = new TipoGaleriaDatos();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();

                seccion.conexion = _conexion;
                tipoGaleria.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(tipoGaleria.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;


                tipoGaleria.conexion = _conexion;
                tipoGaleria.id_tipoGaleria = id;
                tipoGaleria = tipoGaleriaDatos.ObtenerDetalleCatTipoGaleriaxId(tipoGaleria);
                return View(tipoGaleria);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatTipoGaleria/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                TipoGaleriaModels tipoGaleria = new TipoGaleriaModels();
                TipoGaleriaDatos tipoGaleriaDatos = new TipoGaleriaDatos();
                tipoGaleria.conexion = _conexion;
                tipoGaleria.id_tipoGaleria = collection["id_tipoGaleria"];
                tipoGaleria.descripcion = collection["descripcion"];
                tipoGaleria.descripcionIngles = collection["descripcionIngles"];
                tipoGaleria.id_seccion = collection["tablaSeccionesCmb"];
                tipoGaleria.opcion = 2;
                tipoGaleria.user = User.Identity.Name;
                tipoGaleriaDatos.AbcCatTipoGaleria(tipoGaleria);

                TempData["typemessage"] = "1";
                TempData["message"] = "El tipo galeria se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatTipoGaleria/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CatTipoGaleria/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                TipoGaleriaModels tipoGaleria = new TipoGaleriaModels();
                TipoGaleriaDatos tipoGaleriaDatos = new TipoGaleriaDatos();
                tipoGaleria.conexion = _conexion;
                tipoGaleria.id_tipoGaleria = id;
                tipoGaleria.opcion = 3;
                tipoGaleria.user = User.Identity.Name;
                tipoGaleriaDatos.AbcCatTipoGaleria(tipoGaleria);

                TempData["typemessage"] = "1";
                TempData["message"] = "Tipo Galeria se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
