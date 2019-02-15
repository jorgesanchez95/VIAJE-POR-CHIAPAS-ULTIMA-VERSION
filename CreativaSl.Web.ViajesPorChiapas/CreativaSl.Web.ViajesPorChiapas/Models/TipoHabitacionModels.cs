using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoHabitacionModels
    {
        public int id_tipoHabitacion { get; set; }

        private string _descripcion;
        [Required(ErrorMessage = "La descripcion ee obligatoria")]
        [Display(Name = "Descripci{on")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public DataTable tablaTipoHabitacion { get; set; }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}