using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Globalization;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class CatMultimediaPromocionesController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/CatMultimediaEncabezado/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia = multimediaDatos.ObtenerListaMultimediaXEncabezado(multimedia);
                return View(multimedia);
            }
            catch (Exception)
            {
                MultimediaModels multimedia = new MultimediaModels();
                multimedia.tablaMultimedia = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(multimedia);
            }
        }
        // GET: Admin/CaMultimediaBanner/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = Conexion;
                multimedia.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(multimedia.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                return View(multimedia);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CaMultimediaBanner/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia.descripcion = collection["descripcion"];
                multimedia.descripcionIngles = collection["descripcionIngles"];
                multimedia.nombre = collection["nombre"];
                multimedia.nombreIngles = collection["nombreIngles"];
                multimedia.id_seccion = collection["tablaSeccionesCmb"];
                multimedia.fec_ini = DateTime.ParseExact(collection["fec_ini"],"dd/MM/yyyy",CultureInfo.InvariantCulture);
                multimedia.fec_fin = DateTime.ParseExact(collection["fec_fin"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                multimedia.pathMul = "~/Imagenes/default.png";
                multimedia.alt = collection["alt"];
                multimedia.title = collection["title"];
                multimedia.opcion = 1;
                multimedia.user = User.Identity.Name;
                multimedia.tipoArchivo = "";
                multimedia.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre"]);
                multimedia.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                multimedia = multimediaDatos.AbcCatMultimediaXEncabezado(multimedia);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Encabezado/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = multimedia.nombreArchivo + fileExtension;

                    multimedia.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    multimedia.pathMul = "~/Imagenes/Encabezado/" + fileName;
                    multimedia.opcion = 4;
                    multimediaDatos.AbcCatMultimediaXEncabezado(multimedia);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "Encabezado se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CaMultimediaBanner/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                multimedia.conexion = Conexion;
                seccion.conexion = Conexion;
                multimedia.id_multimedia = id;
                multimedia = multimediaDatos.ObtenerDetalleMultimediaEncabezadoxId(multimedia);
                multimedia.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(multimedia.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                return View(multimedia);

            }
            catch (Exception)
            {
                UsuarioModels usuario = new UsuarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CaMultimediaBanner/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia.id_multimedia = collection["id_multimedia"];
                multimedia.descripcion = collection["descripcion"];
                multimedia.descripcionIngles = collection["descripcionIngles"];
                multimedia.nombre = collection["nombre"];
                multimedia.nombreIngles = collection["nombreIngles"];
                multimedia.id_seccion = collection["tablaSeccionesCmb"];
                multimedia.fec_ini = DateTime.ParseExact(collection["fec_ini"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                multimedia.fec_fin = DateTime.ParseExact(collection["fec_fin"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                multimedia.pathMul = "~/Imagenes/default.png";
                multimedia.alt = collection["alt"];
                multimedia.title = collection["title"];
                multimedia.opcion = 2;
                multimedia.user = User.Identity.Name;
                multimedia.tipoArchivo = "";
                multimedia.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre"]);
                multimedia.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                multimedia = multimediaDatos.AbcCatMultimediaXEncabezado(multimedia);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Encabezado/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = multimedia.nombreArchivo + fileExtension;

                    multimedia.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    multimedia.pathMul = "~/Imagenes/Encabezado/" + fileName;
                    multimedia.opcion = 4;
                    multimediaDatos.AbcCatMultimediaXEncabezado(multimedia);
                }
                else
                {
                    multimedia.pathMul = collection["pathMul"];

                    string baseDir = Server.MapPath("~/Imagenes/Encabezado/");
                    string fileExtension = Path.GetExtension(multimedia.pathMul);
                    string fileName = multimedia.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + multimedia.pathMul.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Encabezado/" + fileName).Replace("/", "\\").Replace("~", "");

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
                    multimedia.pathMul = "~/Imagenes/Encabezado/" + fileName;
                    multimedia.opcion = 4;
                    multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "Encabezado se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CaMultimediaBanner/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CaMultimediaBanner/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia.id_multimedia = id;
                multimedia.opcion = 3;
                multimedia.user = User.Identity.Name;
                multimediaDatos.AbcCatMultimediaXEncabezado(multimedia);
                TempData["typemessage"] = "1";
                TempData["message"] = "Usuario se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
