using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class _CatVehiculos_Datos
    {
        public CatVehiculosModels ObtenerListaCatVehiculos(CatVehiculosModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatVehiculos");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaVehiculo = ds.Tables[0];
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
        public CatVehiculosModels AbcCatVehiculos(CatVehiculosModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_vehiculo,datos.descripcion,datos.descripcionIngles ,datos.placas, datos.detalle,datos.detalleIngles ,datos.id_tipovehiculo,
                    datos.combustible, datos.transmision, datos.numPersona, datos.numPuerta, datos.UrlImagen,datos.alt,datos.title,datos.nombre_arc,datos.tipo_arc,datos.nombre_pagina, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatVehiculo", parametros);
                datos.id_vehiculo = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CatVehiculosModels ObtenerDetalleCaracteristicaVehiculos(CatVehiculosModels datos)
        {
            try
            {
                object[] parametros = { datos.id_vehiculo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatVehiculoXId", parametros);
                while (dr.Read())
                {
                    datos.id_vehiculo = dr["id_vehiculo"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcionIngles"].ToString();
                    datos.placas = dr["placas"].ToString();
                    datos.detalle = dr["detalles"].ToString();
                    datos.detalleIngles = dr["detalleIngles"].ToString();
                    datos.id_tipovehiculo = dr["id_tipovehiculo"].ToString();
                    datos.combustible = dr["combustible"].ToString();
                    datos.transmision = dr["tramision"].ToString();
                    datos.numPersona = Convert.ToInt32(dr["numPersona"]);
                    datos.numPuerta = Convert.ToInt32(dr["numPuertas"]);
                    datos.UrlImagen = dr["UrlImagen"].ToString();
                    datos.alt = dr["alt"].ToString();
                    datos.title = dr["title"].ToString();
                    datos.nombre_arc = dr["nombre_arc"].ToString();
                    datos.tipo_arc = dr["tipo_arc"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoVehiculoModels> ObtenerComboTipoVehiculo(CatVehiculosModels datos)
        {
            try
            {
                List<TipoVehiculoModels> lista = new List<TipoVehiculoModels>();
                TipoVehiculoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ListaCatTipoVehiculos");
                while (dr.Read())
                {
                    item = new TipoVehiculoModels();
                    item.id_tipoVehiculo = dr["id_tipoVehiculo"].ToString();
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