using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Filters;
using System.Globalization;
using CreativaSl.Web.ViajesPorChiapas.Resources;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    public class TransportacionController : Controller
    {
        Localizate locale = new Localizate();
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Transportacion
        [HttpGet]
        [Autorizado]
               public ActionResult Index( string current , string id_seccion)
        {
            try
            {
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
                            return RedirectToAction("index", "Transportacion");
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                TransportacionModels transportacion = new TransportacionModels();
                TransportacionDatos transportacionDatos = new TransportacionDatos();

                try
                {
                    transportacion.current = Convert.ToInt32(current);
                    if (transportacion.current <= 0)
                    {
                        transportacion.current = 1;
                        transportacion.offset = 0;
                    }
                    else
                    {
                        transportacion.offset = (transportacion.current - 1) * transportacion.fetchNext;
                    }

                }
                catch (Exception)
                {
                    transportacion.current = 1;
                    transportacion.offset = 0;
                }
                try
                {
                    if (System.Web.HttpContext.Current.Session["idCliente"] != null)
                    {
                        transportacion.idClienteCotizar = System.Web.HttpContext.Current.Session["idCliente"].ToString();
                        ClienteModels cliente = new ClienteModels();
                        ClienteDatos cliente_datos = new ClienteDatos();
                        cliente.conexion = _conexion;
                        cliente.id_cliente = transportacion.idClienteCotizar;
                        cliente_datos.ObtenerDetalleClientexId(cliente);
                        transportacion.idClienteCotizar = cliente.id_cliente;
                        transportacion.nombreCotizar = cliente.nombre;
                        transportacion.apellidoPaternoCotizar = cliente.apPat;
                        transportacion.apellidoMaternoCotizar = cliente.apMat;
                        transportacion.telefonoCotizar = cliente.telefono;
                        transportacion.emailCotizar = cliente.email;
                    }
                    else
                    {
                        transportacion.idClienteCotizar = "";
                        transportacion.nombreCotizar = "";
                        transportacion.apellidoPaternoCotizar = "";
                        transportacion.apellidoMaternoCotizar = "";
                        transportacion.telefonoCotizar = "";
                        transportacion.emailCotizar = "";
                    }
                }
                catch (Exception ex)
                {
                    transportacion.idClienteCotizar = "";
                    transportacion.nombreCotizar = "";
                    transportacion.apellidoPaternoCotizar = "";
                    transportacion.apellidoMaternoCotizar = "";
                    transportacion.telefonoCotizar = "";
                    transportacion.emailCotizar = "";
                }
                transportacion.idioma = Session["locale"] == null ? 1 : 2;
                transportacion.id_seccion = Session["idSeccion"].ToString();
                transportacion.conexion = _conexion;
                transportacion.id_metaTags = "6E525D67-A0FD-4FD3-A0CA-D1935F6A54B1";
                transportacion.id_tipo = 1;
                transportacion = transportacionDatos.ObtenerConfigVehiculo(transportacion);
                return View(transportacion);
            }
            catch (Exception ex)
            {
                TransportacionModels transportacion = new TransportacionModels();
                transportacion.tablaDatosGenerales = new DataTable();
                transportacion.tablaCaracteristicasEmpresa = new DataTable();
                transportacion.tablaArticulos = new DataTable();
                transportacion.tablaGaleria = new DataTable();
                transportacion.tablaSeccion = new DataTable();
                transportacion.tablaSecciones = new DataTable();
                transportacion.tablaTipoVehiculosCotizar = new DataTable();
                transportacion.tablaMetaTags = new DataTable();
                transportacion.TablaPaquetesPopulares= new DataTable();
                transportacion.TablaFormasDePago = new DataTable();
                return View(transportacion);

            }

        }


        // GET: /Transportacion/Index
        [Autorizado]
        [HttpPost]
        public ActionResult Index (FormCollection collection)
        {
            try
            {
                TransportacionModels transporte = new TransportacionModels();
                TransportacionDatos transporteDatos = new TransportacionDatos();
                transporte.conexion = _conexion;
                transporte.id_seccion = Session["idSeccion"].ToString();
                transporte.idClienteCotizar = "";
                transporte.nombreCotizar = collection["nombreCotizar"];
                transporte.apellidoPaternoCotizar = collection["apellidoPaternoCotizar"];
                transporte.apellidoMaternoCotizar = collection["apellidoMaternoCotizar"];
                transporte.emailCotizar = collection["emailCotizar"];
                transporte.telefonoCotizar = collection["telefonoCotizar"];
                 transporte.id_vehiculo = Comun.RemoverSignosAcentos(collection["id_vehiculo"]);
                string vehiculo = collection["id_vehiculo"];
                transporte.fechaLlegadaCotizarCompleta = DateTime.ParseExact(collection["fechaLlegadaCotizar"] + " " + collection["horaLlegadaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                transporte.fechaSalidaCotizarCompleta = DateTime.ParseExact(collection["fechaSalidaCotizar"] + " " + collection["horaSalidaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (transporte.fechaLlegadaCotizarCompleta > transporte.fechaSalidaCotizarCompleta)
                {
                    transporte.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaLlegadaCotizar = collection["horaSalidaCotizar"];
                    transporte.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaSalidaCotizar = collection["horaLlegadaCotizar"];
                }
                else if (transporte.fechaLlegadaCotizarCompleta == transporte.fechaSalidaCotizarCompleta)
                {
                    transporte.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    transporte.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
                    transporte.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                else
                {
                    transporte.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    transporte.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                string nombre = transporte.nombreCotizar + " " + transporte.apellidoPaternoCotizar + " " + transporte.apellidoMaternoCotizar;
                transporte.numeroPersonasCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                transporte.numeroAdultoCotizar = Convert.ToInt32(collection["numeroAdultoCotizar"]);
                transporte.numeroNiños511Cotizar = Convert.ToInt32(collection["numeroNiños511Cotizar"]);
                transporte.numeroNiños14Cotizar = Convert.ToInt32(collection["numeroNiños14Cotizar"]);
                transporte.observacionesCotizar = collection["observacionesCotizar"];
                transporteDatos.CotizarTransporte(ref transporte);
                Comun.EnviarCorreo(
                ConfigurationManager.AppSettings.Get("CorreoTxt")
                , ConfigurationManager.AppSettings.Get("PasswordTxt")
                , transporte.emailCotizar
                , transporte.datosGeneralesCorreo.Rows[0]["asunto"].ToString()
                , Comun.GenerarHtmlTransportacionCotizado(transporte.datosGeneralesCorreo, transporte.tablaRedesSociales,transporte.TablaPaquetesPopulares,nombre, vehiculo, transporte.id_vehiculo)
                , false
                , ""
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                , ConfigurationManager.AppSettings.Get("HostTxt")
                , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                if (transporte.verificadorCotizar == 1 || transporte.verificadorCotizar == 2)
                {
                    TempData["typemessage"] = "1";
                    TempData["message"] = locale.GetResourceCotizar("termino24Horas");
                    TempData["message2"] = locale.GetResourceCotizar("termino24Horas2");
                    //TempData["message3"] = locale.GetResourceCotizar("termino24Horas3");
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
                TransportacionModels transporte = new TransportacionModels();
                transporte.tablaDatosGenerales = new DataTable();
                transporte.tablaCaracteristicasEmpresa = new DataTable();
                transporte.tablaArticulos = new DataTable();
                transporte.tablaGaleria = new DataTable();
                transporte.tablaSeccion = new DataTable();
                transporte.tablaSecciones = new DataTable();
                transporte.tablaTipoVehiculosCotizar = new DataTable();
                transporte.tablaMetaTags = new DataTable();
                transporte.tablaVehiculos = new DataTable();
                return View(transporte);
            }
        }
       
        [HttpGet]
        [Autorizado]
        public ActionResult DetalleAuto(string id)
        {
            try
            {
                TransportacionModels promocion = new TransportacionModels();
                TransportacionDatos PromocionDatos = new TransportacionDatos();
                promocion.idioma = Session["locale"] == null ? 1 : 2;
                promocion.id_seccion = Session["idSeccion"].ToString();
                promocion.conexion = _conexion;
                promocion.nombre_pagina = id;
                promocion.id_tipo = 2;
                promocion = PromocionDatos.ObtenerConfigDetalleVehiculo(promocion);
                return View(promocion);
            }
            catch
            {
                TransportacionModels promocion = new TransportacionModels();
                promocion.tablaDatosGenerales = new DataTable();
                promocion.tablaCaracteristicasEmpresa = new DataTable();
                promocion.tablaArticulos = new DataTable();
                promocion.tablaItinerario = new DataTable();
                promocion.tablaSeccion = new DataTable();
                promocion.tablaSecciones = new DataTable();
                promocion.tablaLugares = new DataTable();
                promocion.tablaMetaTags = new DataTable();
                promocion.tablaPromociones = new DataTable();
                promocion.tablaVehiculos = new DataTable();
                promocion.TablaPaquetesPopulares = new DataTable();
                promocion.TablaFormasDePago = new DataTable();
                return View(promocion);
            }
        }

        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        public ActionResult CotizarEmpresa()
        {
            try
            {
                TransportacionModels transportacion = new TransportacionModels();
                TransportacionDatos transportacionDatos = new TransportacionDatos();
                try
                {
                    if (System.Web.HttpContext.Current.Session["idCliente"] != null)
                    {
                        transportacion.idClienteCotizar = System.Web.HttpContext.Current.Session["idCliente"].ToString();
                        ClienteModels cliente = new ClienteModels();
                        ClienteDatos cliente_datos = new ClienteDatos();
                        cliente.conexion = _conexion;
                        cliente.id_cliente = transportacion.idClienteCotizar;
                        cliente_datos.ObtenerDetalleClientexId(cliente);
                        transportacion.idClienteCotizar = cliente.id_cliente;
                        transportacion.nombreCotizar = cliente.nombre;
                        transportacion.apellidoPaternoCotizar = cliente.apPat;
                        transportacion.apellidoMaternoCotizar = cliente.apMat;
                        transportacion.telefonoCotizar = cliente.telefono;
                        transportacion.emailCotizar = cliente.email;
                    }
                    else
                    {
                        transportacion.idClienteCotizar = "";
                        transportacion.nombreCotizar = "";
                        transportacion.apellidoPaternoCotizar = "";
                        transportacion.apellidoMaternoCotizar = "";
                        transportacion.telefonoCotizar = "";
                        transportacion.emailCotizar = "";
                    }
                }
                catch (Exception ex)
                {
                    transportacion.idClienteCotizar = "";
                    transportacion.nombreCotizar = "";
                    transportacion.apellidoPaternoCotizar = "";
                    transportacion.apellidoMaternoCotizar = "";
                    transportacion.telefonoCotizar = "";
                    transportacion.emailCotizar = "";
                }
                transportacion.idioma = Session["locale"] == null ? 1 : 2;
                transportacion.id_seccion = Session["idSeccion"].ToString();
                transportacion.conexion = _conexion;
                transportacion.id_metaTags = "205DD701-A8D2-4061-8961-0505DD520490";
                transportacion.id_tipo = 1;
                transportacion = transportacionDatos.ObtenerConfigTransportacionEmpresa(transportacion);
                var list = new SelectList(transportacion.tablaTipoVehiculosCotizar.AsDataView(), "id_tipoVehiculo", "descripcion");
                ViewData["cmbTipoVehiculosCotizar"] = list;
                transportacion.emailCotizar = Session["Correo"].ToString();
                return View(transportacion);
            }
            catch (Exception ex)
            {
                TransportacionModels transportacion = new TransportacionModels();
                transportacion.tablaDatosGenerales = new DataTable();
                transportacion.tablaCaracteristicasEmpresa = new DataTable();
                transportacion.tablaArticulos = new DataTable();
                transportacion.tablaGaleria = new DataTable();
                transportacion.tablaSeccion = new DataTable();
                transportacion.tablaSecciones = new DataTable();
                transportacion.tablaTipoVehiculosCotizar = new DataTable();
                transportacion.tablaMetaTags = new DataTable();
                transportacion.TablaPaquetesPopulares = new DataTable();
                transportacion.TablaFormasDePago = new DataTable();
                return View(transportacion);
            }
        }
        // GET: /Transportacion/CotizarEmpresa
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        public ActionResult CotizarEmpresa(FormCollection collection)
        {
            try
            {
                TransportacionModels transporte = new TransportacionModels();
                TransportacionDatos transporteDatos = new TransportacionDatos();
                transporte.conexion = _conexion;
                transporte.id_seccion = Session["idSeccion"].ToString();
                transporte.idClienteCotizar = "";
                transporte.nombreCotizar = collection["nombreCotizar"];
                transporte.apellidoPaternoCotizar = collection["apellidoPaternoCotizar"];
                transporte.apellidoMaternoCotizar = collection["apellidoMaternoCotizar"];
                transporte.emailCotizar = collection["emailCotizar"];
                transporte.telefonoCotizar = collection["telefonoCotizar"];
                transporte.id_TipoVehiculoCotizar = collection["id_TipoVehiculoCotizar"];
                transporte.fechaLlegadaCotizarCompleta = DateTime.ParseExact(collection["fechaLlegadaCotizar"] + " " + collection["horaLlegadaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                transporte.fechaSalidaCotizarCompleta = DateTime.ParseExact(collection["fechaSalidaCotizar"] + " " + collection["horaSalidaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (transporte.fechaLlegadaCotizarCompleta > transporte.fechaSalidaCotizarCompleta)
                {
                    transporte.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaLlegadaCotizar = collection["horaSalidaCotizar"];
                    transporte.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaSalidaCotizar = collection["horaLlegadaCotizar"];
                }
                else if (transporte.fechaLlegadaCotizarCompleta == transporte.fechaSalidaCotizarCompleta)
                {
                    transporte.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    transporte.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
                    transporte.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                else
                {
                    transporte.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    transporte.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    transporte.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                transporte.numeroPersonasCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                transporte.numeroAdultoCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                transporte.observacionesCotizar = collection["observacionesCotizar"];
                transporteDatos.CotizarTransporteEmpresa(ref transporte);
                Comun.EnviarCorreo(
                ConfigurationManager.AppSettings.Get("CorreoTxt")
                , ConfigurationManager.AppSettings.Get("PasswordTxt")
                , transporte.emailCotizar
                , transporte.datosGeneralesCorreo.Rows[0]["asunto"].ToString()
                , Comun.GenerarHtmlTransportacionCotizadoEmpresa(transporte.datosGeneralesCorreo, transporte.tablaRedesSociales,transporte.TablaPaquetesPopulares,transporte.nombre_pagina)
                , false
                , ""
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                , ConfigurationManager.AppSettings.Get("HostTxt")
                , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                if (transporte.verificadorCotizar == 1 || transporte.verificadorCotizar == 2)
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
                TransportacionModels transporte = new TransportacionModels();
                transporte.tablaDatosGenerales = new DataTable();
                transporte.tablaCaracteristicasEmpresa = new DataTable();
                transporte.tablaArticulos = new DataTable();
                transporte.tablaGaleria = new DataTable();
                transporte.tablaSeccion = new DataTable();
                transporte.tablaSecciones = new DataTable();
                transporte.tablaTipoVehiculosCotizar = new DataTable();
                transporte.tablaMetaTags = new DataTable();
                return View(transporte);
            }
        }

        //  POST: /Transportacion/CambiarIdioma/6
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
        //  POST: /Transportacion/MatarSession/6
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
    }
    
}