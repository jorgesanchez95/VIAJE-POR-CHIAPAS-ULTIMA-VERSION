using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ContactoModels
    {
        public string id_contacto { get; set; }

        private string _nombre;
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y numeros")]  
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _correo;
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private string _telefono;
        [Required(ErrorMessage = "El Teléfono es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        [StringLength(15, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo Numeros")]
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _mensaje;
        [Required(ErrorMessage = "El Mensaje es obligatorio")]
        [Display(Name = "Mensaje")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y numeros")]
        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        private string _respuesta;
        [Required(ErrorMessage = "La Respuesta es obligatorio")]
        [Display(Name = "Respuesta")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y numeros")]
        public string respuesta
        {
            get { return _respuesta; }
            set { _respuesta = value; }
        }

        private string _asunto;
        [Required(ErrorMessage = "El Asunto es obligatorio")]
        [Display(Name = "Asunto")]
        [StringLength(505, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y numeros")]
        public string asunto
        {
            get { return _asunto; }
            set { _asunto = value; }
        }

        private string _horarioContacto;
        [Display(Name = "Hora en que podemos localizarlo")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y numeros")]
        public string horarioContacto
        {
            get { return _horarioContacto; }
            set { _horarioContacto = value; }
        }

        public DataTable tablaContacto { get; set; }

        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaSeccion { get; set; }
        public DataTable tablaArticulos { get; set; }
        public DataTable tablaRedesSociales { get; set; }
        
        public string id_seccion { get; set; }
        public int idioma { get; set; }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }
        #region AuxiliaresSuscribirse
        public string id_suscripcion { get; set; }

        private string _correoSuscribirse;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
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