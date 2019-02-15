using System;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.UI;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class SeccionesController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/Secciones/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                seccion = seccionDatos.ObtenerListaSecciones(seccion);
                return View(seccion);
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
        // GET: Admin/Secciones/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create(string id)
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                seccion.latitud = "23.634501";
                seccion.longitud = "-102.55278399999997";
                return View(seccion);
            }
            catch (Exception)
            {
                SeccionModels seccion = new SeccionModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Secciones/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                seccion.nombreSeccion = collection["nombreSeccion"];
                seccion.descripcion = collection["descripcion"];
                seccion.latitud = collection["latitud"];
                seccion.longitud = collection["longitud"];
                seccion.urlYoutube = collection["urlYoutube"];
                seccion.opcion = 1;
                seccion.user = User.Identity.Name;
                seccionDatos.AbcCatSeccion(seccion);

                TempData["typemessage"] = "1";
                TempData["message"] = "La sección sea creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Secciones/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                seccion.id_seccion = id;
                seccion = seccionDatos.ObtenerDetalleSeccionxId(seccion);
                return View(seccion);
            }
            catch (Exception)
            {
                SeccionModels seccion = new SeccionModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Secciones/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                seccion.id_seccion = collection["id_seccion"];
                seccion.nombreSeccion = collection["nombreSeccion"];
                seccion.descripcion = collection["descripcion"];
                seccion.latitud = collection["latitud"];
                seccion.longitud = collection["longitud"];
                seccion.urlYoutube = collection["urlYoutube"];
                seccion.opcion = 2;
                seccion.user = User.Identity.Name;
                seccion.tipoArchivo = "";
                seccion.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                seccion.alt = collection["alt"];
                seccion.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                seccionDatos.AbcCatSeccion(seccion);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Secciones/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = seccion.nombreArchivo + fileExtension;

                    seccion.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    seccion.pathImg = "~/Imagenes/Secciones/" + fileName;
                    seccion.opcion = 5;
                    seccionDatos.AbcCatSeccion(seccion);
                }
                else
                {
                    seccion.pathImg = collection["pathImg"];

                    string baseDir = Server.MapPath("~/Imagenes/Secciones/");
                    string fileExtension = Path.GetExtension(seccion.pathImg);
                    string fileName = seccion.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + seccion.pathImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Secciones/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    seccion.pathImg = "~/Imagenes/Secciones/" + fileName;
                    seccion.tipoArchivo = fileExtension;
                    seccion.opcion = 5;
                    seccionDatos.AbcCatSeccion(seccion);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "La sección se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Secciones/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Secciones/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                seccion.id_seccion = id;
                seccion.opcion = 3;
                seccion.user = User.Identity.Name;
                seccionDatos.AbcCatSeccion(seccion);
                TempData["typemessage"] = "1";
                TempData["message"] = "La sección se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameSeccionAvailability(string nombreArchivo)
        {
            SeccionModels Seccion = new SeccionModels();
            SeccionDatos SeccionD = new SeccionDatos();
            Seccion.conexion = _conexion;
            Seccion.nombreArchivo = nombreArchivo;
            return Json(SeccionD.CheckSeccionesNameSeccion(Seccion), JsonRequestBehavior.AllowGet);
        }
    }
}
