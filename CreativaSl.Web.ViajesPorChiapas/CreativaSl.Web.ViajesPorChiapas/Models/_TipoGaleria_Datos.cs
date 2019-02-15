using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoGaleriaDatos
    {
        public TipoGaleriaModels ObtenerListaCatTipoGaleria(TipoGaleriaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatTipoGaleria");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaTipoGaleria = ds.Tables[0];
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
        public TipoGaleriaModels ObtenerDetalleCatTipoGaleriaxId(TipoGaleriaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_tipoGaleria };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatTipoGaleriaXId", parametros);
                while (dr.Read())
                {
                    datos.id_tipoGaleria = dr["id_tipoGaleria"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcionIngles"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TipoGaleriaModels AbcCatTipoGaleria(TipoGaleriaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_tipoGaleria, datos.id_seccion ,datos.descripcion,datos.descripcionIngles, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatTipoGaleria", parametros);
                datos.id_tipoGaleria = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoGaleriaModels> ObtenerComboTipoGaleria(TipoGaleriaModels datos)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
