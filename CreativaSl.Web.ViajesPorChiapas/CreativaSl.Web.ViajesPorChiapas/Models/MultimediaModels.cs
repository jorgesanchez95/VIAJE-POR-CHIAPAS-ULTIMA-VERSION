using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class MultimediaModels
    {
        public string id_multimedia { get; set; }
        public string id_seccion { get; set; }

        private string _descripcion;
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        [Display(Name = "Descripcion")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private DateTime _fec_ini = DateTime.Now;

        public  DateTime fec_ini
        {
            get { return _fec_ini; }
            set { _fec_ini = value; }
        }
        private DateTime _fec_fin = DateTime.Now;

        public DateTime fec_fin
        {
            get { return _fec_fin; }
            set { _fec_fin = value; }
        }

        private string _descripcionIngles;
        [Required(ErrorMessage = "La descripcion en ingles es obligatorio")]
        [Display(Name = "Descripcion Ingles")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcionIngles
        {
            get { return _descripcionIngles; }
            set { _descripcionIngles = value; }
        }

        private string _nombre;
        [Required(ErrorMessage = "La nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _nombre_pagina;
        [Required(ErrorMessage = "La nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombre_pagina
        {
            get { return _nombre_pagina; }
            set { _nombre_pagina = value; }
        }

        private string _nombreIngles;
        [Required(ErrorMessage = "La nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombreIngles
        {
            get { return _nombreIngles; }
            set { _nombreIngles = value; }
        }

        private string _pathMul;
        public string pathMul
        {
            get { return _pathMul; }
            set { _pathMul = value; }
        }

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

        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameGaleriaAvailability", "Galeria", ErrorMessage = "El nombre de la multimedia ya esta asignado")]
        public string nombreArchivo { get; set; }        
        public string tipoArchivo { get; set; }

        public DataTable tablaMultimedia { get; set; }

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

        private List<TipoGaleriaModels> _tablaTipoGaleriaCmb;
        [Required(ErrorMessage = "Tipo Galeria es un campo requerido")]
        [Display(Name = "Tipo Galeria")]
        public List<TipoGaleriaModels> tablaTipoGaleriaCmb
        {
            get { return _tablaTipoGaleriaCmb; }
            set { _tablaTipoGaleriaCmb = value; }
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
        public DataTable tablaTipoGaleria { get; set; }
        public DataTable tablaGaleria { get; set; }

        public int idioma { get; set; }
        public string id_suscripcion { get; set; }

        private string _correoSuscribirse;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string correoSuscribirse
        {
            get { return _correoSuscribirse; }
            set { _correoSuscribirse = value; }
        }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }
        #region TiposMultimedia
        public string id_tipoGaleria { get; set; }
        public string id_banner { get; set; }
        public string id_bannerInicio { get; set; }
        public string id_lugar { get; set; }
        public string id_encabezado { get; set; }
        #endregion

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}