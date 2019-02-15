using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
using CreativaSl.Web.ViajesPorChiapas.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    [Compress]
    public class PaquetesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        Localizate locale = new Localizate();
        // GET: Paquetes
        [Autorizado]
        [HttpGet]
        public ActionResult Index(string id, string current, string idTags, string id_seccion,string modalidad)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();

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
                            return RedirectToAction("index", "paquetes");

                        }
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    paquetes.current = Convert.ToInt32(current);
                    if (paquetes.current <= 0)
                    {
                        paquetes.current = 1;
                        paquetes.offset = 0;
                    }
                    else
                    {
                        paquetes.offset = (paquetes.current - 1) * paquetes.fetchNext;
                    }

                }
                catch (Exception)
                {
                    paquetes.current = 1;
                    paquetes.offset = 0;
                }

                try
                {
                    paquetes.tablaTagsSelecionados = new DataTable();
                    paquetes.tablaTagsSelecionados.Columns.Add("id_tag", typeof(string));
                    string[] ids = idTags.Split(',');
                    foreach (string aux in ids)
                    {
                        if (aux != "")
                        {
                            paquetes.tablaTagsSelecionados.Rows.Add(aux);
                        }
                    }
                }
                catch (Exception)
                {
                    paquetes.tablaTagsSelecionados = new DataTable();
                    paquetes.tablaTagsSelecionados.Columns.Add("id_tag", typeof(string));
                }
               
                paquetes.idioma = Session["locale"] == null ? 1 : 2;
                paquetes.id_seccion = Session["idSeccion"].ToString();
                paquetes.conexion = _conexion;
                paquetes.id_metaTags = "88A4F614-7E1C-49D1-87F5-3F52F52F559E";
                paquetes.id_tipo = 1;
                string[] idsS = id.Split('-');
                paquetes.modalidad = Convert.ToInt32(modalidad);
                paquetes.id_pais = Convert.ToInt32(idsS[0]);
                paquetes.id_estado = Convert.ToInt32(idsS[1]);
                paquetes = paquetesDatos.ObtenerConfigPaquete(paquetes);
                return View(paquetes);
            }
            catch (Exception ex)
            {
                PaquetesModels paquetes = new PaquetesModels();
                paquetes.tablaDatosGenerales = new DataTable();
                paquetes.tablaCaracteristicasEmpresa = new DataTable();
                paquetes.tablaArticulos = new DataTable();
                paquetes.tablaTags = new DataTable();
                paquetes.tablaPaquetes = new DataTable();
                paquetes.tablaSeccion = new DataTable();
                paquetes.tablaSecciones = new DataTable();
                paquetes.tablaMetaTags = new DataTable();
                paquetes.numeroPaquetes = 0;
                paquetes.TablaPaquetesPopulares = new DataTable();
                paquetes.TablaFormasDePago = new DataTable();
                return View(paquetes);
            }
        }

        // GET: /Paquetes/DetallePaquete/5
        [Autorizado]
        [HttpGet]
        public ActionResult DetallePaquete(string id, string id_seccion)
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
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.idioma = Session["locale"] == null ? 1 : 2;
                paquetes.id_seccion = Session["idSeccion"].ToString();
                paquetes.conexion = _conexion;
                paquetes.nombre_pagina = id;
                paquetes.id_tipo = 2;
                paquetes = paquetesDatos.ObtenerConfigDetallePaquete(paquetes);
                return View(paquetes);
            }
            catch
            {
                PaquetesModels paquetes = new PaquetesModels();
                paquetes.tablaDatosGenerales = new DataTable();
                paquetes.tablaCaracteristicasEmpresa = new DataTable();
                paquetes.tablaArticulos = new DataTable();
                paquetes.tablaPaquetes = new DataTable();
                paquetes.tablaItinerario = new DataTable();
                paquetes.tablaSeccion = new DataTable();
                paquetes.tablaSecciones = new DataTable();
                paquetes.tablaLugares = new DataTable();
                paquetes.tablaMetaTags = new DataTable();
                paquetes.TablaPaquetesPopulares = new DataTable();
                paquetes.TablaFormasDePago = new DataTable();
                return View(paquetes);
            }
        }

        // GET: /Paquetes/Cotizar/5
        [Autorizado]
        [HttpGet]
        public ActionResult Cotizar(string id)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                try
                {
                    if (System.Web.HttpContext.Current.Session["idCliente"] != null)
                    {
                        paquetes.idClienteCotizar = System.Web.HttpContext.Current.Session["idCliente"].ToString();
                        ClienteModels cliente = new ClienteModels();
                        ClienteDatos cliente_datos = new ClienteDatos();
                        cliente.conexion = _conexion;
                        cliente.id_cliente = paquetes.idClienteCotizar;
                        cliente_datos.ObtenerDetalleClientexId(cliente);
                        paquetes.idClienteCotizar = cliente.id_cliente;
                        paquetes.nombreCotizar = cliente.nombre;
                        paquetes.apellidoPaternoCotizar = cliente.apPat;
                        paquetes.apellidoMaternoCotizar = cliente.apMat;
                        paquetes.telefonoCotizar = cliente.telefono;
                        paquetes.emailCotizar = cliente.email;
                    }
                    else
                    {
                        paquetes.idClienteCotizar = "";
                        paquetes.nombreCotizar = "";
                        paquetes.apellidoPaternoCotizar = "";
                        paquetes.apellidoMaternoCotizar = "";
                        paquetes.telefonoCotizar = "";
                        paquetes.emailCotizar = "";
                    }
                }
                catch (Exception ex)
                {
                    paquetes.idClienteCotizar = "";
                    paquetes.nombreCotizar = "";
                    paquetes.apellidoPaternoCotizar = "";
                    paquetes.apellidoMaternoCotizar = "";
                    paquetes.telefonoCotizar = "";
                    paquetes.emailCotizar = "";
                }
                paquetes.nombre_pagina = id;
                paquetes.idioma = Session["locale"] == null ? 1 : 2;
                paquetes.id_seccion = Session["idSeccion"].ToString();
                paquetes.conexion = _conexion;
                paquetes.id_tipo = 3;
                paquetes = paquetesDatos.ObtenerConfigPaquetes(paquetes);
                if (paquetes.nombre_pagina == "" || paquetes.nombre == "")
                {
                    return RedirectToAction("Index");
                }
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
                paquetes.nombre = "";
                paquetes.TablaPaquetesPopulares = new DataTable();
                paquetes.TablaFormasDePago = new DataTable();
                return View(paquetes);
            }
        }
        // POST: /Paquetes/Cotizar
        [Autorizado]
        [HttpPost]
        public ActionResult Cotizar(string id, FormCollection collection)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_seccion = Session["idSeccion"].ToString();
                paquetes.nombre_pagina = id;
                paquetes.idClienteCotizar = "";
                paquetes.nombreCotizar = collection["nombreCotizar"];
                paquetes.apellidoPaternoCotizar = collection["apellidoPaternoCotizar"];
                paquetes.apellidoMaternoCotizar = collection["apellidoMaternoCotizar"];
                paquetes.emailCotizar = collection["emailCotizar"];
                paquetes.telefonoCotizar = collection["telefonoCotizar"];
                paquetes.BoletoCotizar = Convert.ToBoolean(collection["BoletoCotizar"]);
                paquetes.aeropuertoLlegadaCotizar = collection["aeropuertoLlegadaCotizar"];
                paquetes.aeropuertoSalidaCotizar = collection["aeropuertoSalidaCotizar"];
                paquetes.fechaLlegadaCotizarCompleta = DateTime.ParseExact(collection["fechaLlegadaCotizar"] + " " + collection["horaLlegadaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                paquetes.fechaSalidaCotizarCompleta = DateTime.ParseExact(collection["fechaSalidaCotizar"] + " " + collection["horaSalidaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (paquetes.fechaLlegadaCotizarCompleta > paquetes.fechaSalidaCotizarCompleta)
                {
                    paquetes.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaLlegadaCotizar = collection["horaSalidaCotizar"];
                    paquetes.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaSalidaCotizar = collection["horaLlegadaCotizar"];
                }
                else if (paquetes.fechaLlegadaCotizarCompleta == paquetes.fechaSalidaCotizarCompleta)
                {
                    paquetes.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    paquetes.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
                    paquetes.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                else
                {
                    paquetes.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    paquetes.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                paquetes.categoriaHotelCotizar = Convert.ToInt32(collection["categoriaHotelCotizar"]);
                paquetes.numeroPersonasCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                paquetes.numeroAdultoCotizar = Convert.ToInt32(collection["numeroAdultoCotizar"]);
                paquetes.numeroNiños511Cotizar = Convert.ToInt32(collection["numeroNiños511Cotizar"]);
                paquetes.numeroNiños14Cotizar = Convert.ToInt32(collection["numeroNiños14Cotizar"]);
                paquetes.numeroHabitacionesCotizar = Convert.ToInt32(collection["numeroHabitacionesCotizar"]);
                paquetes.numeroPersonasCamaCotizar = new DataTable();
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numero", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroAdultos", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroNiños511", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroNiños14", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroCamas", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("tipoHabitacion", typeof(int));

                int numeroAdultosAux = 0, numeroNiños511Aux = 0, numeroNiño14 = 0, numeroCamasAux = 0, tipoHabitacion = 0;
                for (var j = 1; j <= (paquetes.numeroHabitacionesCotizar); j++)
                {
                    numeroAdultosAux = Convert.ToInt32(collection["numAdultos_tabla_td" + j.ToString()]);
                    numeroNiños511Aux = Convert.ToInt32(collection["numNinosMenores11_tabla_td" + j.ToString()]);
                    numeroNiño14 = Convert.ToInt32(collection["numNinosMenores4_tabla_td" + j.ToString()]);
                    numeroCamasAux = Convert.ToInt32(collection["numCamas_tabla_td" + j.ToString()]);
                    tipoHabitacion = 0;
                    //Cambio Will
                    if ((numeroAdultosAux) == 1)
                        tipoHabitacion = 1;
                    else if ((numeroAdultosAux) == 2)
                        tipoHabitacion = 2;
                    else if ((numeroAdultosAux) == 3)
                        tipoHabitacion = 3;
                    else if ((numeroAdultosAux) == 4)
                        tipoHabitacion = 4;
                    paquetes.numeroPersonasCamaCotizar.Rows.Add(j, numeroAdultosAux, numeroNiños511Aux, numeroNiño14, numeroCamasAux, tipoHabitacion);
                }
                string nombrePersona = paquetes.nombreCotizar + " " + paquetes.apellidoPaternoCotizar + " " + paquetes.apellidoMaternoCotizar;
                paquetesDatos.CotizarPaquete(ref paquetes);
                Comun.EnviarCorreo(
                ConfigurationManager.AppSettings.Get("CorreoTxt")
                , ConfigurationManager.AppSettings.Get("PasswordTxt")
                , paquetes.emailCotizar
                , paquetes.datosGeneralesCorreo.Rows[0]["asunto"].ToString()
                , Comun.GenerarHtmlPaqueteCotizado(paquetes.datosGeneralesCorreo, paquetes.tablaRecamarasCorreo, paquetes.tablaRedesSociales, paquetes.tablaItinerario,paquetes.TablaPaquetesPopulares, nombrePersona, paquetes.nombre_pagina)
                , false
                , ""
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                , ConfigurationManager.AppSettings.Get("HostTxt")
                , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                if (paquetes.verificadorCotizar == 1 || paquetes.verificadorCotizar == 2)
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
                PaquetesModels paquetes = new PaquetesModels();
                paquetes.tablaDatosGenerales = new DataTable();
                paquetes.tablaCaracteristicasEmpresa = new DataTable();
                paquetes.tablaArticulos = new DataTable();
                paquetes.tablaSeccion = new DataTable();
                paquetes.tablaSecciones = new DataTable();
                paquetes.nombre = "";
                paquetes.tablaMetaTags = new DataTable();
                return View(paquetes);
            }
        }
        // GET: /Paquetes/CotizarPaqueteVip/5
        [Autorizado]
        [HttpGet]
        public ActionResult CotizarPaqueteVip()
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                try
                {
                    if (System.Web.HttpContext.Current.Session["idCliente"] != null)
                    {
                        paquetes.idClienteCotizar = System.Web.HttpContext.Current.Session["idCliente"].ToString();
                        ClienteModels cliente = new ClienteModels();
                        ClienteDatos cliente_datos = new ClienteDatos();
                        cliente.conexion = _conexion;
                        cliente.id_cliente = paquetes.idClienteCotizar;
                        cliente_datos.ObtenerDetalleClientexId(cliente);
                        paquetes.idClienteCotizar = cliente.id_cliente;
                        paquetes.nombreCotizar = cliente.nombre;
                        paquetes.apellidoPaternoCotizar = cliente.apPat;
                        paquetes.apellidoMaternoCotizar = cliente.apMat;
                        paquetes.telefonoCotizar = cliente.telefono;
                        paquetes.emailCotizar = cliente.email;
                    }
                    else
                    {
                        paquetes.idClienteCotizar = "";
                        paquetes.nombreCotizar = "";
                        paquetes.apellidoPaternoCotizar = "";
                        paquetes.apellidoMaternoCotizar = "";
                        paquetes.telefonoCotizar = "";
                        paquetes.emailCotizar = "";
                    }
                }
                catch (Exception ex)
                {
                    paquetes.idClienteCotizar = "";
                    paquetes.nombreCotizar = "";
                    paquetes.apellidoPaternoCotizar = "";
                    paquetes.apellidoMaternoCotizar = "";
                    paquetes.telefonoCotizar = "";
                    paquetes.emailCotizar = "";
                }
                paquetes.idioma = Session["locale"] == null ? 1 : 2;
                paquetes.id_seccion = Session["idSeccion"].ToString();
                paquetes.conexion = _conexion;
                paquetes.id_metaTags = "F1D7C15D-8C3B-4DCA-BDC5-87679E986A7D";
                paquetes.id_tipo = 1;
                paquetes = paquetesDatos.ObtenerConfigPaquetesVip(paquetes);
                var list = new SelectList(paquetes.tablaSeccionesEstadosCotizar.AsDataView(), "id_estado", "descripcion");
                ViewData["cmbSeccionesEstadosCotizar"] = list;
                var list2 = new SelectList(paquetes.tablaLugaresTuristicosMunicipiosCotizar.AsDataView(), "id_municipio", "descripcion");
                ViewData["cmbLugaresTuristicosMunicipiosCotizar"] = list2;
                var list3 = new SelectList(paquetes.tablaTipoVehiculosCotizar.AsDataView(), "id_tipoVehiculo", "descripcion");
                ViewData["cmbTipoVehiculosCotizar"] = list3;
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
                paquetes.nombre = "";
                return View(paquetes);
            }
        }
        // POST: /Paquetes/CotizarPaqueteVip
        [Autorizado]
        [HttpPost]
        public ActionResult CotizarPaqueteVip(FormCollection collection)
        {
            try
            {
                PaquetesModels paquetes = new PaquetesModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                paquetes.conexion = _conexion;
                paquetes.id_seccion = Session["idSeccion"].ToString();
                paquetes.idClienteCotizar = "";
                paquetes.nombreCotizar = collection["nombreCotizar"];
                paquetes.apellidoPaternoCotizar = collection["apellidoPaternoCotizar"];
                paquetes.apellidoMaternoCotizar = collection["apellidoMaternoCotizar"];
                paquetes.emailCotizar = collection["emailCotizar"];
                paquetes.telefonoCotizar = collection["telefonoCotizar"];
                paquetes.BoletoCotizar = Convert.ToBoolean(collection["BoletoCotizar"]);
                paquetes.aeropuertoLlegadaCotizar = collection["aeropuertoLlegadaCotizar"];
                paquetes.aeropuertoSalidaCotizar = collection["aeropuertoSalidaCotizar"];
                paquetes.fechaLlegadaCotizarCompleta = DateTime.ParseExact(collection["fechaLlegadaCotizar"] + " " + collection["horaLlegadaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                paquetes.fechaSalidaCotizarCompleta = DateTime.ParseExact(collection["fechaSalidaCotizar"] + " " + collection["horaSalidaCotizar"], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (paquetes.fechaLlegadaCotizarCompleta > paquetes.fechaSalidaCotizarCompleta)
                {
                    paquetes.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaLlegadaCotizar = collection["horaSalidaCotizar"];
                    paquetes.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaSalidaCotizar = collection["horaLlegadaCotizar"];
                }
                else if (paquetes.fechaLlegadaCotizarCompleta == paquetes.fechaSalidaCotizarCompleta)
                {
                    paquetes.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    paquetes.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
                    paquetes.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                else
                {
                    paquetes.fechaLlegadaCotizar = DateTime.ParseExact(collection["fechaLlegadaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaLlegadaCotizar = collection["horaLlegadaCotizar"];
                    paquetes.fechaSalidaCotizar = DateTime.ParseExact(collection["fechaSalidaCotizar"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    paquetes.horaSalidaCotizar = collection["horaSalidaCotizar"];
                }
                paquetes.categoriaHotelCotizar = Convert.ToInt32(collection["categoriaHotelCotizar"]);
                paquetes.numeroPersonasCotizar = Convert.ToInt32(collection["numeroPersonasCotizar"]);
                paquetes.numeroAdultoCotizar = Convert.ToInt32(collection["numeroAdultoCotizar"]);
                paquetes.numeroNiños511Cotizar = Convert.ToInt32(collection["numeroNiños511Cotizar"]);
                paquetes.numeroNiños14Cotizar = Convert.ToInt32(collection["numeroNiños14Cotizar"]);
                paquetes.numeroHabitacionesCotizar = Convert.ToInt32(collection["numeroHabitacionesCotizar"]);
                paquetes.numeroPersonasCamaCotizar = new DataTable();
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numero", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroAdultos", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroNiños511", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroNiños14", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("numeroCamas", typeof(int));
                paquetes.numeroPersonasCamaCotizar.Columns.Add("tipoHabitacion", typeof(int));
                int numeroAdultosAux = 0, numeroNiños511Aux = 0, numeroNiño14 = 0, numeroCamasAux = 0, tipoHabitacion = 0;
                for (var j = 1; j <= (paquetes.numeroHabitacionesCotizar); j++)
                {
                    numeroAdultosAux = Convert.ToInt32(collection["numAdultos_tabla_td" + j.ToString()]);
                    numeroNiños511Aux = Convert.ToInt32(collection["numNinosMenores11_tabla_td" + j.ToString()]);
                    numeroNiño14 = Convert.ToInt32(collection["numNinosMenores4_tabla_td" + j.ToString()]);
                    numeroCamasAux = Convert.ToInt32(collection["numCamas_tabla_td" + j.ToString()]);
                    tipoHabitacion = 0;
                    //Cambio Will
                    if ((numeroAdultosAux) == 1)
                        tipoHabitacion = 1;
                    else if ((numeroAdultosAux) == 2)
                        tipoHabitacion = 2;
                    else if ((numeroAdultosAux) == 3)
                        tipoHabitacion = 3;
                    else if ((numeroAdultosAux) == 4)
                        tipoHabitacion = 4;
                    paquetes.numeroPersonasCamaCotizar.Rows.Add(j, numeroAdultosAux, numeroNiños511Aux, numeroNiño14, numeroCamasAux, tipoHabitacion);
                }
                paquetes.recorridoLugaresTuristicosCotizar = new DataTable();
                paquetes.recorridoLugaresTuristicosCotizar.Columns.Add("numero", typeof(int));
                paquetes.recorridoLugaresTuristicosCotizar.Columns.Add("numeroAdultos", typeof(string));
                int orderAux = 0;
                foreach (var key in collection.AllKeys)
                {
                    if (key.Contains("recorrido_id_lugar"))
                    {
                        orderAux = orderAux + 1;
                        paquetes.recorridoLugaresTuristicosCotizar.Rows.Add(orderAux, collection[key]);
                    }
                }
                string nombrePersona = paquetes.nombreCotizar + " " + paquetes.apellidoPaternoCotizar+ " " +paquetes.apellidoMaternoCotizar;
                paquetes.id_TipoVehiculoCotizar = collection["tablaTipoVehiculosCotizar"];
                paquetes.observacionesCotizar = collection["observacionesCotizar"].ToString();
                paquetesDatos.CotizarPaqueteVip(ref paquetes);
                Comun.EnviarCorreo(
                ConfigurationManager.AppSettings.Get("CorreoTxt")
                , ConfigurationManager.AppSettings.Get("PasswordTxt")
                , paquetes.emailCotizar
                , paquetes.datosGeneralesCorreo.Rows[0]["asunto"].ToString()
                , Comun.GenerarHtmlPaqueteVipCotizado(paquetes.datosGeneralesCorreo, paquetes.tablaRecamarasCorreo, paquetes.tablaRedesSociales, paquetes.tablaItinerario,paquetes.TablaPaquetesPopulares, nombrePersona)
                , false
                , ""
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                , ConfigurationManager.AppSettings.Get("HostTxt")
                , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                if (paquetes.verificadorCotizar == 1 || paquetes.verificadorCotizar == 2)
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
                PaquetesModels paquetes = new PaquetesModels();
                paquetes.tablaDatosGenerales = new DataTable();
                paquetes.tablaCaracteristicasEmpresa = new DataTable();
                paquetes.tablaArticulos = new DataTable();
                paquetes.tablaSeccion = new DataTable();
                paquetes.tablaSecciones = new DataTable();
                paquetes.tablaMetaTags = new DataTable();
                paquetes.TablaPaquetesPopulares = new DataTable();
                paquetes.TablaFormasDePago = new DataTable();
                paquetes.nombre = "";
                return View(paquetes);
            }
        }

        //  POST: /Paquetes/CambiarIdioma/6
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
        //  POST: /Paquetes/MatarSession/6
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
        //  POST: /Paquetes/Municipio/6
        //MODIFICAR MODIFICAR MODIFICAR
        [HttpPost]
        public ActionResult Lugares(string id)
        {
            try
            {
                string[] Ids = id.Split(',');
                MunicipioModels municipio = new MunicipioModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                List<MunicipioModels> lstMunicipio = new List<MunicipioModels>();
                municipio.id_pais = Convert.ToInt32(Ids[0]);
                municipio.id_estado = Convert.ToInt32(Ids[1]);
                municipio.conexion = _conexion;
                lstMunicipio = paquetesDatos.ObtenerComboCatLugares(municipio);
                return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //  POST: /Paquetes/Municipio/6
        [HttpPost]
        public ActionResult Municipio(int id)
        {
            try
            {
                MunicipioModels municipio = new MunicipioModels();
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                List<MunicipioModels> lstMunicipio = new List<MunicipioModels>();
                municipio.id_estado = id;
                municipio.conexion = _conexion;
                lstMunicipio = paquetesDatos.ObtenerComboCatMunicipios(municipio);
                return Json(lstMunicipio, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //  POST: /Paquetes/LugaresTuristicosXMunicipios/6
        [HttpPost]
        public ActionResult LugaresTuristicosXMunicipios(string id)
        {
            try
            {
                string[] words = id.Split(',');
                LugaresTuristicosModels lugaresTuristicos = new LugaresTuristicosModels();
                lugaresTuristicos.idioma = Session["locale"] == null ? 1 : 2;
                lugaresTuristicos.conexion = _conexion;
                lugaresTuristicos.id_pais = Convert.ToInt32(words[0]);
                lugaresTuristicos.id_estado = Convert.ToInt32(words[1]);
                lugaresTuristicos.id_municipio = Convert.ToInt32(words[2]);
                PaquetesDatos paquetesDatos = new PaquetesDatos();
                List<LugaresTuristicosModels> lstLugaresTuristicos = new List<LugaresTuristicosModels>();
                lstLugaresTuristicos = paquetesDatos.ObtenerComboCatLugaresTuristicos(lugaresTuristicos);
                return Json(lstLugaresTuristicos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}