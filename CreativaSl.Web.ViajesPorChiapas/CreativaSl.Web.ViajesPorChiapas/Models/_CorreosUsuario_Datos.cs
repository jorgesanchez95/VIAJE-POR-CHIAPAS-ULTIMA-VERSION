using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class CorreosUsuarioDatos
    {
        public CorreosUsuarioModels ObtenerListaCorreosUsuario(CorreosUsuarioModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCorreosUsuario");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaCorreosUsuario = ds.Tables[0];
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
        public CorreosUsuarioModels ObtenerDetalleCorreosUsuarioxId(CorreosUsuarioModels datos)
        {
            try
            {
                object[] parametros = { datos.id_cliente };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCorreosUsuarioXId", parametros);
                while (dr.Read())
                {
                    datos.id_cliente = dr["id_cliente"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.correo = dr["correo"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CorreosUsuarioModels AbcCatCorreosUsuario(CorreosUsuarioModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_cliente, datos.nombre, datos.correo, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CorreosUsuario", parametros);
                datos.id_cliente = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
