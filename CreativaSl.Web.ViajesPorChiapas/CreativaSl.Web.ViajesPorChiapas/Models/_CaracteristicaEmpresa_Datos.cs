using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CaracteristicaEmpresaDatos
    {
        public CaracteristicaEmpresaModels ObtenerListaCaracteristicaEmpresa(CaracteristicaEmpresaModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatCaracteristicaEmpresa");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaCaracteristicaEmpresa = ds.Tables[0];
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

        public CaracteristicaEmpresaModels ObtenerDetalleCaracteristicaEmpresaxId(CaracteristicaEmpresaModels datos)
        {
            try
            {
                object[] parametros = { datos.id_catacteristicaEmpresa };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatCaracteristicaEmpresaXId", parametros);
                while (dr.Read())
                {
                    datos.id_catacteristicaEmpresa = dr["id_catacteristicaEmpresa"].ToString();
                    datos.frase = dr["frase"].ToString();
                    datos.fraseIngles = dr["fraseIngles"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcionIngles"].ToString();
                    datos.urlImg = dr["urlImg"].ToString();
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

        public CaracteristicaEmpresaModels AbcCatCaracteristicaEmpresa(CaracteristicaEmpresaModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_catacteristicaEmpresa,datos.frase, datos.fraseIngles, datos.descripcion, datos.descripcionIngles, datos.urlImg,
                    datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatCaracteristicaEmpresa", parametros);
                datos.id_catacteristicaEmpresa = aux.ToString();
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
