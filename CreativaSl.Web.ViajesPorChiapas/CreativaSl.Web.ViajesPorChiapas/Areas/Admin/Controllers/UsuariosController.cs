using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using System.Web.UI;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class UsuariosController : Controller
    {
        string Conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        // GET: /Admin/Usuarios/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                UsuarioModels usuario = new UsuarioModels();
                UsuarioDatos usuarioDatos = new UsuarioDatos();
                usuario.conexion = Conexion;
                usuario = usuarioDatos.ObtenerUsuarios(usuario);
                return View(usuario);
            }
            catch (Exception)
            {
                UsuarioModels usuario = new UsuarioModels();
                usuario.tablaUsuario = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(usuario);
            }
        }
        // GET: Admin/Usuarios/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create(string id)
        {
            try
            {
                UsuarioModels usuario = new UsuarioModels();
                UsuarioDatos usuarioDatos = new UsuarioDatos();
                usuario.conexion = Conexion;
                usuario.opcion = 1;
                usuario.id_usuario = id;
                usuario.tablaTipoUsuariosCmb = usuarioDatos.ObtenerComboTipoUsuario(usuario);
                usuario.fechaNac = DateTime.Now;
                usuario.password = Guid.NewGuid().ToString().Substring(0, 5);
                var list = new SelectList(usuario.tablaTipoUsuariosCmb, "id_tipoUsuario", "tipoUsuario");
                ViewData["cmbTipoUsuario"] = list;
                return View(usuario);
            }
            catch (Exception)
            {
                UsuarioModels usuario = new UsuarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Usuarios/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                UsuarioModels usuario = new UsuarioModels();
                UsuarioDatos usuarioDatos = new UsuarioDatos();
                usuario.conexion = Conexion;
                usuario.nombre = collection["nombre"];
                usuario.apPat = collection["apPat"];
                usuario.apMat = collection["apMat"];
                usuario.fechaNac = DateTime.ParseExact(collection["fechaNac"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                usuario.direccion = collection["direccion"];
                usuario.telefono = collection["telefono"];
                usuario.email = collection["email"];
                usuario.id_tipoUsuario = Convert.ToInt32(collection["tablaTipoUsuariosCmb"]);
                usuario.cuenta = collection["cuenta"];
                usuario.codigoPostal = "";
                usuario.password = collection["password"];
                usuario.url_foto = "~/Imagenes/default.png";
                usuario.opcion = 1;
                usuario.user = User.Identity.Name;

                usuario.tipoArchivo = "";
                usuario.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                usuario.alt = collection["alt"];
                usuario.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                usuario = usuarioDatos.AbcCatUsuarios(usuario);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Usuarios/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = usuario.nombreArchivo + fileExtension;

                    usuario.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    usuario.url_foto = "~/Imagenes/Usuarios/" + fileName;
                    usuario.opcion = 4;
                    usuarioDatos.AbcCatUsuarios(usuario);
                }
                Comun.EnviarCorreo(
                     ConfigurationManager.AppSettings.Get("CorreoTxt")
                    , ConfigurationManager.AppSettings.Get("PasswordTxt")
                    , usuario.email
                    , "Registro Usuario Viajes Por Chiapas"
                    , Comun.GenerarHtmlRegistoUsuario(usuario.cuenta, usuario.password)
                    , false
                    , ""
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                    , ConfigurationManager.AppSettings.Get("HostTxt")
                    , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                    , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                TempData["typemessage"] = "1";
                TempData["message"] = "Usuario sea creado correctamente";
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Usuarios/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                UsuarioModels usuario = new UsuarioModels();
                UsuarioDatos usuarioDatos = new UsuarioDatos();
                usuario.conexion = Conexion;
                usuario.opcion = 1;
                usuario.id_usuario = id;
                usuario = usuarioDatos.ObtenerDetalleUsuarioxID(usuario);
                usuario.tablaTipoUsuariosCmb = usuarioDatos.ObtenerComboTipoUsuario(usuario);
                var list = new SelectList(usuario.tablaTipoUsuariosCmb, "id_tipoUsuario", "tipoUsuario");
                ViewData["cmbTipoUsuario"] = list;
                return View(usuario);
            }
            catch (Exception)
            {
                UsuarioModels usuario = new UsuarioModels();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Usuarios/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                UsuarioModels usuario = new UsuarioModels();
                UsuarioDatos usuarioDatos = new UsuarioDatos();
                usuario.conexion = Conexion;
                usuario.id_usuario = collection["id_usuario"];
                usuario.nombre = collection["nombre"];
                usuario.apPat = collection["apPat"];
                usuario.apMat = collection["apMat"];
                usuario.fechaNac = DateTime.ParseExact(collection["fechaNac"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                usuario.direccion = collection["direccion"];
                usuario.telefono = collection["telefono"];
                usuario.email = collection["email"];
                usuario.id_tipoUsuario = Convert.ToInt32(collection["tablaTipoUsuariosCmb"]);
                usuario.cuenta = collection["cuenta"];
                usuario.codigoPostal = "";
                if (!collection["password"].ToString().Equals("dc89sd989sdd"))
                    usuario.password = collection["password"];
                else
                    usuario.password = "";
                usuario.url_foto = "~/Imagenes/default.png";
                usuario.opcion = 2;
                usuario.user = User.Identity.Name;

                usuario.tipoArchivo = "";
                usuario.nombreArchivo = Comun.RemoverAcentos(collection["nombreArchivo"]);
                usuario.alt = collection["alt"];
                usuario.title = collection["title"];

                HttpPostedFileBase bannerImage = Request.Files[0] as HttpPostedFileBase;
                usuarioDatos.AbcCatUsuarios(usuario);
                if (bannerImage != null && bannerImage.ContentLength > 0)
                {
                    string baseDir = Server.MapPath("~/Imagenes/Usuarios/");
                    string fileExtension = Path.GetExtension(bannerImage.FileName);
                    string fileName = usuario.nombreArchivo + fileExtension;

                    usuario.tipoArchivo = fileExtension;

                    Stream s = bannerImage.InputStream;
                    Image img = new Bitmap(s);
                    img = Comun.ResizeImage(img, 1250, 800);
                    img.Save(baseDir + fileName);
                    usuario.url_foto = "~/Imagenes/Usuarios/" + fileName;
                    usuario.opcion = 4;
                    usuarioDatos.AbcCatUsuarios(usuario);
                }
                else
                {
                    usuario.url_foto = collection["url_foto"];

                    string baseDir = Server.MapPath("~/Imagenes/Usuarios/");
                    string fileExtension = Path.GetExtension(usuario.url_foto);
                    string fileName = usuario.nombreArchivo + fileExtension;

                    string rutaold = Server.MapPath("~") + usuario.url_foto.Replace("/", "\\").Replace("~", "");
                    string rutanew = Server.MapPath("~") + Convert.ToString("~/Imagenes/Usuarios/" + fileName).Replace("/", "\\").Replace("~", "");
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
                    usuario.url_foto = "~/Imagenes/Usuarios/" + fileName;
                    usuario.tipoArchivo = fileExtension;
                    usuario.opcion = 4;
                    usuarioDatos.AbcCatUsuarios(usuario);
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "Usuario se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Usuarios/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Usuarios/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                UsuarioModels usuario = new UsuarioModels();
                UsuarioDatos usuarioDatos = new UsuarioDatos();
                usuario.conexion = Conexion;
                usuario.id_usuario = id;
                usuario.opcion = 3;
                usuario.user = User.Identity.Name;
                usuarioDatos.AbcCatUsuarios(usuario);
                TempData["typemessage"] = "1";
                TempData["message"] = "Usuario se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckNameToursAvailability(string nombreArchivo)
        {
            UsuarioModels Usuario = new UsuarioModels();
            UsuarioDatos UsuarioDatos = new UsuarioDatos();
            Usuario.conexion = Conexion;
            Usuario.nombreArchivo = nombreArchivo;
            return Json(UsuarioDatos.CheckUsuarioArchivoNameUsuario(Usuario), JsonRequestBehavior.AllowGet);
        }
    }
}
