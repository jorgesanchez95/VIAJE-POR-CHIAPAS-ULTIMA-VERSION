using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class CatVehiculosController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/CatVehiculos
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                CatVehiculosModels catvehiculos = new CatVehiculosModels();
                _CatVehiculos_Datos catvehiculosDatos = new _CatVehiculos_Datos();
                catvehiculos.conexion = _conexion;

                catvehiculos = catvehiculosDatos.ObtenerListaCatVehiculos(catvehiculos);
                return View(catvehiculos);
            }
            catch (Exception)
            {
                CatVehiculosModels catvehiculos = new CatVehiculosModels();
                catvehiculos.TablaVehiculo = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(catvehiculos);
            }
        }
        //GET
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                CatVehiculosModels catvehiculos = new CatVehiculosModels();
                _CatVehiculos_Datos catvehiculosDatos = new _CatVehiculos_Datos();
                catvehiculos.conexion = _conexion;
                catvehiculos.tablaTipoVehiculoCmb = catvehiculosDatos.ObtenerComboTipoVehiculo(catvehiculos);
                var list = new SelectList(catvehiculos.tablaTipoVehiculoCmb, "id_tipoVehiculo", "descripcion");
                ViewData["cmbTipoVehiculos"] = list;
                return View(catvehiculos);
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatVehiculosModels catvehiculo = new CatVehiculosModels();
                _CatVehiculos_Datos catvehiculosDatos = new _CatVehiculos_Datos();

                catvehiculo.conexion = _conexion;
                catvehiculo.descripcion = collection["descripcion"];
                catvehiculo.descripcionIngles = collection["descripcionIngles"];
                catvehiculo.placas = collection["placas"];
                catvehiculo.detalle = collection["detalle"];
                catvehiculo.detalleIngles = collection["detalleIngles"];
                catvehiculo.combustible = collection["combustible"];
                catvehiculo.transmision = collection["transmision"];
                catvehiculo.numPersona = Convert.ToInt32(collection["numPersona"]);
                catvehiculo.numPuerta = Convert.ToInt32(collection["numPuerta"]);
                catvehiculo.id_tipovehiculo = collection["tablaTipoVehiculoCmb"];
                catvehiculo.UrlImagen = "~/Imagenes/default.png";
                catvehiculo.opcion = 1;
                catvehiculo.user = User.Identity.Name;

                catvehiculo.tipo_arc = "";
                catvehiculo.nombre_pagina = Comun.RemoverSignosAcentos(collection["descripcion"]);
                catvehiculo.nombre_arc = Comun.RemoverAcentos(collection["nombre_arc"]);
                catvehiculo.alt = collection["alt"];
                catvehiculo.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                catvehiculo = catvehiculosDatos.AbcCatVehiculos(catvehiculo);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/CatVehiculos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = catvehiculo.nombre_arc + fileExtension;

                    catvehiculo.tipo_arc = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    catvehiculo.UrlImagen = "~/Imagenes/CatVehiculos/" + fileName;
                    catvehiculo.opcion = 4;
                    catvehiculosDatos.AbcCatVehiculos(catvehiculo);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "Caracteristica se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatVehiculosModels catvehiculos = new CatVehiculosModels();
                _CatVehiculos_Datos catVehiculosDatos = new _CatVehiculos_Datos();

                

                catvehiculos.conexion = _conexion;
                catvehiculos.tablaTipoVehiculoCmb = catVehiculosDatos.ObtenerComboTipoVehiculo(catvehiculos);
                var list = new SelectList(catvehiculos.tablaTipoVehiculoCmb, "id_tipoVehiculo", "descripcion");
                ViewData["cmbTipoVehiculos"] = list;


                catvehiculos.conexion = _conexion;
                catvehiculos.id_vehiculo = id;
                catvehiculos = catVehiculosDatos.ObtenerDetalleCaracteristicaVehiculos(catvehiculos);
                return View(catvehiculos);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                CatVehiculosModels catvehiculo = new CatVehiculosModels();
                _CatVehiculos_Datos catvehiculosDatos = new _CatVehiculos_Datos();

                catvehiculo.conexion = _conexion;
                catvehiculo.id_vehiculo = collection["id_vehiculo"];
                catvehiculo.descripcion = collection["descripcion"];
                catvehiculo.descripcionIngles = collection["descripcionIngles"];
                catvehiculo.placas = collection["placas"];
                catvehiculo.detalle = collection["detalle"];
                catvehiculo.detalleIngles = collection["detalleIngles"];
                catvehiculo.combustible = collection["combustible"];
                catvehiculo.transmision = collection["transmision"];
                catvehiculo.numPersona = Convert.ToInt32(collection["numPersona"]);
                catvehiculo.numPuerta = Convert.ToInt32(collection["numPuerta"]);
                catvehiculo.id_tipovehiculo = collection["tablaTipoVehiculoCmb"];
                catvehiculo.opcion = 2;
                catvehiculo.user = User.Identity.Name;
                catvehiculo.UrlImagen = "~/Imagenes/default.png";
              
                catvehiculo.user = User.Identity.Name;

                catvehiculo.tipo_arc = "";
                catvehiculo.nombre_arc = Comun.RemoverAcentos(collection["nombre_arc"]);
                catvehiculo.nombre_pagina = Comun.RemoverSignosAcentos(collection["descripcion"]);
                catvehiculo.alt = collection["alt"];
                catvehiculo.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                catvehiculo = catvehiculosDatos.AbcCatVehiculos(catvehiculo);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/CatVehiculos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = catvehiculo.nombre_arc + fileExtension;

                    catvehiculo.tipo_arc = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    catvehiculo.UrlImagen = "~/Imagenes/CatVehiculos/" + fileName;
                    catvehiculo.opcion = 4;
                    catvehiculosDatos.AbcCatVehiculos(catvehiculo);
                }


                TempData["typemessage"] = "1";
                TempData["message"] = "Los datos del Vehiculo se editaron correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
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
                CatVehiculosModels catvehiculo = new CatVehiculosModels();
                _CatVehiculos_Datos catvehiculosDatos = new _CatVehiculos_Datos();

                catvehiculo.conexion = _conexion;
                catvehiculo.id_vehiculo = id;
                catvehiculo.opcion = 3;
                catvehiculo.user = User.Identity.Name;
                catvehiculosDatos.AbcCatVehiculos(catvehiculo);

                TempData["typemessage"] = "1";
                TempData["message"] = "El vehiculo se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}