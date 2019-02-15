using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
using CreativaSl.Web.ViajesPorChiapas.Resources;
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
    public class BusquedaController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        Localizate locale = new Localizate();
        // GET: Busqueda
        public ActionResult Index(string id, int idLugars, string current, string idTags, string id_seccion)
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
                string[] idPaisEstado = id.Split(',');
                paquetes.id_pais = Convert.ToInt32(idPaisEstado[0]);
                paquetes.id_estado = Convert.ToInt32(idPaisEstado[1]);
                paquetes.modalidad = idLugars;
                paquetes = paquetesDatos.ObtenerConfigPaqueteBusqueda(paquetes);
                return View(paquetes);
            }
            catch
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
                paquetes.TablaFormasDePago = new DataTable();
                paquetes.TablaPaquetesPopulares = new DataTable();
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
    }
}