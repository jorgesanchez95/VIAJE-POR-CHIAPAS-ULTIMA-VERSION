using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ItinerarioDatos
    {
        public ItinerarioModels ObtenerListaItinerarioXIdPaquete(ItinerarioModels datos)
        {
            try
            {
                object[] parametros = {datos.id_paquete};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatItinerarioXPaquete", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaItinerarios = ds.Tables[0];
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

        public ItinerarioModels ObtenerListaItinerarioXIdTour(ItinerarioModels datos)
        {
            try
            {
                object[] parametros = { datos.id_paquete };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatItinerarioXTour", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaItinerarios = ds.Tables[0];
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

        public ItinerarioModels ObtenerDetalleItinerarioxId(ItinerarioModels datos)
        {
            try
            {
                object[] parametros = { datos.id_itinerario };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatItinerarioXId", parametros);
                while (dr.Read())
                {
                    datos.id_itinerario = dr["id_itinerario"].ToString();
                    datos.id_paquete = dr["id_paquete"].ToString();
                    datos.id_lugar = dr["id_lugar"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.nombreIngles = dr["nombreIngles"].ToString();
                    datos.horaSalida = dr["horasalida"].ToString();
                    datos.orden = Convert.ToInt32(dr["orden"].ToString());
                    datos.lugarSalida = dr["lugarsalida"].ToString();
                    datos.finDeServicios = dr["finServicio"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcionIngles"].ToString();
                    datos.observaciones = dr["observaciones"].ToString();
                    datos.observacionesIngles = dr["observacionesIngles"].ToString();
                    datos.recomendaciones = dr["recomendaciones"].ToString();
                    datos.recomendacionesIngles = dr["recomendaciones_ingles"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ItinerarioModels AbcCatItinerario(ItinerarioModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_itinerario, datos.id_paquete, datos.id_lugar, datos.nombre, datos.nombreIngles,
                    datos.descripcion, datos.descripcionIngles, datos.observaciones,datos.observacionesIngles,
                    datos.recomendaciones,datos.recomendacionesIngles,datos.finDeServicios, datos.lugarSalida,
                    datos.horaSalida,datos.orden,datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatItinerario", parametros);
                datos.id_itinerario = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
