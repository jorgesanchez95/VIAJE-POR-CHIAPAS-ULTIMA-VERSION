using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class GrupoDatos
    {
        public GrupoModels ObtenerListaGrupo(GrupoModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatGrupo");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaGrupo = ds.Tables[0];
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
        public GrupoModels ObtenerDetalleGrupoxId(GrupoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_grupo };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatGrupoXId", parametros);
                while (dr.Read())
                {
                    datos.id_grupo = dr["id_grupo"].ToString();
                    datos.nombreGrupo = dr["nombreGrupo"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public GrupoModels AbcCatGrupo(GrupoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_grupo,datos.nombreGrupo, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatGrupo", parametros);
                datos.id_grupo = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GrupoModels> ObtenerComboGrupos(GrupoModels datos)
        {
            try
            {
                List<GrupoModels> lista = new List<GrupoModels>();
                GrupoModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatGrupo");
                while (dr.Read())
                {
                    item = new GrupoModels();
                    item.id_grupo = dr["id_grupo"].ToString();
                    item.nombreGrupo = dr["nombreGrupo"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IntegrantesGrupoModels ObtenerListaIntegrantesGrupoxId(IntegrantesGrupoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_grupo};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatIntegranteGrupoxId", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaIntegranteGrupo = ds.Tables[0];
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

        public void AbcIntegranteGrupo(IntegrantesGrupoModels datos)
        {
            try
            {
                string[] id_clientes;
                if (!string.IsNullOrEmpty(datos.id_cliente))
                {
                    if (datos.id_cliente.Contains(","))
                    {
                        id_clientes = datos.id_cliente.Split(',');
                    }
                    else
                    {
                        id_clientes = new string[] { datos.id_cliente };
                    }
                }
                else
                {
                    id_clientes = new string[] { string.Empty };
                }

                foreach (string id_cliente in id_clientes)
                {
                    object[] parametros =
                    {
                    datos.opcion, datos.id_integranteGrupo, id_cliente, datos.id_grupo, datos.user
                 };
                    object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_IntegranteGrupo", parametros);
                    datos.id_integranteGrupo = aux.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
