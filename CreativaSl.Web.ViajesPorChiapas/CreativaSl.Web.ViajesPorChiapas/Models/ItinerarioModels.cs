using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ItinerarioModels
    {
        public string id_itinerario { get; set; }
        public string id_paquete { get; set; }
        public string id_lugar { get; set; }
        public string id_seccion { get; set; }

        private string _nombre;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(300, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _nombreIngles;
        [Required(ErrorMessage = "El nombre(Ingles) es obligatorio")]
        [Display(Name = "Nombre(Ingles)")]
        [StringLength(300, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombreIngles
        {
            get { return _nombreIngles; }
            set { _nombreIngles = value; }
        }

        private string _horaSalida;
        [Required(ErrorMessage = "La hora de salida es obligatorio")]
        [Display(Name = "Hora Salida")]
        [StringLength(10, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "El formato de hora no es correcto")]
        public string horaSalida
        {
            get { return _horaSalida; }
            set { _horaSalida = value; }
        }

        private string _lugarSalida;
        [Required(ErrorMessage = "El Lugar de Salida es obligatorio")]
        [Display(Name = "Lugar de Salida")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string lugarSalida
        {
            get { return _lugarSalida; }
            set { _lugarSalida = value; }
        }

        private string _finDeServicios;
        [Required(ErrorMessage = "Fin de Servivios es obligatorio")]
        [Display(Name = "Fin de Servivios")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string finDeServicios
        {
            get { return _finDeServicios; }
            set { _finDeServicios = value; }
        }

        private string _descripcion;
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [Display(Name = "Descripcion")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descripcionIngles;
        [Required(ErrorMessage = "Descripción (ingles) es obligatorio")]
        [Display(Name = "Descripcion (ingles)")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcionIngles
        {
            get { return _descripcionIngles; }
            set { _descripcionIngles = value; }
        }

        private string _observaciones;
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [Display(Name = "Descripcion")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        private string _observacionesIngles;
        [Required(ErrorMessage = "Observaciones (ingles) es obligatorio")]
        [Display(Name = "Observaciones (ingles)")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string observacionesIngles
        {
            get { return _observacionesIngles; }
            set { _observacionesIngles = value; }
        }

        private string _recomendaciones;
        [Required(ErrorMessage = "Recomendaciones es obligatorio")]
        [Display(Name = "Recomendaciones")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string recomendaciones
        {
            get { return _recomendaciones; }
            set { _recomendaciones = value; }
        }

        private string _recomendacionesIngles;
        [Required(ErrorMessage = "Recomendaciones (ingles) es obligatorio")]
        [Display(Name = "Recomendaciones (ingles)")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string recomendacionesIngles
        {
            get { return _recomendacionesIngles; }
            set { _recomendacionesIngles = value; }
        }

        private int _orden;
        [Display(Name = "Orden")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Solo números")]
        public int orden
        {
            get { return _orden; }
            set { _orden = value; }
        }

        public DataTable tablaItinerarios { get; set; }

        private List<LugaresTuristicosModels> _tablaLugaresCmb;
        [Required(ErrorMessage = "Lugar es un campo requerido")]
        [Display(Name = "Lugar")]
        public List<LugaresTuristicosModels> tablaLugaresCmb
        {
            get { return _tablaLugaresCmb; }
            set { _tablaLugaresCmb = value; }
        }

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}