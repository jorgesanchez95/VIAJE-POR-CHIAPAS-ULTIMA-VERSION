using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ArticulosDatos
    {
        public ArticulosModels ObtenerListaArticulos(ArticulosModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaArticulos");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaArticulos = ds.Tables[0];
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
        public ArticulosModels ObtenerDetalleArticulosxId(ArticulosModels datos)
        {
            try
            {
                object[] parametros = { datos.id_post };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleArticuloXId", parametros);
                while (dr.Read())
                {
                    datos.id_post = dr["id_post"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.titulo = dr["titulo"].ToString();
                    datos.tituloIngles = dr["tituloIngles"].ToString();
                    datos.introduccion = dr["introduccion"].ToString();
                    datos.introduccionIngles = dr["introduccionIngles"].ToString();
                    datos.contenido = dr["contenido"].ToString();
                    datos.contenidoIngles = dr["contenidoIngles"].ToString();
                    datos.urlYoutube = dr["urlYoutube"].ToString();
                    datos.pathImg = dr["pathImg"].ToString();
                    datos.creadoPor = dr["creadoPor"].ToString();
                    datos.alt = dr["alt"].ToString();
                    datos.title = dr["title"].ToString();
                    datos.nombreArchivo = dr["nombre_arc"].ToString(); 
                    datos.nombre_pagina = dr["nombre_pagina"].ToString();
                    if (datos.nombre_pagina == "")
                        datos.nombre_pagina = Comun.RemoverSignosAcentos(datos.titulo);
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ArticulosModels AbcArticulos(ArticulosModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion,
                    datos.id_post,
                    datos.id_seccion,
                    datos.titulo,
                    datos.tituloIngles,
                    datos.introduccion,
                    datos.introduccionIngles,
                    datos.contenido,
                    datos.contenidoIngles,
                    datos.pathImg,
                    datos.urlYoutube,
                    datos.creadoPor,
                    datos.visitas,
                    datos.alt,
                    datos.title,
                    datos.nombreArchivo,
                    datos.tipoArchivo,
                    datos.nombre_pagina,
                    datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_Articulos", parametros);
                datos.id_post = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckArticuloArchivoNameArticulo(ArticulosModels articulo)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(articulo.conexion, "spCSLDB_get_CheckCatArticuloArchivoName", articulo.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         public bool CheckArticuloArchivoNameTituloEs(ArticulosModels articulo)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(articulo.conexion, "spCSLDB_get_CheckCatArticuloArchivoNombreEsp", articulo.titulo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         public bool CheckArticuloArchivoNameTituloIng(ArticulosModels articulo)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(articulo.conexion, "spCSLDB_get_CheckCatArticuloArchivoNombreIng", articulo.tituloIngles);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #region Pagina
        public ArticulosModels ObtenerConfigBlog(ArticulosModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_get_ConfigBlog",
                  new SqlParameter("@leguaje", datos.idioma),
                  new SqlParameter("@id_seccion", datos.id_seccion),
                  new SqlParameter("@offset", datos.offset),
                  new SqlParameter("@fetchNext", datos.fetchNext),
                  new SqlParameter("@idTag", datos.id_tags),
                  new SqlParameter("@banBuscar", datos.opcion),
                  new SqlParameter("@aBuscar", datos.aBuscar),
                  new SqlParameter("@id_metaTags", datos.id_metaTags),
                  new SqlParameter("@id_tipoMetaTags", datos.id_tipo)
                  );
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaArticulo = ds.Tables[1];
                            datos.tablaArticulosPopulares = ds.Tables[2];
                            datos.tablaTags = ds.Tables[3];
                            datos.tablaSeccion = ds.Tables[4];
                            datos.tablaSecciones = ds.Tables[5];
                            datos.tablaMetaTags = ds.Tables[6];
                            datos.numeroArticulos = Convert.ToInt32(ds.Tables[7].Rows[0][0]);
                            datos.TablaPaquetesPopulares = ds.Tables[8];
                            datos.TablaFormasDePago = ds.Tables[9];
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

        public ArticulosModels ObtenerConfigDetalleArticulo(ArticulosModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.nombre_pagina, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigDetalleArticulo", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaArticulo = ds.Tables[3];
                            datos.tablaArticulosPopulares = ds.Tables[4];
                            datos.tablaTags = ds.Tables[5];
                            datos.tablaSeccion = ds.Tables[6];
                            datos.tablaSecciones = ds.Tables[7];
                            datos.tablaMetaTags = ds.Tables[8];
                            datos.TablaPaquetesPopulares = ds.Tables[9];
                            datos.TablaFormasDePago = ds.Tables[10];
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
