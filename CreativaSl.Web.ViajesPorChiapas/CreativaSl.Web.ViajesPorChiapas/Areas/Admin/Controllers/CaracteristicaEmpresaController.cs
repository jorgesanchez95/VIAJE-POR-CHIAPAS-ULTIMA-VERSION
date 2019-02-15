using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Web.UI;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class CaracteristicaEmpresaController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/CaracteristicaEmpresa/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                CaracteristicaEmpresaModels caracteristicaEmpresa = new CaracteristicaEmpresaModels();
                CaracteristicaEmpresaDatos caracteristicaEmpresaDatos = new CaracteristicaEmpresaDatos();
                caracteristicaEmpresa.conexion = _conexion;
                caracteristicaEmpresa = caracteristicaEmpresaDatos.ObtenerListaCaracteristicaEmpresa(caracteristicaEmpresa);
                return View(caracteristicaEmpresa);
            }
            catch (Exception)
            {
                CaracteristicaEmpresaModels caracteristicaEmpresa = new CaracteristicaEmpresaModels();
                caracteristicaEmpresa.tablaCaracteristicaEmpresa = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(caracteristicaEmpresa);
            }
        }
        // GET: Admin/CaracteristicaEmpresa/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                CaracteristicaEmpresaModels caracteristicaEmpresa = new CaracteristicaEmpresaModels();

                return View(caracteristicaEmpresa);
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
                CaracteristicaEmpresaModels caracteristicaEmpresa = new CaracteristicaEmpresaModels();
                CaracteristicaEmpresaDatos caracteristicaEmpresaDatos = new CaracteristicaEmpresaDatos();
                caracteristicaEmpresa.conexion = _conexion;
                caracteristicaEmpresa.frase = collection["frase"];
                caracteristicaEmpresa.fraseIngles = collection["fraseIngles"];
                caracteristicaEmpresa.descripcion = collection["descripcion"];
                caracteristicaEmpresa.descripcionIngles = collection["descripcionIngles"];
                caracteristicaEmpresa.urlImg = "~/Imagenes/default.png";
                caracteristicaEmpresa.opcion = 1;
                caracteristicaEmpresa.user = User.Identity.Name;

                caracteristicaEmpresa.tipoArchivo = "";
                caracteristicaEmpresa.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                caracteristicaEmpresa.alt = collection["alt"];
                caracteristicaEmpresa.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                caracteristicaEmpresa = caracteristicaEmpresaDatos.AbcCatCaracteristicaEmpresa(caracteristicaEmpresa);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/CaracteristicaEmpresa/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = caracteristicaEmpresa.nombreArchivo + fileExtension;

                    caracteristicaEmpresa.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    caracteristicaEmpresa.urlImg = "~/Imagenes/CaracteristicaEmpresa/" + fileName;
                    caracteristicaEmpresa.opcion = 4;
                    caracteristicaEmpresaDatos.AbcCatCaracteristicaEmpresa(caracteristicaEmpresa);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "Caracteristica se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CaracteristicaEmpresa/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                CaracteristicaEmpresaModels caracteristicaEmpresa = new CaracteristicaEmpresaModels();
                CaracteristicaEmpresaDatos caracteristicaEmpresaDatos = new CaracteristicaEmpresaDatos();
                caracteristicaEmpresa.conexion = _conexion;
                caracteristicaEmpresa.id_catacteristicaEmpresa = id;
                caracteristicaEmpresa = caracteristicaEmpresaDatos.ObtenerDetalleCaracteristicaEmpresaxId(caracteristicaEmpresa);

                return View(caracteristicaEmpresa);
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
                CaracteristicaEmpresaModels caracteristicaEmpresa = new CaracteristicaEmpresaModels();
                CaracteristicaEmpresaDatos caracteristicaEmpresaDatos = new CaracteristicaEmpresaDatos();
                caracteristicaEmpresa.conexion = _conexion;
                caracteristicaEmpresa.id_catacteristicaEmpresa = collection["id_catacteristicaEmpresa"];
                caracteristicaEmpresa.frase = collection["frase"];
                caracteristicaEmpresa.fraseIngles = collection["fraseIngles"];
                caracteristicaEmpresa.descripcion = collection["descripcion"];
                caracteristicaEmpresa.descripcionIngles = collection["descripcionIngles"];
                caracteristicaEmpresa.urlImg = "~/Imagenes/default.png";
                caracteristicaEmpresa.opcion = 2;
                caracteristicaEmpresa.user = User.Identity.Name;

                caracteristicaEmpresa.tipoArchivo = "";
                caracteristicaEmpresa.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                caracteristicaEmpresa.alt = collection["alt"];
                caracteristicaEmpresa.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                caracteristicaEmpresa = caracteristicaEmpresaDatos.AbcCatCaracteristicaEmpresa(caracteristicaEmpresa);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/CaracteristicaEmpresa/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = caracteristicaEmpresa.nombreArchivo + fileExtension;

                    caracteristicaEmpresa.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    caracteristicaEmpresa.urlImg = "~/Imagenes/CaracteristicaEmpresa/" + fileName;
                    caracteristicaEmpresa.opcion = 4;
                    caracteristicaEmpresaDatos.AbcCatCaracteristicaEmpresa(caracteristicaEmpresa);
                }
                else
                {
                    caracteristicaEmpresa.urlImg = collection["urlImg"];

                    string baseDir = Server.MapPath("~/Imagenes/CaracteristicaEmpresa/");
                    string fileExtension = Path.GetExtension(caracteristicaEmpresa.urlImg);
                    string fileName = caracteristicaEmpresa.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + caracteristicaEmpresa.urlImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/CaracteristicaEmpresa/" + fileName).Replace("/", "\\").Replace("~", "");
                    if (rutaold != rutanew)
                    {
                        try
                        {
                            System.IO.File.Copy(rutaold, rutanew, true);
                        }
                        catch (Exception ex)
                        {
                        }
                        try
                        {
                            if (System.IO.File.Exists(rutaold))
                                System.IO.File.Delete(rutaold);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    caracteristicaEmpresa.urlImg = "~/Imagenes/CaracteristicaEmpresa/" + fileName;
                    caracteristicaEmpresa.tipoArchivo = fileExtension;
                    caracteristicaEmpresa.opcion = 4;
                    caracteristicaEmpresaDatos.AbcCatCaracteristicaEmpresa(caracteristicaEmpresa);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "La caracteristica se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CaracteristicaEmpresa/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CaracteristicaEmpresa/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CaracteristicaEmpresaModels caracteristicaEmpresa = new CaracteristicaEmpresaModels();
                CaracteristicaEmpresaDatos caracteristicaEmpresaDatos = new CaracteristicaEmpresaDatos();
                caracteristicaEmpresa.conexion = _conexion;
                caracteristicaEmpresa.id_catacteristicaEmpresa = id;
                caracteristicaEmpresa.opcion = 3;
                caracteristicaEmpresa.user = User.Identity.Name;
                caracteristicaEmpresaDatos.AbcCatCaracteristicaEmpresa(caracteristicaEmpresa);
                TempData["typemessage"] = "1";
                TempData["message"] = "La caracteristica se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameCaracteristicaEmpresaAvailability(string nombreArchivo)
        {
            CaracteristicaEmpresaModels CaracteristcaEmpresa = new CaracteristicaEmpresaModels();
            CaracteristicaEmpresaDatos CarcteristicaDatos = new CaracteristicaEmpresaDatos();
            CaracteristcaEmpresa.conexion = _conexion;
            CaracteristcaEmpresa.nombreArchivo = nombreArchivo;
            return Json(CarcteristicaDatos.CheckCaracteristicaEmpresaArchivoNameTours(CaracteristcaEmpresa), JsonRequestBehavior.AllowGet);
        }
    }
}
