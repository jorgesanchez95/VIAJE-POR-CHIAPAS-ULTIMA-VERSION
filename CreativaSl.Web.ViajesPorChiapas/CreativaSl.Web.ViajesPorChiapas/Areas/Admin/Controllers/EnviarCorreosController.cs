using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Net.Mail;
using System.Drawing;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class EnviarCorreosController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        //
        //GET: /Admin/EnviarCorreos/Browse
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Browse(string id)
        {
            try
            {
                TempData["aux"] = id;
                return View();
            }
            catch (Exception)
            {
                TempData["aux"] = "0";
                return View();
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseUpload1
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUpload1()
        {
            try
            {
                if (HttpContext.Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = HttpContext.Request.Files;
                    foreach (string key in files)
                    {
                        HttpPostedFileBase file = files[key];
                        string fileName = file.FileName;
                        fileName = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads1/" + Path.GetFileName(fileName));
                        Stream s = file.InputStream;
                        Image img = new Bitmap(s);
                        img = Comun.ResizeImage(img, 150, 75);
                        img.Save(fileName);
                    }
                }
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.Write("File(s) uploaded successfully!");
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        //GET: /Admin/EnviarCorreos/BrowseUploadGetImageList1
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUploadGetImageList1()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads1/"));
                FileInfo[] filePaths = dir.GetFiles();
                String[] validExt = { ".png", ".jpg", ".jpeg" };

                string response = "{\"files\": [";
                int elements = 0;
                foreach (FileInfo filePath in filePaths)
                {
                    if (validExt.Contains(filePath.Extension))
                    {
                        response += "\"" + filePath.Name + "\",";
                        elements++;
                    }
                }

                if (elements > 0)
                    response = response.Remove(response.Length - 1);
                response += "]}";
                HttpContext.Response.Write(response);
                return View();
            }
            catch (Exception ex)
            {
                HttpContext.Response.Write("");
                return View();
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseDelete1
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseDelete1(FormCollection collection)
        {
            try
            {
                string file = collection["file"];
                string filePath = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads1/" + Path.GetFileName(file));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseUpload3
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUpload3()
        {
            try
            {
                if (HttpContext.Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = HttpContext.Request.Files;
                    foreach (string key in files)
                    {
                        HttpPostedFileBase file = files[key];
                        string fileName = file.FileName;
                        fileName = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads3/" + Path.GetFileName(fileName));
                        Stream s = file.InputStream;
                        Image img = new Bitmap(s);
                        img = Comun.ResizeImage(img, 800, 480);
                        img.Save(fileName);
                    }
                }
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.Write("File(s) uploaded successfully!");
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        //GET: /Admin/EnviarCorreos/BrowseUploadGetImageList3
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUploadGetImageList3()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads3/"));
                FileInfo[] filePaths = dir.GetFiles();
                String[] validExt = { ".png", ".jpg", ".jpeg" };

                string response = "{\"files\": [";
                int elements = 0;
                foreach (FileInfo filePath in filePaths)
                {
                    if (validExt.Contains(filePath.Extension))
                    {
                        response += "\"" + filePath.Name + "\",";
                        elements++;
                    }
                }

                if (elements > 0)
                    response = response.Remove(response.Length - 1);
                response += "]}";
                HttpContext.Response.Write(response);
                return View();
            }
            catch (Exception ex)
            {
                HttpContext.Response.Write("");
                return View();
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseDelete3
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseDelete3(FormCollection collection)
        {
            try
            {
                string file = collection["file"];
                string filePath = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads3/" + Path.GetFileName(file));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseUpload4
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUpload4()
        {
            try
            {
                if (HttpContext.Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = HttpContext.Request.Files;
                    foreach (string key in files)
                    {
                        HttpPostedFileBase file = files[key];
                        string fileName = file.FileName;
                        fileName = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads4/" + Path.GetFileName(fileName));
                        Stream s = file.InputStream;
                        Image img = new Bitmap(s);
                        img = Comun.ResizeImage(img, 400, 360);
                        img.Save(fileName);
                    }
                }
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.Write("File(s) uploaded successfully!");
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        //GET: /Admin/EnviarCorreos/BrowseUploadGetImageList4
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUploadGetImageList4()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads4/"));
                FileInfo[] filePaths = dir.GetFiles();
                String[] validExt = { ".png", ".jpg", ".jpeg" };

                string response = "{\"files\": [";
                int elements = 0;
                foreach (FileInfo filePath in filePaths)
                {
                    if (validExt.Contains(filePath.Extension))
                    {
                        response += "\"" + filePath.Name + "\",";
                        elements++;
                    }
                }

                if (elements > 0)
                    response = response.Remove(response.Length - 1);
                response += "]}";
                HttpContext.Response.Write(response);
                return View();
            }
            catch (Exception ex)
            {
                HttpContext.Response.Write("");
                return View();
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseDelete4
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseDelete4(FormCollection collection)
        {
            try
            {
                string file = collection["file"];
                string filePath = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads4/" + Path.GetFileName(file));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseUpload5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUpload5()
        {
            try
            {
                if (HttpContext.Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = HttpContext.Request.Files;
                    foreach (string key in files)
                    {
                        HttpPostedFileBase file = files[key];
                        string fileName = file.FileName;
                        fileName = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads5/" + Path.GetFileName(fileName));
                        Stream s = file.InputStream;
                        Image img = new Bitmap(s);
                        img = Comun.ResizeImage(img, 400, 360);
                        img.Save(fileName);
                    }
                }
                HttpContext.Response.ContentType = "text/plain";
                HttpContext.Response.Write("File(s) uploaded successfully!");
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        //GET: /Admin/EnviarCorreos/BrowseUploadGetImageList5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult BrowseUploadGetImageList5()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads5/"));
                FileInfo[] filePaths = dir.GetFiles();
                String[] validExt = { ".png", ".jpg", ".jpeg" };

                string response = "{\"files\": [";
                int elements = 0;
                foreach (FileInfo filePath in filePaths)
                {
                    if (validExt.Contains(filePath.Extension))
                    {
                        response += "\"" + filePath.Name + "\",";
                        elements++;
                    }
                }

                if (elements > 0)
                    response = response.Remove(response.Length - 1);
                response += "]}";
                HttpContext.Response.Write(response);
                return View();
            }
            catch (Exception ex)
            {
                HttpContext.Response.Write("");
                return View();
            }
        }
        //POST: /Admin/EnviarCorreos/BrowseDelete5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult BrowseDelete5(FormCollection collection)
        {
            try
            {
                string file = collection["file"];
                string filePath = HttpContext.Server.MapPath("/Content/Administrador/plugins/email/img/uploads5/" + Path.GetFileName(file));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        //GET: /Admin/EnviarCorreos/Index0
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente.tablaClientes2Cmb = clienteDatos.ObtenerComboClientesAll(cliente);
                var list = new SelectList(cliente.tablaClientes2Cmb, "id_cliente", "nombre");
                ViewData["cmbClientes2"] = list;

                cliente.tablaClientesSeleccionadosCmb = new List<ClienteModels>();
                var list2 = new SelectList(cliente.tablaClientesSeleccionadosCmb, "id_cliente", "nombre");
                ViewData["cmbClientesSeleccionados"] = list2;

                GrupoModels grupo = new GrupoModels();
                GrupoDatos grupoDatos = new GrupoDatos();
                grupo.conexion = _conexion;
                cliente.tablaGruposCmb = grupoDatos.ObtenerComboGrupos(grupo);
                list = new SelectList(cliente.tablaGruposCmb, "id_grupo", "nombreGrupo");
                ViewData["cmbGrupos"] = list;

                cliente.tablaClientesCmb = new List<ClienteModels>();
                list2 = new SelectList(cliente.tablaClientesCmb, "id_cliente", "nombre");
                ViewData["cmbClientes"] = list2;

                return View(cliente);
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        //
        //POST: Admin/EnviarCorreos/ObtenerClientesXGrupo/6
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult ObtenerClientesXGrupo(string id)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();

                List<ClienteModels> lstClientes = new List<ClienteModels>();
                cliente.id_grupo = id;
                cliente.conexion = _conexion;
                lstClientes = clienteDatos.ObtenerComboClientesxGrupo(cliente);
                return Json(lstClientes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        // POST: Admin/EnviarCorreos/EnviarAGrupo
        [HttpPost]
        [Authorize(Roles = "1")]
        [ValidateInput(false)]
        public ActionResult EnviarAGrupo(FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                cliente.asunto = collection["asunto"];
                cliente.email = collection["tablaClientesCmb"];
                cliente.html = collection["html"];

                string[] correo_clientes;
                if (!string.IsNullOrEmpty(cliente.email))
                {
                    if (cliente.email.Contains(","))
                    {
                        correo_clientes = cliente.email.Split(',');
                    }
                    else
                    {
                        correo_clientes = new string[] { cliente.email };
                    }
                }
                else
                {
                    correo_clientes = new string[] { string.Empty };
                }

                foreach (string correo in correo_clientes)
                {
                    Comun.EnviarCorreo(
                        ConfigurationManager.AppSettings.Get("CorreoTxt")
                       ,ConfigurationManager.AppSettings.Get("PasswordTxt")
                       ,correo
                       ,cliente.asunto
                       ,cliente.html
                       ,false
                       ,""
                       ,Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                       ,ConfigurationManager.AppSettings.Get("HostTxt")
                       ,Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                       ,Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                }

                TempData["typemessage"] = "1";
                TempData["message"] = "Mensaje enviados correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/EnviarCorreos/EnviarASeleccinados
        [HttpPost]
        [Authorize(Roles = "1")]
        [ValidateInput(false)]
        public ActionResult EnviarASeleccinados(FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                cliente.asunto = collection["asunto"];
                cliente.email = collection["tablaClientesSeleccionadosCmb"];
                cliente.html = collection["html"];

                string[] correo_clientes;
                if (!string.IsNullOrEmpty(cliente.email))
                {
                    if (cliente.email.Contains(","))
                    {
                        correo_clientes = cliente.email.Split(',');
                    }
                    else
                    {
                        correo_clientes = new string[] { cliente.email };
                    }
                }
                else
                {
                    correo_clientes = new string[] { string.Empty };
                }

                foreach (string correo in correo_clientes)
                {
                    Comun.EnviarCorreo(
                        ConfigurationManager.AppSettings.Get("CorreoTxt")
                       ,ConfigurationManager.AppSettings.Get("PasswordTxt")
                       ,correo
                       , cliente.asunto
                       ,cliente.html
                       ,false
                       ,""
                       ,Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                       ,ConfigurationManager.AppSettings.Get("HostTxt")
                       ,Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                       ,Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                }
                TempData["typemessage"] = "1";
                TempData["message"] = "Mensaje enviados correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
    }
}
