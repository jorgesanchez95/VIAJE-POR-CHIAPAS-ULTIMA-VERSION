using CreativaSl.Web.ViajesPorChiapas.Filters;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace CreativaSl.Web.ViajesPorChiapas.Controllers
{
    [Compress]
    public class SitemapController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");

        [OutputCache(Duration = 120, VaryByParam = "none")]
        public ActionResult Index()
        {
            var Website = "http://www.viajeporchiapas.com";
            var SitemapItems = new List<SitemapItem>();
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/",
                Priority = "1",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/paquetes",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/tours",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/transportacion",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            //SitemapItems.Add(new SitemapItem
            //{
            //    URL = Website + "/hoteles",
            //    Priority = "0.80",
            //    ChangeFreq = "monthly",
            //    DateAdded = new DateTime(2017, 1, 1)
            //});
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/galerias",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            //SitemapItems.Add(new SitemapItem
            //{
            //    URL = Website + "/conocenos",
            //    Priority = "0.80",
            //    ChangeFreq = "monthly",
            //    DateAdded = new DateTime(2017, 1, 1)
            //});
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/contactanos",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/blog",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/login",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/recomendaciones",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });
            SitemapItems.Add(new SitemapItem
            {
                URL = Website + "/promociones",
                Priority = "0.80",
                ChangeFreq = "monthly",
                DateAdded = new DateTime(2017, 1, 1)
            });

            Sitemap_Datos sitemap_datos = new Sitemap_Datos();
            DataSet datos = sitemap_datos.ObtenerListaUrl(_conexion);

            if (datos != null)
            {
                foreach (DataRow paquetes in datos.Tables[0].Rows)
                {
                    SitemapItems.Add(new SitemapItem
                    {
                        URL = Website + "/paquetes/detallepaquete/" + paquetes["nombre_pagina"].ToString(),
                        Priority = "0.70",
                        ChangeFreq = "monthly",
                        DateAdded = new DateTime(2017, 1, 1)
                    });

                    SitemapItems.Add(new SitemapItem
                    {
                        URL = Website + "/paquetes/cotizar/" + paquetes["nombre_pagina"].ToString(),
                        Priority = "0.70",
                        ChangeFreq = "monthly",
                        DateAdded = new DateTime(2017, 1, 1)
                    });
                }

                foreach (DataRow tours in datos.Tables[1].Rows)
                {
                    SitemapItems.Add(new SitemapItem
                    {
                        URL = Website + "/tours/detalletour/" + tours["nombre_pagina"].ToString(),
                        Priority = "0.70",
                        ChangeFreq = "monthly",
                        DateAdded = new DateTime(2017, 1, 1)
                    });

                    SitemapItems.Add(new SitemapItem
                    {
                        URL = Website + "/tours/cotizar/" + tours["nombre_pagina"].ToString(),
                        Priority = "0.70",
                        ChangeFreq = "monthly",
                        DateAdded = new DateTime(2017, 1, 1)
                    });
                }

                //foreach (DataRow hotel in datos.Tables[2].Rows)
                //{
                //    SitemapItems.Add(new SitemapItem
                //    {
                //        URL = Website + "/hoteles/cotizar/" + hotel["nombre_pagina"].ToString(),
                //        Priority = "0.70",
                //        ChangeFreq = "monthly",
                //        DateAdded = new DateTime(2017, 1, 1)
                //    });
                //}

                foreach (DataRow blog in datos.Tables[3].Rows)
                {
                    SitemapItems.Add(new SitemapItem
                    {
                        URL = Website + "/blog/detallearticulo/" + blog["nombre_pagina"].ToString(),
                        Priority = "0.70",
                        ChangeFreq = "monthly",
                        DateAdded = new DateTime(2017, 1, 1)
                    });
                }

                foreach (DataRow imagen in datos.Tables[4].Rows)
                {
                    SitemapItems.Add(new SitemapItem
                    {
                        URL = Website + imagen["pathimg"].ToString().ToLower().Replace("~", ""),
                        Priority = "0.50",
                        ChangeFreq = "monthly",
                        DateAdded = new DateTime(2017, 1, 1)
                    });
                }
            }

            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapItem sitemapNode in SitemapItems)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.URL)),
                    sitemapNode.DateAdded == null ? null : new XElement(xmlns + "lastmod", sitemapNode.DateAdded.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                        new XElement(xmlns + "changefreq", "daily"),
                    sitemapNode.Priority == null ? null : new XElement(xmlns + "priority", sitemapNode.Priority));
                root.Add(urlElement);
            }

            var document = new XDocument(root);

            return new XmlActionResult(document);
        }
    }
    public sealed class XmlActionResult : ActionResult
    {
        private readonly XDocument _document;

        public Formatting Formatting { get; set; }
        public string MimeType { get; set; }

        public XmlActionResult(XDocument document)
        {
            if (document == null)
                throw new ArgumentNullException("document");

            _document = document;

            // Default values
            MimeType = "text/xml";
            Formatting = Formatting.None;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = MimeType;

            using (var writer = new XmlTextWriter(context.HttpContext.Response.OutputStream, Encoding.UTF8) { Formatting = Formatting })
                _document.WriteTo(writer);
        }
    }
}