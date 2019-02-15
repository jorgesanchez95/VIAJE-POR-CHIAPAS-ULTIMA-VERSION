using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class HomeModels
    {
        public DataTable tablaSeccion { get; set; }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}