using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ArticulosModels
    {
        public string id_post { get; set; }
        public string id_seccion { get; set; }
        public int visitas { get; set; }

        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameArticuloAvailability", "Articulos", ErrorMessage = "El nombre de la Imagen ya esta asignado")]
        public string nombreArchivo { get; set; }

        public string tipoArchivo { get; set; }

        private string _alt;
        [Required(ErrorMessage = "Alt es obligatorio")]
        [Display(Name = "Alt")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        public string alt
        {
            get { return _alt; }
            set { _alt = value; }
        }

        private string _title;
        [Required(ErrorMessage = "Title es obligatorio")]
        [Display(Name = "Title")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }


        private string _creadoPor;
        [Required(ErrorMessage = "Creado Por es obligatorio")]
        [Display(Name = "Creado Por")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string creadoPor
        {
            get { return _creadoPor; }
            set { _creadoPor = value; }
        }

        private string _titulo;
        [Required(ErrorMessage = "El titulo es obligatorio")]
        [Display(Name = "Titulo")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        [Remote("CheckNombreESArticuloAvailability", "Articulos", ErrorMessage = "El titulo ya esta asignado")]
        public string titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private string _tituloIngles;
        [Required(ErrorMessage = "El titulo(ingles) es obligatorio")]
        [Display(Name = "Titulo(Ingles)")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        [Remote("CheckNombreIngArticulovailability", "Articulos", ErrorMessage = "El titulo ingles ya esta asignado")]
        public string tituloIngles
        {
            get { return _tituloIngles; }
            set { _tituloIngles = value; }
        }
        [Required(ErrorMessage = "Introducción es obligatorio")]
        public string introduccion { get; set; }
        [Required(ErrorMessage = "Introducción en ingles es obligatorio")]
        public string introduccionIngles { get; set; }
        [Required(ErrorMessage = "Contenido es obligatorio")]
        public string contenido { get; set; }
        [Required(ErrorMessage = "Contenido en ingles es obligatorio")] 
        public string contenidoIngles { get; set; }
        public string urlYoutube { get; set; }
        public string pathImg { get; set; }

        private HttpPostedFileBase _foto;
        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "Selecciones una Imagen")]
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

        private List<SeccionModels> _tablaSeccionesCmb;
        [Required(ErrorMessage = "Seccion es un campo requerido")]
        [Display(Name = "Sección")]
        public List<SeccionModels> tablaSeccionesCmb
        {
            get { return _tablaSeccionesCmb; }
            set { _tablaSeccionesCmb = value; }
        }

        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaSeccion { get; set; }
        public DataTable tablaArticulos { get; set; }
        public DataTable tablaArticulo { get; set; }
        public DataTable tablaTipoGaleria { get; set; }
        public DataTable tablaGaleria { get; set; }
        public DataTable tablaTagsSelecionados { get; set; }
        public DataTable tablaMetaTags { get; set; }
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }
        public DataTable tablaArticulosPopulares { get; set; }
        public int numeroArticulos { get; set; }
        public int offset { get; set; }
        public int current { get; set; }

        private int _fetchNext = 5;
        public int fetchNext
        {
            get { return _fetchNext; }
            set { _fetchNext = value; }
        }

        public int idioma { get; set; }
        public string id_suscripcion { get; set; }
        public string id_tags { get; set; }
        public string query { get; set; }
        public string aBuscar { get; set; }

        private string _correoSuscribirse;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string correoSuscribirse
        {
            get { return _correoSuscribirse; }
            set { _correoSuscribirse = value; }
        }

        #region Datos de control

        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }

        #endregion

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public string nombre_pagina { get; set; }
    }
}