using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TipoPagosDetalleDatos
    {
        public TipoPagosDetalleModels ObtenerListaTipoPagosDetalle(TipoPagosDetalleModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatTipoPagoDetalle");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaCatTipoPagosDetalle = ds.Tables[0];
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
        public TipoPagosDetalleModels ObtenerDetalleTipoPagosDetallexId(TipoPagosDetalleModels datos)
        {
            try
            {
                object[] parametros = { datos.idDepositosTransferencia };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatTipoPagoDetalleXId", parametros);
                while (dr.Read())
                {
                    datos.idDepositosTransferencia = dr["id_tipoPagoDetalle"].ToString();
                    datos.id_tipoPago = Convert.ToInt32(dr["id_tipoPago"].ToString());
                    datos.banco = dr["descripcion"].ToString();
                    datos.titular = dr["titular"].ToString();
                    datos.numeroReferencia = dr["numero_referencia"].ToString();
                    datos.pathDepositosTransferencia = dr["imagen"].ToString();
                    datos.activo = Convert.ToBoolean(dr["activo"].ToString());
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
        public TipoPagosDetalleModels AbcCatTipoPagosDetalle(TipoPagosDetalleModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.idDepositosTransferencia,datos.id_tipoPago, datos.banco, datos.titular, datos.numeroReferencia,datos.pathDepositosTransferencia,
                    datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.activo, datos.user,datos.estado
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatTipoPagosDetalles", parametros);
                datos.idDepositosTransferencia = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoPagosDetalleModels> ObtenerComboTipoPago(TipoPagosDetalleModels datos)
        {
            try
            {
                List<TipoPagosDetalleModels> lista = new List<TipoPagosDetalleModels>();
                TipoPagosDetalleModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoPago");
                while (dr.Read())
                {
                    item = new TipoPagosDetalleModels();
                    item.id_tipoPago = Convert.ToInt32(dr["id_tipoPago"].ToString());
                    item.tipoPago = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TipoPagosDetalleModels ObtenerConfigTipoPago(TipoPagosDetalleModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_tipoPago, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigTiposPagos", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];

                            datos.tablaSeccion = ds.Tables[1];
                            datos.tablaSecciones = ds.Tables[2];
                            datos.tablaCatTipoPagosDetalle = ds.Tables[3];
                            datos.tablaMetaTags = ds.Tables[4];
                            datos.TablaPaquetesPopulares = ds.Tables[5];
                            datos.TablaFormasDePago = ds.Tables[6];
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
        public bool CheckDepositoTransNameDepositoTrans(TipoPagosDetalleModels Pagos)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(Pagos.conexion, "spCSLDB_get_CheckDapositoTransferenciaArchivoName", Pagos.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
