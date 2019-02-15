using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class GrupoModels
    {
        public string id_grupo { get; set; }

        private string _nombreGrupo;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre Grupo")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string nombreGrupo
        {
            get { return _nombreGrupo; }
            set { _nombreGrupo = value; }
        }

        public DataTable tablaGrupo { get; set; }

        private List<SeccionModels> _tablaGrupoCmb;
        [Required(ErrorMessage = "Grupo es un campo requerido")]
        [Display(Name = "Grupo")]
        public List<SeccionModels> tablaGrupoCmb
        {
            get { return _tablaGrupoCmb; }
            set { _tablaGrupoCmb = value; }
        }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}