using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ClienteModels
    {
        public string id_cliente { get; set; }
        public int id_tipoCliente { get; set; }
        public int id_municipio { get; set; }
        public int id_estado { get; set; }
        public int id_ocupacion { get; set; }
        public int id_genero { get; set; }
        public bool solicitado { get; set; }
        public bool entregado { get; set; }
        public int id_pais { get; set; }
        public string enlace { get; set; }
        public string nombrePagina { get; set; }
        private string _colonia;
        [Display(Name = "Colonia")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string colonia
        {
            get { return _colonia; }
            set { _colonia = value; }
        }

        private string _asunto;
        [Display(Name = "Asunto")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string asunto
        {
            get { return _asunto; }
            set { _asunto = value; }
        }

        public string nombreCompleto { get; set; }

        private string _curp;
        [Required(ErrorMessage = "La curp es obligatorio")]
        [Display(Name = "CURP")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-z0-9\s]*$", ErrorMessage = "Solo Letras y numeros")]
        public string curp
        {
            get { return _curp; }
            set { _curp = value; }
        }

        private string _nombre;
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apPat;
        [Required(ErrorMessage = "El Apellido Paterno es obligatorio")]
        [Display(Name = "Apellido Paterno")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string apPat
        {
            get { return _apPat; }
            set { _apPat = value; }
        }

        private string _apMat;

        [Required(ErrorMessage = "El Apellido Materno es obligatorio")]
        [Display(Name = "Apellido Materno")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string apMat
        {
            get { return _apMat; }
            set { _apMat = value; }
        }

        private DateTime _fechaNac = DateTime.Now;
        [Required(ErrorMessage = "La Fecha de Nacimiento es obligatorio")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        private string _telefono;
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo números")]    
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _email;
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        //[RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        //[StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        //[Remote("CheckEmailAvailability", "Account", ErrorMessage = "Este email esta ocupado")]
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;
        [Required(ErrorMessage = "La Contraseña es obligatorio")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _passwordNew;
        [Required(ErrorMessage = "La Contraseña Nueva es obligatorio")]
        [Display(Name = "Contraseña Nueva")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        public string passwordNew
        {
            get { return _passwordNew; }
            set { _passwordNew = value; }
        }

        private string _passwordConfirm;
        [Required(ErrorMessage = "La Contraseña Nueva es obligatorio")]
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [System.ComponentModel.DataAnnotations.Compare("passwordNew")]
        public string passwordConfirm
        {
            get { return _passwordConfirm; }
            set { _passwordConfirm = value; }
        }

        private string _email2;
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        [StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        public string email2
        {
            get { return _email2; }
            set { _email2 = value; }
        }

        public DataTable tablaClientes { get; set; }

        private List<TipoClienteModels> _tablaTipoClienteCmb;
        [Required(ErrorMessage = "Tipo de Usuario es un campo requerido")]
        [Display(Name = "Tipo de Usuario")]
        public List<TipoClienteModels> tablaTipoClienteCmb
        {
            get { return _tablaTipoClienteCmb; }
            set { _tablaTipoClienteCmb = value; }
        }

        private List<CatOcupacionesModels> _tablaOcupacionesCmb;
        [Required(ErrorMessage = "Ocupaciones es un campo requerido")]
        [Display(Name = "Ocupaciones")]
        public List<CatOcupacionesModels> tablaOcupacionesCmb
        {
            get { return _tablaOcupacionesCmb; }
            set { _tablaOcupacionesCmb = value; }
        }

        private List<CatGeneroModels> _tablaGeneroCmb;
        [Required(ErrorMessage = "Genero es un campo requerido")]
        [Display(Name = "Genero")]
        public List<CatGeneroModels> tablaGeneroCmb
        {
            get { return _tablaGeneroCmb; }
            set { _tablaGeneroCmb = value; }
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

        private List<GrupoModels> _tablaGruposCmb;
        [Required(ErrorMessage = "Grupo es un campo requerido")]
        [Display(Name = "Grupos")]
        public List<GrupoModels> tablaGruposCmb
        {
            get { return _tablaGruposCmb; }
            set { _tablaGruposCmb = value; }
        }

        private List<ClienteModels> _tablaClientesCmb;
        [Required(ErrorMessage = "Cliente es un campo requerido")]
        [Display(Name = "Clientes")]
        public List<ClienteModels> tablaClientesCmb
        {
            get { return _tablaClientesCmb; }
            set { _tablaClientesCmb = value; }
        }

        private List<ClienteModels> _tablaClientesSeleccionadosCmb;
        [Required(ErrorMessage = "Cliente es un campo requerido")]
        [Display(Name = "Clientes")]
        public List<ClienteModels> tablaClientesSeleccionadosCmb
        {
            get { return _tablaClientesSeleccionadosCmb; }
            set { _tablaClientesSeleccionadosCmb = value; }
        }

        private List<ClienteModels> _tablaClientes2Cmb;
        [Display(Name = "Clientes")]
        public List<ClienteModels> tablaClientes2Cmb
        {
            get { return _tablaClientes2Cmb; }
            set { _tablaClientes2Cmb = value; }
        }

        public DataTable tablaSeccion { get; set; }
        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaBannerInicio { get; set; }
        public DataTable tablaArticulos { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaCotizacionesRecientes { get; set; }
        public DataTable tablaCotizaciones { get; set; }
        public DataTable tablaDetalleSolicitud { get; set; }
        public DataTable tablaDetalleSolicitdHabitacion { get; set; }
        public DataTable tablaRedesSociales { get; set; }
        public DataTable tablaFormaPago { get; set; }
        public DataTable tablaItinerario { get; set; }

        public int id_tipoSolicitud { get; set; }
        public string htmlSolicitud { get; set; }

        public string id_seccion { get; set; }
        public int idioma { get; set; }
        public string html { get; set; }

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion

        public string id_grupo { get; set; }

        public int numeroSolicitudes { get; set; }
        public int offset { get; set; }
        public int current { get; set; }

        private int _fetchNext = 5;
        public int fetchNext
        {
            get { return _fetchNext; }
            set { _fetchNext = value; }
        }
        public string id_solicitud { get; set; }
        public string id_cotizacion { get; set; }
        public string id_tipoPago { get; set; }
        public float subtotal { get; set; }
        public float anticipo { get; set; }
        public string id_venta { get; set; }
        public string id_pagoOnline { get; set; }

        public string URL { get; set; }

        
        private bool _panginator = false;
        public bool panginator
        {
            get { return _panginator; }
            set { _panginator = value; }
        }

        private bool _verificador = false;
        public bool verificador
        {
            get { return _verificador; }
            set { _verificador = value; }
        }

        private int _tipoPago = 0;
        public int tipoPago
        {
            get { return _tipoPago; }
            set { _tipoPago = value; }
        }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }
    }
}