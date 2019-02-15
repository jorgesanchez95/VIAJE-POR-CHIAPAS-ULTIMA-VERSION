using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TransportacionModels
    {
        public string id_vehiculo { get; set; }
        public string id_seccion { get; set; }

        public string id_TipoVehiculoCotizar { get; set; }
        public string id_tipoGaleria { get; set; }
        public int id_pais { get; set; }
        public int id_estado { get; set; }
        public int id_municipio { get; set; }
        public int numeroEstrellas { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }

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
        public int numeroPromociones { get; set; }
        public int numeroPaquetes { get; set; }
        public int offset { get; set; }
        public int current { get; set; }
        public int totalPaquetes { get; set; }
        private int _fetchNext = 6;
        public int fetchNext
        {
            get { return _fetchNext; }
            set { _fetchNext = value; }
        }

        private string _nombre_pagina;

        public string nombre_pagina
        {
            get { return _nombre_pagina; }
            set { _nombre_pagina = value; }
        }

        public string pathMul { get; set; }

        public DataTable tablaTransportacion { get; set; }
        public DataTable tablaGaleria { get; set; }

        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaSeccion { get; set; }
        public DataTable tablaArticulos { get; set; }
        public DataTable tablaItinerario { get; set; }
        public DataTable tablaLugares { get; set; }
        public DataTable tablaTipoVehiculosCotizar { get; set; }
        public DataTable tablaRedesSociales { get; set; }
        public DataTable tablaPromociones { get; set; }

        public DataTable tablaVehiculos { get; set; }
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }
        public int idioma { get; set; }


        #region AuxiliaresSuscribirse
        public string id_suscripcion { get; set; }

        private string _correoSuscribirse;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[_A-Za-z0-9.-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
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
		//[Required(ErrorMessage = "El Apellido Materno obligatorio")]
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
        [RegularExpression(@"^[_A-Za-z0-9.-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string emailCotizar
        {
            get { return _emailCotizar; }
            set { _emailCotizar = value; }
        }
        private string _telefonoCotizar;
		[Required(ErrorMessage = "El Telefono es obligatorio")]
        [Display(Name = "Telefono Cotizar")]
		[StringLength(14, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
		[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Escriba un número telefónico correcto")]
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
        private string _observacionesCotizar;
        public string observacionesCotizar
        {
            get { return _observacionesCotizar; }
            set { _observacionesCotizar = value; }
        }
        #endregion    

        #region Correo
        public DataTable datosGeneralesCorreo { get; set; }
        #endregion

        public DateTime fechaSalidaCotizarCompleta { get; set; }
        public DateTime fechaLlegadaCotizarCompleta { get; set; }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }
        public DataTable TablaPromocionesPopulares { get; set; }
    }
}