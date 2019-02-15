using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ConfiguracionModels
    {

        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameConfiguracionesAvailability", "Configuracion", ErrorMessage = "El nombre de la Imagen ya esta asignado")]
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

        public string id_configuracion { get; set; }

        private string _direccion;
        [Required(ErrorMessage = "La Direccion es obligatorio")]
        [Display(Name = "Direccion")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _telefono;
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [Display(Name = "Telefono")]
        [StringLength(18, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[0-9\s\,\.\;\:\-\(\)\+]*$", ErrorMessage = "Solo numeros")]
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _pieAcerca;
        [Required(ErrorMessage = "Acerca (pie pagina) es obligatorio")]
        [Display(Name = "Acerca (pie pagina)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string pieAcerca
        {
            get { return _pieAcerca; }
            set { _pieAcerca = value; }
        }

        private string _pieAcercaIngles;
        [Required(ErrorMessage = "Acerca (pie pagina)(Ingles) es obligatorio")]
        [Display(Name = "Acerca (pie pagina)(Ingles)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string pieAcercaIngles
        {
            get { return _pieAcercaIngles; }
            set { _pieAcercaIngles = value; }
        }

        private string _textoUno;
        [Required(ErrorMessage = "Texto uno es obligatorio")]
        [Display(Name = "Texto uno")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string textoUno
        {
            get { return _textoUno; }
            set { _textoUno = value; }
        }

        private string _textoUnoIngles;
        [Required(ErrorMessage = "Texto uno (Ingles) es obligatorio")]
        [Display(Name = "Texto uno (Ingles)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string textoUnoIngles
        {
            get { return _textoUnoIngles; }
            set { _textoUnoIngles = value; }
        }

        private string _topCinco;
        [Required(ErrorMessage = "Top cinco es obligatorio")]
        [Display(Name = "Top cinco")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string topCinco
        {
            get { return _topCinco; }
            set { _topCinco = value; }
        }

        private string _topCincoIngles;
        [Required(ErrorMessage = "Top cinco(Ingles) es obligatorio")]
        [Display(Name = "Top cinco(Ingles)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string topCincoIngles
        {
            get { return _topCincoIngles; }
            set { _topCincoIngles = value; }
        }

        private string _newsletter;
        [Required(ErrorMessage = "Newsletter es obligatorio")]
        [Display(Name = "Newsletter")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string newsletter
        {
            get { return _newsletter; }
            set { _newsletter = value; }
        }

        private string _newsletterIngles;
        [Required(ErrorMessage = "Newsletter(Ingles) es obligatorio")]
        [Display(Name = "Newsletter(Ingles)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string newsletterIngles
        {
            get { return _newsletterIngles; }
            set { _newsletterIngles = value; }
        }

        private string _textoDos;
        [Required(ErrorMessage = "Texto dos es obligatorio")]
        [Display(Name = "Texto dos")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\?\¿\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string textoDos
        {
            get { return _textoDos; }
            set { _textoDos = value; }
        }

        private string _textoDosIngles;
        [Required(ErrorMessage = "Texto dos(Ingles) es obligatorio")]
        [Display(Name = "Texto dos(Ingles)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\?\¿\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string textoDosIngles
        {
            get { return _textoDosIngles; }
            set { _textoDosIngles = value; }
        }

        private string _correo;
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private string _facebook;
        [Required(ErrorMessage = "Facebook es obligatorio")]
        [Display(Name = "Facebook")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        //[RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        private string _twitter;
        [Required(ErrorMessage = "Twitter es obligatorio")]
        [Display(Name = "Twitter")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        //[RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }

        private string _youtube;
        [Required(ErrorMessage = "Instagram es obligatorio")]
        [Display(Name = "Instagaram")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        //[RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string youtube
        {
            get { return _youtube; }
            set { _youtube = value; }
        }

        private string _google;
        [Required(ErrorMessage = "Instagram es obligatorio")]
        [Display(Name = "Instagaram")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        //[RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string google
        {
            get { return _google; }
            set { _google = value; }
        }

        private string _instagram;
        [Required(ErrorMessage = "Instagram es obligatorio")]
        [Display(Name = "Instagaram")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        //[RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string instagram
        {
            get { return _instagram; }
            set { _instagram = value; }
        }

        private string _contactanos;
        [Required(ErrorMessage = "Contactanos es obligatorio")]
        [Display(Name = "Contactanos")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string contactanos
        {
            get { return _contactanos; }
            set { _contactanos = value; }
        }

        private string _contactanosIngles;
        [Required(ErrorMessage = "Contactanos(Ingles) es obligatorio")]
        [Display(Name = "Contactanos(Ingles)")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string contactanosIngles
        {
            get { return _contactanosIngles; }
            set { _contactanosIngles = value; }
        }

        private string _quienEs;
        [Required(ErrorMessage = "¿Quien es...? es obligatorio")]
        [Display(Name = "¿Quien es...?")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string quienEs
        {
            get { return _quienEs; }
            set { _quienEs = value; }
        }

        private string _quienEsIngles;
        [Required(ErrorMessage = "¿Quien es...?(Ingles) es obligatorio")]
        [Display(Name = "¿Quien es...?(Ingles)")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string quienEsIngles
        {
            get { return _quienEsIngles; }
            set { _quienEsIngles = value; }
        }

        private string _nuestrosServicios;
        [Required(ErrorMessage = "Nuestros servicios es obligatorio")]
        [Display(Name = "Nuestros servicios")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nuestrosServicios
        {
            get { return _nuestrosServicios; }
            set { _nuestrosServicios = value; }
        }

        private string _nuestrosServiciosIngles;
        [Required(ErrorMessage = "Nuestros servicios(Ingles) es obligatorio")]
        [Display(Name = "Nuestros servicios(Ingles)")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nuestrosServiciosIngles
        {
            get { return _nuestrosServiciosIngles; }
            set { _nuestrosServiciosIngles = value; }
        }

        private string _servicioBoletos;
        [Required(ErrorMessage = "Servicio boletos es obligatorio")]
        [Display(Name = "Servicio boletos")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioBoletos
        {
            get { return _servicioBoletos; }
            set { _servicioBoletos = value; }
        }

        private string _servicioBoletosIngles;
        [Required(ErrorMessage = "Servicio boletos(Ingles) es obligatorio")]
        [Display(Name = "Servicio boletos(ingles)")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioBoletosIngles
        {
            get { return _servicioBoletosIngles; }
            set { _servicioBoletosIngles = value; }
        }

        private string _servicioHotel;
        [Required(ErrorMessage = "Servicio hotel es obligatorio")]
        [Display(Name = "Servicio hotel")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioHotel
        {
            get { return _servicioHotel; }
            set { _servicioHotel = value; }
        }

        private string _servicioHotelIngles;
        [Required(ErrorMessage = "Servicio hotel(Ingles) es obligatorio")]
        [Display(Name = "Servicio hotel(Ingles)")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioHotelIngles
        {
            get { return _servicioHotelIngles; }
            set { _servicioHotelIngles = value; }
        }

        private string _servicioTraslado;
        [Required(ErrorMessage = "Servicio traslado es obligatorio")]
        [Display(Name = "Servicio traslado")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioTraslado
        {
            get { return _servicioTraslado; }
            set { _servicioTraslado = value; }
        }

        private string _servicioTrasladoIngles;
        [Required(ErrorMessage = "Servicio traslado(Ingles) es obligatorio")]
        [Display(Name = "Servicio traslado(Ingles)")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioTrasladoIngles
        {
            get { return _servicioTrasladoIngles; }
            set { _servicioTrasladoIngles = value; }
        }

        private string _servicioPaquetes;
        [Required(ErrorMessage = "Servicio paquetes es obligatorio")]
        [Display(Name = "Servicio paquetes")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioPaquetes
        {
            get { return _servicioPaquetes; }
            set { _servicioPaquetes = value; }
        }

        private string _servicioPaquetesIngles;
        [Required(ErrorMessage = "Servicio paquetes(Ingles) es obligatorio")]
        [Display(Name = "Servicio paquetes(Ingles)")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string servicioPaquetesIngles
        {
            get { return _servicioPaquetesIngles; }
            set { _servicioPaquetesIngles = value; }
        }

        public string pathImg { get; set; }

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

        private string _descripcionTransportacion;
        [Required(ErrorMessage = "Descripcion Transportacion es obligatorio")]
        [Display(Name = "Descripcion Transportacion")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcionTransportacion
        {
            get { return _descripcionTransportacion; }
            set { _descripcionTransportacion = value; }
        }

        private string _descripcionTransportacionIngles;
        [Required(ErrorMessage = "Descripcion Transportacion(Ingles) es obligatorio")]
        [Display(Name = "Descripcion Transportacion(Ingles)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcionTransportacionIngles
        {
            get { return _descripcionTransportacionIngles; }
            set { _descripcionTransportacionIngles = value; }
        }

        private string _detalleTransportacion;
        [Required(ErrorMessage = "Detalle Transportacion es obligatorio")]
        [Display(Name = "Detalle Transportacion")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string detalleTransportacion
        {
            get { return _detalleTransportacion; }
            set { _detalleTransportacion = value; }
        }

        private string _detalleTransportacionIngles;
        [Required(ErrorMessage = "Detalle Transportacion(Ingles) es obligatorio")]
        [Display(Name = "Detalle Transportacion(Ingles)")]
        [StringLength(4000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string detalleTransportacionIngles
        {
            get { return _detalleTransportacionIngles; }
            set { _detalleTransportacionIngles = value; }
        }

        private string _terminosCondiciones;
        [Required(ErrorMessage = "Terminos y Condiciones es obligatorio")]
        [Display(Name = "Terminos y Condiciones")]
        public string terminosCondiciones
        {
            get { return _terminosCondiciones; }
            set { _terminosCondiciones = value; }
        }

        private string _terminosCondicionesIngles;
        [Required(ErrorMessage = "Terminos y Condiciones (Ingles) es obligatorio")]
        [Display(Name = "Terminos y Condiciones(Ingles)")]
        public string terminosCondicionesIngles
        {
            get { return _terminosCondicionesIngles; }
            set { _terminosCondicionesIngles = value; }
        }

        public DataTable tablaConfiguracion { get; set; }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}