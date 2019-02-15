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
    public class GaleriaController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/Galeria/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia = multimediaDatos.ObtenerListaMultimediaXGaleria(multimedia);
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
        // GET: Admin/Galeria/Create
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


                multimedia.tablaTipoGaleriaCmb = new List<TipoGaleriaModels>();
                var list2 = new SelectList(multimedia.tablaTipoGaleriaCmb, "id_tipoGaleria", "descripcion");
                ViewData["cmbTipoGaleria"] = list2;

                //multimedia.conexion = Conexion;
                //multimedia.tablaTipoGaleriaCmb = multimediaDatos.ObtenerComboTipoGaleriaXSeccion(multimedia);
                //list = new SelectList(multimedia.tablaTipoGaleriaCmb, "id_tipoGaleria", "descripcion");
                //ViewData["cmbTipoGaleria"] = list;
                return View(multimedia);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        //  POST: Admin/LugaresTuristicos/Municipio/6
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult TipoGaleria(string id)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();

                List<TipoGaleriaModels> listaTipoGaleria = new List<TipoGaleriaModels>();
                multimedia.conexion = Conexion;
                multimedia.id_seccion = id;

                listaTipoGaleria = multimediaDatos.ObtenerComboTipoGaleriaXSeccion(multimedia);
                return Json(listaTipoGaleria, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        // POST: Admin/Galeria/Create
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
                multimedia.id_seccion = collection["tablaSeccionesCmb"];
                multimedia.id_tipoGaleria = collection["tablaTipoGaleriaCmb"];
                multimedia.pathMul = "~/Imagenes/default.png";
                multimedia.alt = collection["alt"];
                multimedia.title = collection["title"];
                multimedia.opcion = 1;
                multimedia.user = User.Identity.Name;
                multimedia.tipoArchivo = "";
                multimedia.nombreArchivo  = Comun.RemoverAcentos(collection["nombreArchivo"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                multimedia = multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Galeria/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = multimedia.nombreArchivo + fileExtension;

                    multimedia.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    multimedia.pathMul = "~/Imagenes/Galeria/" + fileName;
                    multimedia.opcion = 4;
                    multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "Galeria se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Usuarios/Edit/5
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
                multimedia = multimediaDatos.ObtenerDetalleMultimediaGaleriaxId(multimedia);
                multimedia.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(multimedia.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                multimedia.tablaTipoGaleriaCmb = multimediaDatos.ObtenerComboTipoGaleriaXSeccion(multimedia);
                list = new SelectList(multimedia.tablaTipoGaleriaCmb, "id_tipoGaleria", "descripcion");
                ViewData["cmbTipoGaleria"] = list;
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
        // POST: Admin/Galeria/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                    MultimediaModels multimedia = new MultimediaModels();
                    MultimediaDatos multimediaDatos = new MultimediaDatos();
                    multimedia.conexion = Conexion;
                    multimedia.id_multimedia = collection["id_multimedia"];
                    multimedia.descripcion = collection["descripcion"];
                    multimedia.descripcionIngles = collection["descripcionIngles"];
                    multimedia.id_seccion = collection["tablaSeccionesCmb"];
                    multimedia.id_tipoGaleria = collection["tablaTipoGaleriaCmb"];
                    multimedia.pathMul = "~/Imagenes/default.png";
                    multimedia.alt = collection["alt"];
                    multimedia.title = collection["title"];

                    multimedia.opcion = 2;
                    multimedia.user = User.Identity.Name;
                    multimedia.tipoArchivo = "";
                    multimedia.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);

                    HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                    multimedia = multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                    if (bannerImage != null && bannerImage.ContentLength > 0)
                    {
                        string baseDir = Server.MapPath("~/Imagenes/Galeria/");
                        string fileExtension = Path.GetExtension(bannerImage.FileName);
                        string fileName = multimedia.nombreArchivo + fileExtension;

                        multimedia.tipoArchivo = fileExtension;

                        Stream s = bannerImage.InputStream;
                        Image img = new Bitmap(s);
                        img = Comun.ResizeImage(img, 1250, 800);
                        img.Save(baseDir + fileName);
                        multimedia.pathMul = "~/Imagenes/Galeria/" + fileName;
                        multimedia.opcion = 4;
                        multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                    }
                    else
                    {
                        multimedia.pathMul = collection["pathMul"];

                        string baseDir = Server.MapPath("~/Imagenes/Galeria/");
                        string fileExtension = Path.GetExtension(multimedia.pathMul);
                        string fileName = multimedia.nombreArchivo + fileExtension;

                        string rutaold = Server.MapPath("~") + multimedia.pathMul.Replace("/", "\\").Replace("~", "");
                        string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Galeria/" + fileName).Replace("/", "\\").Replace("~", "");
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
                        multimedia.pathMul = "~/Imagenes/Galeria/" + fileName;
                        multimedia.opcion = 4;
                        multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                    }

                    TempData["typemessage"] = "1";
                    TempData["message"] = "Galeria se ha editado correctamente";
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Galeria/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Galeria/Delete/5
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
                multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                TempData["typemessage"] = "1";
                TempData["message"] = "Imagen se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameGaleriaAvailability(string nombreArchivo)
        {
            MultimediaModels multimedia = new MultimediaModels();
            MultimediaDatos multimediaDatos = new MultimediaDatos();
            multimedia.conexion = Conexion;
            multimedia.nombreArchivo = nombreArchivo;
            return Json(multimediaDatos.CheckGaleriaArchivoNameGaleria(multimedia), JsonRequestBehavior.AllowGet);
        }
    
    }
}
