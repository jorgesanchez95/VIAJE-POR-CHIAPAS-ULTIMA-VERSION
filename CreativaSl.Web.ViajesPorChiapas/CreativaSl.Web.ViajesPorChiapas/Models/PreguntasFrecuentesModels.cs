using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class PreguntasFrecuentesModels
    {
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }
        public string id_preguntaFrecuente { get; set; }
        public string id_seccion { get; set; }

        private string _pregunta;
        [Required(ErrorMessage = "La pregunta es obligatoria")]
        [Display(Name = "Pregunta")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\?\¿\s]*$", ErrorMessage = "Solo Letras y números")]
        public string pregunta
        {
            get { return _pregunta; }
            set { this._pregunta = value; }
        }

        private string _respuesta;
        [Required(ErrorMessage = "La respuesta es obligatoria")]
        [Display(Name = "Respuesta")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\?\¿\s]*$", ErrorMessage = "Solo Letras y números")]
        public string respuesta
        {
            get { return _respuesta; }
            set { this._respuesta = value; }
        }

        private string _preguntaIngles;
        [Required(ErrorMessage = "La pregunta en ingles es obligatoria")]
        [Display(Name = "Pregunta en Ingles")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\?\¿\s]*$", ErrorMessage = "Solo Letras y números")]
        public string preguntaIngles
        {
            get { return _preguntaIngles; }
            set { this._preguntaIngles = value; }
        }

        private string _respuestaIngles;
        [Required(ErrorMessage = "La respuesta en ingles es obligatoria")]
        [Display(Name = "Respuesta en Ingles")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\?\¿\s]*$", ErrorMessage = "Solo Letras y números")]
        public string respuestaIngles
        {
            get { return _respuestaIngles; }
            set { this._respuestaIngles = value; }
        }

        public DataTable tablaPreguntasFrecuentes { get; set; }

        private List<SeccionModels> _tablaSeccionesCmb;
        [Required(ErrorMessage = "Seccion es un campo requerido")]
        [Display(Name = "Sección")]
        public List<SeccionModels> tablaSeccionesCmb
        {
            get { return _tablaSeccionesCmb; }
            set { _tablaSeccionesCmb = value; }
        }


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

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}