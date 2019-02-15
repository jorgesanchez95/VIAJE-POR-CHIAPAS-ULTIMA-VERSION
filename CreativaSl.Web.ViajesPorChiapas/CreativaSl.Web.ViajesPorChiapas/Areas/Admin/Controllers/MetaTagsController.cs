using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class MetaTagsController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/MetaTags/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                CatMetaTagsModels metaTags = new CatMetaTagsModels();
                CatMetaTagsDatos MetaDatos = new CatMetaTagsDatos();
                metaTags.conexion = _conexion;
                metaTags = MetaDatos.ObtenerListaCatMetaTags(metaTags);
                return View(metaTags);
            }
            catch (Exception)
            {
                CatMetaTagsModels metaTags = new CatMetaTagsModels();
                metaTags.tablaMetaTags = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(metaTags);
            }
        }
        // GET: Admin/MetaTags/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, string id2)
        {
            try
            {
                CatMetaTagsModels metaTags = new CatMetaTagsModels();
                CatMetaTagsDatos MetaDatos = new CatMetaTagsDatos();
                metaTags.conexion = _conexion;
                metaTags.id_metaTags = id;
                metaTags.id_tipo = Convert.ToInt32(id2);
                metaTags = MetaDatos.ObtenerDetalleCatMetaTagsxId(metaTags);
                return View(metaTags);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CaracteristicaEmpresa/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                CatMetaTagsModels metaTags = new CatMetaTagsModels();
                CatMetaTagsDatos MetaDatos = new CatMetaTagsDatos();
                metaTags.conexion = _conexion;
                metaTags.id_metaTags = collection["id_metaTags"];
                metaTags.id_tipo = Convert.ToInt32(collection["id_tipo"]);
                metaTags.title = collection["title"];
                metaTags.canonical = collection["canonical"];
                metaTags.description = collection["description"];
                metaTags.subjetc = collection["subjetc"];
                metaTags.keywords = collection["keywords"];
                metaTags.robots = collection["robots"];
                metaTags.author = collection["author"];
                metaTags.opcion = 2;
                metaTags.user = User.Identity.Name;

                MetaDatos.AbcCatMetaTags(metaTags);
                TempData["typemessage"] = "1";
                TempData["message"] = "Se guardo correctarmente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
    }
}
