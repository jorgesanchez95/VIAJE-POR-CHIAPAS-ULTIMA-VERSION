using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TagsDatos
    {
        public CatTagsModels ObtenerListaTags(CatTagsModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatTags");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaTags = ds.Tables[0];
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

        public CatTagsModels ObtenerDetalleTagxId(CatTagsModels datos)
        {
            try
            {
                object[] parametros = { datos.id_tag };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatTagXId", parametros);
                while (dr.Read())
                {
                    datos.id_tag = dr["id_tag"].ToString();
                    datos.id_tipoTag = Convert.ToInt32(dr["id_tipoTag"].ToString());
                    datos.nombre = dr["nombre"].ToString();
                    datos.nombreIngles = dr["nombreIngles"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcionIngles"].ToString();
                    datos.icon = dr["icon"].ToString();
                    datos.pathImg = dr["pathImg"].ToString();
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

        public CatTagsModels AbcCatTags(CatTagsModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_tag, datos.id_tipoTag, datos.nombre, datos.nombreIngles, datos.descripcion, datos.descripcionIngles, 
                    datos.icon, datos.pathImg, datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatTags", parametros);
                datos.id_tag = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatTagsModels> ObtenerComboTags(RelacionTagsModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.id_datoRelacionado, datos.id_tipoTag
                };
                var lista = new List<CatTagsModels>();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTags", parametros);
                while (dr.Read())
                {
                    var item = new CatTagsModels();
                    item.id_tag = dr["id_tag"].ToString();
                    item.nombre = dr["nombre"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatTagsModels> ObtenerComboTagsMostrar(TagsMostrarModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.id_tagMostrar
                };
                var lista = new List<CatTagsModels>();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboTagsMostrar", parametros);
                while (dr.Read())
                {
                    var item = new CatTagsModels();
                    item.id_tag = dr["id_tag"].ToString();
                    item.nombre = dr["nombre"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoTagModels> ObtenerComboTipoTag(CatTagsModels datos)
        {
            try
            {
                List<TipoTagModels> lista = new List<TipoTagModels>();
                TipoTagModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoTag");
                while (dr.Read())
                {
                    item = new TipoTagModels();
                    item.id_tipoTag = Convert.ToInt32(dr["id_tipoTag"].ToString());
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckTagsArchivoNameTags(CatTagsModels tags)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(tags.conexion, "spCSLDB_get_CheckCatTagsArchivoName", tags.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
