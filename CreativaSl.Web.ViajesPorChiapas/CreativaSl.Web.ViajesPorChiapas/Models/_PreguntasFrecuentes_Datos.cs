using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class PreguntasFrecuentesDatos
    {
        public PreguntasFrecuentesModels ObtenerListaPreguntasFrecuentes(PreguntasFrecuentesModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatPreguntasFrecuentas");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaPreguntasFrecuentes = ds.Tables[0];
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
        public PreguntasFrecuentesModels ObtenerDetallePreguntasFrecuentesXId(PreguntasFrecuentesModels datos)
        {
            try
            {
                object[] parametros = { datos.id_preguntaFrecuente };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatPreguntasFrecuentasXId", parametros);
                while (dr.Read())
                {
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.id_preguntaFrecuente = dr["id_preguntaFrecuente"].ToString();
                    datos.pregunta = dr["pregunta"].ToString();
                    datos.preguntaIngles = dr["preguntaIngles"].ToString();
                    datos.respuesta = dr["respuesta"].ToString();
                    datos.respuestaIngles = dr["respuestaIngles"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public PreguntasFrecuentesModels AbcCatPreguntasFrecuentes(PreguntasFrecuentesModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_preguntaFrecuente, datos.id_seccion, datos.pregunta, datos.preguntaIngles, datos.respuesta,
                    datos.respuestaIngles, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatPreguntasFrecuentes", parametros);
                datos.id_preguntaFrecuente = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Pagina
        public PreguntasFrecuentesModels ObtenerConfigRecomendaciones(PreguntasFrecuentesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigRecomendaciones", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                          
                            datos.tablaPreguntasFrecuentes = ds.Tables[1];
                            datos.tablaSeccion = ds.Tables[2];
                            datos.tablaSecciones = ds.Tables[3];
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
        #endregion

    }
}
