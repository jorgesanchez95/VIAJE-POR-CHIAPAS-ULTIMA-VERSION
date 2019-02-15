using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoVehiculoModels
    {
        public string id_tipoVehiculo { get; set; }

        private string _descripcion;
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripcion")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public DataTable tablaTipoVehiculo { get; set; }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}