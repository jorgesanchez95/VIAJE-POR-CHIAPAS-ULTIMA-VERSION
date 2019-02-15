﻿using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class MunicipioModels
    {
        public int idioma { get; set; }
        public int id_municipio { get; set; }
        public string id_municipio2 { get; set; }
        public int id_estado { get; set; }
        public int id_pais { get; set; }

        private string _descripcion;
        [Display(Name = "Descripcion")]
        [StringLength(505, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descripcionIngles;
        [Display(Name = "Descripcion(Ingles)")]
        [StringLength(505, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y números")]
        public string descripcionIngles
        {
            get { return _descripcionIngles; }
            set { _descripcionIngles = value; }
        }

        #region Datos de control
        public bool activo { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion
    }
}