using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CorreosUsuarioModels
    {
        private string _id_cliente;
        public string id_cliente
        {
            get { return _id_cliente; }
            set { _id_cliente = value; }
        }

        private string _nombre;
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(505, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y numeros")]

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _correo;
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        [RegularExpression(@"^[._A-Za-z0-9-\\+]+(\\.[._A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Correo no Valido")]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckEmailAvailability", "Account", ErrorMessage = "Este Correo esta ocupado")]
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }


        private DataTable _tablaCorreosUsuario;
        public DataTable tablaCorreosUsuario
        {
            get { return _tablaCorreosUsuario; }
            set { _tablaCorreosUsuario = value; }
        }

        #region Control
        private bool _activo;
        public bool activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        private string _user;
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }
        #endregion
    }
}