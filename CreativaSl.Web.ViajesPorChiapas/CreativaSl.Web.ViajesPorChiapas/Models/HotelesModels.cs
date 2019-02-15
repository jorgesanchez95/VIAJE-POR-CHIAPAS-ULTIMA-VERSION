using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class HotelesModels
    {
        public string id_hotel { get; set; }
        public string id_seccion { get; set; }



        public int id_pais { get; set; }
        public int id_estado { get; set; }
        public int id_municipio { get; set; }
        public int numeroEstrellas { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }

        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameGaleriaAvailability", "Galeria", ErrorMessage = "El nombre de la Galeria ya esta asignado")]
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
        [Remote("CheckNombreESHotelesAvailability", "CatHoteles", ErrorMessage = "El nombre ya esta asignado")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _encargado;
        [Required(ErrorMessage = "Encargado es obligatorio")]
        [Display(Name = "Encargado")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string encargado
        {
            get { return _encargado; }
            set { _encargado = value; }
        }

        private string _telefonolocal;
        [Required(ErrorMessage = "Telefono Local es obligatorio")]
        [Display(Name = "Telefono Local")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Solo números")]
        public string telefonolocal
        {
            get { return _telefonolocal; }
            set { _telefonolocal = value; }
        }

        private string _telefonomovil;
        [Required(ErrorMessage = "Telefono Movil es obligatorio")]
        [Display(Name = "Telefono Movil")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Solo números")]
        public string telefonomovil
        {
            get { return _telefonomovil; }
            set { _telefonomovil = value; }
        }

        private string _correoelectronico;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[._A-Za-z0-9.-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string correoelectronico
        {
            get { return _correoelectronico; }
            set { _correoelectronico = value; }
        }

        private string _direccion;
        [Required(ErrorMessage = "Direccion es obligatorio")]
        [Display(Name = "Direccion")]
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private int _numestrellas;
        [Required(ErrorMessage = "Numero de Estrella es Obligatorio")]
        [Display(Name = "Numero Estrella")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Solo números")]
        public int numestrellas
        {
            get { return _numestrellas; }
            set { _numestrellas = value; }
        }

        private string _descripcion;
        [Required(ErrorMessage = "Descripcion es Obligatorio")]
        [Display(Name = "Descripcion")]
        [StringLength(350, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descripcion_ingles;
        [Required(ErrorMessage = "Descripcion en Ingles es Obligatorio")]
        [Display(Name = "Descripcion Ingles")]
        [StringLength(350, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion_ingles
        {
            get { return _descripcion_ingles; }
            set { _descripcion_ingles = value; }
        }
        private List<PaisModels> _tablaPaisesCmb;
        [Required(ErrorMessage = "Pais es un campo requerido")]
        [Display(Name = "Pais")]
        public List<PaisModels> tablaPaisesCmb
        {
            get { return _tablaPaisesCmb; }
            set { _tablaPaisesCmb = value; }
        }
        public string pathMul { get; set; }

        public DataTable tablaHoteles { get; set; }

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


        private List<CatTagsModels> _tablaTagsCmb;
        [Required(ErrorMessage = "Tags es un campo requerido")]
        [Display(Name = "Tags")]
        public List<CatTagsModels> tablaTagsCmb
        {
            get { return _tablaTagsCmb; }
            set { _tablaTagsCmb = value; }
        }

        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaSeccion { get; set; }
        public DataTable tablaArticulos { get; set; }
        public DataTable tablaItinerario { get; set; }
        public DataTable tablaLugares { get; set; }
        public DataTable tablaRedesSociales { get; set; }

        public int idioma { get; set; }

        public DataTable tablaTagsSelecionados { get; set; }
        public DataTable tablaEstrellasSeleccionadas { get; set; }

        public int numeroPaquetes { get; set; }
        public int totalPaquetes { get; set; }
        
        public int offset { get; set; }
        public int current { get; set; }

        private int _fetchNext = 5;
        public int fetchNext
        {
            get { return _fetchNext; }
            set { _fetchNext = value; }
        }

        public string stars { get; set; }
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

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
      
        #region Cotizar
        private string _idClienteCotizar;
        public string idClienteCotizar
        {
            get { return _idClienteCotizar; }
            set { _idClienteCotizar = value; }
        }
        private string _nombreCotizar;
		[Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre Cotizar")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string nombreCotizar
        {
            get { return _nombreCotizar; }
            set { _nombreCotizar = value; }
        }
        private string _apellidoPaternoCotizar;
		[Required(ErrorMessage = "El Apellido Paterno obligatorio")]
        [Display(Name = "Apellido Paterno Cotizar")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string apellidoPaternoCotizar
        {
            get { return _apellidoPaternoCotizar; }
            set { _apellidoPaternoCotizar = value; }
        }
        private string _apellidoMaternoCotizar;
		[Required(ErrorMessage = "El Apellido Materno obligatorio")]
        [Display(Name = "Apellido Materno Cotizar")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ\s]*$", ErrorMessage = "Solo Letras")]
        public string apellidoMaternoCotizar
        {
            get { return _apellidoMaternoCotizar; }
            set { _apellidoMaternoCotizar = value; }
        }
        private string _emailCotizar;
		[Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
		[StringLength(3000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[._A-Za-z0-9.-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string emailCotizar
        {
            get { return _emailCotizar; }
            set { _emailCotizar = value; }
        }
        private string _telefonoCotizar;
		[Required(ErrorMessage = "El Telefono es obligatorio")]
        [Display(Name = "Telefono Cotizar")]
		[StringLength(14, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
		[RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Solo números")]
        public string telefonoCotizar
        {
            get { return _telefonoCotizar; }
            set { _telefonoCotizar = value; }
        }
        private bool _boletoAvionCotizar;
		[Required(ErrorMessage = "El Boleto de Avion es obligatorio")]
		[Display(Name = "Boleto Avion Cotizar")]
        public bool BoletoCotizar
        {
            get { return _boletoAvionCotizar; }
            set { _boletoAvionCotizar = value; }
        }
        private string _aeropuertoLlegadaCotizar;
		[Display(Name = "Aeropuerto Llegada Cotizar")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string aeropuertoLlegadaCotizar
        {
            get { return _aeropuertoLlegadaCotizar; }
            set { _aeropuertoLlegadaCotizar = value; }
        }
        private DateTime _fechaLlegadaCotizar = DateTime.Now;
		[Required(ErrorMessage = "La Fecha Llegada es obligatorio")]
        [Display(Name = "Fecha Llegada Cotizar")]
        public DateTime fechaLlegadaCotizar
        {
            get { return _fechaLlegadaCotizar; }
            set { _fechaLlegadaCotizar = value; }
        }
        private string _horaLlegadaCotizar = "00:00";
		[Required(ErrorMessage = "La Hora de Llegada es obligatorio")]
        [Display(Name = "Hora de Llegada")]
        public string horaLlegadaCotizar
        {
            get { return _horaLlegadaCotizar; }
            set { _horaLlegadaCotizar = value; }
        }
        private string _aeropuertoSalidaCotizar;
		[Display(Name = "Aeropuerto Salida Cotizar")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string aeropuertoSalidaCotizar
        {
            get { return _aeropuertoSalidaCotizar; }
            set { _aeropuertoSalidaCotizar = value; }
        }
        private DateTime _fechaSalidaCotizar = DateTime.Now.AddDays(1);
		[Required(ErrorMessage = "La Fecha Salida es obligatorio")]
        [Display(Name = "Fecha Salida Cotizar")]
        public DateTime fechaSalidaCotizar
        {
            get { return _fechaSalidaCotizar; }
            set { _fechaSalidaCotizar = value; }
        }
        private string _horaSalidaCotizar = "00:00";
		[Required(ErrorMessage = "La Hora de Salida es obligatorio")]
        [Display(Name = "Hora de Salida Cotizar")]
        public string horaSalidaCotizar
        {
            get { return _horaSalidaCotizar; }
            set { _horaSalidaCotizar = value; }
        }
        private int _categoriaHotelCotizar;
		[Required(ErrorMessage = "El Categoria Hotel es obligatorio")]
        [Display(Name = "Categoria Hotel Cotizar")]
        public int categoriaHotelCotizar
        {
            get { return _categoriaHotelCotizar; }
            set { _categoriaHotelCotizar = value; }
        }
        private int _numeroPersonasCotizar;
		[Required(ErrorMessage = "El Numero de Persona es obligatorio")]
        [Display(Name = "Numero de Persona Cotizar")]
		[RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Solo números")]
        public int numeroPersonasCotizar
        {
            get { return _numeroPersonasCotizar; }
            set { _numeroPersonasCotizar = value; }
        }
        private int _numeroAdultoCotizar;
		[Required(ErrorMessage = "El Numero de Adulto es obligatorio")]
        [Display(Name = "Numero de Adulto Cotizar")]
        public int numeroAdultoCotizar
        {
            get { return _numeroAdultoCotizar; }
            set { _numeroAdultoCotizar = value; }
        }
        private int _numeroNiños511Cotizar;
		[Required(ErrorMessage = "El Numero de Niño es obligatorio")]
        [Display(Name = "Numero de Niño Cotizar")]
        public int numeroNiños511Cotizar
        {
            get { return _numeroNiños511Cotizar; }
            set { _numeroNiños511Cotizar = value; }
        }
        private int _numeroNiños14Cotizar;
		[Required(ErrorMessage = "El Numero de Niño es obligatorio")]
        [Display(Name = "Numero de Niño Cotizar")]
        public int numeroNiños14Cotizar
        {
            get { return _numeroNiños14Cotizar; }
            set { _numeroNiños14Cotizar = value; }
        }
        private int _numeroHabitacionesCotizar;
		[Required(ErrorMessage = "El Numero de Habitaciones es obligatorio")]
        [Display(Name = "Numero de Habitaciones Cotizar")]
        public int numeroHabitacionesCotizar
        {
            get { return _numeroHabitacionesCotizar; }
            set { _numeroHabitacionesCotizar = value; }
        }
        private DataTable _numeroPersonasCamaCotizar;
		[Required(ErrorMessage = "El Numero de Persona por Cama es obligatorio")]
        [Display(Name = "Numero de Persona por Cama Cotizar")]
        public DataTable numeroPersonasCamaCotizar
        {
            get { return _numeroPersonasCamaCotizar; }
            set { _numeroPersonasCamaCotizar = value; }
        }
        private int _verificadorCotizar;
        public int verificadorCotizar
        {
            get { return _verificadorCotizar; }
            set { _verificadorCotizar = value; }
        }
        #endregion    

        #region Correo
        public DataTable datosGeneralesCorreo { get; set; }
        public DataTable tablaRecamarasCorreo { get; set; }
        #endregion
        public DataTable TablaPaquetesPopulares { get; set; }
        public DateTime fechaSalidaCotizarCompleta { get; set; }
        public DateTime fechaLlegadaCotizarCompleta { get; set; }

        public string nombre_pagina { get; set; }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }
    }
}