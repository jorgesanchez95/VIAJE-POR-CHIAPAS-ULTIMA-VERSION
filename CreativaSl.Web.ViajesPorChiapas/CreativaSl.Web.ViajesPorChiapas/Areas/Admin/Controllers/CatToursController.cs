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
    public class CatToursController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/CatTours/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                tours.conexion = _conexion;
                tours = toursDatos.ObtenerListaTours(tours);
                return View(tours);
            }
            catch (Exception)
            {
                ToursModels tours = new ToursModels();
                tours.tablaTours = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(tours);
            }
        }
        // GET: Admin/CatTours/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                ToursModels tours = new ToursModels();

                tours.latitud = "23.634501";
                tours.longitud = "-102.55278399999997";

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                tours.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(tours.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                TipoPaqueteModels tipoPaquete = new TipoPaqueteModels();
                ComunDatos comunDatos = new ComunDatos();
                tipoPaquete.conexion = _conexion;
                tours.tablaTipoPaqueteCmb = comunDatos.ObtenerComboCatTipoPaquete(tipoPaquete);
                list = new SelectList(tours.tablaTipoPaqueteCmb, "id_tipoPaquete", "descripcion");
                ViewData["cmbTipoPaquete"] = list;

                EstadoModels estado = new EstadoModels();
                estado.conexion = _conexion;
                tours.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(tours.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                tours.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(tours.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = _conexion;
                tours.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(tours.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;
                return View(tours);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        //  POST: Admin/CatTours/Estado/6
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
                estado.conexion = _conexion;
                lstMunicipio = comunDatos.ObtenerComboCatEstados(estado);
                return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //  POST: Admin/CatTours/Municipio/6
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
        // POST: Admin/CatTours/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                tours.conexion = _conexion;
                tours.nombre = collection["nombre"];
                tours.nombreIngles = collection["nombreIngles"];
                tours.descripcion = collection["descripcion"];
                tours.descripcionIngles = collection["descripcionIngles"];
                tours.latitud = collection["latitud"];
                tours.longitud = collection["longitud"];
                tours.id_seccion = collection["tablaSeccionesCmb"];
                tours.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                tours.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                tours.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                tours.pathImg = "~/Imagenes/default.png";
                tours.adultoAlta = Convert.ToDecimal(collection["adultoAlta"]);
                tours.adultoBaja = Convert.ToDecimal(collection["adultoBaja"]);
                tours.ninioAlta = Convert.ToDecimal(collection["ninioAlta"]);
                tours.ninioBaja = Convert.ToDecimal(collection["ninioBaja"]);
                tours.cantidadDias = Convert.ToInt32(collection["cantidadDias"]);
                tours.cantidadNoches = Convert.ToInt32(collection["cantidadNoches"]);
                tours.finDeServicios = collection["finDeServicios"];
                tours.finDeServiciosIngles = collection["finDeServiciosIngles"];
                tours.id_tipoPaquete = Convert.ToInt32(collection["tablaTipoPaqueteCmb"]);
                tours.incluye = collection["incluye"];
                tours.incluyeIngles = collection["incluyeIngles"];
                tours.noIncluye = collection["noIncluye"];
                tours.noIncluyeIngles = collection["noIncluyeIngles"];
                tours.observaciones = collection["observaciones"];
                tours.observacionesingles = collection["observacionesIngles"];
                tours.horaLlegada = Convert.ToInt32(collection["horaLlegada"]);
                tours.minutosLlegada = Convert.ToInt32(collection["minutosLlegada"]);
                tours.opcion = 1;
                tours.user = User.Identity.Name;
                tours.tipoArchivo = "";
                tours.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                tours.alt = collection["alt"];
                tours.title = collection["title"];
                tours.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre"]);
                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                tours = toursDatos.AbcCatTours(tours);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Tours/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = tours.nombreArchivo + fileExtension;

                    tours.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    tours.pathImg = "~/Imagenes/Tours/" + fileName;
                    tours.opcion = 4;
                    toursDatos.AbcCatTours(tours);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "El Tour se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatTours/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();

                tours.conexion = _conexion;
                tours.id_tour = id;
                tours = toursDatos.ObtenerDetalleTourxId(tours);
                tours = toursDatos.ObtenerDetalleTourPreciosxId(tours);

                seccion.conexion = _conexion;
                tours.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(tours.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                TipoPaqueteModels tipoPaquete = new TipoPaqueteModels();
                ComunDatos comunDatos = new ComunDatos();
                tipoPaquete.conexion = _conexion;
                tours.tablaTipoPaqueteCmb = comunDatos.ObtenerComboCatTipoPaquete(tipoPaquete);
                list = new SelectList(tours.tablaTipoPaqueteCmb, "id_tipoPaquete", "descripcion");
                ViewData["cmbTipoPaquete"] = list;

                EstadoModels estado = new EstadoModels();
                estado.conexion = _conexion;
                tours.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(tours.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                tours.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(tours.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = _conexion;
                tours.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(tours.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;
                return View(tours);
                
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/CatTours/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                tours.conexion = _conexion;
                tours.id_tour = collection["id_tour"];
                tours.nombre = collection["nombre"];
                tours.nombreIngles = collection["nombreIngles"];
                tours.descripcion = collection["descripcion"];
                tours.descripcionIngles = collection["descripcionIngles"];
                tours.latitud = collection["latitud"];
                tours.longitud = collection["longitud"];
                tours.id_seccion = collection["tablaSeccionesCmb"];
                tours.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                tours.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                tours.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                tours.pathImg = "~/Imagenes/default.png";
                tours.adultoAlta = Convert.ToDecimal(collection["adultoAlta"]);
                tours.adultoBaja = Convert.ToDecimal(collection["adultoBaja"]);
                tours.ninioAlta = Convert.ToDecimal(collection["ninioAlta"]);
                tours.ninioBaja = Convert.ToDecimal(collection["ninioBaja"]);
                tours.cantidadDias = Convert.ToInt32(collection["cantidadDias"]);
                tours.cantidadNoches = Convert.ToInt32(collection["cantidadNoches"]);
                tours.finDeServicios = collection["finDeServicios"];
                tours.finDeServiciosIngles = collection["finDeServiciosIngles"];
                tours.id_tipoPaquete = Convert.ToInt32(collection["tablaTipoPaqueteCmb"]);
                tours.observaciones = collection["observaciones"];
                tours.observacionesingles = collection["observacionesIngles"];
                tours.incluye = collection["incluye"];
                tours.incluyeIngles = collection["incluyeIngles"];
                tours.noIncluye = collection["noIncluye"];
                tours.noIncluyeIngles = collection["noIncluyeIngles"];
                tours.horaLlegada = Convert.ToInt32(collection["horaLlegada"]);
                tours.minutosLlegada = Convert.ToInt32(collection["minutosLlegada"]);
                tours.opcion = 2;
                tours.user = User.Identity.Name;

                tours.tipoArchivo = "";
                tours.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                tours.alt = collection["alt"];
                tours.title = collection["title"];

                tours.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre"]);
                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                tours = toursDatos.AbcCatTours(tours);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Tours/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = tours.nombreArchivo + fileExtension;

                    tours.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    tours.pathImg = "~/Imagenes/Tours/" + fileName;
                    tours.opcion = 4;
                    toursDatos.AbcCatTours(tours);
                }
                else
                {
                    tours.pathImg = collection["pathImg"];

                    string baseDir = Server.MapPath("~/Imagenes/Tours/");
                    string fileExtension = Path.GetExtension(tours.pathImg);
                    string fileName = tours.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + tours.pathImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Tours/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    tours.pathImg = "~/Imagenes/Tours/" + fileName;
                    tours.tipoArchivo = fileExtension;
                    tours.opcion = 4;
                    toursDatos.AbcCatTours(tours);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "El Tour se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatTours/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CatTours/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                tours.conexion = _conexion;
                tours.id_tour = id;
                tours.opcion = 3;
                tours.user = User.Identity.Name;
                toursDatos.AbcCatTours(tours);
                TempData["typemessage"] = "1";
                TempData["message"] = "Tour se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        // GET: /Admin/CatTours/Itinerario
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Itinerario(string id, string id2)
        {
            try
            {
                ItinerarioModels itinerario = new ItinerarioModels();
                ItinerarioDatos itinerarioDatos = new ItinerarioDatos();
                itinerario.conexion = _conexion;
                itinerario.id_paquete = id;
                itinerario.id_seccion = id2;
                itinerario = itinerarioDatos.ObtenerListaItinerarioXIdTour(itinerario);
                return View(itinerario);
            }
            catch (Exception)
            {
                ItinerarioModels itinerario = new ItinerarioModels();
                itinerario.tablaItinerarios = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(itinerario);
            }
        }
        // GET: Admin/CatTours/CreateItinerario
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult CreateItinerario(string id,string id2)
        {
            try
            {
                ItinerarioModels itinerario = new ItinerarioModels();

                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                LugaresTuristicosDatos seccionDatos = new LugaresTuristicosDatos();
                lugaresTuristicos.conexion = _conexion;
                lugaresTuristicos.id_seccion = id2;
                itinerario.tablaLugaresCmb = seccionDatos.ObtenerComboLugaresXSeccion(lugaresTuristicos);
                var list = new SelectList(itinerario.tablaLugaresCmb, "id_lugar", "nombre");
                ViewData["cmbLugares"] = list;

                itinerario.id_paquete = id;
                itinerario.id_seccion = id2;
                return View(itinerario);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatTours/CreateItinerario
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult CreateItinerario(string id,FormCollection collection)
        {
            try
            {
                ItinerarioModels itinerario = new ItinerarioModels();
                ItinerarioDatos itinerarioDatos = new ItinerarioDatos();
                itinerario.conexion = _conexion;
                itinerario.id_paquete = collection["id_paquete"];
                itinerario.id_lugar = collection["tablaLugaresCmb"];
                string id3 = collection["id_seccion"];
                itinerario.nombre = collection["nombre"];
                itinerario.nombreIngles = collection["nombreIngles"];
                itinerario.descripcion = collection["descripcion"];
                itinerario.descripcionIngles = collection["descripcionIngles"];
                itinerario.observaciones = collection["observaciones"];
                itinerario.observacionesIngles = collection["observacionesIngles"];
                itinerario.recomendaciones = collection["recomendaciones"];
                itinerario.recomendacionesIngles = collection["recomendacionesIngles"];
                itinerario.finDeServicios = collection["finDeServicios"];
                itinerario.lugarSalida = collection["lugarSalida"];
                itinerario.orden = Convert.ToInt32(collection["orden"]);
                itinerario.horaSalida = collection["horaSalida"];
                itinerario.opcion = 1;
                itinerario.user = User.Identity.Name;
                itinerarioDatos.AbcCatItinerario(itinerario);

                TempData["typemessage"] = "1";
                TempData["message"] = "El lugar se agrego correctamente";
                return RedirectToAction("Itinerario", new { id = id, id2 = id3 });
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatTours/CreateItinerario
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult EditItinerario(string id, string id2, string id3)
        {
            try
            {
                ItinerarioModels itinerario = new ItinerarioModels();
                ItinerarioDatos itinerarioDatos = new ItinerarioDatos();
                itinerario.conexion = _conexion;
                itinerario.id_itinerario = id;
                itinerario.id_paquete = id2;
                itinerarioDatos.ObtenerDetalleItinerarioxId(itinerario);

                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                LugaresTuristicosDatos seccionDatos = new LugaresTuristicosDatos();
                lugaresTuristicos.conexion = _conexion;
                lugaresTuristicos.id_seccion = id3;
                itinerario.tablaLugaresCmb = seccionDatos.ObtenerComboLugaresXSeccion(lugaresTuristicos);
                var list = new SelectList(itinerario.tablaLugaresCmb, "id_lugar", "nombre");
                ViewData["cmbLugares"] = list;

                itinerario.id_seccion = id3;

                return View(itinerario);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatTours/CreateItinerario
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult EditItinerario(string id, string id2, FormCollection collection)
        {
            try
            {
                ItinerarioModels itinerario = new ItinerarioModels();
                ItinerarioDatos itinerarioDatos = new ItinerarioDatos();
                itinerario.conexion = _conexion;
                itinerario.id_itinerario = collection["id_itinerario"];
                itinerario.id_paquete = collection["id_paquete"];
                string id3 = collection["id_seccion"];
                id2 = itinerario.id_paquete;
                itinerario.id_lugar = collection["tablaLugaresCmb"];
                itinerario.nombre = collection["nombre"];
                itinerario.nombreIngles = collection["nombreIngles"];
                itinerario.descripcion = collection["descripcion"];
                itinerario.descripcionIngles = collection["descripcionIngles"];
                itinerario.observaciones = collection["observaciones"];
                itinerario.observacionesIngles = collection["observacionesIngles"];
                itinerario.recomendaciones = collection["recomendaciones"];
                itinerario.recomendacionesIngles = collection["recomendacionesIngles"];
                itinerario.finDeServicios = collection["finDeServicios"];
                itinerario.lugarSalida = collection["lugarSalida"];
                itinerario.orden = Convert.ToInt32(collection["orden"]);
                itinerario.horaSalida = collection["horaSalida"];
                itinerario.opcion = 2;
                itinerario.user = User.Identity.Name;
                itinerarioDatos.AbcCatItinerario(itinerario);

                TempData["typemessage"] = "1";
                TempData["message"] = "El lugar se edito correctamente";
                return RedirectToAction("Itinerario", new { id = id2, id2 = id3 });
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatTours/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult DeleteItinerario(string id)
        {
            return View();
        }
        // POST: Admin/CatTours/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult DeleteItinerario(string id, FormCollection collection)
        {
            try
            {
                ItinerarioModels itinerario = new ItinerarioModels();
                ItinerarioDatos itinerarioDatos = new ItinerarioDatos();
                itinerario.conexion = _conexion;
                itinerario.id_itinerario = id;
                itinerario.opcion = 3;
                itinerario.user = User.Identity.Name;
                itinerarioDatos.AbcCatItinerario(itinerario);
                TempData["typemessage"] = "1";
                TempData["message"] = "El lugar se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        // GET: /Admin/CatPaquetes/Tags
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
                relacionTags.id_tipoDatoRelacionado = 2;
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
        // GET: Admin/CatGrupos/CreateIntegrante
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
                relacionTags.id_tipoTag = 2;
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
                relacionTags.id_tipoDatoRelacionado = 2;
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
        public ActionResult CheckNameToursAvailability(string nombreArchivo)
        {
            ToursModels Tours = new ToursModels();
            ToursDatos toursDatos = new ToursDatos();
            Tours.conexion = _conexion;
            Tours.nombreArchivo = nombreArchivo;
            return Json(toursDatos.CheckToursArchivoNameTours(Tours), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNombreESToursAvailability(string nombre)
        {
            ToursModels Tours = new ToursModels();
            ToursDatos toursDatos = new ToursDatos();
            Tours.conexion = _conexion;
            Tours.nombre = nombre;
            return Json(toursDatos.CheckToursArchivoNameEsp(Tours), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNombreIngToursvailability(string nombreIngle)
        {
            ToursModels Tours = new ToursModels();
            ToursDatos toursDatos = new ToursDatos();
            Tours.conexion = _conexion;
            Tours.nombreIngles = nombreIngle;
            return Json(toursDatos.CheckToursArchivoNameIng(Tours), JsonRequestBehavior.AllowGet);
        }
    }
}
