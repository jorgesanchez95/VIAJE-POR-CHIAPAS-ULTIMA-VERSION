using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
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
    public class MiCuentaController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");

        //
        // GET: /MiCuenta/
        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        public ActionResult Index(string current)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                try
                {
                    if (current == null)
                        cliente.panginator = false;
                    else
                        cliente.panginator = true;

                    cliente.current = Convert.ToInt32(current);
                    if (cliente.current <= 0)
                    {
                        cliente.current = 1;
                        cliente.offset = 0;
                    }
                    else
                    {
                        cliente.offset = (cliente.current - 1) * cliente.fetchNext;
                    }

                }
                catch (Exception)
                {
                    cliente.current = 1;
                    cliente.offset = 0;
                    cliente.panginator = false;
                }
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.conexion = _conexion;
                cliente.id_metaTags = "FAF3E091-4565-405A-9104-E138838352F1";
                cliente.id_tipo = 1;
                cliente = clienteDatos.ObtenerConfigMiCuenta(cliente);
                cliente = clienteDatos.ObtenerDetalleClientexId(cliente);
                cliente = clienteDatos.ObtenerSolicitudesxCliente(cliente);

                ComunDatos comunDatos = new ComunDatos();

                CatGeneroModels genero = new CatGeneroModels();
                genero.conexion = _conexion;
                cliente.tablaGeneroCmb = comunDatos.ObtenerComboCatGenero(genero);
                var list = new SelectList(cliente.tablaGeneroCmb, "id_genero", "descripcion");
                ViewData["cmbGeneros"] = list;

                CatOcupacionesModels ocupaciones = new CatOcupacionesModels();
                ocupaciones.conexion = _conexion;
                cliente.tablaOcupacionesCmb = comunDatos.ObtenerComboCatOcupaciones(ocupaciones);
                list = new SelectList(cliente.tablaOcupacionesCmb, "id_ocupacion", "descripcion");
                ViewData["cmbOcupaciones"] = list;

                EstadoModels estado = new EstadoModels();
                estado.conexion = _conexion;
                estado.id_pais = 143;
                cliente.tablaEstadosCmb = comunDatos.ObtenerComboCatEstados(estado);
                list = new SelectList(cliente.tablaEstadosCmb, "id_estado", "descripcion");
                ViewData["cmbEstados"] = list;

                cliente.tablaMunicipiosCmb = new List<MunicipioModels>();
                var list2 = new SelectList(cliente.tablaMunicipiosCmb, "id_municipio", "descripcion");
                ViewData["cmbMunicipios"] = list2;

                return View(cliente);
            }
            catch
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaClientes = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                cliente.tablaMetaTags = new DataTable();
                cliente.TablaPaquetesPopulares = new DataTable();
                cliente.TablaFormasDePago = new DataTable();
                return View(cliente);
            }
        }
        //  POST: MiCuenta/Municipio/6
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        public ActionResult Municipio(int id)
        {
            try
            {
                MunicipioModels municipio = new MunicipioModels();
                ComunDatos comunDatos = new ComunDatos();

                List<MunicipioModels> lstMunicipio = new List<MunicipioModels>();
                municipio.id_estado = id;
                municipio.id_pais = 143;
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
        // POST: MiCuenta/EditDatos/5
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        public ActionResult EditDatos(string id, FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();

                cliente.conexion = _conexion;
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.nombre = collection["nombre"];
                cliente.apPat = collection["apPat"];
                cliente.apMat = collection["apMat"];
                cliente.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                cliente.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                cliente.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                cliente.id_genero = Convert.ToInt32(collection["tablaGeneroCmb"]);
                cliente.id_ocupacion = 1;
                cliente.curp = "";
                cliente.telefono = collection["telefono"];
                cliente.fechaNac = DateTime.ParseExact(collection["fechaNac"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cliente.colonia = collection["colonia"];
                cliente.email = collection["email"];
                cliente.opcion = 4;
                cliente.user = User.Identity.Name;
                clienteDatos.AbcCatCliente(cliente);


                return RedirectToAction("Index", "MiCuenta");
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "MiCuenta");
            }
        }
        // POST: MiCuenta/EditPassword/5
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        public ActionResult EditPassword(FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.password = collection["passwordNew"];
                cliente.opcion = 5;
                cliente.user = User.Identity.Name;
                clienteDatos.AbcCatCliente(cliente);
                return RedirectToAction("Index", "MiCuenta");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "MiCuenta");
            }
        }
        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        // GET: /MiCuenta/DetalleSolicitud/5
        public ActionResult DetalleSolicitud(string id)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.id_solicitud = id;
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.conexion = _conexion;
                cliente.id_metaTags = "C6E91C23-97BC-4C12-9D62-4E4737624F43";
                cliente.id_tipo = 1;
                cliente = clienteDatos.ObtenerConfigDetalleSolicitud(cliente);
                if (cliente.id_tipoSolicitud == 1)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlPaqueteCotizado(cliente.tablaDetalleSolicitud, cliente.tablaDetalleSolicitdHabitacion, cliente.tablaRedesSociales, cliente.tablaItinerario,cliente.TablaPaquetesPopulares,cliente.nombreCompleto,cliente.nombrePagina);
                }
                else if (cliente.id_tipoSolicitud == 2)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlToursCotizado(cliente.tablaDetalleSolicitud, cliente.tablaRedesSociales,cliente.TablaPaquetesPopulares,cliente.nombreCompleto,cliente.nombrePagina);
                }
                else if (cliente.id_tipoSolicitud == 3)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlHotelesCotizado(cliente.tablaDetalleSolicitud, cliente.tablaDetalleSolicitdHabitacion, cliente.tablaRedesSociales);
                }
                else if (cliente.id_tipoSolicitud == 4)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlTransportacionCotizado(cliente.tablaDetalleSolicitud, cliente.tablaRedesSociales,cliente.TablaPaquetesPopulares,cliente.nombre, cliente.nombrePagina,cliente.enlace);
                }
                else if (cliente.id_tipoSolicitud == 5)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlPaqueteVipCotizado(cliente.tablaDetalleSolicitud, cliente.tablaDetalleSolicitdHabitacion, cliente.tablaRedesSociales, cliente.tablaItinerario,cliente.TablaPaquetesPopulares,cliente.nombreCompleto);
                }
                return View(cliente);
            }
            catch(Exception ex)
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                cliente.tablaMetaTags = new DataTable();
                cliente.TablaPaquetesPopulares = new DataTable();
                cliente.TablaFormasDePago = new DataTable();
                return View(cliente);
            }
        }
        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        // GET: /MiCuenta/DeleteSolicitud/5
        public ActionResult DeleteSolicitud(string id)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos cliente_datos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.id_solicitud = id;
                cliente_datos.cancelacionSolicitud(cliente);
                return RedirectToAction("Index", "MiCuenta");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "MiCuenta");
            }
        }
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        //  POST: /MiCuenta/CambiarIdioma/6
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
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        //  POST: /MiCuenta/MatarSession/6
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
        //  GET: /MiCuenta/ResetPassword/
        [Autorizado]
        [HttpGet]
        public ActionResult ResetPassword()
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos cliente_datos = new ClienteDatos();
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.conexion = _conexion;
                cliente.id_metaTags = "012BF752-9AF3-49C6-ACD3-E756E44DCB81";
                cliente.id_tipo = 1;
                cliente = cliente_datos.ObtenerConfigResetPassword(cliente);
                return View(cliente);
            }
            catch
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                cliente.TablaFormasDePago = new DataTable();
                cliente.TablaPaquetesPopulares = new DataTable();
                return View(cliente);
            }
        }
        // POST: MiCuenta/ResetPassword/
        [Autorizado]
        [HttpPost]
        public ActionResult ResetPassword(FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente.email = collection["email"];
                clienteDatos.ResetPasswordCliente(cliente);
                if (cliente.activo == true)
                {
                    Comun.EnviarCorreo(
                    ConfigurationManager.AppSettings.Get("CorreoTxt")
                    , ConfigurationManager.AppSettings.Get("PasswordTxt")
                    , cliente.email
                    , "Reset Password"
                    , Comun.GenerarHtmlResetContraseñaPaginaWeb(cliente.email, cliente.password)
                    , false
                    , ""
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                    , ConfigurationManager.AppSettings.Get("HostTxt")
                    , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));

                    TempData["typemessage"] = "1";
                    TempData["message"] = "La Contraseña fue reseteada, Favor de revisar su correo.";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["typemessage"] = "2";
                    TempData["message"] = "No fue encontrado su correo electrónico";
                    cliente = new ClienteModels();
                    clienteDatos = new ClienteDatos();
                    cliente.idioma = Session["locale"] == null ? 1 : 2;
                    cliente.id_seccion = Session["idSeccion"].ToString();
                    cliente.conexion = _conexion;
                    cliente.id_metaTags = "012BF752-9AF3-49C6-ACD3-E756E44DCB81";
                    cliente.id_tipo = 1;
                    cliente = clienteDatos.ObtenerConfigResetPassword(cliente);
                    return View(cliente);
                }
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No fue encontrado su correo electrónico";
                ClienteModels cliente = new ClienteModels();
                ClienteDatos cliente_datos = new ClienteDatos();
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.conexion = _conexion;
                cliente.id_metaTags = "012BF752-9AF3-49C6-ACD3-E756E44DCB81";
                cliente.id_tipo = 1;
                cliente = cliente_datos.ObtenerConfigResetPassword(cliente);
                return View(cliente);
            }
        }
        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        // GET: /MiCuenta/CotizacionesSolicitud/5
        public ActionResult CotizacionesSolicitud(string id)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.id_solicitud = id;
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.conexion = _conexion;
                cliente.id_metaTags = "B6D0623D-075B-48CC-B72F-CF4A77794794";
                cliente.id_tipo = 1;
                cliente = clienteDatos.ObtenerConfigCotizacionesSolicitud(cliente);
                return View(cliente);
            }
            catch
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                cliente.tablaCotizaciones = new DataTable();
                cliente.tablaMetaTags = new DataTable();
                cliente.TablaPaquetesPopulares = new DataTable();
                cliente.TablaFormasDePago = new DataTable();
                return View(cliente);
            }
        }
        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        // GET: /MiCuenta/ComprarCotizacionesSolicitud/5&id2=5
        public ActionResult ComprarCotizacionesSolicitud(string id, string id2)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.id_solicitud = id;
                cliente.id_cotizacion = id2;
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.conexion = _conexion;
                cliente.id_metaTags = "6844477E-BF86-4C0A-A817-4AB4BF9A3A25";
                cliente.id_tipo = 1;
                cliente = clienteDatos.ObtenerConfigComprarCotizacionesSolicitud(cliente);
                cliente.anticipo = Convert.ToSingle(cliente.tablaDetalleSolicitud.Rows[0]["anticipo"]);
                return View(cliente);
            }
            catch
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                cliente.tablaDetalleSolicitud = new DataTable();
                cliente.TablaFormasDePago = new DataTable();
                cliente.TablaPaquetesPopulares = new DataTable();
                return View(cliente);
            }
        }
        [Autorizado]
        [AutorizadoPerfil]
        [HttpPost]
        public ActionResult ComprarCotizacionesSolicitud(FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente.idioma = Session["locale"] == null ? 1 : 2;
                cliente.id_seccion = Session["idSeccion"].ToString();
                cliente.id_cliente = Session["idCliente"].ToString();
                cliente.id_solicitud = collection["id_solicitud"];
                cliente.id_cotizacion = collection["id_cotizacion"];
                cliente.anticipo = Convert.ToSingle(collection["anticipo"].ToString());
                cliente = clienteDatos.ObtenerConfigTipoPagoComprarCotizacionesSolicitud(cliente);
                if (cliente.verificador == true)
                {
                    if (cliente.tablaFormaPago != null)
                    {
                        foreach (DataRow formaPago in cliente.tablaFormaPago.Rows)
                        {
                            try
                            {
                                if (collection["id_tipoPago" + formaPago["id_tipoPago"].ToString()] != null)
                                {
                                    cliente.id_tipoPago = formaPago["id_tipoPago"].ToString();
                                    cliente.URL = formaPago["URL"].ToString();
                                    cliente.id_pagoOnline = formaPago["id_pagoOnline"].ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    cliente = clienteDatos.VentaServicio(cliente);
                    if (!String.IsNullOrEmpty(cliente.id_venta))
                    {
                        if (cliente.id_tipoPago == "2")
                        {
                            cliente.opcion = 1;
                            cliente = clienteDatos.RegistrarPagoComprarCotizacionesSolicitudPaypal(cliente);
                            return Redirect(cliente.URL);
                        }
                        else
                        {
                            return RedirectToAction("Index", "TipoPagos", new { id = cliente.id_tipoPago });
                        }
                    }
                    else
                    {
                        cliente = new ClienteModels();
                        clienteDatos = new ClienteDatos();
                        cliente.id_solicitud = collection["id_solicitud"];
                        cliente.id_cotizacion = collection["id_cotizacion"];
                        cliente.idioma = Session["locale"] == null ? 1 : 2;
                        cliente.id_seccion = Session["idSeccion"].ToString();
                        cliente.id_cliente = Session["idCliente"].ToString();
                        cliente.conexion = _conexion;
                        cliente.id_metaTags = "6844477E-BF86-4C0A-A817-4AB4BF9A3A25";
                        cliente.id_tipo = 1;
                        cliente = clienteDatos.ObtenerConfigComprarCotizacionesSolicitud(cliente);
                        return View(cliente);
                    }
                }
                else
                {
                    cliente = new ClienteModels();
                    clienteDatos = new ClienteDatos();
                    cliente.id_solicitud = collection["id_solicitud"];
                    cliente.id_cotizacion = collection["id_cotizacion"];
                    cliente.idioma = Session["locale"] == null ? 1 : 2;
                    cliente.id_seccion = Session["idSeccion"].ToString();
                    cliente.id_cliente = Session["idCliente"].ToString();
                    cliente.conexion = _conexion;
                    cliente.id_metaTags = "6844477E-BF86-4C0A-A817-4AB4BF9A3A25";
                    cliente.id_tipo = 1;
                    cliente = clienteDatos.ObtenerConfigComprarCotizacionesSolicitud(cliente);
                    return View(cliente);
                }
            }
            catch (Exception)
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                cliente.tablaDetalleSolicitud = new DataTable();
                cliente.tablaMetaTags = new DataTable();
                return View(cliente);
            }
        }

        [Autorizado]
        [AutorizadoPerfil]
        [HttpGet]
        // GET: /MiCuenta/panelCorreo/4
        public ActionResult panelCorreo(string id)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.id_solicitud = id;
                cliente.conexion = _conexion;
                cliente = clienteDatos.ObtenerConfigpanelCorreo(cliente);
                if (cliente.id_tipoSolicitud == 1)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlPaqueteCotizado(cliente.tablaDetalleSolicitud, cliente.tablaDetalleSolicitdHabitacion, cliente.tablaRedesSociales, cliente.tablaItinerario,cliente.TablaPaquetesPopulares, cliente.nombreCompleto, cliente.nombrePagina);
                }
                else if (cliente.id_tipoSolicitud == 2)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlToursCotizado(cliente.tablaDetalleSolicitud, cliente.tablaRedesSociales,cliente.TablaPaquetesPopulares,cliente.nombreCompleto,cliente.nombrePagina);
                }
                else if (cliente.id_tipoSolicitud == 3)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlHotelesCotizado(cliente.tablaDetalleSolicitud, cliente.tablaDetalleSolicitdHabitacion, cliente.tablaRedesSociales);
                }
                else if (cliente.id_tipoSolicitud == 4)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlTransportacionCotizado(cliente.tablaDetalleSolicitud, cliente.tablaRedesSociales,cliente.TablaPaquetesPopulares,cliente.nombre,cliente.nombrePagina,cliente.enlace);
                }
                else if (cliente.id_tipoSolicitud == 5)
                {
                    cliente.htmlSolicitud = Comun.GenerarHtmlPaqueteVipCotizado(cliente.tablaDetalleSolicitud, cliente.tablaDetalleSolicitdHabitacion, cliente.tablaRedesSociales, cliente.tablaItinerario,cliente.TablaPaquetesPopulares,cliente.nombreCompleto);
                }
                return View(cliente);
            }
            catch
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaDatosGenerales = new DataTable();
                cliente.tablaArticulos = new DataTable();
                cliente.tablaCaracteristicasEmpresa = new DataTable();
                cliente.tablaSeccion = new DataTable();
                cliente.tablaSecciones = new DataTable();
                return View(cliente);
            }
        }
    }
}