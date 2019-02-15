using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TagsMostrarDatos
    {
        public TagsMostrarModels ObtenerListaTagsMostrar(TagsMostrarModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaTagsMostrar");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaTagsMostrar = ds.Tables[0];
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

        public TagsMostrarModels ObtenerDetalleTagMostarxId(TagsMostrarModels datos)
        {
            try
            {
                object[] parametros = { datos.id_tagMostrar };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleTagMostarXId", parametros);
                while (dr.Read())
                {
                    datos.id_tagMostrar = dr["id_tagMostrar"].ToString();
                    datos.id_tag = dr["id_tag"].ToString();
                    datos.indice = Convert.ToInt32(dr["indice"].ToString());
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcTagsMostrar(TagsMostrarModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_tagMostrar, datos.id_tag, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_TagsMostrar", parametros);
                datos.id_tagMostrar = aux.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
