using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TerminosYCondiciones_Datos
    {
        #region Pagina
        public TerminosYCondicionesModels ObtenerConfigTerminosYCondiciones(TerminosYCondicionesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigTerminosYCondiciones", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaSeccion = ds.Tables[1];
                            datos.tablaSecciones = ds.Tables[2];
                            datos.tablaMetaTags = ds.Tables[3];
                            datos.TablaPaquetesPopulares = ds.Tables[4];
                            datos.TablaFormasDePago = ds.Tables[5];
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
