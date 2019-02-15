using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Filters;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    public class PromocionesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Promociones
        [HttpGet]
        [Autorizado]
        public ActionResult Index(string current , string id_seccion)
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
                            return RedirectToAction("index", "Promociones");
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
                transportacion.id_metaTags = "1E6A79C6-EA60-40F6-8AB7-283F953135F9";
                transportacion.id_tipo = 1;
                transportacion = transportacionDatos.ObtenerConfigPromociones(transportacion);
                return View(transportacion);
            }
            catch
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
                transportacion.tablaPromociones = new DataTable();
                transportacion.TablaPromocionesPopulares = new DataTable();
                transportacion.TablaFormasDePago = new DataTable();
                return View(transportacion);
            }
        }
        // GET: Promociones/DetallePromociones/5
        [HttpGet]
        [Autorizado]
        public ActionResult DetallePromocion(string id)
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
                promocion = PromocionDatos.ObtenerConfigDetallePromociones(promocion);
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
                promocion.TablaPromocionesPopulares = new DataTable();
                promocion.TablaFormasDePago = new DataTable();
                return View(promocion);
            }
        }

        //  POST: /Contactanos/CambiarIdioma/6
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

        //  POST: /Contactanos/MatarSession/6
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