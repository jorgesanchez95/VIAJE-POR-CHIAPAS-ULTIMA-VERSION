using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class SeccionModels
    {
        public string pathImg { get; set; }


        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameSeccionAvailability", "Secciones", ErrorMessage = "El nombre de la Imagen ya esta asignado")]
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


        public string id_seccion { get; set; }

        private string _nombreSeccion;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombreSeccion
        {
            get { return _nombreSeccion; }
            set { _nombreSeccion = value; }
        }


        private string _descripcion;
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        [Display(Name = "Descripcion")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string urlYoutube { get; set; }

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

        [Required(ErrorMessage = "Seccion es un campo requerido")]
        [Display(Name = "Sección")]
        public List<SeccionModels> tablaSeccionesCmb { get; set; }

        public DataTable tablaSeccion { get; set; }
        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaBannerInicio { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTopPaquetes { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaArticulos { get; set; }
        public DataTable tablaUbicacionesLugaresTuristicos { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaMetaTags { get; set; }
        public DataTable TablaTuors { get; set; }
        public DataTable TablaDestinosPaquetes { get; set; }
        public DataTable TablaDestinosTours { get; set; }
        public DataTable TablaTestimoniales { get; set; }
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }
        public DataTable TablaPromociones { get; set; }
        public DataTable TablaVehiculo { get; set; }
        public int idioma { get; set; }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }

        #region AuxiliaresSuscribirse
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
        #endregion

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}