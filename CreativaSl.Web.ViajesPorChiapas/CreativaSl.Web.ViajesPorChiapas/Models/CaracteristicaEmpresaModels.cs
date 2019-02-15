using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CaracteristicaEmpresaModels
    {
        public string id_catacteristicaEmpresa { get; set; }

        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameCaracteristicaEmpresaAvailability", "CaracteristicaEmpresa", ErrorMessage = "El nombre de la Imagen ya esta asignado")]
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

        private string _frase;
        [Required(ErrorMessage = "La Frase es obligatorio")]
        [Display(Name = "Frase")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string frase
        {
            get { return _frase; }
            set { _frase = value; }
        }

        private string _fraseIngles;
        [Required(ErrorMessage = "La Frase (Ingles) es obligatorio")]
        [Display(Name = "Frase (Ingles)")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string fraseIngles
        {
            get { return _fraseIngles; }
            set { _fraseIngles = value; }
        }

        private string _descripcion;
        [Required(ErrorMessage = "La Descripcion es obligatorio")]
        [Display(Name = "Descripcion")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descripcionIngles;
        [Required(ErrorMessage = "La Descripcion(Ingles) es obligatorio")]
        [Display(Name = "Descripcion(Ingles)")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string descripcionIngles
        {
            get { return _descripcionIngles; }
            set { _descripcionIngles = value; }
        }

        public string urlImg { get; set; }

        public DataTable tablaCaracteristicaEmpresa { get; set; }

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

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}