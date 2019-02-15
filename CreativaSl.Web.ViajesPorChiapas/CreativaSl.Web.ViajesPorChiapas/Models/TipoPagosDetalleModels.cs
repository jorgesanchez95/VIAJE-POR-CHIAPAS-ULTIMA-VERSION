using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoPagosDetalleModels
    {

        [Required(ErrorMessage = "El nombre de la imagen es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\-0-9]*$", ErrorMessage = "Solo Letras, Guion Medio, Sin espacios")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y máximo {1}.", MinimumLength = 1)]
        [Remote("CheckNameDepositoTransAvailability", "DepositosTransferencia", ErrorMessage = "El nombre de la Imagen ya esta asignado")]
        public string nombreArchivo { get; set; }

        public string tipoArchivo { get; set; }

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


        public string idDepositosTransferencia { get; set; }

        public int id_tipoPago { get; set; }

        public string tipoPago { get; set; }

        private string _pathDepositosTransferencia;
        public string pathDepositosTransferencia
        {
            get { return _pathDepositosTransferencia; }
            set { this._pathDepositosTransferencia = value; }
        }

        private HttpPostedFileBase _foto2;
        [Display(Name = "Imagen")]
        [FileExtensions(Extensions = "png,jpg,jpeg", ErrorMessage = "Solo imagenes")]
        public HttpPostedFileBase foto2
        {
            get { return _foto2; }
            set { _foto2 = value; }
        }

        private string _banco;
        public string banco
        {
            get { return _banco; }
            set { this._banco = value; }
        }

        private string _titular;
        public string titular
        {
            get { return _titular; }
            set { this._titular = value; }
        }

        private string _numeroReferencia;
        public string numeroReferencia
        {
            get { return _numeroReferencia; }
            set { this._numeroReferencia = value; }
        }

        public DataTable tablaCatTipoPagosDetalle { get; set; }
        public List<TipoPagosDetalleModels> tablaTipoPagoCmb { get; set; }

        #region Control
        public bool activo { get; set; }
        public bool estado { get; set; }
        public string user { get; set; }
        public string conexion { get; set; }
        public int opcion { get; set; }
        #endregion

        public DataTable tablaDatosGenerales { get; set; }
        public DataTable tablaCaracteristicasEmpresa { get; set; }
        public DataTable tablaTags { get; set; }
        public DataTable tablaSecciones { get; set; }
        public DataTable tablaSeccion { get; set; }
        public DataTable tablaArticulos { get; set; }

        public int idioma { get; set; }
        public string id_suscripcion { get; set; }
        public string id_seccion { get; set; }

        public string id_metaTags { get; set; }
        public int id_tipo { get; set; }
        public DataTable tablaMetaTags { get; set; }
        public DataTable TablaPaquetesPopulares { get; set; }
        public DataTable TablaFormasDePago { get; set; }

    }
}