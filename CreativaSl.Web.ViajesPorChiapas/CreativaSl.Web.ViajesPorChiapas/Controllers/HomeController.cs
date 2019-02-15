using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    public class HomeController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Home
        [Autorizado]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SeccionDatos seccionDatos = new SeccionDatos();
                seccion.idioma = Session["locale"] == null ? 1 : 2;
                seccion.id_seccion = Session["idSeccion"].ToString();
                seccion.conexion = _conexion;
                seccion.id_metaTags = "8DDCA3F9-0FEF-4BCB-A990-010154DA0256";
                seccion.id_tipo = 1;
                seccion = seccionDatos.ObtenerHomeSeccion(seccion);
                return View(seccion);
            }
            catch
            {
                SeccionModels seccion = new SeccionModels();
                seccion.tablaDatosGenerales = new DataTable();
                seccion.tablaBannerInicio = new DataTable();
                seccion.tablaCaracteristicasEmpresa = new DataTable();
                seccion.tablaTopPaquetes = new DataTable();
                seccion.tablaTags = new DataTable();
                seccion.tablaArticulos = new DataTable();
                seccion.TablaTuors = new DataTable();
                seccion.tablaSeccion = new DataTable();
                seccion.tablaUbicacionesLugaresTuristicos = new DataTable();
                seccion.tablaSecciones = new DataTable();
                seccion.tablaMetaTags = new DataTable();
                seccion.TablaDestinosPaquetes = new DataTable();
                seccion.TablaDestinosTours = new DataTable();
                seccion.TablaTestimoniales = new DataTable();
                seccion.TablaFormasDePago = new DataTable();
                seccion.TablaPaquetesPopulares = new DataTable();
                return View(seccion);
            }
        }
        //  POST: Admin/CatPaquetes/Municipio/6
        [HttpPost]
        public ActionResult Paquetes(string id)
        {
            try
            {
                string[] IDs = id.Split(',');
                MunicipioModels municipio = new MunicipioModels();
                PaquetesDatos PaqueteDatos = new PaquetesDatos();

                List<MunicipioModels> lstMunicipio = new List<MunicipioModels>();
                municipio.id_estado = Convert.ToInt32(IDs[1]);
                municipio.conexion = _conexion;
                lstMunicipio = PaqueteDatos.ObtenerComboCatMunicipios(municipio);
                return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult LugaresTuristicos(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    string[] IDs = id.Split(',');
                    LugaresTuristicosModels municipio = new LugaresTuristicosModels();
                    PaquetesDatos PaqueteDatos = new PaquetesDatos();

                   
                    municipio.id_estado = Convert.ToInt32(IDs[1]);
                    municipio.id_pais = Convert.ToInt32(IDs[0]);
                    municipio.idioma = Session["locale"] == null ? 1 : 2;
                    municipio.conexion = _conexion;
                   municipio.listaTipoPaquete = PaqueteDatos.ObtenerComboCatLugaresTuristicosHome(municipio);
                    return Json(municipio.listaTipoPaquete, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    PaquetesDatos PaqueteDatoss = new PaquetesDatos();
                    LugaresTuristicosModels municipio = new LugaresTuristicosModels();
                    List<LugaresTuristicosModels> lstMunicipio = new List<LugaresTuristicosModels>();
                    lstMunicipio = PaqueteDatoss.ObtenerSelecte(municipio);
                    return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult LugaresTuristicosTours(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    string[] IDs = id.Split(',');
                    LugaresTuristicosModels municipio = new LugaresTuristicosModels();
                    PaquetesDatos PaqueteDatos = new PaquetesDatos();
                    List<LugaresTuristicosModels> lstMunicipio = new List<LugaresTuristicosModels>();
                    municipio.id_estado = Convert.ToInt32(IDs[1]);
                    municipio.id_pais = Convert.ToInt32(IDs[0]);
                    municipio.idioma = Session["locale"] == null ? 1 : 2;
                    municipio.conexion = _conexion;
                    lstMunicipio = PaqueteDatos.ObtenerComboCatLugaresTuristicosHomeTours(municipio);
                    return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    PaquetesDatos PaqueteDatoss = new PaquetesDatos();
                    LugaresTuristicosModels municipio = new LugaresTuristicosModels();
                    List<LugaresTuristicosModels> lstMunicipio = new List<LugaresTuristicosModels>();
                    lstMunicipio = PaqueteDatoss.ObtenerSelecte(municipio);
                    return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //  GET: /Home/CotizarFinalizar/
        [Autorizado]
        [HttpGet]
        public ActionResult CotizarFinalizar()
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.idioma = Session["locale"] == null ? 1 : 2;
                paquetes.id_seccion = Session["idSeccion"].ToString();
                paquetes.conexion = _conexion;
                paquetes.id_metaTags = "6F3EA2DB-F9C6-446C-B476-B6D3E4A192AF";
                paquetes.id_tipo = 1;
                paquetes = paquetesDatos.ObtenerConfigCotizarFinalizar(paquetes);
                return View(paquetes);
            }
            catch
            {
                PaquetesModels paquetes = new PaquetesModels();
                paquetes.tablaDatosGenerales = new DataTable();
                paquetes.tablaCaracteristicasEmpresa = new DataTable();
                paquetes.tablaArticulos = new DataTable();
                paquetes.tablaSeccion = new DataTable();
                paquetes.tablaSecciones = new DataTable();
                paquetes.tablaMetaTags = new DataTable();
                paquetes.TablaFormasDePago = new DataTable();
                paquetes.TablaPaquetesPopulares = new DataTable();
                return View(paquetes);
            }
        }

        //  POST: Home/IrASeccion/6
        [HttpPost]
        public ActionResult IrASeccion(string id_seccion)
        {
            try
            {
                Session["idSeccion"] = id_seccion;
                string resultado = "OK";
                //if (lang == "mx")
                //    Session["locale"] = null;
                //else
                //    Session["locale"] = lang;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        //  POST: /Home/CambiarIdioma/6
        [HttpPost]
        public ActionResult CambiarIdioma(string lang)
        {
            try
            {
                if (lang == "mx")
                    Session["locale"] = null;
                else
                    Session["locale"] = lang;
                string resultado = "OK";

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //  POST: /Home/MatarSession/6
        [HttpPost]
        public ActionResult MatarSession()
        {
            try
            {
                Session["idSeccion"] = null;
                string resultado = "OK";

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult MatarSessionCliente()
        {
            try
            {
                Session["idCliente"] = null;
                Session["nombreCompleto"] = null;
                string resultado = "OK";

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        // POST: /Home/Suscribirse
        [Autorizado]
        [HttpPost]
        public ActionResult Suscribirse(string correoSuscribirse)
        {
            try
            {
                SeccionModels seccion = new SeccionModels();
                SuscripcionDatos suscripcionDatos = new SuscripcionDatos();

                string resultado;
                var expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                if (Regex.IsMatch(correoSuscribirse, expresion))
                {
                    if (Regex.Replace(correoSuscribirse, expresion, String.Empty).Length == 0)
                    {
                        seccion.conexion = _conexion;
                        seccion.correoSuscribirse = correoSuscribirse;
                        seccion.opcion = 1;
                        seccion.user = "newsletter";
                        suscripcionDatos.AbcCatSuscripcion(seccion);

                        resultado = "OK";
                    }
                    else
                    {
                        resultado = "KO";
                    }
                }
                else
                {
                    resultado = "KO";
                }

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string resultado = "KO";
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

        //  POST: /Home/CambiarIdioma/6
        [HttpPost]
        public ActionResult Estado(string IdEstado)
        {
            try
            {
               Session["Id_Estado"] = IdEstado;
                string resultado = "OK";

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}