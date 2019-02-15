using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TestimonialesModels
    {
        private string _id_testimoniales;

        public string id_testimoniales
        {
            get { return _id_testimoniales; }
            set { _id_testimoniales = value; }
        }
        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _nombresa;

        public string nombresa
        {
            get { return _nombresa; }
            set { _nombresa = value; }
        }
        private string _comentario;

        public string comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }
        
        private DataTable _TablaTestimoniales;  


        public DataTable TablaTestimoniales
        {
            get { return _TablaTestimoniales; }
            set { _TablaTestimoniales = value; }
        }
        private string _urlimagen;
        public string urlimagen
        {
            get { return _urlimagen; }
            set { _urlimagen = value; }
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
        public bool webver { get; set; }
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        private HttpPostedFileBase _foto;
        [Required(ErrorMessage = "La Imagen es obligatorio")]
        [Display(Name = "Imagen")]
        [FileExtensions(Extensions = "png,jpg,jpeg", ErrorMessage = "Solo imagenes")]
        public HttpPostedFileBase foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
    }
}