using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class PaisModels
    {
        public int id_pais { get; set; }

        public string A2 { get; set; }

        public string A3 { get; set; }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public DataTable tablaPaises { get; set; }

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion

    }
}