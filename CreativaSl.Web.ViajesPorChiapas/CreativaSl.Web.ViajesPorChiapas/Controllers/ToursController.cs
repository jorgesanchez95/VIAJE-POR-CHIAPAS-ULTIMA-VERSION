using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
using CreativaSl.Web.ViajesPorChiapas.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    [Compress]
    public class ToursController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        Localizate locale = new Localizate();
        // GET: Tours
        [Autorizado]
        public ActionResult Index(string id, string current, string idTags, string id_seccion,string modalidad)
        {
          
                try
                {
                    ToursModels tours = new ToursModels();
                    ToursDatos toursDatos = new ToursDatos();
                    try
                    {
                        if (id_seccion != null)
                        {
                            if (id_seccion != "")
                            {
                                SeccionModels seccion = new SeccionModels();
                                seccion.conexion = _conexion;
                                seccion.id_seccion = id_seccion;
                                seccion.opcion = 4;
                                SeccionDatos seccionDatos = new SeccionDatos();
                                if (seccionDatos.VerificarSeccion(seccion) == true)
                                    Session["idSeccion"] = id_seccion;
                                return RedirectToAction("index", "tours");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                        tours.current = Convert.ToInt32(current);
                        if (tours.current <= 0)
                        {
                            tours.current = 1;
                            tours.offset = 0;
                        }
                        else
                        {
                            tours.offset = (tours.current - 1) * tours.fetchNext;
                        }
                    }
                    catch (Exception)
                    {
                        tours.current = 1;
                        tours.offset = 0;
                    }

                    try
                    {
                        tours.tablaTagsSelecionados = new DataTable();
                        tours.tablaTagsSelecionados.Columns.Add("id_tag", typeof(string));
                        string[] ids = idTags.Split(',');
                        foreach (string aux in ids)
                        {
                            if (aux != "")
                            {
                                tours.tablaTagsSelecionados.Rows.Add(aux);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        tours.tablaTagsSelecionados = new DataTable();
                        tours.tablaTagsSelecionados.Columns.Add("id_tag", typeof(string));
                    }
                
                tours.idioma = Session["locale"] == null ? 1 : 2;
                    tours.id_seccion = Session["idSeccion"].ToString();
                    tours.conexion = _conexion;
                    tours.id_metaTags = "22EE3EE8-C009-43B4-AC2B-8D30A225FC01";
                    tours.id_tipo = 1;
                    tours.modalidad = Convert.ToInt32(modalidad);
                    string[] idsS = id.Split('-');
                    tours.id_pais = Convert.ToInt32(idsS[0]);
                    tours.id_estado = Convert.ToInt32(idsS[1]);
                    tours = toursDatos.ObtenerConfigTour(tours);
                    return View(tours);
                }
                catch
                {
                    ToursModels tours = new ToursModels();
                    tours.tablaDatosGenerales = new DataTable();
                    tours.tablaCaracteristicasEmpresa = new DataTable();
                    tours.tablaArticulos = new DataTable();
                    tours.tablaTags = new DataTable();
                    tours.tablaTours = new DataTable();
                    tours.tablaSeccion = new DataTable();
                    tours.tablaSecciones = new DataTable();
                    tours.tablaMetaTags = new DataTable();
                    tours.TablaPaquetesPopulares = new DataTable();
                    tours.TablaFormasDePago = new DataTable();
                    tours.numeroPaquetes = 0;
                    return View(tours);
                }
            
        }

        // GET: /Tours/DetalleTour/5
        [Autorizado]
        [HttpGet]
        public ActionResult DetalleTour(string id)
        {
            try
            {
                ToursModels tour = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                tour.idioma = Session["locale"] == null ? 1 : 2;
                tour.id_seccion = Session["idSeccion"].ToString();
                tour.conexion = _conexion;
                tour.nombre_pagina = id;
                tour.id_tipo = 2;
                tour = toursDatos.ObtenerConfigDetalleTour(tour);
                return View(tour);
            }
            catch
            {
                ToursModels tour = new ToursModels();
                tour.tablaDatosGenerales = new DataTable();
                tour.tablaCaracteristicasEmpresa = new DataTable();
                tour.tablaArticulos = new DataTable();
                tour.tablaTours = new DataTable();
                tour.tablaItinerario = new DataTable();
                tour.tablaSeccion = new DataTable();
                tour.tablaSecciones = new DataTable();
                tour.tablaLugares = new DataTable();
                tour.tablaMetaTags = new DataTable();
                tour.TablaPaquetesPopulares = new DataTable();
                tour.TablaFormasDePago = new DataTable();
                return View(tour);
            }
        }

        // GET: /Tours/Cotizar/5
        [Autorizado]
        [HttpGet]
        public ActionResult Cotizar(string id)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                try
                {
                    if (System.Web.HttpContext.Current.Session["idCliente"] != null)
                    {
                        tours.idClienteCotizar = System.Web.HttpContext.Current.Session["idCliente"].ToString();
                        ClienteModels cliente = new ClienteModels();
                        ClienteDatos cliente_datos = new ClienteDatos();
                        cliente.conexion = _conexion;
                        cliente.id_cliente = tours.idClienteCotizar;
                        cliente_datos.ObtenerDetalleClientexId(cliente);
                        tours.idClienteCotizar = cliente.id_cliente;
                        tours.nombreCotizar = cliente.nombre;
                        tours.apellidoPaternoCotizar = cliente.apPat;
                        tours.apellidoMaternoCotizar = cliente.apMat;
                        tours.telefonoCotizar = cliente.telefono;
                        tours.emailCotizar = cliente.email;
                    }
                    else
                    {
                        tours.idClienteCotizar = "";
                        tours.nombreCotizar = "";
                        tours.apellidoPaternoCotizar = "";
                        tours.apellidoMaternoCotizar = "";
                        tours.telefonoCotizar = "";
                        tours.emailCotizar = "";
                    }
                }
                catch (Exception ex)
                {
                    tours.idClienteCotizar = "";
                    tours.nombreCotizar = "";
                    tours.apellidoPaternoCotizar = "";
                    tours.apellidoMaternoCotizar = "";
                    tours.telefonoCotizar = "";
                    tours.emailCotizar = "";
                }
                tours.nombre_pagina = id;
                tours.idioma = Session["locale"] == null ? 1 : 2;
                tours.id_seccion = Session["idSeccion"].ToString();
                tours.conexion = _conexion;
                tours.id_tipo = 3;
                tours = toursDatos.ObtenerConfigTours(tours);
                if (tours.id_tour == "" || tours.nombre == "")
                {
                    return RedirectToAction("Index");
                }
                return View(tours);
            }
            catch
            {
                ToursModels tours = new ToursModels();
                tours.tablaDatosGenerales = new DataTable();
                tours.tablaCaracteristicasEmpresa = new DataTable();
                tours.tablaArticulos = new DataTable();
                tours.tablaSeccion = new DataTable();
                tours.tablaSecciones = new DataTable();
                tours.tablaMetaTags = new DataTable();
                tours.TablaPaquetesPopulares = new DataTable();
                tours.TablaFormasDePago = new DataTable();
                tours.nombre = "";
                return View(tours);
            }
        }
        // POST: /Tours/Cotizar/
        [Autorizado]
        [HttpPost]
        public ActionResult Cotizar(string id, FormCollection collection)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                tours.conexion = _conexion;
                tours.id_seccion = Session["idSeccion"].ToString();
                tours.nombre_pagina = id;
                tours.idClienteCotizar = "";
                tours.nombreCotizar = collection["nombreCotizar"];
                tours.apellidoPaternoCotizar = collection["apellidoPaternoCotizar"];
                tours.apellidoMaternoCotizar = collection["apellidoMaternoCotizar"];
                tours.emailCotizar = collection["emailCotizar"];
                tours.telefonoCotizar = collection["telefonoCotizar"];
                tours.BoletoCotizar = Convert.ToBoolean(collection["BoletoCotizar"]);
                tours.aeropuertoLlegadaCotizar = collection["aeropuertoLlegadaCotizar"];
                tours.aeropuertoSalidaCotizar = collection["aeropuertoSalidaCotizar"];
                tours.fechaLlegadaCotizarCompleta = DateTime.ParseExact(collection["fechaLlegadaCotizar"] + " " + collection["horaLlegadaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                tours.fechaSalidaCotizarCompleta = DateTime.ParseExact(collection["fechaSalidaCotizar"] + " " + collection["horaSalidaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (tours.fechaLlegadaCotizarCompleta > tours.fechaSalidaCotizarCompleta)
                {
                    tours.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaLlegadaCotizar = collection["horaSalidaCotizar"];
                    tours.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaSalidaCotizar = collection["horaLlegadaCotizar"];
                }
                else if (tours.fechaLlegadaCotizarCompleta == tours.fechaSalidaCotizarCompleta)
                {
                    tours.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    tours.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
                    tours.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                else
                {
                    tours.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    tours.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                string nombrePersona = tours.nombreCotizar+" "+ tours.apellidoPaternoCotizar+" "+ tours.apellidoMaternoCotizar;
                tours.numeroPersonasCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                tours.numeroAdultoCotizar = Convert.ToInt32(collection["numeroAdultoCotizar"]);
                tours.numeroNiños511Cotizar = Convert.ToInt32(collection["numeroNiños511Cotizar"]);
                tours.numeroNiños14Cotizar = Convert.ToInt32(collection["numeroNiños14Cotizar"]);
                toursDatos.CotizarTours(ref tours);
                Comun.EnviarCorreo(
                ConfigurationManager.AppSettings.Get("CorreoTxt")
                , ConfigurationManager.AppSettings.Get("PasswordTxt")
                , tours.emailCotizar
                , tours.datosGeneralesCorreo.Rows[0]["asunto"].ToString()
                , Comun.GenerarHtmlToursCotizado(tours.datosGeneralesCorreo, tours.tablaRedesSociales,tours.TablaPaquetesPopulares,nombrePersona, tours.nombre_pagina)
                , false
                , ""
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                , ConfigurationManager.AppSettings.Get("HostTxt")
                , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));

                if (tours.verificadorCotizar == 1 || tours.verificadorCotizar == 2)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = locale.GetResourceCotizar("termino24Horas");
                    TempData["message2"] = locale.GetResourceCotizar("termino24Horas2");
                   // TempData["message3"] = locale.GetResourceCotizar("termino24Horas3");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message2"] = locale.GetResourceCotizar("noSePudoRealizarCotizacion");
                }
                return RedirectToAction("CotizarFinalizar", "Home");
            }
            catch
            {
                ToursModels tours = new ToursModels();
                tours.tablaDatosGenerales = new DataTable();
                tours.tablaCaracteristicasEmpresa = new DataTable();
                tours.tablaArticulos = new DataTable();
                tours.tablaSeccion = new DataTable();
                tours.tablaSecciones = new DataTable();
                tours.tablaMetaTags = new DataTable();
                tours.nombre = "";
                return View(tours);
            }
        }
        // GET: /Tours/CotizarEmpresa/5
        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        public ActionResult CotizarEmpresa()
        {
            try
            {
                ToursModels tours = new ToursModels();
                tours.conexion = _conexion;
                ToursDatos toursDatos = new ToursDatos();
                try
                {
                    if (System.Web.HttpContext.Current.Session["idCliente"] != null)
                    {
                        tours.idClienteCotizar = System.Web.HttpContext.Current.Session["idCliente"].ToString();
                        ClienteModels cliente = new ClienteModels();
                        ClienteDatos cliente_datos = new ClienteDatos();
                        cliente.conexion = _conexion;
                        cliente.id_cliente = tours.idClienteCotizar;
                        cliente_datos.ObtenerDetalleClientexId(cliente);
                        tours.idClienteCotizar = cliente.id_cliente;
                        tours.nombreCotizar = cliente.nombre;
                        tours.apellidoPaternoCotizar = cliente.apPat;
                        tours.apellidoMaternoCotizar = cliente.apMat;
                        tours.telefonoCotizar = cliente.telefono;
                        tours.emailCotizar = cliente.email;
                    }
                    else
                    {
                        tours.idClienteCotizar = "";
                        tours.nombreCotizar = "";
                        tours.apellidoPaternoCotizar = "";
                        tours.apellidoMaternoCotizar = "";
                        tours.telefonoCotizar = "";
                        tours.emailCotizar = "";
                        return RedirectToAction("Index");
                    }
                    tours.idioma = Session["locale"] == null ? 1 : 2;
                    tours.id_seccion = Session["idSeccion"].ToString();
                    tours.conexion = _conexion;
                    tours.id_metaTags = "A3BEFF63-A0AE-447F-AB95-DA266B471758";
                    tours.id_tipo = 1;
                    tours = toursDatos.ObtenerConfigToursEmpresa(tours);
                    tours.tablaToursCmb = toursDatos.ObtenerComboCatTours(tours);
                    tours.emailCotizar = Session["Correo"].ToString();
                    var list = new SelectList(tours.tablaToursCmb, "id_tour", "nombre");
                    ViewData["cmbTours"] = list;
                }
                catch (Exception ex)
                {
                    tours.idClienteCotizar = "";
                    tours.nombreCotizar = "";
                    tours.apellidoPaternoCotizar = "";
                    tours.apellidoMaternoCotizar = "";
                    tours.telefonoCotizar = "";
                    tours.emailCotizar = "";
                    return RedirectToAction("Index");
                }
                return View(tours);
            }
            catch
            {
                ToursModels tours = new ToursModels();
                tours.tablaDatosGenerales = new DataTable();
                tours.tablaCaracteristicasEmpresa = new DataTable();
                tours.tablaArticulos = new DataTable();
                tours.tablaSeccion = new DataTable();
                tours.tablaSecciones = new DataTable();
                tours.tablaMetaTags = new DataTable();
                tours.TablaPaquetesPopulares = new DataTable();
                tours.TablaFormasDePago = new DataTable();
                tours.nombre = "";
                return View(tours);
            }
        }
        // POST: /Tours/CotizarEmpresa/
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        public ActionResult CotizarEmpresa(FormCollection collection)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                tours.conexion = _conexion;
                tours.id_seccion = Session["idSeccion"].ToString();
                tours.id_tour = collection["tablaToursCmb"];
                tours.idClienteCotizar = "";
                tours.nombreCotizar = collection["nombreCotizar"];
                tours.apellidoPaternoCotizar = collection["apellidoPaternoCotizar"];
                tours.apellidoMaternoCotizar = collection["apellidoMaternoCotizar"];
                tours.emailCotizar = collection["emailCotizar"];
                tours.telefonoCotizar = collection["telefonoCotizar"];
                tours.BoletoCotizar = Convert.ToBoolean(collection["BoletoCotizar"]);
                tours.aeropuertoLlegadaCotizar = collection["aeropuertoLlegadaCotizar"];
                tours.aeropuertoSalidaCotizar = collection["aeropuertoSalidaCotizar"];
                tours.fechaLlegadaCotizarCompleta = DateTime.ParseExact(collection["fechaLlegadaCotizar"] + " " + collection["horaLlegadaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                tours.fechaSalidaCotizarCompleta = DateTime.ParseExact(collection["fechaSalidaCotizar"] + " " + collection["horaSalidaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (tours.fechaLlegadaCotizarCompleta > tours.fechaSalidaCotizarCompleta)
                {
                    tours.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaLlegadaCotizar = collection["horaSalidaCotizar"];
                    tours.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaSalidaCotizar = collection["horaLlegadaCotizar"];
                }
                else if (tours.fechaLlegadaCotizarCompleta == tours.fechaSalidaCotizarCompleta)
                {
                    tours.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    tours.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
                    tours.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                else
                {
                    tours.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    tours.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    tours.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                tours.numeroPersonasCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                tours.numeroAdultoCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                tours.numeroNiños511Cotizar = 0;
                tours.numeroNiños14Cotizar = 0;
                toursDatos.CotizarToursEmpresa(ref tours);
                Comun.EnviarCorreo(
                ConfigurationManager.AppSettings.Get("CorreoTxt")
                , ConfigurationManager.AppSettings.Get("PasswordTxt")
                , tours.emailCotizar
                , tours.datosGeneralesCorreo.Rows[0]["asunto"].ToString()
                , Comun.GenerarHtmlToursEmpresaCotizado(tours.datosGeneralesCorreo, tours.tablaRedesSociales,tours.TablaPaquetesPopulares)
                , false
                , ""
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                , ConfigurationManager.AppSettings.Get("HostTxt")
                , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));

                if (tours.verificadorCotizar == 1 || tours.verificadorCotizar == 2)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = locale.GetResourceCotizar("termino24Horas");
                    TempData["message2"] = locale.GetResourceCotizar("termino24Horas2");
                   // TempData["message3"] = locale.GetResourceCotizar("termino24Horas3");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message2"] = locale.GetResourceCotizar("noSePudoRealizarCotizacion");
                }
                return RedirectToAction("CotizarFinalizar", "Home");
            }
            catch (Exception ex)
            {
                ToursModels tours = new ToursModels();
                tours.tablaDatosGenerales = new DataTable();
                tours.tablaCaracteristicasEmpresa = new DataTable();
                tours.tablaArticulos = new DataTable();
                tours.tablaSeccion = new DataTable();
                tours.tablaSecciones = new DataTable();
                tours.tablaMetaTags = new DataTable();
                tours.nombre = "";
                return View(tours);
            }
        }
        
        //  POST: /Tours/CambiarIdioma/6
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
        //  POST: /Tours/MatarSession/6
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

        [Autorizado]
        public ActionResult Busqueda(string id, string idLugars, string current, string idTags, string id_seccion)
        {
            try
            {
                ToursModels tours = new ToursModels();
                ToursDatos toursDatos = new ToursDatos();
                try
                {
                    if (id_seccion != null)
                    {
                        if (id_seccion != "")
                        {
                            SeccionModels seccion = new SeccionModels();
                            seccion.conexion = _conexion;
                            seccion.id_seccion = id_seccion;
                            seccion.opcion = 4;
                            SeccionDatos seccionDatos = new SeccionDatos();
                            if (seccionDatos.VerificarSeccion(seccion) == true)
                                Session["idSeccion"] = id_seccion;
                            return RedirectToAction("index", "tours");
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    tours.current = Convert.ToInt32(current);
                    if (tours.current <= 0)
                    {
                        tours.current = 1;
                        tours.offset = 0;
                    }
                    else
                    {
                        tours.offset = (tours.current - 1) * tours.fetchNext;
                    }
                }
                catch (Exception)
                {
                    tours.current = 1;
                    tours.offset = 0;
                }

                try
                {
                    tours.tablaTagsSelecionados = new DataTable();
                    tours.tablaTagsSelecionados.Columns.Add("id_tag", typeof(string));
                    string[] ids = idTags.Split(',');
                    foreach (string aux in ids)
                    {
                        if (aux != "")
                        {
                            tours.tablaTagsSelecionados.Rows.Add(aux);
                        }
                    }
                }
                catch (Exception)
                {
                    tours.tablaTagsSelecionados = new DataTable();
                    tours.tablaTagsSelecionados.Columns.Add("id_tag", typeof(string));
                }
                tours.idioma = Session["locale"] == null ? 1 : 2;
                tours.id_seccion = Session["idSeccion"].ToString();
                tours.conexion = _conexion;
                tours.id_metaTags = "22EE3EE8-C009-43B4-AC2B-8D30A225FC01";
                tours.id_tipo = 1;
                //string IDPaiss = id.ToString().Replace("-", ",");
                string[] idsS = id.Split(',');
                tours.id_pais = Convert.ToInt32(idsS[0]);
                tours.id_estado = Convert.ToInt32(idsS[1]);
                tours.id_Lugar = idLugars;
                tours = toursDatos.ObtenerConfigTourBusqueda(tours);
                return View(tours);
            }
            catch
            {
                ToursModels tours = new ToursModels();
                tours.tablaDatosGenerales = new DataTable();
                tours.tablaCaracteristicasEmpresa = new DataTable();
                tours.tablaArticulos = new DataTable();
                tours.tablaTags = new DataTable();
                tours.tablaTours = new DataTable();
                tours.tablaSeccion = new DataTable();
                tours.tablaSecciones = new DataTable();
                tours.tablaMetaTags = new DataTable();
                tours.TablaPaquetesPopulares = new DataTable();
                tours.TablaFormasDePago = new DataTable();
                tours.numeroPaquetes = 0;
                return View(tours);
            }
        }
    }
}