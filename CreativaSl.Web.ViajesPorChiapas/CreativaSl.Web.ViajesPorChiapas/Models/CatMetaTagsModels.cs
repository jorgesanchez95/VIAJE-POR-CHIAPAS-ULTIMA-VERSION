using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CatMetaTagsModels
    {
        private string _id_metaTags;

        public string id_metaTags
        {
            get { return _id_metaTags; }
            set { _id_metaTags = value; }
        }

        private int _id_tipo;

        public int id_tipo
        {
            get { return _id_tipo; }
            set { _id_tipo = value; }
        }

        private string _alt;
        [Required(ErrorMessage = "Alt es obligatorio")]
        [Display(Name = "Alt")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        public string alt
        {
            get { return _alt; }
            set { _alt = value; }
        }

        private string _title;
        [Required(ErrorMessage = "Title es obligatorio")]
        [Display(Name = "Title")]
        [StringLength(5000, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _canonical;

        public string canonical
        {
            get { return _canonical; }
            set { _canonical = value; }
        }

        private string _description;

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _subjetc;

        public string subjetc
        {
            get { return _subjetc; }
            set { _subjetc = value; }
        }

        private string _keywords;

        public string keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        private string _robots;

        public string robots
        {
            get { return _robots; }
            set { _robots = value; }
        }
        
        private string _author;

        public string author
        {
            get { return _author; }
            set { _author = value; }
        }

        private DataTable _tablaMetaTags;

        public DataTable tablaMetaTags
        {
            get { return _tablaMetaTags; }
            set { _tablaMetaTags = value; }
        }

        private DataTable _cmbRobots;

        public DataTable cmbRobots
        {
            get { return _cmbRobots; }
            set { _cmbRobots = value; }
        }
        
        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}