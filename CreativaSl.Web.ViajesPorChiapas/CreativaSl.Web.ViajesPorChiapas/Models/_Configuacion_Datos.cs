using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ConfiguracionDatos
    {
        public ConfiguracionModels ObtenerListaConfiguracion(ConfiguracionModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaConfiguracionPagina");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaConfiguracion = ds.Tables[0];
                        }
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ConfiguracionModels ObtenerDetalleConfiguracionPaginaxId(ConfiguracionModels datos)
        {
            try
            {
                object[] parametros = { datos.id_configuracion };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleConfiguracionPaginaXId", parametros);
                while (dr.Read())
                {
                    datos.id_configuracion = dr["id_configuracion"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.correo = dr["correo"].ToString();
                    datos.textoUno = dr["textoUno"].ToString();
                    datos.textoUnoIngles = dr["textoUnoIngles"].ToString();
                    datos.topCinco = dr["topCinco"].ToString();
                    datos.topCincoIngles = dr["topCincoIngles"].ToString();
                    datos.textoDos = dr["textoDos"].ToString();
                    datos.textoDosIngles = dr["textoDosIngles"].ToString();
                    datos.newsletter = dr["newsletter"].ToString();
                    datos.newsletterIngles = dr["newsletterIngles"].ToString();
                    datos.pieAcerca = dr["pieAcerca"].ToString();
                    datos.pieAcercaIngles = dr["pieAcercaIngles"].ToString();
                    datos.direccion = dr["direccion"].ToString();
                    datos.facebook = dr["facebook"].ToString();
                    datos.twitter = dr["twitter"].ToString();
                    datos.instagram = dr["instagram"].ToString();
                    datos.youtube = dr["youtube"].ToString();
                    datos.google = dr["google"].ToString();
                    datos.contactanos = dr["contactanos"].ToString();
                    datos.contactanosIngles = dr["contactanosIngles"].ToString();
                    datos.quienEs = dr["quienEs"].ToString();
                    datos.quienEsIngles = dr["quienEsIngles"].ToString();
                    datos.nuestrosServicios = dr["nuestrosServicios"].ToString();
                    datos.nuestrosServiciosIngles = dr["nuestrosServiciosIngles"].ToString();
                    datos.servicioBoletos = dr["servicioBoletos"].ToString();
                    datos.servicioBoletosIngles = dr["servicioBoletosIngles"].ToString();
                    datos.servicioHotel = dr["servicioHotel"].ToString();
                    datos.servicioHotelIngles = dr["servicioHotelIngles"].ToString();
                    datos.servicioTraslado = dr["servicioTraslado"].ToString();
                    datos.servicioTrasladoIngles = dr["servicioTrasladoIngles"].ToString();
                    datos.servicioPaquetes = dr["servicioPaquetes"].ToString();
                    datos.servicioPaquetesIngles = dr["servicioPaquetesIngles"].ToString();
                    datos.pathImg = dr["pathImg"].ToString();
                    datos.descripcionTransportacion = dr["descripcionTransportacion"].ToString();
                    datos.descripcionTransportacionIngles = dr["descripcionTransportacionIngles"].ToString();
                    
                    datos.detalleTransportacion = dr["detalleTransportacion"].ToString();
                    datos.detalleTransportacionIngles = dr["detalleTransportacionIngles"].ToString();
                    datos.terminosCondiciones = dr["terminosCondiciones"].ToString();
                    datos.terminosCondicionesIngles = dr["terminosCondicionesIngles"].ToString();
                    datos.alt = dr["alt"].ToString();
                    datos.title = dr["title"].ToString();
                    datos.nombreArchivo = dr["nombre_arc"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ConfiguracionModels AbcCatConfiguracion(ConfiguracionModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_configuracion,datos.telefono, datos.correo, datos.textoUno,
                    datos.textoUnoIngles,datos.topCinco, datos.topCincoIngles ,datos.textoDos,datos.textoDosIngles,
                    datos.newsletter,datos.newsletterIngles, datos.pieAcerca,datos.pieAcercaIngles,
                    datos.direccion,datos.facebook, datos.twitter, datos.instagram,datos.youtube,datos.google,
                    datos.contactanos, datos.contactanosIngles, datos.quienEs, datos.quienEsIngles, datos.nuestrosServicios,
                    datos.nuestrosServiciosIngles, datos.servicioBoletos, datos.servicioBoletosIngles, datos.servicioHotel,
                    datos.servicioHotelIngles, datos.servicioTraslado, datos.servicioTrasladoIngles,
                    datos.servicioPaquetes, datos.servicioPaquetesIngles, datos.pathImg, datos.descripcionTransportacion,datos.descripcionTransportacionIngles, 
                    datos.detalleTransportacion, datos.detalleTransportacionIngles, datos.terminosCondiciones, datos.terminosCondicionesIngles,
                    datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo,datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_ConfiguracionPagina", parametros);
                datos.id_configuracion = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckConfiguracionesArchivoNameConfig(ConfiguracionModels config)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(config.conexion, "spCSLDB_get_CheckConfiguracionsPaginasArchivoName", config.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
