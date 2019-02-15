using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class RelacionTagsDatos
    {
        public RelacionTagsModels ObtenerListaRelacionTagsXIdTipo(RelacionTagsModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.id_datoRelacionado, datos.id_tipoDatoRelacionado
                };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaRelacionesTagsxIdTipo", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaRelacionTags = ds.Tables[0];
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

        public void AbcRelacionTags(RelacionTagsModels datos)
        {
            try
            {

                string[] id_Tags;
                if (!string.IsNullOrEmpty(datos.id_tag))
                {
                    if (datos.id_tag.Contains(","))
                    {
                        id_Tags = datos.id_tag.Split(',');
                    }
                    else
                    {
                        id_Tags = new string[] { datos.id_tag };
                    }
                }
                else
                {
                    id_Tags = new string[] { string.Empty };
                }

                foreach (string idCliente in id_Tags)
                {
                    object[] parametros =
                    {
                    datos.opcion, datos.id_relacionTags, idCliente, datos.id_datoRelacionado, datos.id_tipoDatoRelacionado, datos.user
                    };
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_RelacionTags", parametros);
                    datos.id_relacionTags = aux.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
