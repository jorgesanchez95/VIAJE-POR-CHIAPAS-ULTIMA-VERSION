using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class IntegrantesGrupoModels
    {
        public string id_integranteGrupo { get; set; }
        public string id_cliente { get; set; }
        public string id_grupo { get; set; }

        public DataTable tablaIntegranteGrupo { get; set; }

        private List<CorreosUsuarioModels> _tablaClientesCmb;
        [Required(ErrorMessage = "El cliente es obligatorio")]
        [Display(Name = "Cliente")]
        public List<CorreosUsuarioModels> tablaClientesCmb
        {
            get { return _tablaClientesCmb; }
            set { _tablaClientesCmb = value; }
        }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}