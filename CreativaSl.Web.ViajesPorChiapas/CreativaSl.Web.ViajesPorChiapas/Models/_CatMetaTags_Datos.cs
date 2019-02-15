using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CatMetaTagsDatos
    {
        public CatMetaTagsModels ObtenerListaCatMetaTags(CatMetaTagsModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatMetaTags");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaMetaTags = ds.Tables[0];
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

        public CatMetaTagsModels ObtenerDetalleCatMetaTagsxId(CatMetaTagsModels datos)
        {
            try
            {
                object[] parametros = { datos.id_metaTags, datos.id_tipo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatMetaTagsXId", parametros);
                while (dr.Read())
                {
                    datos.id_metaTags = dr["id_metaTags"].ToString();
                    datos.title = dr["title"].ToString();
                    datos.canonical = dr["canonical"].ToString();
                    datos.description = dr["description"].ToString();
                    datos.subjetc = dr["subjetc"].ToString();
                    datos.keywords = dr["keywords"].ToString();
                    datos.robots = dr["robots"].ToString();
                    datos.author = dr["author"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CatMetaTagsModels AbcCatMetaTags (CatMetaTagsModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_metaTags, datos.id_tipo, datos.title, datos.canonical, datos.description, datos.subjetc,
                    datos.keywords, datos.robots, datos.author, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatMetaTags", parametros);
                datos.id_metaTags = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckCaracteristicaEmpresaArchivoNameTours(CaracteristicaEmpresaModels Caracteristica)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(Caracteristica.conexion, "spCSLDB_get_CheckCatCaracteristicaEmpresaArchivoName", Caracteristica.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
