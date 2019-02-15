using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Web.UI;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class DepositosTransferenciaController : Controller
    {
        readonly string _conexion = ConfigurationManager.AppSettings.Get("strConnection");

        //
        // GET: /Admin/DepositosTransferencia/

        public ActionResult Index()
        {
            try
            {
                TipoPagosDetalleModels tipoPagosDetalle = new TipoPagosDetalleModels();
                TipoPagosDetalleDatos tipoPagosDetalleDatos = new TipoPagosDetalleDatos();
                tipoPagosDetalle.conexion = _conexion;
                tipoPagosDetalle = tipoPagosDetalleDatos.ObtenerListaTipoPagosDetalle(tipoPagosDetalle);
                return View(tipoPagosDetalle);
            }
            catch (Exception)
            {
                TipoPagosDetalleModels tipoPagosDetalle = new TipoPagosDetalleModels();
                tipoPagosDetalle.tablaCatTipoPagosDetalle = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(tipoPagosDetalle);
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
        public ActionResult ActivarFormadePago(string id, string id2, FormCollection collection)
        {
            try
            {
                TipoPagosDetalleModels tipoPagosDetalle = new TipoPagosDetalleModels();
                TipoPagosDetalleDatos tipoPagosDetalleDatos = new TipoPagosDetalleDatos();

                tipoPagosDetalle.conexion = _conexion;
                tipoPagosDetalle.idDepositosTransferencia = id;
                var estado = false;
                bool.TryParse(id2, out estado);
                tipoPagosDetalle.estado = estado;
                tipoPagosDetalle.opcion = 5;
                tipoPagosDetalle.user = User.Identity.Name;
                tipoPagosDetalleDatos.AbcCatTipoPagosDetalle(tipoPagosDetalle);

                TempData["typemessage"] = "1";
                TempData["message"] = "El estado del comentario se ha cambiado correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Usuarios/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                TipoPagosDetalleModels tipoPagosDetalle = new TipoPagosDetalleModels();
                TipoPagosDetalleDatos tipoPagosDetalleDatos = new TipoPagosDetalleDatos();
                tipoPagosDetalle.conexion = _conexion;
                tipoPagosDetalle.idDepositosTransferencia = id;
                tipoPagosDetalle = tipoPagosDetalleDatos.ObtenerDetalleTipoPagosDetallexId(tipoPagosDetalle);

                tipoPagosDetalle.tablaTipoPagoCmb = tipoPagosDetalleDatos.ObtenerComboTipoPago(tipoPagosDetalle);
                var list = new SelectList(tipoPagosDetalle.tablaTipoPagoCmb, "id_tipoPago", "tipoPago");
                ViewData["cmbTipoPago"] = list;
                return View(tipoPagosDetalle);

            }
            catch (Exception)
            {
                UsuarioModels usuario = new UsuarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Galeria/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                TipoPagosDetalleModels tipoPagosDetalle = new TipoPagosDetalleModels();
                TipoPagosDetalleDatos tipoPagosDetalleDatos = new TipoPagosDetalleDatos();
                tipoPagosDetalle.conexion = _conexion;
                tipoPagosDetalle.idDepositosTransferencia = collection["idDepositosTransferencia"];
                tipoPagosDetalle.id_tipoPago = Convert.ToInt32(collection["tablaTipoPagoCmb"]);
                tipoPagosDetalle.titular = collection["titular"];
                tipoPagosDetalle.banco = collection["banco"];
                tipoPagosDetalle.numeroReferencia = collection["numeroReferencia"];

                tipoPagosDetalle.pathDepositosTransferencia = "~/Imagenes/default.png";
                tipoPagosDetalle.opcion = 2;
                tipoPagosDetalle.user = User.Identity.Name;
                if (tipoPagosDetalle.id_tipoPago != 2)
                {
                    if (collection["activo"].Contains("true") == true)
                        tipoPagosDetalle.activo = true;
                    else
                        tipoPagosDetalle.activo = false;
                }
                else
                    tipoPagosDetalle.activo = true;

                tipoPagosDetalle.tipoArchivo = "";
                tipoPagosDetalle.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                tipoPagosDetalle.alt = collection["alt"];
                tipoPagosDetalle.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                tipoPagosDetalle = tipoPagosDetalleDatos.AbcCatTipoPagosDetalle(tipoPagosDetalle);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/DepositosTransferencia/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = tipoPagosDetalle.nombreArchivo + fileExtension;

                    tipoPagosDetalle.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 500);
                    img.Save(baseDir + fileName);
                    tipoPagosDetalle.pathDepositosTransferencia = "~/Imagenes/DepositosTransferencia/" + fileName;
                    tipoPagosDetalle.opcion = 4;
                    tipoPagosDetalleDatos.AbcCatTipoPagosDetalle(tipoPagosDetalle);
                }
                else
                {
                    tipoPagosDetalle.pathDepositosTransferencia = collection["pathDepositosTransferencia"];

                    string baseDir = Server.MapPath("~/Imagenes/DepositosTransferencia/");
                    string fileExtension = Path.GetExtension(tipoPagosDetalle.pathDepositosTransferencia);
                    string fileName = tipoPagosDetalle.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + tipoPagosDetalle.pathDepositosTransferencia.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/DepositosTransferencia/" + fileName).Replace("/", "\\").Replace("~", "");
                    if (rutaold != rutanew)
                    {
                        try
                        {
                            System.IO.File.Copy(rutaold, rutanew, true);
                        }
                        catch (Exception ex)
                        {
                        }
                        try
                        {
                            if (System.IO.File.Exists(rutaold))
                                System.IO.File.Delete(rutaold);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    tipoPagosDetalle.pathDepositosTransferencia = "~/Imagenes/DepositosTransferencia/" + fileName;
                    tipoPagosDetalle.tipoArchivo = fileExtension;
                    tipoPagosDetalle.opcion = 4;
                    tipoPagosDetalleDatos.AbcCatTipoPagosDetalle(tipoPagosDetalle);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "DepositoTransferencia se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameDepositoTransAvailability(string nombreArchivo)
        {
            TipoPagosDetalleModels Pagos = new TipoPagosDetalleModels();
            TipoPagosDetalleDatos TipoPagos = new TipoPagosDetalleDatos();
            Pagos.conexion = _conexion;
            Pagos.nombreArchivo = nombreArchivo;
            return Json(TipoPagos.CheckDepositoTransNameDepositoTrans(Pagos), JsonRequestBehavior.AllowGet);
        }
    }
}
