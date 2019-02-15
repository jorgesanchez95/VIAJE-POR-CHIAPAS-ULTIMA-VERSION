using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoVehiculoDatos
    {
        #region Admin
        public TipoVehiculoModels ObtenerListaTipoVehiculo(TipoVehiculoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatTipoVehiculos");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaTipoVehiculo = ds.Tables[0];
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

        public TipoVehiculoModels ObtenerDetalleTipoVehiculoxId(TipoVehiculoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_tipoVehiculo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatTipoVehiculoXId", parametros);
                while (dr.Read())
                {
                    datos.id_tipoVehiculo= dr["id_tipoVehiculo"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoVehiculoModels AbcCatTipoVehiculo(TipoVehiculoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_tipoVehiculo, datos.descripcion,datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatTipoVehiculos", parametros);
                datos.id_tipoVehiculo = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Pagina
        public PaquetesModels ObtenerConfigPaquete(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPaquete", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaTags = ds.Tables[3];
                            datos.tablaPaquetes = ds.Tables[4];
                            datos.tablaSeccion = ds.Tables[5];
                            datos.tablaSecciones = ds.Tables[6];
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
        public PaquetesModels ObtenerConfigDetallePaquete(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_paquete };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigDetallePaquete", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaPaquetes = ds.Tables[3];
                            datos.tablaItinerario = ds.Tables[4];
                            datos.tablaSeccion = ds.Tables[5];
                            datos.tablaSecciones = ds.Tables[6];
                            datos.tablaLugares = ds.Tables[7];
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
        public PaquetesModels ObtenerConfigPaquetes(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion,datos.id_paquete };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPaqueteNew", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.nombre = ds.Tables[5].Rows[0][0].ToString();
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
        #endregion
    }
}
