using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CatOcupacionesModels
    {
        public int id_ocupacion { get; set; }

        private string _descripcion;
        [Display(Name = "Descripcion")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descripcionIngles;
        [Display(Name = "Descripcion(Ingles)")]
        [StringLength(1001, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcionIngles
        {
            get { return _descripcionIngles; }
            set { _descripcionIngles = value; }
        }

        public DataTable tablaTipoCliente { get; set; }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}