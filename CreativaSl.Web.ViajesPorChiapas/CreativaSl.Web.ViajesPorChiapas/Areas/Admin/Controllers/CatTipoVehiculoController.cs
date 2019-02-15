using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class CatTipoVehiculoController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/CatTipoVehiculo/

        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                TipoVehiculoModels vehiculo = new TipoVehiculoModels();
                TipoVehiculoDatos vehiculoDatos = new TipoVehiculoDatos();
                vehiculo.conexion = _conexion;
                vehiculo = vehiculoDatos.ObtenerListaTipoVehiculo(vehiculo);
                return View(vehiculo);
            }
            catch (Exception)
            {
                TipoVehiculoModels vehiculo = new TipoVehiculoModels { tablaTipoVehiculo = new DataTable() };
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(vehiculo);
            }
        }


        // GET: Admin/CatTipoVehiculo/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                TipoVehiculoModels vehiculo = new TipoVehiculoModels();
                return View(vehiculo);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatHoteles/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TipoVehiculoModels vehiculo = new TipoVehiculoModels();
                TipoVehiculoDatos vehiculoDatos = new TipoVehiculoDatos();
                vehiculo.conexion = _conexion;
                vehiculo.id_tipoVehiculo = collection["id_tipoVehiculo"];
                vehiculo.descripcion = collection["descripcion"];
                vehiculo.opcion = 1;
                vehiculo.user = User.Identity.Name;
                vehiculoDatos.AbcCatTipoVehiculo(vehiculo);
                
                TempData["typemessage"] = "1";
                TempData["message"] = "El Vehiculo se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatTipoVehiculo/Edit
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                TipoVehiculoModels vehiculo = new TipoVehiculoModels();
                TipoVehiculoDatos vehiculoDatos = new TipoVehiculoDatos();
                vehiculo.id_tipoVehiculo = id;
                vehiculo.conexion = _conexion;
                vehiculo = vehiculoDatos.ObtenerDetalleTipoVehiculoxId(vehiculo);
                return View(vehiculo);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatTipoVehiculo/Edit
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                TipoVehiculoModels vehiculo = new TipoVehiculoModels();
                TipoVehiculoDatos vehiculoDatos = new TipoVehiculoDatos();
                vehiculo.conexion = _conexion;
                vehiculo.id_tipoVehiculo = collection["id_tipoVehiculo"];
                vehiculo.descripcion = collection["descripcion"];
                vehiculo.opcion = 2;
                vehiculo.user = User.Identity.Name;
                vehiculo = vehiculoDatos.AbcCatTipoVehiculo(vehiculo);

                TempData["typemessage"] = "1";
                TempData["message"] = "El Vehiculo se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatTipoVehiculo/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CatTipoVehiculo/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                TipoVehiculoModels vehiculo = new TipoVehiculoModels();
                TipoVehiculoDatos vehiculoDatos = new TipoVehiculoDatos();
                vehiculo.conexion = _conexion;
                vehiculo.id_tipoVehiculo = id;
                vehiculo.opcion = 3;
                vehiculo.user = User.Identity.Name;
                vehiculoDatos.AbcCatTipoVehiculo(vehiculo);
                TempData["typemessage"] = "1";
                TempData["message"] = "El Vehiculo se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
