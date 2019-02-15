using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class MultimediaDatos
    {
        public List<TipoGaleriaModels> ObtenerComboTipoGaleria(MultimediaModels datos) 
        {
            try
            {
                List<TipoGaleriaModels> lista = new List<TipoGaleriaModels>();
                TipoGaleriaModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoGaleria");
                while (dr.Read())
                {
                    item = new TipoGaleriaModels();
                    item.id_tipoGaleria = dr["id_tipoGaleria"].ToString();
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        #region BannerInicio
        public MultimediaModels ObtenerListaMultimediaXBannerInicio(MultimediaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatMultimediaXBannerInicio");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaMultimedia = ds.Tables[0];
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

        public MultimediaModels ObtenerDetalleMultimediaBannerInicioxId(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_multimedia };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatMultimediaXBannerInicioXId", parametros);
                while (dr.Read())
                {
                    datos.id_multimedia = dr["id_multimedia"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcion_ingles"].ToString();
                    datos.pathMul = dr["pathMul"].ToString();
                    datos.title = dr["title"].ToString();
                    datos.alt = dr["alt"].ToString();
                    datos.nombreArchivo = dr["nombre_arc"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MultimediaModels AbcCatMultimediaXBannerInicio(MultimediaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_multimedia, datos.id_seccion, datos.descripcion,
                    datos.descripcionIngles, datos.nombreArchivo, datos.tipoArchivo, datos.pathMul, datos.alt, datos.title, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatMultimediaXBannerInicio", parametros);
                datos.id_multimedia = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Banner
        public MultimediaModels ObtenerListaMultimediaXBanner(MultimediaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatMultimediaXBanner");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaMultimedia = ds.Tables[0];
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

        public MultimediaModels ObtenerDetalleMultimediaBannerxId(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_multimedia };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatMultimediaXBannerXId", parametros);
                while (dr.Read())
                {
                    datos.id_multimedia = dr["id_multimedia"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcion_ingles"].ToString();
                    datos.pathMul = dr["pathMul"].ToString();
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

        public MultimediaModels AbcCatMultimediaXBanner(MultimediaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_multimedia, datos.id_seccion, datos.descripcion,
                    datos.descripcionIngles, datos.nombreArchivo, datos.tipoArchivo, datos.pathMul, datos.alt, datos.title, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatMultimediaXBanner", parametros);
                datos.id_multimedia = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Encabezado
        public MultimediaModels ObtenerListaMultimediaXEncabezado(MultimediaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatMultimediaXEncabezado");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaMultimedia = ds.Tables[0];
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

        public MultimediaModels ObtenerDetalleMultimediaEncabezadoxId(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_multimedia };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatMultimediaXEncabezadoXId", parametros);
                while (dr.Read())
                {
                    datos.id_multimedia = dr["id_multimedia"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.nombreIngles = dr["nombreIngles"].ToString();
                    datos.fec_ini = Convert.ToDateTime(dr["fec_ini"].ToString());
                    datos.fec_fin = Convert.ToDateTime(dr["fec_fin"].ToString());
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcion_ingles"].ToString();
                    datos.pathMul = dr["pathMul"].ToString(); 
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

        public MultimediaModels AbcCatMultimediaXEncabezado(MultimediaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_multimedia, datos.id_seccion, datos.descripcion,
                    datos.descripcionIngles, datos.nombre,datos.nombreIngles,datos.fec_ini,datos.fec_fin,datos.nombre_pagina, datos.nombreArchivo, datos.tipoArchivo, datos.pathMul, datos.alt, datos.title, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatMultimediaXEncabezado", parametros);
                datos.id_multimedia = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Lugar
        public MultimediaModels ObtenerListaMultimediaXLugar(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_lugar };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatMultimediaXLugar", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaMultimedia = ds.Tables[0];
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

        public MultimediaModels ObtenerDetalleMultimediaLugarxId(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_multimedia };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatMultimediaXLugarXId", parametros);
                while (dr.Read())
                {
                    datos.id_multimedia = dr["id_multimedia"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcion_ingles"].ToString();
                    datos.pathMul = dr["pathMul"].ToString();
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

        public MultimediaModels AbcCatMultimediaXLugar(MultimediaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_multimedia, datos.id_lugar, datos.id_seccion, datos.descripcion,
                    datos.descripcionIngles, datos.nombreArchivo, datos.tipoArchivo, datos.pathMul, datos.alt, datos.title, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatMultimediaXLugares", parametros);
                datos.id_multimedia = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Galeria
        public MultimediaModels ObtenerListaMultimediaXGaleria(MultimediaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatMultimediaXGaleria");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaMultimedia = ds.Tables[0];
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
        public MultimediaModels ObtenerDetalleMultimediaGaleriaxId(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_multimedia };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatMultimediaXGaleriaXId", parametros);
                while (dr.Read())
                {
                    datos.id_multimedia = dr["id_multimedia"].ToString();
                    datos.id_tipoGaleria = dr["id_tipoGaleria"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcion_ingles"].ToString();
                    datos.pathMul = dr["pathMul"].ToString();
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
        public MultimediaModels AbcCatMultimediaXGaleria(MultimediaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_multimedia, datos.id_tipoGaleria, datos.id_seccion, datos.descripcion,
                    datos.descripcionIngles, datos.nombreArchivo, datos.tipoArchivo, datos.pathMul, datos.alt, datos.title, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatMultimediaXGaleria", parametros);
                datos.id_multimedia = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Front-End
        public MultimediaModels ObtenerConfigGalerias(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigGaleria", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaTipoGaleria = ds.Tables[1];
                            datos.tablaGaleria = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.TablaPaquetesPopulares = ds.Tables[6];
                            datos.TablaFormasDePago = ds.Tables[7];
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
        public List<TipoGaleriaModels> ObtenerComboTipoGaleriaXSeccion(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_seccion };
                List<TipoGaleriaModels> lista = new List<TipoGaleriaModels>();
                TipoGaleriaModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoGaleriaXSeccion", parametros);
                while (dr.Read())
                {
                    item = new TipoGaleriaModels();
                    item.id_tipoGaleria = dr["id_tipoGaleria"].ToString();
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
        #endregion
        #region Promociones
        public MultimediaModels ObtenerConfigPromociones(MultimediaModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPromociones", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaMultimedia = ds.Tables[3];
                            datos.tablaSeccion = ds.Tables[4];
                            datos.tablaSecciones = ds.Tables[5];
                            datos.tablaMetaTags = ds.Tables[6];
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

        public bool CheckGaleriaArchivoNameGaleria(MultimediaModels multimedia)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(multimedia.conexion, "spCSLDB_get_CheckGaleriaArchivoName", multimedia.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
