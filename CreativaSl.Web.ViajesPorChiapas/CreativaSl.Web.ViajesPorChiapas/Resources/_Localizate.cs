using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Resources
{
    public class Localizate
    {
        public string GetResource(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return ResourceUS.ResourceManager.GetString(resourceName);
                return ResourceMX.ResourceManager.GetString(resourceName);
            }
            return ResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceSeccion(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return SeccionResourceUS.ResourceManager.GetString(resourceName);
                return SeccionResourceMX.ResourceManager.GetString(resourceName);
            }
            return SeccionResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceConocenos(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return ConocenosResourceUS.ResourceManager.GetString(resourceName);
                return ConocenosResourceMX.ResourceManager.GetString(resourceName);
            }
            return ConocenosResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceContacto(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return ContactoResourceUS.ResourceManager.GetString(resourceName);
                return ContactoResourceMX.ResourceManager.GetString(resourceName);
            }
            return ContactoResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceGaleria(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return GaleriaResourceUS.ResourceManager.GetString(resourceName);
                return GaleriaResourceMX.ResourceManager.GetString(resourceName);
            }
            return GaleriaResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceDetallePaquete(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return DetallePaqueteResourceUS.ResourceManager.GetString(resourceName);
                return DetallePaqueteResourceMX.ResourceManager.GetString(resourceName);
            }
            return DetallePaqueteResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceTour(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return ToursResourceUS.ResourceManager.GetString(resourceName);
                return ToursResourceMX.ResourceManager.GetString(resourceName);
            }
            return ToursResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourcePaquete(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return PaquetesResourceUS.ResourceManager.GetString(resourceName);
                return PaquetesResourceMX.ResourceManager.GetString(resourceName);
            }
            return PaquetesResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceCotizar(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return CotizarPaqueteResourceUS.ResourceManager.GetString(resourceName);
                return CotizarPaqueteResourceMX.ResourceManager.GetString(resourceName);
            }
            return CotizarPaqueteResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceCotizarPaqueteVip(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return CotizarPaqueteVipResourceUS.ResourceManager.GetString(resourceName);
                return CotizarPaqueteVipResourceMX.ResourceManager.GetString(resourceName);
            }
            return CotizarPaqueteVipResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceCotizarHotel(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return CotizarHotelResourceUS.ResourceManager.GetString(resourceName);
                return CotizarHotelResourceMX.ResourceManager.GetString(resourceName);
            }
            return CotizarHotelResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceCotizarTours(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return CotizarToursResourceUS.ResourceManager.GetString(resourceName);
                return CotizarToursResourceMX.ResourceManager.GetString(resourceName);
            }
            return CotizarToursResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceHoteles(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return HotelesResourceUS.ResourceManager.GetString(resourceName);
                return HotelesResourceMX.ResourceManager.GetString(resourceName);
            }
            return HotelesResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceTransportacion(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return TransportacionResourceUS.ResourceManager.GetString(resourceName);
                return TransportacionResourceMX.ResourceManager.GetString(resourceName);
            }
            return TransportacionResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourcePromociones(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return PromocionesResourceUS.ResourceManager.GetString(resourceName);
                return PromocionesResourceMX.ResourceManager.GetString(resourceName);
            }
            return PromocionesResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceDetalleArticulo(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return DetalleArticuloResourceUS.ResourceManager.GetString(resourceName);
                return DetalleArticuloResourceMX.ResourceManager.GetString(resourceName);
            }
            return DetalleArticuloResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceBlog(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return BlogsResourceUS.ResourceManager.GetString(resourceName);
                return BlogsResourceMX.ResourceManager.GetString(resourceName);
            }
            return BlogsResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceHome(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return HomeResourceUS.ResourceManager.GetString(resourceName);
                return HomeResourceMX.ResourceManager.GetString(resourceName);
            }
            return HomeResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceLogin(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return LoginResourceUS.ResourceManager.GetString(resourceName);
                return LoginResourceMX.ResourceManager.GetString(resourceName);
            }
            return LoginResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceComprarCotizaciones(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return ComprarCotizacionesResourceUS.ResourceManager.GetString(resourceName);
                return ComprarCotizacionesResourceMX.ResourceManager.GetString(resourceName);
            }
            return ComprarCotizacionesResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceCotizacionSolicitud(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return CotizacionSolicitudResourceUS.ResourceManager.GetString(resourceName);
                return CotizacionSolicitudResourceMX.ResourceManager.GetString(resourceName);
            }
            return CotizacionSolicitudResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceDetalleSolicitud(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return DetalleSolicitudResourceUS.ResourceManager.GetString(resourceName);
                return DetalleSolicitudResourceMX.ResourceManager.GetString(resourceName);
            }
            return DetalleSolicitudResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceMiCuenta(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return MiCuentaResourceUS.ResourceManager.GetString(resourceName);
                return MiCuentaResourceMX.ResourceManager.GetString(resourceName);
            }
            return MiCuentaResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceResetPassword(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return ResetPasswordResourceUS.ResourceManager.GetString(resourceName);
                return ResetPasswordResourceMX.ResourceManager.GetString(resourceName);
            }
            return ResetPasswordResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourcePagoRealizado(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return PagoRealizadoResourceUS.ResourceManager.GetString(resourceName);
                return PagoRealizadoResourceMX.ResourceManager.GetString(resourceName);
            }
            return PagoRealizadoResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceRecomendaciones(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return RecomendacionesResourceUS.ResourceManager.GetString(resourceName);
                return RecomendacionesResourceMX.ResourceManager.GetString(resourceName);
            }
            return RecomendacionesResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceTipoPagos(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return TipoPagosResourceUS.ResourceManager.GetString(resourceName);
                return TipoPagosResourceMX.ResourceManager.GetString(resourceName);
            }
            return TipoPagosResourceMX.ResourceManager.GetString(resourceName);
        }
        public string GetResourceTerminosYCondiciones(string resourceName)
        {
            if (HttpContext.Current.Session["locale"] != null)
            {
                string language = HttpContext.Current.Session["locale"].ToString();
                if (language == "en")
                    return TerminosYCondiconesResourceUS.ResourceManager.GetString(resourceName);
                return TerminosYCondiconesResourceMX.ResourceManager.GetString(resourceName);
            }
            return TerminosYCondiconesResourceMX.ResourceManager.GetString(resourceName);
        }
    }
}