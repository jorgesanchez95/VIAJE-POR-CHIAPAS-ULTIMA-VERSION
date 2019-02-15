using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Web.UI;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class ConfiguracionController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/Configuracion/
        public ActionResult Index()
        {
            try
            {
                ConfiguracionModels configuracion = new ConfiguracionModels();
                ConfiguracionDatos configuracionDatos = new ConfiguracionDatos();
                configuracion.conexion = _conexion;
                configuracion = configuracionDatos.ObtenerListaConfiguracion(configuracion);
                return View(configuracion);
            }
            catch (Exception)
            {
                ConfiguracionModels configuracion = new ConfiguracionModels();
                configuracion.tablaConfiguracion = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(configuracion);
            }
        }
        // GET: Admin/Secciones/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                ConfiguracionModels configuracion = new ConfiguracionModels();
                ConfiguracionDatos configuracionDatos = new ConfiguracionDatos();
                configuracion.conexion = _conexion;
                configuracion.id_configuracion = id;
                configuracion = configuracionDatos.ObtenerDetalleConfiguracionPaginaxId(configuracion);
                return View(configuracion);
            }
            catch (Exception)
            {
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
                ConfiguracionModels configuracion = new ConfiguracionModels();
                ConfiguracionDatos configuracionDatos = new ConfiguracionDatos();
                configuracion.conexion = _conexion;
                configuracion.id_configuracion = collection["id_configuracion"];
                configuracion.telefono = collection["telefono"];
                configuracion.correo = collection["correo"];
                configuracion.textoUno = collection["textoUno"];
                configuracion.textoUnoIngles = collection["textoUnoIngles"];
                configuracion.topCinco = collection["topCinco"];
                configuracion.topCincoIngles = collection["topCincoIngles"];
                configuracion.textoDos = collection["textoDos"];
                configuracion.textoDosIngles = collection["textoDosIngles"];
                configuracion.newsletter = collection["newsletter"];
                configuracion.newsletterIngles = collection["newsletterIngles"];
                configuracion.pieAcerca = collection["pieAcerca"];
                configuracion.pieAcercaIngles = collection["pieAcercaIngles"];
                configuracion.direccion = collection["direccion"];
                configuracion.facebook = collection["facebook"];
                configuracion.twitter = collection["twitter"];
                configuracion.instagram = collection["instagram"];
                configuracion.youtube = collection["youtube"];
                configuracion.google = collection["google"];
                configuracion.contactanos = collection["contactanos"];
                configuracion.contactanosIngles = collection["contactanosIngles"];
                configuracion.quienEs = collection["quienEs"];
                configuracion.quienEsIngles = collection["quienEsIngles"];
                configuracion.nuestrosServicios = collection["nuestrosServicios"];
                configuracion.nuestrosServiciosIngles = collection["nuestrosServiciosIngles"];
                configuracion.servicioBoletos = collection["servicioBoletos"];
                configuracion.servicioBoletosIngles = collection["servicioBoletosIngles"];
                configuracion.servicioHotel = collection["servicioHotel"];
                configuracion.servicioHotelIngles = collection["servicioHotelIngles"];
                configuracion.servicioTraslado = collection["servicioTraslado"];
                configuracion.servicioTrasladoIngles = collection["servicioTrasladoIngles"];
                configuracion.servicioPaquetes = collection["servicioPaquetes"];
                configuracion.servicioPaquetesIngles = collection["servicioPaquetesIngles"];
                configuracion.pathImg = "~/Imagenes/default.png";
                configuracion.descripcionTransportacion = collection["descripcionTransportacion"];
                configuracion.descripcionTransportacionIngles = collection["descripcionTransportacionIngles"];
                configuracion.detalleTransportacion = collection["detalleTransportacion"];
                configuracion.detalleTransportacionIngles = collection["detalleTransportacionIngles"];
                configuracion.terminosCondiciones = collection["terminosCondiciones"];
                configuracion.terminosCondicionesIngles = collection["terminosCondicionesIngles"];
                configuracion.opcion = 2;
                configuracion.user = User.Identity.Name;

                configuracion.tipoArchivo = "";
                configuracion.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                configuracion.alt = collection["alt"];
                configuracion.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                configuracion = configuracionDatos.AbcCatConfiguracion(configuracion);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Configuracion/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = configuracion.nombreArchivo + fileExtension;

                    configuracion.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    configuracion.pathImg = "~/Imagenes/Configuracion/" + fileName;
                    configuracion.opcion = 4;
                    configuracionDatos.AbcCatConfiguracion(configuracion);
                }
                else
                {
                    configuracion.pathImg = collection["pathImg"];

                    string baseDir = Server.MapPath("~/Imagenes/Configuracion/");
                    string fileExtension = Path.GetExtension(configuracion.pathImg);
                    string fileName = configuracion.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + configuracion.pathImg.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Configuracion/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    configuracion.pathImg = "~/Imagenes/Configuracion/" + fileName;
                    configuracion.tipoArchivo = fileExtension;
                    configuracion.opcion = 4;
                    configuracionDatos.AbcCatConfiguracion(configuracion);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "La configuración se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameConfiguracionesAvailability(string nombreArchivo)
       {
            ConfiguracionModels Config = new ConfiguracionModels();
            ConfiguracionDatos ConfigDatos = new ConfiguracionDatos();
            Config.conexion = _conexion;
            Config.nombreArchivo = nombreArchivo;
            return Json(ConfigDatos.CheckConfiguracionesArchivoNameConfig(Config), JsonRequestBehavior.AllowGet);
        }
    }
}
