using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class SeccionDatos
    {
        public SeccionModels ObtenerListaSecciones(SeccionModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatSeccion");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaSeccion = ds.Tables[0];
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
        public SeccionModels ObtenerDetalleSeccionxId(SeccionModels datos)
        {
            try
            {
                object[] parametros = { datos.id_seccion };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatSeccionXId", parametros);
                while (dr.Read())
                {
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.nombreSeccion = dr["nombre_seccion"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.latitud = dr["latitud"].ToString();
                    datos.longitud = dr["longitud"].ToString();
                    datos.urlYoutube = dr["urlYoutube"].ToString();
                    datos.pathImg = dr["imagen"].ToString();
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
        public SeccionModels AbcCatSeccion(SeccionModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_seccion,datos.nombreSeccion, datos.descripcion, datos.latitud, datos.longitud, datos.urlYoutube, 
                    datos.pathImg, datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatSeccion", parametros);
                datos.id_seccion = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SeccionModels> ObtenerComboSecciones(SeccionModels datos)
        {
            try
            {
                List<SeccionModels> lista = new List<SeccionModels>();
                SeccionModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatSeccion");
                while (dr.Read())
                {
                    item = new SeccionModels();
                    item.id_seccion = dr["id_seccion"].ToString();
                    item.nombreSeccion = dr["nombre_seccion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Pagina
        public SeccionModels ObtenerHomeSeccion(SeccionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigSeccion2", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaBannerInicio = ds.Tables[1];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[2];
                            datos.TablaPromociones = ds.Tables[3];
                            datos.tablaTags = ds.Tables[4];
                            datos.tablaArticulos = ds.Tables[5];
                            datos.TablaTuors = ds.Tables[6];
                            datos.tablaSeccion = ds.Tables[7];
                            datos.tablaUbicacionesLugaresTuristicos = ds.Tables[8];
                            datos.tablaSecciones = ds.Tables[9];
                            datos.tablaMetaTags = ds.Tables[10];
                            datos.TablaDestinosPaquetes = ds.Tables[11];
                            datos.TablaDestinosTours = ds.Tables[12];
                            datos.TablaTestimoniales = ds.Tables[13];
                            datos.TablaPaquetesPopulares = ds.Tables[14];
                            datos.TablaFormasDePago = ds.Tables[15];
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

        public bool VerificarSeccion(SeccionModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_seccion,datos.nombreSeccion, datos.descripcion, datos.latitud, datos.longitud, datos.urlYoutube,
                    datos.pathImg, datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatSeccion", parametros);
                if(Convert.ToInt32(aux.ToString()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CheckSeccionesNameSeccion(SeccionModels Seccion)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(Seccion.conexion, "spCSLDB_get_CheckCatSeccionesArchivoName", Seccion.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region ObtenerMenu
        public SeccionModels ObtenerMenu(SeccionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_MenuDinamico", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaTopPaquetes = ds.Tables[1];
                            datos.TablaTuors = ds.Tables[2];
                            datos.TablaVehiculo = ds.Tables[3];
                            datos.TablaPromociones = ds.Tables[4];
                            datos.TablaDestinosPaquetes = ds.Tables[5];
                            datos.TablaDestinosTours = ds.Tables[6];
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
