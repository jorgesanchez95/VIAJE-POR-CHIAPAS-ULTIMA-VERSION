using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TagsMostrarModels
    {
        public string id_tagMostrar { get; set; }
        public string id_tag { get; set; }
        public string id_seccion { get; set; }
        public int indice { get; set; }

        public DataTable tablaTagsMostrar { get; set; }

        private List<CatTagsModels> _tablaTagsCmb;
        [Required(ErrorMessage = "El tag es obligatorio")]
        [Display(Name = "Tag")]
        public List<CatTagsModels> tablaTagsCmb
        {
            get { return _tablaTagsCmb; }
            set { _tablaTagsCmb = value; }
        }

        #region Control

        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }

        #endregion
    }
}