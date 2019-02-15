using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class RecomendacionesModels
    {
        public string id_recomendacion { get; set; }
        public string id_seccion { get; set; }


        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaSeccion { get; set; }
        public DataTable tablaArticulos { get; set; }
        public DataTable tablaTipoGaleria { get; set; }
        public DataTable tablaGaleria { get; set; }

        public int idioma { get; set; }
        public string id_suscripcion { get; set; }

        private string _correoSuscribirse;
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        public string correoSuscribirse
        {
            get { return _correoSuscribirse; }
            set { _correoSuscribirse = value; }
        }


        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}