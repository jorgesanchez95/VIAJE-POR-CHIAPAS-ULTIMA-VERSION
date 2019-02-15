using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class RecomendacionesDatos
    {
        #region Recomendaciones
        public RecomendacionesModels ObtenerConfigRecomendaciones(RecomendacionesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigRecomendaciones", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
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
