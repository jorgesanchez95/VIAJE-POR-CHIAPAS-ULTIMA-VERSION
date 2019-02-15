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
    public class TagsAMostrarController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/TagsAMostrar/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                TagsMostrarModels tagsMostrar = new TagsMostrarModels();
                TagsMostrarDatos tagsMostrarDatos = new TagsMostrarDatos();
                tagsMostrar.conexion = _conexion;
                tagsMostrar = tagsMostrarDatos.ObtenerListaTagsMostrar(tagsMostrar);
                return View(tagsMostrar);
            }
            catch (Exception)
            {
                TagsMostrarModels tagsMostrar = new TagsMostrarModels{ tablaTagsMostrar = new DataTable() };
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(tagsMostrar);
            }
        }
        // GET: Admin/LugaresTuristicos/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                TagsMostrarModels tagsMostrar = new TagsMostrarModels();
                TagsMostrarDatos tagsMostrarDatos = new TagsMostrarDatos();
                tagsMostrar.conexion = _conexion;
                tagsMostrar.id_tagMostrar = id;

                tagsMostrar = tagsMostrarDatos.ObtenerDetalleTagMostarxId(tagsMostrar);

                TagsDatos tagsDatos = new TagsDatos();
                tagsMostrar.id_tagMostrar = id;
                tagsMostrar.conexion = _conexion;
                tagsMostrar.tablaTagsCmb = tagsDatos.ObtenerComboTagsMostrar(tagsMostrar);
                var list = new SelectList(tagsMostrar.tablaTagsCmb, "id_tag", "nombre");
                ViewData["cmbTags"] = list;

                return View(tagsMostrar);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/LugaresTuristicos/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                TagsMostrarModels tagsMostrar = new TagsMostrarModels();
                TagsMostrarDatos tagsMostrarDatos = new TagsMostrarDatos();
                tagsMostrar.conexion = _conexion;
                tagsMostrar.opcion = 2;
                tagsMostrar.id_tagMostrar = collection["id_tagMostrar"];
                tagsMostrar.id_tag = collection["tablaTagsCmb"];

                tagsMostrar.user = User.Identity.Name;

                tagsMostrarDatos.AbcTagsMostrar(tagsMostrar);

                TempData["typemessage"] = "1";
                TempData["message"] = "El lugar se ha creado correctamente";
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
