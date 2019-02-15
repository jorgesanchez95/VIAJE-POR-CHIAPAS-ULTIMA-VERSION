using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoClienteModels
    {
        public int id_tipoCliente { get; set; }

        public string tipoCliente { get; set; }

        public DataTable tablaTipoCliente { get; set; }

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}