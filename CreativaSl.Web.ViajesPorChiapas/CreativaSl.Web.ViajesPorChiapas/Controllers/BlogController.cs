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
    public class BlogController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Blog
        [HttpGet]
        [Autorizado]
        public ActionResult Index(string current, string idTags, string query)
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                ArticulosDatos articulosDatos = new ArticulosDatos();

                if (query == null)
                {
                    articulos.opcion = 1;
                }
                if (query != null)
                {
                    articulos.opcion = 2;
                    articulos.aBuscar = query;
                }

                try
                {
                    articulos.current = Convert.ToInt32(current);
                    if (articulos.current <= 0)
                    {
                        articulos.current = 1;
                        articulos.offset = 0;
                    }
                    else
                    {
                        articulos.offset = (articulos.current - 1) * articulos.fetchNext;
                    }

                }
                catch (Exception)
                {
                    articulos.current = 1;
                    articulos.offset = 0;
                }

                if (idTags == "0")
                {
                    idTags = "";
                }

                if (idTags != "")
                {
                    articulos.id_tags = idTags;
                }

                articulos.idioma = Session["locale"] == null ? 1 : 2;
                articulos.id_seccion = Session["idSeccion"].ToString();
                articulos.conexion = _conexion;
                articulos.id_metaTags = "5CA3A39C-6F8F-4A14-B6E6-9635B848C032";
                articulos.id_tipo = 1;
                articulos = articulosDatos.ObtenerConfigBlog(articulos);
                return View(articulos);
            }
            catch
            {
                ArticulosModels articulos = new ArticulosModels();
                articulos.tablaDatosGenerales = new DataTable();
                articulos.tablaCaracteristicasEmpresa = new DataTable();
                articulos.tablaArticulos = new DataTable();
                articulos.tablaArticulo = new DataTable();
                articulos.tablaArticulosPopulares = new DataTable();
                articulos.tablaTags = new DataTable();
                articulos.tablaSeccion = new DataTable();
                articulos.tablaSecciones = new DataTable();
                articulos.tablaMetaTags = new DataTable();
                articulos.numeroArticulos = 0;
                articulos.TablaPaquetesPopulares = new DataTable();
                articulos.TablaFormasDePago = new DataTable();
                return View(articulos);
            }
        }
        // GET: Blog/DetalleArticulo/5
        [HttpGet]
        [Autorizado]
        public ActionResult DetalleArticulo(string id)
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                ArticulosDatos articulosDatos = new ArticulosDatos();
                articulos.idioma = Session["locale"] == null ? 1 : 2;
                articulos.id_seccion = Session["idSeccion"].ToString();
                articulos.conexion = _conexion;
                articulos.nombre_pagina = id;
                articulos.id_tipo = 2;
                articulos = articulosDatos.ObtenerConfigDetalleArticulo(articulos);
                articulos.visitas = Convert.ToInt32(articulos.tablaArticulo.Rows[0]["visitas"]) + 1;
                articulos.id_post = id;
                articulos.opcion = 5;
                articulos = articulosDatos.AbcArticulos(articulos);
                return View(articulos);
            }
            catch
            {
                ArticulosModels articulos = new ArticulosModels();
                articulos.tablaDatosGenerales = new DataTable();
                articulos.tablaCaracteristicasEmpresa = new DataTable();
                articulos.tablaArticulos = new DataTable();
                articulos.tablaArticulo = new DataTable();
                articulos.tablaArticulosPopulares = new DataTable();
                articulos.tablaTags = new DataTable();
                articulos.tablaSeccion = new DataTable();
                articulos.tablaSecciones = new DataTable();
                articulos.tablaMetaTags = new DataTable();
                articulos.TablaFormasDePago = new DataTable();
                articulos.TablaPaquetesPopulares = new DataTable();
                return View(articulos);
            }
        }
        // POST: Blog/CambiarIdeoma/a
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
        // POTS: Blog/MatarSession/5
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
        public ActionResult Buscar(FormCollection collection)
        {
            try
            {
                ArticulosModels articulos = new ArticulosModels();
                articulos.aBuscar = collection["aBuscar"];
                articulos.current = 0;
                articulos.id_tags = "0";

                return RedirectToAction("Index", new { current = articulos.current, idTags = articulos.id_tags, query = articulos.aBuscar });
            }
            catch
            {
                ArticulosModels articulos = new ArticulosModels();
                return RedirectToAction("Index", new { current = articulos.current, idTags = articulos.id_tags, query = articulos.aBuscar });
            }
        }
    }
}