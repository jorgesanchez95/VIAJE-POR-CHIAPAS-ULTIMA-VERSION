using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class LugaresTuristicosDatos
    {
        public LugaresTuristicosModels ObtenerListaLugaresTuristicos(LugaresTuristicosModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatLugaresTuristicos");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaLugaresTuristicos = ds.Tables[0];
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

        public LugaresTuristicosModels ObtenerDetalleLugaresTuristicosxId(LugaresTuristicosModels datos)
        {
            try
            {
                object[] parametros = { datos.id_lugar };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatLugaresTuriticosXId", parametros);
                while (dr.Read())
                {
                    datos.id_lugar = dr["id_lugar"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.id_pais = Convert.ToInt32(dr["id_pais"].ToString());
                    datos.id_estado = Convert.ToInt32(dr["id_estado"].ToString());
                    datos.id_municipio = Convert.ToInt32(dr["id_municipio"].ToString());
                    datos.nombre = dr["nombre"].ToString();
                    datos.latitud = dr["latitud"].ToString();
                    datos.longitud = dr["longitud"].ToString();
                    datos.pathImg = dr["pathImg"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcion_ingles = dr["descripcion_ingles"].ToString();
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

        public LugaresTuristicosModels AbcCatLugaresTuristicos(LugaresTuristicosModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_lugar, datos.id_seccion, datos.nombre, datos.id_pais, datos.id_estado, datos.id_municipio,
                    datos.latitud, datos.longitud, datos.pathImg, datos.descripcion, datos.descripcion_ingles, datos.alt, datos.title,datos.nombreArchivo, datos.tipoArchivo, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatLugaresTuristicos", parametros);
                datos.id_lugar = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LugaresTuristicosModels> ObtenerComboLugares(LugaresTuristicosModels datos)
        {
            try
            {
                List<LugaresTuristicosModels> lista = new List<LugaresTuristicosModels>();
                LugaresTuristicosModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatLugaresTuristicos");
                while (dr.Read())
                {
                    item = new LugaresTuristicosModels();
                    item.id_lugar = dr["id_lugar"].ToString();
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

        public List<LugaresTuristicosModels> ObtenerComboLugaresXSeccion(LugaresTuristicosModels datos)
        {
            try
            {
                List<LugaresTuristicosModels> lista = new List<LugaresTuristicosModels>();
                LugaresTuristicosModels item;
                object[] parametros = { datos.id_seccion};
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatLugaresTuristicosXSeccion", parametros);
                while (dr.Read())
                {
                    item = new LugaresTuristicosModels();
                    item.id_lugar = dr["id_lugar"].ToString();
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

        public bool CheckLugaresTuristicosArchivoNameLugares(LugaresTuristicosModels Lugares)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(Lugares.conexion, "spCSLDB_get_CheckCatLugaresTuristicosArchivoName", Lugares.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
