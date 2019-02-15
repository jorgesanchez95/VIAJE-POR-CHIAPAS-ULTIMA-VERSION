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
    public class CatPaquetesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/CatPaquetes/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes = paquetesDatos.ObtenerListaPaquetes(paquetes);
                return View(paquetes);
            }
            catch (Exception)
            {
                PaquetesModels paquetes = new PaquetesModels {tablaPaquetes = new DataTable()};
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(paquetes);
            }
        }
        // GET: Admin/CatPaquetes/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();

                paquetes.latitud = "23.634501";
                paquetes.longitud = "-102.55278399999997";

                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                paquetes.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(paquetes.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                TipoPaqueteModels tipoPaquete = new TipoPaqueteModels();
                ComunDatos comunDatos = new ComunDatos();
                tipoPaquete.conexion = _conexion;
                paquetes.tablaTipoPaqueteCmb = comunDatos.ObtenerComboCatTipoPaquete(tipoPaquete);
                var list3 = new SelectList(paquetes.tablaTipoPaqueteCmb, "id_tipoPaquete", "descripcion");
                ViewData["cmbTipoPaquete"] = list3;

                EstadoModels estado = new EstadoModels();
                estado.conexion = _conexion;
                paquetes.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(paquetes.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                paquetes.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(paquetes.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = _conexion;
                paquetes.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(paquetes.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;

                return View(paquetes);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        //  POST: Admin/CatPaquetes/Estado/
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
        //  POST: Admin/CatPaquetes/Municipio/6
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
        // POST: Admin/CatPaquetes/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.nombre = collection["nombre"];
                paquetes.nombreIngles = collection["nombreIngles"];
                paquetes.descripcion = collection["descripcion"];
                paquetes.descripcionIngles = collection["descripcionIngles"];
                paquetes.latitud = collection["latitud"];
                paquetes.longitud = collection["longitud"];
                paquetes.id_seccion = collection["tablaSeccionesCmb"];
                paquetes.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                paquetes.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                paquetes.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                paquetes.pathImg = "~/Imagenes/default.png";
                paquetes.cantidadDias = Convert.ToInt32(collection["cantidadDias"]);
                paquetes.cantidadNoches = Convert.ToInt32(collection["cantidadNoches"]);
                paquetes.finDeServicios = collection["finDeServicios"];
                paquetes.finDeServiciosIngles = collection["finDeServiciosIngles"];
                paquetes.id_tipoPaquete = Convert.ToInt32(collection["tablaTipoPaqueteCmb"]);
                paquetes.incluye = collection["incluye"];
                paquetes.incluyeIngles = collection["incluyeIngles"];
                paquetes.noIncluye = collection["noIncluye"];
                paquetes.noIncluyeIngles = collection["noIncluyeIngles"];
                paquetes.horaLlegada = Convert.ToInt32(collection["horaLlegada"]);
                paquetes.minutosLlegada = Convert.ToInt32(collection["minutosLlegada"]);
                paquetes.opcion = 1;
                paquetes.user = User.Identity.Name;

                paquetes.tipoArchivo = "";
                paquetes.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                paquetes.alt = collection["alt"];
                paquetes.title = collection["title"];

                paquetes.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre"]);

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                paquetes = paquetesDatos.AbcCatPaquetes(paquetes);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Paquetes/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = paquetes.nombreArchivo + fileExtension;

                    paquetes.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    paquetes.pathImg = "~/Imagenes/Paquetes/" + fileName;
                    paquetes.opcion = 4;
                    paquetesDatos.AbcCatPaquetes(paquetes);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "El Paquete se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatPaquetes/Edit
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_paquete = id;
                paquetesDatos.ObtenerDetallePaquetexId(paquetes);


                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.conexion = _conexion;
                paquetes.tablaSeccionesCmb = seccionDatos.ObtenerComboSecciones(seccion);
                var list = new SelectList(paquetes.tablaSeccionesCmb, "id_seccion", "nombreSeccion");
                ViewData["cmbSecciones"] = list;

                TipoPaqueteModels tipoPaquete = new TipoPaqueteModels();
                ComunDatos comunDatos = new ComunDatos();
                tipoPaquete.conexion = _conexion;
                paquetes.tablaTipoPaqueteCmb = comunDatos.ObtenerComboCatTipoPaquete(tipoPaquete);
                list = new SelectList(paquetes.tablaTipoPaqueteCmb, "id_tipoPaquete", "descripcion");
                ViewData["cmbTipoPaquete"] = list;

                EstadoModels estado = new EstadoModels();
                estado.conexion = _conexion;
                paquetes.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                var list1 = new SelectList(paquetes.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list1;



                paquetes.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(paquetes.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                PaisModels pais = new PaisModels();
                pais.conexion = _conexion;
                paquetes.tablaPaisesCmb = comunDatos.ObtenerComboCatPaises(pais);
                list = new SelectList(paquetes.tablaPaisesCmb, "id_pais", "descripcion");
                ViewData["cmbPaises"] = list;

                return View(paquetes);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatPaquetes/Edit
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_paquete = collection["id_paquete"];
                paquetes.nombre = collection["nombre"];
                paquetes.nombreIngles = collection["nombreIngles"];
                paquetes.descripcion = collection["descripcion"];
                paquetes.descripcionIngles = collection["descripcionIngles"];
                paquetes.latitud = collection["latitud"];
                paquetes.longitud = collection["longitud"];
                paquetes.id_seccion = collection["tablaSeccionesCmb"];
                paquetes.id_pais = Convert.ToInt32(collection["cmbPaises"]);
                paquetes.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                paquetes.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                paquetes.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                paquetes.pathImg = "~/Imagenes/default.png";
                paquetes.cantidadDias = Convert.ToInt32(collection["cantidadDias"]);
                paquetes.cantidadNoches = Convert.ToInt32(collection["cantidadNoches"]);
                paquetes.finDeServicios = collection["finDeServicios"];
                paquetes.finDeServiciosIngles = collection["finDeServiciosIngles"];
                paquetes.id_tipoPaquete = Convert.ToInt32(collection["cmbTipoPaquete"]); ;
                paquetes.incluye = collection["incluye"];
                paquetes.id_tipoPaquete = Convert.ToInt32(collection["tablaTipoPaqueteCmb"]);
                paquetes.incluyeIngles = collection["incluyeIngles"];
                paquetes.noIncluye = collection["noIncluye"];
                paquetes.noIncluyeIngles = collection["noIncluyeIngles"];
                paquetes.horaLlegada = Convert.ToInt32(collection["horaLlegada"]);
                paquetes.minutosLlegada = Convert.ToInt32(collection["minutosLlegada"]);
                paquetes.opcion = 2;
                paquetes.user = User.Identity.Name;

                paquetes.tipoArchivo = "";
                paquetes.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                paquetes.alt = collection["alt"];
                paquetes.title = collection["title"];


                paquetes.nombre_pagina = Comun.RemoverSignosAcentos(collection["nombre"]);
                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                paquetes = paquetesDatos.AbcCatPaquetes(paquetes);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Paquetes/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = paquetes.nombreArchivo + fileExtension;

                    paquetes.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    paquetes.pathImg = "~/Imagenes/Paquetes/" + fileName;
                    paquetes.opcion = 4;
                    paquetesDatos.AbcCatPaquetes(paquetes);
                }
                else
                {
                    paquetes.pathImg = collection["pathimg"];

                    string baseDir = Server.MapPath("~/Imagenes/Paquetes/");
                    string fileExtension = Path.GetExtension(paquetes.pathImg);
                    string fileName = paquetes.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + paquetes.pathImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Paquetes/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    paquetes.pathImg = "~/Imagenes/Paquetes/" + fileName;
                    paquetes.tipoArchivo = fileExtension;
                    paquetes.opcion = 4;
                    paquetesDatos.AbcCatPaquetes(paquetes);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "El Paquete se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatPaquetes/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CatPaquetes/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_paquete = id;
                paquetes.opcion = 3;
                paquetes.user = User.Identity.Name;
                paquetesDatos.AbcCatPaquetes(paquetes);
                TempData["typemessage"] = "1";
                TempData["message"] = "Paquete se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        // GET: /Admin/CatPaquetes/Itinerario
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
                itinerario = itinerarioDatos.ObtenerListaItinerarioXIdPaquete(itinerario);
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
        // GET: Admin/CatPaquetes/CreateItinerario
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult CreateItinerario(string id, string id2)
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
        // POST: Admin/CatPaquetes/CreateItinerario
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult CreateItinerario(string id, FormCollection collection)
        {
            try
            {
                ItinerarioModels itinerario = new ItinerarioModels();
                ItinerarioDatos itinerarioDatos = new ItinerarioDatos();
                itinerario.conexion = _conexion;
                itinerario.id_paquete = collection["id_paquete"];
                string id3 = collection["id_seccion"];
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
                itinerario.opcion = 1;
                itinerario.user = User.Identity.Name;
                itinerarioDatos.AbcCatItinerario(itinerario);

                TempData["typemessage"] = "1";
                TempData["message"] = "El lugar se agrego correctamente";
                return RedirectToAction("Itinerario", new { id = id , id2 = id3});
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatPaquetes/CreateItinerario
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
        // POST: Admin/CatPaquetes/CreateItinerario
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
                return RedirectToAction("Itinerario", new { id = id2 , id2 = id3 });
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatPaquetes/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult DeleteItinerario(string id)
        {
            return View();
        }
        // POST: Admin/CatPaquetes/Delete/5
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
        // GET: /Admin/CatPaquetes/Precios
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Precios(string id)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_paquete = id;
                paquetes = paquetesDatos.ObtenerListaPaquetesPrecios(paquetes);
                return View(paquetes);
            }
            catch (Exception)
            {
                PaquetesModels paquetes = new PaquetesModels();
                paquetes.tablaPaquetes = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(paquetes);
            }
        }
        // GET: Admin/CatPaquetes/CreatePrecio
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult CreatePrecio(string id)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                TipoHabitacionModels tipoHabitacion = new TipoHabitacionModels();
                ComunDatos comunDatos = new ComunDatos();
                tipoHabitacion.conexion = _conexion;
                paquetes.tablaTipoHabitacionCmb = comunDatos.ObtenerComboCatTipoHabitacion(tipoHabitacion);
                var list = new SelectList(paquetes.tablaTipoHabitacionCmb, "id_tipohabitacion", "descripcion");
                ViewData["cmbTipoHabitaciones"] = list;

                paquetes.id_paquete = id;
                return View(paquetes);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatPaquetes/CreatePrecio
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult CreatePrecio(string id, FormCollection collection)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_paquete = collection["id_paquete"];
                id = paquetes.id_paquete;
                paquetes.id_tipoHabitacion = Convert.ToInt32(collection["tablaTipoHabitacionCmb"]);
                paquetes.numeroEstrellas = Convert.ToInt32(collection["numeroEstrellas"]);
                paquetes.adultoAlta = Convert.ToDecimal(collection["adultoAlta"]);
                paquetes.adultoBaja = Convert.ToDecimal(collection["adultoBaja"]);
                paquetes.ninioAlta = Convert.ToDecimal(collection["ninioAlta"]);
                paquetes.ninioBaja = Convert.ToDecimal(collection["ninioBaja"]);
                paquetes.user = User.Identity.Name;
                paquetes = paquetesDatos.InsertarPaquetePrecio(paquetes);

                TempData["typemessage"] = "1";
                TempData["message"] = "El Precio se agrego correctamente";
                return RedirectToAction("Precios", new {id = id});
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente " + ex.ToString();
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/CatPaquetes/EditPrecio
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult EditPrecio(string id, string id2, string id3)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_paquete = id;
                paquetes.id_tipoHabitacion = Convert.ToInt32(id2);
                paquetes.numeroEstrellas = Convert.ToInt32(id3);
                paquetes = paquetesDatos.ObtenerDetallePaquetePreciosxId(paquetes);

                TipoHabitacionModels tipoHabitacion = new TipoHabitacionModels();
                ComunDatos comunDatos = new ComunDatos();
                tipoHabitacion.conexion = _conexion;
                paquetes.tablaTipoHabitacionCmb = comunDatos.ObtenerComboCatTipoHabitacion(tipoHabitacion);
                var list = new SelectList(paquetes.tablaTipoHabitacionCmb, "id_tipohabitacion", "descripcion");
                ViewData["cmbTipoHabitaciones"] = list;

                paquetes.id_paquete = id;
                return View(paquetes);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/CatPaquetes/CreatePrecio
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult EditPrecio(string id, FormCollection collection)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_paquete = collection["id_paquete"];
                id = paquetes.id_paquete;
                paquetes.id_tipoHabitacion = Convert.ToInt32(collection["tablaTipoHabitacionCmb"]);
                paquetes.numeroEstrellas = Convert.ToInt32(collection["numeroEstrellas"]);
                paquetes.adultoAlta = Convert.ToDecimal(collection["adultoAlta"]);
                paquetes.adultoBaja = Convert.ToDecimal(collection["adultoBaja"]);
                paquetes.ninioAlta = Convert.ToDecimal(collection["ninioAlta"]);
                paquetes.ninioBaja = Convert.ToDecimal(collection["ninioBaja"]);
                paquetes.user = User.Identity.Name;
                paquetes = paquetesDatos.ModificarPaquetePrecio(paquetes);

                TempData["typemessage"] = "1";
                TempData["message"] = "El Precio se edito correctamente";
                return RedirectToAction("Precios", new { id = id });
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
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
                relacionTags.id_tipoDatoRelacionado = 1;
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
                relacionTags.id_tipoTag = 1;
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
                relacionTags.id_tipoDatoRelacionado = 1;
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
        public ActionResult CheckNamePaqueteAvailability(string nombreArchivo)
        {
            PaquetesModels Paquetes = new PaquetesModels();
            PaquetesDatos PaqueteDatoss = new PaquetesDatos();
            Paquetes.conexion = _conexion;
            Paquetes.nombreArchivo = nombreArchivo;
            return Json(PaqueteDatoss.CheckPqqueteArchivoNamePaquete(Paquetes), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNombreESPaqueteAvailability(string nombre)
        {
            PaquetesModels Paquetes = new PaquetesModels();
            PaquetesDatos PaqueteDatoss = new PaquetesDatos();
            Paquetes.conexion = _conexion;
            Paquetes.nombre = nombre;
            return Json(PaqueteDatoss.CheckPaqueteArchivoNnombreEsP(Paquetes), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNombreIngPaqueteAvailability(string nombreIngle)
        {
            PaquetesModels Paquetes = new PaquetesModels();
            PaquetesDatos PaqueteDatoss = new PaquetesDatos();
            Paquetes.conexion = _conexion;
            Paquetes.nombreIngles = nombreIngle;
            return Json(PaqueteDatoss.CheckPaqueteArchivoNnombreIng(Paquetes), JsonRequestBehavior.AllowGet);
        }
    }
}
