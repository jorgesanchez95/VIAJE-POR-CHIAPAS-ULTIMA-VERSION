using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CatVehiculosModels
    {
        private string _id_vehiculo;

        public string id_vehiculo
        {
            get { return _id_vehiculo; }
            set { _id_vehiculo = value; }
        }
        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private string _descripcionIngles;

        public string descripcionIngles
        {
            get { return _descripcionIngles; }
            set { _descripcionIngles = value; }
        }
        private string _detalleIngles;

        public string detalleIngles
        {
            get { return _detalleIngles; }
            set { _detalleIngles = value; }
        }

        private string _placas;

        public string placas
        {
            get { return _placas; }
            set { _placas = value; }
        }
        private string _detalle;

        public string detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }
        private string _id_tipovehiculo;

        public string id_tipovehiculo
        {
            get { return _id_tipovehiculo; }
            set { _id_tipovehiculo = value; }
        }

       
        private string _combustible;

        public string combustible
        {
            get { return _combustible; }
            set { _combustible = value; }
        }
        private string _transmision;

        public string transmision
        {
            get { return _transmision; }
            set { _transmision = value; }
        }
        private int _numPersona;

        public int numPersona
        {
            get { return _numPersona; }
            set { _numPersona = value; }
        }
        private int _numPuerta;

        public int numPuerta
        {
            get { return _numPuerta; }
            set { _numPuerta = value; }
        }

        private string _nombre_pagina;
      
        public string nombre_pagina
        {
            get { return _nombre_pagina; }
            set { _nombre_pagina = value; }
        }

        private string _UrlImagen;

        public string UrlImagen
        {
            get { return _UrlImagen; }
            set { _UrlImagen = value; }
        }
        private string _title;

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _alt;

        public string alt
        {
            get { return _alt; }
            set { _alt = value; }
        }
        private string _nombre_arc;

        public string nombre_arc
        {
            get { return _nombre_arc; }
            set { _nombre_arc = value; }
        }
        private string _tipo_arc;

        public string tipo_arc
        {
            get { return _tipo_arc; }
            set { _tipo_arc = value; }
        }
        private List<TipoVehiculoModels> _tablaTipoVehiculoCmb;
        [Required(ErrorMessage = "Seccion es un campo requerido")]
        [Display(Name = "Sección")]
        public List<TipoVehiculoModels> tablaTipoVehiculoCmb
        {
            get { return _tablaTipoVehiculoCmb; }
            set { _tablaTipoVehiculoCmb = value; }
        }

        private DataTable  _TablaVehiculo;
       

        public DataTable  TablaVehiculo     
        {
            get { return _TablaVehiculo; }
            set { _TablaVehiculo = value; }
        }
        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
        private HttpPostedFileBase _foto;
        [Required(ErrorMessage = "La Imagen es obligatorio")]
        [Display(Name = "Imagen")]
        [FileExtensions(Extensions = "png,jpg,jpeg", ErrorMessage = "Solo imagenes")]
        public HttpPostedFileBase foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        private HttpPostedFileBase _foto2;
        [Display(Name = "Imagen")]
        [FileExtensions(Extensions = "png,jpg,jpeg", ErrorMessage = "Solo imagenes")]
        public HttpPostedFileBase foto2
        {
            get { return _foto2; }
            set { _foto2 = value; }
        }
    }
}