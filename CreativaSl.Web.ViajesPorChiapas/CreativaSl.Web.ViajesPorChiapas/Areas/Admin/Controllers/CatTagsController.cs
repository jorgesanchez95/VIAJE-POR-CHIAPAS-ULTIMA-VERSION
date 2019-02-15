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
    public class CatTagsController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/CatTags/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                CatTagsModels tags = new CatTagsModels();
                TagsDatos tagsDatos = new TagsDatos();
                tags.conexion = _conexion;
                tags = tagsDatos.ObtenerListaTags(tags);
                return View(tags);
            }
            catch (Exception)
            {
                CatTagsModels tags = new CatTagsModels();
                tags.tablaTags = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(tags);
            }
        }
        // GET: Admin/LugaresTuristicos/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                CatTagsModels tags = new CatTagsModels();
                TagsDatos tagsDatos = new TagsDatos();
                tags.conexion = _conexion;
                tags.tablaTipoTagCmb = tagsDatos.ObtenerComboTipoTag(tags);
                var list = new SelectList(tags.tablaTipoTagCmb, "id_tipoTag", "descripcion");
                ViewData["cmbTipoTag"] = list;

                return View(tags);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/LugaresTuristicos/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CatTagsModels tags = new CatTagsModels();
                TagsDatos tagsDatos = new TagsDatos();
                tags.conexion = _conexion;
                tags.id_tipoTag = Convert.ToInt32(collection["tablaTipoTagCmb"]);
                tags.nombre = collection["nombre"];
                tags.icon = collection["icons-tag"];
                tags.nombreIngles = collection["nombreIngles"];
                tags.descripcion = collection["descripcion"];
                tags.descripcionIngles = collection["descripcionIngles"];
                tags.pathImg = "~/Imagenes/default.png";
                tags.opcion = 1;
                tags.user = User.Identity.Name;

                tags.tipoArchivo = "";
                tags.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                tags.alt = collection["alt"];
                tags.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                tags = tagsDatos.AbcCatTags(tags);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Tags/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = tags.nombreArchivo + fileExtension;

                    tags.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    tags.pathImg = "~/Imagenes/Tags/" + fileName;
                    tags.opcion = 4;
                    tagsDatos.AbcCatTags(tags);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "El Tag se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/LugaresTuristicos/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                CatTagsModels tags = new CatTagsModels();
                TagsDatos tagsDatos = new TagsDatos();
                tags.id_tag = id;
                tags.conexion = _conexion;
                tags = tagsDatos.ObtenerDetalleTagxId(tags);

                tags.tablaTipoTagCmb = tagsDatos.ObtenerComboTipoTag(tags);
                var list = new SelectList(tags.tablaTipoTagCmb, "id_tipoTag", "descripcion");
                ViewData["cmbTipoTag"] = list;

                return View(tags);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/LugaresTuristicos/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                CatTagsModels tags = new CatTagsModels();
                TagsDatos tagsDatos = new TagsDatos();
                tags.conexion = _conexion;
                tags.id_tag = collection["id_tag"];
                tags.id_tipoTag = Convert.ToInt32(collection["tablaTipoTagCmb"]);
                tags.icon = collection["icons-tag"];
                tags.nombre = collection["nombre"];
                tags.nombreIngles = collection["nombreIngles"];
                tags.descripcion = collection["descripcion"];
                tags.descripcionIngles = collection["descripcionIngles"];
                tags.pathImg = "~/Imagenes/default.png";
                tags.opcion = 2;
                tags.user = User.Identity.Name;

                tags.tipoArchivo = "";
                tags.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                tags.alt = collection["alt"];
                tags.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                tags = tagsDatos.AbcCatTags(tags);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Tags/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = tags.nombreArchivo + fileExtension;

                    tags.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    tags.pathImg = "~/Imagenes/Tags/" + fileName;
                    tags.opcion = 4;
                    tagsDatos.AbcCatTags(tags);
                }
                else
                {
                    tags.pathImg = collection["pathImg"];

                    string baseDir = Server.MapPath("~/Imagenes/Tags/");
                    string fileExtension = Path.GetExtension(tags.pathImg);
                    string fileName = tags.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + tags.pathImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Tags/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    tags.pathImg = "~/Imagenes/Tags/" + fileName;
                    tags.tipoArchivo = fileExtension;
                    tags.opcion = 4;
                    tagsDatos.AbcCatTags(tags);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "El tag se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/LugaresTuristicos/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/LugaresTuristicos/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                CatTagsModels tags = new CatTagsModels();
                TagsDatos tagsDatos = new TagsDatos();
                tags.conexion = _conexion;
                tags.id_tag = id;
                tags.opcion = 3;
                tags.user = User.Identity.Name;
                tagsDatos.AbcCatTags(tags);
                TempData["typemessage"] = "1";
                TempData["message"] = "El tag se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameTagsAvailability(string nombreArchivo)
        {
            CatTagsModels tags = new CatTagsModels();
            TagsDatos tagsDatos = new TagsDatos();
            tags.conexion = _conexion;
            tags.nombreArchivo = nombreArchivo;
            return Json(tagsDatos.CheckTagsArchivoNameTags(tags), JsonRequestBehavior.AllowGet);
        }
    }
}
