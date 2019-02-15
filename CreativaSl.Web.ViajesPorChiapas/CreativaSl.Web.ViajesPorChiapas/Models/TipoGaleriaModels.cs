using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoGaleriaModels
    {
        public string id_tipoGaleria { get; set; }
        public string id_seccion { get; set; }

        private string _descripcion;
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripcion")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descripcionIngles;
        [Required(ErrorMessage = "La descripcion(Ingles) es obligatoria")]
        [Display(Name = "Descripcion(Ingles)")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]

        public string descripcionIngles
        {
            get { return _descripcionIngles; }
            set { _descripcionIngles = value; }
        }

        public DataTable tablaTipoGaleria { get; set; }

        private List<SeccionModels> _tablaSeccionesCmb;
        [Required(ErrorMessage = "Seccion es un campo requerido")]
        [Display(Name = "Sección")]
        public List<SeccionModels> tablaSeccionesCmb
        {
            get { return _tablaSeccionesCmb; }
            set { _tablaSeccionesCmb = value; }
        }

        #region Control
        private bool _activo;
        public bool activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        private string _user;
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }
        #endregion
    }
}