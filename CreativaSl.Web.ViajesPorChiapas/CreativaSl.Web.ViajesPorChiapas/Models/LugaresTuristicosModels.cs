using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class LugaresTuristicosModels
    {
        private List<TipoPaqueteModels> _listaTipoPaquete;

        public List<TipoPaqueteModels> listaTipoPaquete
        {
            get { return _listaTipoPaquete; }
            set { _listaTipoPaquete = value; }
        }

        public string id_lugar { get; set; }
        public string id_seccion { get; set; }


        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameLugaresTuristicosAvailability", "LugaresTuristicos", ErrorMessage = "El nombre de la Imagen ya esta asignado")]
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

        private string _nombre;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int id_pais { get; set; }
        public int id_estado { get; set; }
        public int id_municipio { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string pathImg { get; set; }

        private string _descripcion;
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [Display(Name = "Descripcion")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y el número máximo {1}.", MinimumLength = 1)]
        //[RegularExpression(@"/^\s*$/", ErrorMessage = "Solo Letras y números")]
       // [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descripcion_ingles;
        [Required(ErrorMessage = "Descripcion en ingles es obligatorio")]
        [Display(Name = "Descripcion en Ingles")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        //[RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion_ingles
        {
            get { return _descripcion_ingles; }
            set { _descripcion_ingles = value; }
        }
        
        public DataTable tablaLugaresTuristicos { get; set; }

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

        private List<SeccionModels> _tablaSeccionesCmb;
        [Required(ErrorMessage = "Seccion es un campo requerido")]
        [Display(Name = "Sección")]
        public List<SeccionModels> tablaSeccionesCmb
        {
            get { return _tablaSeccionesCmb; }
            set { _tablaSeccionesCmb = value; }
        }

        private List<PaisModels> _tablaPaisesCmb;
        [Required(ErrorMessage = "Pais es un campo requerido")]
        [Display(Name = "Pais")]
        public List<PaisModels> tablaPaisesCmb
        {
            get { return _tablaPaisesCmb; }
            set { _tablaPaisesCmb = value; }
        }
        private List<EstadoModels> _tablaEstadosCmb;
        [Required(ErrorMessage = "Estado es un campo requerido")]
        [Display(Name = "Estado")]
        public List<EstadoModels> tablaEstadosCmb
        {
            get { return _tablaEstadosCmb; }
            set { _tablaEstadosCmb = value; }
        }

        private List<MunicipioModels> _tablaMunicipiosCmb;
        [Required(ErrorMessage = "Estado es un campo requerido")]
        [Display(Name = "Estado")]
        public List<MunicipioModels> tablaMunicipiosCmb
        {
            get { return _tablaMunicipiosCmb; }
            set { _tablaMunicipiosCmb = value; }
        }

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion

        public int idioma { get; set; }

       
    }
}