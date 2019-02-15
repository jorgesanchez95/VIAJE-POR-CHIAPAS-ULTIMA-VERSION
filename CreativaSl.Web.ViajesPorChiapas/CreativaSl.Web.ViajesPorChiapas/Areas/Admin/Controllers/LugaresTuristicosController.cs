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
    public class LugaresTuristicosController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/LugaresTuristicos/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                LugaresTuristicosDatos lugaresTuristicosDatos = new LugaresTuristicosDatos();
                lugaresTuristicos.conexion = Conexion;
                lugaresTuristicos = lugaresTuristicosDatos.ObtenerListaLugaresTuristicos(lugaresTuristicos);
                return View(lugaresTuristicos);
            }
            catch (Exception)
            {
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                lugaresTuristicos.tablaLugaresTuristicos = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(lugaresTuristicos);
            }
        }
        // GET: Admin/LugaresTuristicos/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();

                lugaresTuristicos.latitud = "23.634501";
                lugaresTuristicos.longitud = "-102.55278399999997";

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = Conexion;
                lugaresTuristicos.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(lugaresTuristicos.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                EstadoModels estado = new EstadoModels();
                ComunDatos comunDatos = new ComunDatos();
                estado.conexion = Conexion;
                lugaresTuristicos.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(lugaresTuristicos.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                lugaresTuristicos.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(lugaresTuristicos.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = Conexion;
                lugaresTuristicos.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(lugaresTuristicos.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;
            

                return View(lugaresTuristicos);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        //  POST: Admin/LugaresTuristicos/Estado/
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Estado(int id)
        {
            try
            {
                EstadoModels estado = new EstadoModels();
                ComunDatos comunDatos = new ComunDatos();

                List<EstadoModels> lstMunicipio = new List<EstadoModels>();
                estado.id_pais = id;
                estado.conexion = Conexion;
                lstMunicipio = comunDatos.ObtenerComboCatEstados(estado);
                return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //  POST: Admin/LugaresTuristicos/Municipio/6
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Municipio(int idPais, int id)
        {
            try
            {
                MunicipioModels municipio = new MunicipioModels();
                ComunDatos comunDatos = new ComunDatos();

                List<MunicipioModels> lstMunicipio = new List<MunicipioModels>();
                municipio.id_estado = id;
                municipio.id_pais = idPais;
                municipio.conexion = Conexion;
                lstMunicipio = comunDatos.ObtenerComboCatMunicipios(municipio);
                return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        // POST: Admin/LugaresTuristicos/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                LugaresTuristicosDatos lugaresTuristicosDatos = new LugaresTuristicosDatos();
                lugaresTuristicos.conexion = Conexion;
                lugaresTuristicos.nombre = collection["nombre"];
                lugaresTuristicos.latitud = collection["latitud"];
                lugaresTuristicos.longitud = collection["longitud"];
                lugaresTuristicos.id_seccion = collection["tablaSeccionesCmb"];
                lugaresTuristicos.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                lugaresTuristicos.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                lugaresTuristicos.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                lugaresTuristicos.pathImg = "~/Imagenes/default.png";
                lugaresTuristicos.descripcion = collection["descripcion"];
                lugaresTuristicos.descripcion_ingles = collection["descripcion_ingles"];
                lugaresTuristicos.opcion = 1;
                lugaresTuristicos.user = User.Identity.Name;

                lugaresTuristicos.tipoArchivo = "";
                lugaresTuristicos.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                lugaresTuristicos.alt = collection["alt"];
                lugaresTuristicos.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                lugaresTuristicos = lugaresTuristicosDatos.AbcCatLugaresTuristicos(lugaresTuristicos);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/LugaresTuristicos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = lugaresTuristicos.nombreArchivo + fileExtension;

                    lugaresTuristicos.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    lugaresTuristicos.pathImg = "~/Imagenes/LugaresTuristicos/" + fileName;
                    lugaresTuristicos.opcion = 4;
                    lugaresTuristicosDatos.AbcCatLugaresTuristicos(lugaresTuristicos);
                }

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
        // GET: Admin/LugaresTuristicos/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                LugaresTuristicosDatos lugaresTuristicosDatos = new LugaresTuristicosDatos();
                lugaresTuristicos.id_lugar = id;
                lugaresTuristicos.conexion = Conexion;
                lugaresTuristicos = lugaresTuristicosDatos.ObtenerDetalleLugaresTuristicosxId(lugaresTuristicos);
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = Conexion;
                lugaresTuristicos.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(lugaresTuristicos.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                EstadoModels estado = new EstadoModels();
                ComunDatos comunDatos = new ComunDatos();
                estado.conexion = Conexion;
                lugaresTuristicos.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(lugaresTuristicos.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                lugaresTuristicos.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(lugaresTuristicos.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = Conexion;
                lugaresTuristicos.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(lugaresTuristicos.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;
                return View(lugaresTuristicos);
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
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                LugaresTuristicosDatos lugaresTuristicosDatos = new LugaresTuristicosDatos();
                lugaresTuristicos.conexion = Conexion;
                lugaresTuristicos.id_lugar = collection["id_lugar"];
                lugaresTuristicos.nombre = collection["nombre"];
                lugaresTuristicos.latitud = collection["latitud"];
                lugaresTuristicos.longitud = collection["longitud"];
                lugaresTuristicos.id_seccion = collection["tablaSeccionesCmb"];
                lugaresTuristicos.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                lugaresTuristicos.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                lugaresTuristicos.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                lugaresTuristicos.pathImg = "~/Imagenes/default.png";
                lugaresTuristicos.descripcion = collection["descripcion"];
                lugaresTuristicos.descripcion_ingles = collection["descripcion_ingles"];
                lugaresTuristicos.opcion = 2;
                lugaresTuristicos.user = User.Identity.Name;

                lugaresTuristicos.tipoArchivo = "";
                lugaresTuristicos.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                lugaresTuristicos.alt = collection["alt"];
                lugaresTuristicos.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                lugaresTuristicos = lugaresTuristicosDatos.AbcCatLugaresTuristicos(lugaresTuristicos);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/LugaresTuristicos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = lugaresTuristicos.nombreArchivo + fileExtension;

                    lugaresTuristicos.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    lugaresTuristicos.pathImg = "~/Imagenes/LugaresTuristicos/" + fileName;
                    lugaresTuristicos.opcion = 4;
                    lugaresTuristicosDatos.AbcCatLugaresTuristicos(lugaresTuristicos);
                }
                else
                {
                    lugaresTuristicos.pathImg = collection["pathImg"];

                    string baseDir = Server.MapPath("~/Imagenes/LugaresTuristicos/");
                    string fileExtension = Path.GetExtension(lugaresTuristicos.pathImg);
                    string fileName = lugaresTuristicos.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + lugaresTuristicos.pathImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/LugaresTuristicos/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    lugaresTuristicos.pathImg = "~/Imagenes/LugaresTuristicos/" + fileName;
                    lugaresTuristicos.tipoArchivo = fileExtension;
                    lugaresTuristicos.opcion = 4;
                    lugaresTuristicosDatos.AbcCatLugaresTuristicos(lugaresTuristicos);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "El lugar se ha editado correctamente";
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
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                LugaresTuristicosDatos lugaresTuristicosDatos = new LugaresTuristicosDatos();
                lugaresTuristicos.conexion = Conexion;
                lugaresTuristicos.id_lugar = id;
                lugaresTuristicos.opcion = 3;
                lugaresTuristicos.user = User.Identity.Name;
                lugaresTuristicosDatos.AbcCatLugaresTuristicos(lugaresTuristicos);
                TempData["typemessage"] = "1";
                TempData["message"] = "El Lugar se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        // GET: /Admin/LugaresTuristicos/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult AddFotos(string id, string id2)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia.id_lugar = id;
                multimedia.id_seccion = id2;
                multimedia = multimediaDatos.ObtenerListaMultimediaXLugar(multimedia);
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
        // GET: Admin/LugaresTuristicos/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult CreateFoto(string id, string id2)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                multimedia.id_lugar = id;
                multimedia.id_seccion = id2;

                return View(multimedia);
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
        public ActionResult CreateFoto( string id, string id2, FormCollection collection)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia.id_lugar = collection["id_lugar"];
                multimedia.descripcion = collection["descripcion"];
                multimedia.descripcionIngles = collection["descripcionIngles"];
                multimedia.id_seccion = collection["id_seccion"];
                multimedia.pathMul = "~/Imagenes/default.png";
                multimedia.alt = collection["alt"];
                multimedia.title = collection["title"];
                multimedia.opcion = 1;
                multimedia.user = User.Identity.Name;
                multimedia.tipoArchivo = "";
                multimedia.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                multimedia = multimediaDatos.AbcCatMultimediaXLugar(multimedia);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/LugaresTuristicos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = multimedia.nombreArchivo + fileExtension;

                    multimedia.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    multimedia.pathMul = "~/Imagenes/LugaresTuristicos/" + fileName;
                    multimedia.opcion = 4;
                    multimediaDatos.AbcCatMultimediaXLugar(multimedia);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "La foto se ha cargado correctamente";
                return RedirectToAction("AddFotos", new { id = multimedia.id_lugar, id2 = multimedia.id_seccion});
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
        public ActionResult EditFoto(string id, string id2)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();

                multimedia.conexion = Conexion;
                multimedia.id_multimedia = id;
                multimedia.id_lugar = id2;
                multimedia = multimediaDatos.ObtenerDetalleMultimediaLugarxId(multimedia);

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
        // POST: Admin/LugaresTuristicos/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult EditFoto(FormCollection collection)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.id_multimedia = collection["id_multimedia"];
                multimedia.conexion = Conexion;
                multimedia.id_lugar = collection["id_lugar"];
                multimedia.descripcion = collection["descripcion"];
                multimedia.descripcionIngles = collection["descripcionIngles"];
                multimedia.id_seccion = collection["id_seccion"];
                multimedia.pathMul = "~/Imagenes/default.png";
                multimedia.alt = collection["alt"];
                multimedia.title = collection["title"];
                multimedia.opcion = 2;
                multimedia.user = User.Identity.Name;
                multimedia.tipoArchivo = "";
                multimedia.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                multimedia = multimediaDatos.AbcCatMultimediaXLugar(multimedia);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/LugaresTuristicos/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = multimedia.nombreArchivo + fileExtension;

                    multimedia.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    multimedia.pathMul = "~/Imagenes/LugaresTuristicos/" + fileName;
                    multimedia.opcion = 4;
                    multimediaDatos.AbcCatMultimediaXLugar(multimedia);
                }
                else
                {
                    multimedia.pathMul = collection["pathMul"];

                    string baseDir = Server.MapPath("~/Imagenes/LugaresTuristicos/");
                    string fileExtension = Path.GetExtension(multimedia.pathMul);
                    string fileName = multimedia.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + multimedia.pathMul.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/LugaresTuristicos/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    multimedia.pathMul = "~/Imagenes/LugaresTuristicos/" + fileName;
                    multimedia.opcion = 4;
                    multimediaDatos.AbcCatMultimediaXGaleria(multimedia);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "La Foto del Lugar se ha editado correctamente";
                return RedirectToAction("AddFotos", new { id = multimedia.id_lugar, id2 = multimedia.id_seccion});
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
        public ActionResult DeleteFoto(string id)
        {
            return View();
        }
        // POST: Admin/LugaresTuristicos/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult DeleteFoto(string id, FormCollection collection)
        {
            try
            {
                MultimediaModels multimedia = new MultimediaModels();
                MultimediaDatos multimediaDatos = new MultimediaDatos();
                multimedia.conexion = Conexion;
                multimedia.id_multimedia = id;
                multimedia.opcion = 3;
                multimedia.user = User.Identity.Name;
                multimediaDatos.AbcCatMultimediaXLugar(multimedia);
                TempData["typemessage"] = "1";
                TempData["message"] = "La Foto se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameLugaresTuristicosAvailability(string nombreArchivo)
        {
            LugaresTuristicosModels LugaresTuristicos = new LugaresTuristicosModels();
            LugaresTuristicosDatos LugaresTuristicoss = new LugaresTuristicosDatos();
            LugaresTuristicos.conexion = Conexion;
            LugaresTuristicos.nombreArchivo = nombreArchivo;
            return Json(LugaresTuristicoss.CheckLugaresTuristicosArchivoNameLugares(LugaresTuristicos), JsonRequestBehavior.AllowGet);
        }
    }
}
