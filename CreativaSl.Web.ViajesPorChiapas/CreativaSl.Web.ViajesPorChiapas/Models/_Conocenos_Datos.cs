using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ConocenosDatos
    {
        public ConocenosModels ObtenerConfigConocenos(ConocenosModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigConocenos", parametros);
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
                            datos.tablaMetaTags = ds.Tables[5];
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

    }
}
