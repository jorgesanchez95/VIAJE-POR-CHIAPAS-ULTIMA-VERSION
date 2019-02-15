using CreativaSl.Web.ViajesPorChiapas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class TestimonialesController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: Admin/Testimoniales
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                TestimonialesModels testimoniales = new TestimonialesModels();
                _Testimoniales_Datos testimonialesDatos = new _Testimoniales_Datos();
                testimoniales.conexion = _conexion;
                testimoniales = testimonialesDatos.ObtenerListaTestimoniales(testimoniales);
                return View(testimoniales);
            }
            catch (Exception)
            {
                TestimonialesModels testimoniales = new TestimonialesModels();
                testimoniales.TablaTestimoniales = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(testimoniales);
            }
        }

                [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult MostrarComentario(string id)
        {
            try
            {
                TestimonialesModels testimoniales = new TestimonialesModels();
                _Testimoniales_Datos testimonialesDatos = new _Testimoniales_Datos();



                testimoniales.conexion = _conexion;



                testimoniales.conexion = _conexion;
                testimoniales.id_testimoniales = id;
                testimoniales = testimonialesDatos.ObtenerDetalleComentarioTestimoniales(testimoniales);
                return View(testimoniales);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
       
        // POST: Admin/CaracteristicaEmpresa/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TestimonialesModels testimoniales = new TestimonialesModels();
                _Testimoniales_Datos testimonialesDatos = new _Testimoniales_Datos();

                testimoniales.conexion = _conexion;
                testimoniales.nombre = collection["nombre"];
                testimoniales.comentario = collection["comentario"];
                testimoniales.urlimagen = "~/Imagenes/default.png";
                testimoniales.opcion = 1;
                testimoniales.user = User.Identity.Name;

               

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                testimoniales = testimonialesDatos.AbcTestimoniales(testimoniales);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Testimoniales/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    testimoniales.nombresa = Comun.RemoverSignosAcentos(collection["nombre"]);
                    string fileName = testimoniales.nombresa + fileExtension;

                    testimoniales.tipo_arc = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    testimoniales.urlimagen = "~/Imagenes/Testimoniales/" + fileName;
                    testimoniales.opcion = 4;
                    testimonialesDatos.AbcTestimoniales(testimoniales);
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "Caracteristica se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CatTipoGaleria/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult ActivarComentario(string id, string id2)
        {
            return View();
        }
        // POST: Admin/CatTipoGaleria/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult ActivarComentario(string id, string id2, FormCollection collection)
        {
            try
            {
                TestimonialesModels testimoniales = new TestimonialesModels();
                _Testimoniales_Datos testimonialesDatos = new _Testimoniales_Datos();

                testimoniales.conexion = _conexion;
                testimoniales.id_testimoniales = id;
                var estado = false;
                bool.TryParse(id2, out estado); 
                testimoniales.webver = estado;
                testimoniales.opcion = 2;
                testimoniales.user = User.Identity.Name;
                testimonialesDatos.AbcTestimoniales(testimoniales);

                TempData["typemessage"] = "1";
                TempData["message"] = "El estado del comentario se ha cambiado correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/CatTipoGaleria/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                TestimonialesModels testimoniales = new TestimonialesModels();
                _Testimoniales_Datos testimonialesDatos = new _Testimoniales_Datos();

                testimoniales.conexion = _conexion;
                testimoniales.id_testimoniales = id;
                testimoniales.opcion = 3;
                testimoniales.user = User.Identity.Name;
                testimonialesDatos.AbcTestimoniales(testimoniales);

                TempData["typemessage"] = "1";
                TempData["message"] = "El comentario se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}