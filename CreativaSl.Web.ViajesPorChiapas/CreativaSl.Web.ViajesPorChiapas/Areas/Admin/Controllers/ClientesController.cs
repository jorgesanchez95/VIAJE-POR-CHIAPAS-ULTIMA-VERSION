using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web.Mvc;
using CreativaSl.Web.ViajesPorChiapas.Models;

namespace CreativaSl.Web.ViajesPorChiapas.Areas.Admin.Controllers
{
    public class ClientesController : Controller
    {
        string _conexion = ConfigurationManager.AppSettings.Get("strConnection");
        // GET: /Admin/Clientes/
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente = clienteDatos.ObtenerListaClientes(cliente);
                return View(cliente);
            }
            catch (Exception)
            {
                ClienteModels cliente = new ClienteModels();
                cliente.tablaClientes = new DataTable();
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return View(cliente);
            }
        }
        // GET: Admin/Clientes/Create
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Create()
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
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
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Clientes/Create
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente.nombre = collection["nombre"];
                cliente.apPat = collection["apPat"];
                cliente.apMat = collection["apMat"];
                cliente.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                cliente.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                cliente.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                cliente.id_genero = Convert.ToInt32(collection["tablaGeneroCmb"]);
                cliente.id_ocupacion = Convert.ToInt32(collection["tablaOcupacionesCmb"]);
                cliente.curp = collection["curp"];
                cliente.telefono = collection["telefono"];
                cliente.fechaNac = DateTime.ParseExact(collection["fechaNac"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cliente.password = collection["password"];
                cliente.colonia = collection["colonia"];
                cliente.email = collection["email"];
                cliente.opcion = 1;
                cliente.user = User.Identity.Name;
                cliente = clienteDatos.AbcCatCliente(cliente);

                TempData["typemessage"] = "1";
                TempData["message"] = "El cliente se creo correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guardar correctamente";
                return RedirectToAction("Index");
            }
        }
        // GET: Admin/Clientes/Edit/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();

                cliente.conexion = _conexion;
                cliente.id_cliente = id;
                cliente = clienteDatos.ObtenerDetalleClientexId(cliente);

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
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede cargar la vista";
                return RedirectToAction("Index");
            }
        }
        // POST: Admin/Clientes/Edit/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();

                cliente.conexion = _conexion;
                cliente.id_cliente = id;
                cliente.nombre = collection["nombre"];
                cliente.apPat = collection["apPat"];
                cliente.apMat = collection["apMat"];
                cliente.id_pais = Convert.ToInt32(collection["tablaPaisesCmb"]);
                cliente.id_estado = Convert.ToInt32(collection["tablaEstadosCmb"]);
                cliente.id_municipio = Convert.ToInt32(collection["tablaMunicipiosCmb"]);
                cliente.id_genero = Convert.ToInt32(collection["tablaGeneroCmb"]);
                cliente.id_ocupacion = Convert.ToInt32(collection["tablaOcupacionesCmb"]);
                cliente.curp = collection["curp"];
                cliente.telefono = collection["telefono"];
                cliente.fechaNac = DateTime.ParseExact(collection["fechaNac"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                cliente.password = collection["password"];
                cliente.colonia = collection["colonia"];
                cliente.email = collection["email"];
                cliente.opcion = 2;
                cliente.user = User.Identity.Name;
                cliente = clienteDatos.AbcCatCliente(cliente);


                TempData["typemessage"] = "1";
                TempData["message"] = "El cliente se edito correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["typemessage"] = "2";
                TempData["message"] = "No se puede guradar correctamente";
                return RedirectToAction("Index");
            }
        }
        //  POST: Admin/Cliente/Municipio/6
        [HttpPost]
        [Authorize(Roles = "1")]
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
        // GET: Admin/Clientes/Delete/5
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id)
        {
            return View();
        }
        // POST: Admin/Clientes/Delete/5
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                ClienteModels cliente = new ClienteModels();
                ClienteDatos clienteDatos = new ClienteDatos();
                cliente.conexion = _conexion;
                cliente.id_cliente = id;
                cliente.opcion = 3;
                cliente.user = User.Identity.Name;
                clienteDatos.AbcCatCliente(cliente);
                TempData["typemessage"] = "1";
                TempData["message"] = "El cliente se elimino correctamente";
                return Json("");
            }
            catch
            {
                return View();
            }
        }
    }
}
