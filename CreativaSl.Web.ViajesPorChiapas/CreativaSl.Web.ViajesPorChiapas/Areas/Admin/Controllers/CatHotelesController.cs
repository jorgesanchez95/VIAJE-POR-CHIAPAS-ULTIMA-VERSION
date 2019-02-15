using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web.UI;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class CatHotelesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/CatHoteles/

        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                HotelesModels hoteles = new HotelesModels();
                HotelesDatos hotelesDatos = new HotelesDatos();
                hoteles.conexion = _conexion;
                hoteles = hotelesDatos.ObtenerListaHoteles(hoteles);
                return View(hoteles);
            }
            catch (Exception)
            {
                HotelesModels hoteles = new HotelesModels { tablaHoteles = new DataTable() };
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(hoteles);
            }
        }

        // GET: /Admin/CatHoteles/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                HotelesModels hoteles = new HotelesModels();

                hoteles.latitud = "23.634501";
                hoteles.longitud = "-102.55278399999997";

                ComunDatos comunDatos = new ComunDatos();
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                hoteles.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(hoteles.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;


                EstadoModels estado = new EstadoModels();
                estado.conexion = _conexion;
                hoteles.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(hoteles.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                hoteles.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(hoteles.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = _conexion;
                hoteles.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(hoteles.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;

                return View(hoteles);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        //  POST: Admin/CatHoteles/Municipio/6
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
                municipio.conexion = _conexion;
                lstMunicipio = comunDatos.ObtenerComboCatMunicipios(municipio);
                return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Admin/CatHoteles/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                HotelesModels hoteles = new HotelesModels();
                HotelesDatos hotelesDatos = new HotelesDatos();
                hoteles.conexion = _conexion;
                hoteles.id_seccion = collection["tablaSeccionesCmb"];
                hoteles.nombre = collection["nombre"];
                hoteles.encargado = collection["encargado"];
                hoteles.telefonolocal = collection["telefonolocal"];
                hoteles.telefonomovil = collection["telefonomovil"];
                hoteles.correoelectronico = collection["correoelectronico"];
                hoteles.direccion = collection["direccion"];
                hoteles.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                hoteles.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                hoteles.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                hoteles.latitud = collection["latitud"];
                hoteles.longitud = collection["longitud"];
                hoteles.pathMul = "~/Imagenes/default.png";
                hoteles.numestrellas = Convert.ToInt32(collection["numeroEstrellas"]);
                hoteles.descripcion = collection["descripcion"];
                hoteles.descripcion_ingles = collection["descripcion_ingles"];
                hoteles.opcion = 1;
                hoteles.user = User.Identity.Name;

                hoteles.tipoArchivo = "";
                hoteles.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                hoteles.alt = collection["alt"];
                hoteles.title = collection["title"];

                hoteles.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                hoteles = hotelesDatos.AbcCatHoteles(hoteles);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Hoteles/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = hoteles.nombreArchivo + fileExtension;

                    hoteles.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    hoteles.pathMul = "~/Imagenes/Hoteles/" + fileName;
                    hoteles.opcion = 4;
                    hotelesDatos.AbcCatHoteles(hoteles);
                }

                   
                TempData["typemessage"] = "1";
                TempData["message"] = "El Hotel se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: /Admin/CatHoteles/Edit
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                HotelesModels hoteles = new HotelesModels();
                HotelesDatos hotelesDatos = new HotelesDatos();
                hoteles.conexion = _conexion;
                hoteles.id_hotel = id;
                hotelesDatos.ObtenerDetalleHotelesxId(hoteles);

                ComunDatos comunDatos = new ComunDatos();
                
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                hoteles.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(hoteles.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                EstadoModels estado = new EstadoModels();
                estado.conexion = _conexion;
                hoteles.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(hoteles.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                hoteles.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(hoteles.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = _conexion;
                hoteles.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(hoteles.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;

                return View(hoteles);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatHoteles/Edit
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                HotelesModels hoteles = new HotelesModels();
                HotelesDatos hotelesDatos = new HotelesDatos();
                hoteles.conexion = _conexion;
                hoteles.id_hotel = collection["id_hotel"];
                hoteles.id_seccion = collection["tablaSeccionesCmb"];
                hoteles.nombre = collection["nombre"];
                hoteles.encargado = collection["encargado"];
                hoteles.telefonolocal = collection["telefonolocal"];
                hoteles.telefonomovil = collection["telefonomovil"];
                hoteles.correoelectronico = collection["correoelectronico"];
                hoteles.direccion = collection["direccion"];
                hoteles.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                hoteles.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                hoteles.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                hoteles.latitud = collection["latitud"];
                hoteles.longitud = collection["longitud"];
                hoteles.pathMul = "~/Imagenes/default.png";
                hoteles.numestrellas = Convert.ToInt32(collection["numeroEstrellas"]);
                hoteles.descripcion = collection["descripcion"];
                hoteles.descripcion_ingles = collection["descripcion_ingles"];
                hoteles.opcion = 2;
                hoteles.user = User.Identity.Name;
                hoteles.tipoArchivo = "";
                hoteles.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                hoteles.alt = collection["alt"];
                hoteles.title = collection["title"];

                hoteles.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre_pagina"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                hoteles = hotelesDatos.AbcCatHoteles(hoteles);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Hoteles/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = hoteles.nombreArchivo + fileExtension;

                    hoteles.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    hoteles.pathMul = "~/Imagenes/Hoteles/" + fileName;
                    hoteles.opcion = 4;
                    hotelesDatos.AbcCatHoteles(hoteles);
                }
                else
                {
                    hoteles.pathMul = collection["pathMul"];

                    string baseDir = Server.MapPath("~/Imagenes/Hoteles/");
                    string fileExtension = Path.GetExtension(hoteles.pathMul);
                    string fileName = hoteles.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + hoteles.pathMul.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Hoteles/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    hoteles.pathMul = "~/Imagenes/Hoteles/" + fileName;
                    hoteles.opcion = 4;
                    hotelesDatos.AbcCatHoteles(hoteles);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "El Hotel se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatHoteles/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CatHoteles/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                HotelesModels hoteles = new HotelesModels();
                HotelesDatos hotelesDatos = new HotelesDatos();
                hoteles.conexion = _conexion;
                hoteles.id_hotel = id;
                hoteles.opcion = 3;
                hoteles.user = User.Identity.Name;
                hotelesDatos.AbcCatHoteles(hoteles);
                TempData["typemessage"] = "1";
                TempData["message"] = "Hotel se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Admin/CatHoteles/Tags
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
                relacionTags.id_tipoDatoRelacionado = 3;
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

        // GET: Admin/CatHoteles/AddTags
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
                relacionTags.id_tipoTag = 3;
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

        // POSt: Admin/CatGrupos/CreateIntegrante
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
                relacionTags.id_tipoDatoRelacionado = 3;
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

        // GET: Admin/CatPaquetes/DeleteTag/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult DeleteTag(string id)
        {
            return View();
        }
        // POST: Admin/CatPaquetes/DeleteTag/5
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
        public ActionResult CheckNombreESHotelesAvailability(string nombre)
        {
            HotelesModels hoteles = new HotelesModels();
            HotelesDatos hotelesDatos = new HotelesDatos();
            hoteles.conexion = _conexion;
            hoteles.nombre = nombre;
            return Json(hotelesDatos.CheckHotelArchivoNnombreEsP(hoteles), JsonRequestBehavior.AllowGet);
        }
    }
}
