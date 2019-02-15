using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class UsuarioCuentaModels
    {
        private string _id_usuario;

        public string id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        private string _usuario;

        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _conInt;

        public int conInt
        {
            get { return _conInt; }
            set { _conInt = value; }
        }

        private Boolean _estatus;

        public Boolean estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        private DateTime _fecBloqueo;

        public DateTime fecBloqueo
        {
            get { return _fecBloqueo; }
            set { _fecBloqueo = value; }
        }

        private DateTime _fecCaducidad;

        public DateTime fecCaducidad
        {
            get { return _fecCaducidad; }
            set { _fecCaducidad = value; }
        }

        private DataTable _tablaUsuariCuenta;

        public DataTable tablaUsuarioCuenta
        {
            get { return _tablaUsuariCuenta; }
            set { _tablaUsuariCuenta = value; }
        }

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