using System;
using System.Collections.Generic;
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
    public class ArticulosController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/Articulos/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                ArticulosDatos articulosDatos = new ArticulosDatos();
                articulos.conexion = _conexion;
                articulos = articulosDatos.ObtenerListaArticulos(articulos);
                return View(articulos);
            }
            catch (Exception)
            {
                ArticulosModels articulos = new ArticulosModels();
                articulos.tablaArticulos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(articulos);
            }
        }
        // GET: Admin/Articulos/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                articulos.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(articulos.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                return View(articulos);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Articulos/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                ArticulosDatos articulosDatos = new ArticulosDatos();
                articulos.conexion = _conexion;
                articulos.titulo = collection["titulo"];
                articulos.tituloIngles = collection["tituloIngles"];
                articulos.introduccion = collection["introduccion"];
                articulos.introduccionIngles = collection["introduccionIngles"];
                articulos.contenido = collection["contenido"];
                articulos.contenidoIngles = collection["contenidoIngles"];
                articulos.urlYoutube = collection["urlYoutube"];
                articulos.creadoPor = collection["creadoPor"];
                articulos.id_seccion = collection["tablaSeccionesCmb"];
                articulos.pathImg = "~/Imagenes/default.png";
                articulos.opcion = 1;
                articulos.user = User.Identity.Name;

                articulos.tipoArchivo = "";
                articulos.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                articulos.alt = collection["alt"];
                articulos.title = collection["title"];

                articulos.nombre_pagina = Comun.RemoverSignosAcentos(collection["titulo"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                articulos = articulosDatos.AbcArticulos(articulos);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Articulos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = articulos.nombreArchivo + fileExtension;

                    articulos.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    articulos.pathImg = "~/Imagenes/Articulos/" + fileName;
                    articulos.opcion = 4;
                    articulosDatos.AbcArticulos(articulos);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "El articulo se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Articulos/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                ArticulosDatos articulosDatos = new ArticulosDatos();
                articulos.conexion = _conexion;
                articulos.id_post = id;

                articulos = articulosDatos.ObtenerDetalleArticulosxId(articulos);

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                articulos.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(articulos.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;
                
                return View(articulos);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Articulos/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                ArticulosDatos articulosDatos = new ArticulosDatos();
                articulos.conexion = _conexion;
                articulos.id_post = collection["id_post"];
                articulos.titulo = collection["titulo"];
                articulos.tituloIngles = collection["tituloIngles"];
                articulos.introduccion = collection["introduccion"];
                articulos.introduccionIngles = collection["introduccionIngles"];
                articulos.contenido = collection["contenido"];
                articulos.creadoPor = collection["creadoPor"];
                articulos.urlYoutube = collection["urlYoutube"];
                articulos.contenidoIngles = collection["contenidoIngles"];
                articulos.id_seccion = collection["tablaSeccionesCmb"];
                articulos.pathImg = "~/Imagenes/default.png";
                articulos.opcion = 2;
                articulos.user = User.Identity.Name;

                articulos.tipoArchivo = "";
                articulos.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                articulos.alt = collection["alt"];
                articulos.title = collection["title"];

                articulos.nombre_pagina = Comun.RemoverSignosAcentos(collection["titulo"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                articulos = articulosDatos.AbcArticulos(articulos);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Articulos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = articulos.nombreArchivo + fileExtension;

                    articulos.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    articulos.pathImg = "~/Imagenes/Articulos/" + fileName;
                    articulos.opcion = 4;
                    articulosDatos.AbcArticulos(articulos);
                }
                else
                {
                    articulos.pathImg = collection["pathImg"];

                    string baseDir = Server.MapPath("~/Imagenes/Articulos/");
                    string fileExtension = Path.GetExtension(articulos.pathImg);
                    string fileName = articulos.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + articulos.pathImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Articulos/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    articulos.pathImg = "~/Imagenes/Articulos/" + fileName;
                    articulos.tipoArchivo = fileExtension;
                    articulos.opcion = 4;
                    articulosDatos.AbcArticulos(articulos);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "El articulo se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Articulos/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Articulos/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                ArticulosDatos articulosDatos = new ArticulosDatos();
                articulos.conexion = _conexion;
                articulos.id_post = id;
                articulos.opcion = 3;
                articulos.user = User.Identity.Name;
                articulosDatos.AbcArticulos(articulos);
                TempData["typemessage"] = "1";
                TempData["message"] = "El articulo se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Admin/Articulos/Tags
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Tags(string id)
        {
            try
            {
                RelacionTagsModels relacionTags = new RelacionTagsModels();
                RelacionTagsDatos relacionTagsDatos = new RelacionTagsDatos();
                relacionTags.conexion = _conexion;
                relacionTags.id_datoRelacionado = id;
                relacionTags.id_tipoDatoRelacionado = 4;
                relacionTags = relacionTagsDatos.ObtenerListaRelacionTagsXIdTipo(relacionTags);
                return View(relacionTags);
            }
            catch (Exception)
            {
                RelacionTagsModels relacionTags = new RelacionTagsModels();
                relacionTags.tablaRelacionTags = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(relacionTags);
            }
        }

        // GET: Admin/Articulos/AddTags
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult AddTags(string id)
        {
            try
            {
                RelacionTagsModels relacionTags = new RelacionTagsModels();
                TagsDatos tagsDatos = new TagsDatos();
                relacionTags.id_datoRelacionado = id;
                relacionTags.conexion = _conexion;
                relacionTags.id_tipoTag = 4;
                relacionTags.tablaTagsCmb = tagsDatos.ObtenerComboTags(relacionTags);
                var list = new SelectList(relacionTags.tablaTagsCmb, "id_tag", "nombre");
                ViewData["cmbTags"] = list;

                return View(relacionTags);
            }
            catch (Exception)
            {
                RelacionTagsModels relacionTags = new RelacionTagsModels();
                relacionTags.id_datoRelacionado = id;
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede mostrar la vista";
                return RedirectToAction("Tags", new { id = relacionTags.id_datoRelacionado });
            }
        }

        // POSt: Admin/Articulos/CreateIntegrante
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult AddTags(FormCollection collection)
        {
            try
            {
                RelacionTagsModels relacionTags = new RelacionTagsModels();
                RelacionTagsDatos relacionTagsDatos = new RelacionTagsDatos();
                relacionTags.conexion = _conexion;
                relacionTags.id_datoRelacionado = collection["id_datoRelacionado"];
                relacionTags.id_tag = collection["tablaTagsCmb"];
                relacionTags.id_tipoDatoRelacionado = 4;
                relacionTags.opcion = 1;
                relacionTags.user = User.Identity.Name;
                relacionTagsDatos.AbcRelacionTags(relacionTags);
                TempData["typemessage"] = "1";
                TempData["message"] = "Los Tags se agregaron correctamente";
                return RedirectToAction("Tags", new { id = relacionTags.id_datoRelacionado });
            }
            catch (Exception)
            {
                RelacionTagsModels relacionTags = new RelacionTagsModels();
                relacionTags.id_datoRelacionado = collection["id_datoRelacionado"];
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede guardar correctamente";
                return RedirectToAction("Tags", new { id = relacionTags.id_datoRelacionado });
            }
        }

        // GET: Admin/Articulos/DeleteTag/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult DeleteTag(string id)
        {
            return View();
        }
        // POST: Admin/Articulos/DeleteTag/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult DeleteTag(string id, FormCollection collection)
        {
            try
            {
                RelacionTagsModels relacionTags = new RelacionTagsModels();
                RelacionTagsDatos relacionTagsDatos = new RelacionTagsDatos();
                relacionTags.conexion = _conexion;
                relacionTags.id_relacionTags = id;
                relacionTags.opcion = 3;
                relacionTags.user = User.Identity.Name;
                relacionTagsDatos.AbcRelacionTags(relacionTags);
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
        public ActionResult CheckNameArticuloAvailability(string nombreArchivo)
        {
            ArticulosModels articulos = new ArticulosModels();
            ArticulosDatos ArticuloDatos = new ArticulosDatos();
            articulos.conexion = _conexion;
            articulos.nombreArchivo = nombreArchivo;
            return Json(ArticuloDatos.CheckArticuloArchivoNameArticulo(articulos), JsonRequestBehavior.AllowGet);
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNombreESArticuloAvailability(string titulo)
        {
            ArticulosModels articulos = new ArticulosModels();
            ArticulosDatos ArticuloDatos = new ArticulosDatos();
            articulos.conexion = _conexion;
            articulos.titulo = titulo;
            return Json(ArticuloDatos.CheckArticuloArchivoNameTituloEs(articulos), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNombreIngArticulovailability(string tituloIngle)
        {
            ArticulosModels articulos = new ArticulosModels();
            ArticulosDatos ArticuloDatos = new ArticulosDatos();
            articulos.conexion = _conexion;
            articulos.tituloIngles = tituloIngle;
            return Json(ArticuloDatos.CheckArticuloArchivoNameTituloIng(articulos), JsonRequestBehavior.AllowGet);
        }
    }
}
