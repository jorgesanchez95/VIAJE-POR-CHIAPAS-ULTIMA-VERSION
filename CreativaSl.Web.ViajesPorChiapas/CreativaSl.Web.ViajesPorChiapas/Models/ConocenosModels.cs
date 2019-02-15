using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ConocenosModels
    {
        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaSeccion { get; set; }
        public DataTable tablaArticulos { get; set; }
       

        public string id_seccion { get; set; }
        public int idioma { get; set; }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }

        #region AuxiliaresSuscribirse
        public string id_suscripcion { get; set; }

        private string _correoSuscribirse;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string correoSuscribirse
        {
            get { return _correoSuscribirse; }
            set { _correoSuscribirse = value; }
        }
        #endregion

        #region Control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}