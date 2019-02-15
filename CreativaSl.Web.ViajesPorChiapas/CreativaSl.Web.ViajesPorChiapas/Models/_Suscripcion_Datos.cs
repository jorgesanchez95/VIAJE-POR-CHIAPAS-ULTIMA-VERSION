using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class SuscripcionDatos
    {
        public SuscripcionModels ObtenerListaSuscripcion(SuscripcionModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaSuscripcion");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaSuscripcion = ds.Tables[0];
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
        public SuscripcionModels ObtenerDetalleSuscripcionxId(SuscripcionModels datos)
        {
            try
            {
                object[] parametros = { datos.id_suscripcion };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleSuscripcionXId", parametros);
                while (dr.Read())
                {
                    datos.id_suscripcion = dr["id_suscripcion"].ToString();
                    datos.correoSuscribirse = dr["correo"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcCatSuscripcion(SeccionModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_suscripcion,datos.correoSuscribirse, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_Suscripcion", parametros);
                datos.id_suscripcion = aux.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
