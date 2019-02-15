using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    [Compress]
    public class LoginController : Controller
    {
        int _verificador = 0;
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        
        // GET: /Login/
        [Autorizado]
        [HttpGet]
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["idCliente"] != null)
            {
                ClienteModels cliente = new ClienteModels();
                cliente.conexion = _conexion;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    ClienteModels cliente = new ClienteModels();
                    ClienteDatos usuariosDatos = new ClienteDatos();
                    cliente.idioma = Session["locale"] == null ? 1 : 2;
                    cliente.id_seccion = Session["idSeccion"].ToString();
                    cliente.conexion = _conexion;
                    cliente.id_metaTags = "DD040951-A99A-406A-9B2B-20FAABECF714";
                    cliente.id_tipo = 1;
                    cliente = usuariosDatos.ObtenerConfigLogin(cliente);
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
                    cliente.tablaMetaTags = new DataTable();
                    cliente.TablaPaquetesPopulares = new DataTable();
                    cliente.TablaFormasDePago = new DataTable();
                    return View(cliente);
                }
            }
        }

        //
        // POST: /Account/Index
        [HttpPost]
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index(ClienteModels model, string returnUrl)
        {
            LoginDatos UD = new LoginDatos();
            model.conexion = _conexion;
            model = UD.ValidarCliente(model);
            if (model.opcion == 1)
            {
                Session["idCliente"] = model.id_cliente;
                Session["nombreCliente"] = model.nombreCompleto;
                Session["Correo"] = model.email;
                return RedirectToAction("Index", "MiCuenta");
            }
            else if (model.opcion == 2)
            {
                ModelState.AddModelError("", "Usuario no existe");
                //Session.Abandon();
                //Session.Clear();
                //Session.RemoveAll();

                try
                {
                    ClienteDatos usuariosDatos = new ClienteDatos();
                    model.idioma = Session["locale"] == null ? 1 : 2;
                    model.id_seccion = Session["idSeccion"].ToString();
                    model.conexion = _conexion;
                    model.id_metaTags = "DD040951-A99A-406A-9B2B-20FAABECF714";
                    model.id_tipo = 1;
                    model = usuariosDatos.ObtenerConfigLogin(model);
                    return View(model);
                }
                catch
                {
                    model.tablaDatosGenerales = new DataTable();
                    model.tablaArticulos = new DataTable();
                    model.tablaCaracteristicasEmpresa = new DataTable();
                    model.tablaSeccion = new DataTable();
                    model.tablaSecciones = new DataTable();
                    model.tablaMetaTags = new DataTable();
                    return View(model);
                }
            }
            else if (model.opcion == 3)
            {
                ModelState.AddModelError("", "Error de Contraseña");
                //Session.Abandon();
                //Session.Clear();
                //Session.RemoveAll();

                try
                {
                    ClienteDatos usuariosDatos = new ClienteDatos();
                    model.idioma = Session["locale"] == null ? 1 : 2;
                    model.id_seccion = Session["idSeccion"].ToString();
                    model.conexion = _conexion;
                    model.id_metaTags = "DD040951-A99A-406A-9B2B-20FAABECF714";
                    model.id_tipo = 1;
                    model = usuariosDatos.ObtenerConfigLogin(model);
                    return View(model);
                }
                catch
                {
                    model.tablaDatosGenerales = new DataTable();
                    model.tablaArticulos = new DataTable();
                    model.tablaCaracteristicasEmpresa = new DataTable();
                    model.tablaSeccion = new DataTable();
                    model.tablaSecciones = new DataTable();
                    model.tablaMetaTags = new DataTable();
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "El usuario o contraseña son incorrectos!!.");
                //Session.Abandon();
                //Session.Clear();
                //Session.RemoveAll();
                try
                {
                    ClienteDatos usuariosDatos = new ClienteDatos();
                    model.idioma = Session["locale"] == null ? 1 : 2;
                    model.id_seccion = Session["idSeccion"].ToString();
                    model.conexion = _conexion;
                    model.id_metaTags = "DD040951-A99A-406A-9B2B-20FAABECF714";
                    model.id_tipo = 1;
                    model = usuariosDatos.ObtenerConfigLogin(model);
                    return View(model);
                }
                catch
                {
                    model.tablaDatosGenerales = new DataTable();
                    model.tablaArticulos = new DataTable();
                    model.tablaCaracteristicasEmpresa = new DataTable();
                    model.tablaSeccion = new DataTable();
                    model.tablaSecciones = new DataTable();
                    model.tablaMetaTags = new DataTable();
                    return View(model);
                }
            }
        }

        //  POST: Seccion/CambiarIdioma/6
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
        //  POST: Seccion/MatarSession/6
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
