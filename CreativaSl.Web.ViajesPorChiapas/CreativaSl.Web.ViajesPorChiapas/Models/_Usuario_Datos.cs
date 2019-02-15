using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class UsuarioDatos
    {
        public List<TipoUsuarioModels> ObtenerComboTipoUsuario(UsuarioModels datos) 
        {
            try
            {
                List<TipoUsuarioModels> lista = new List<TipoUsuarioModels>();
                TipoUsuarioModels item;
                object[] parametros = { datos.opcion };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoUsuario", parametros);
                while (dr.Read())
                {
                    item = new TipoUsuarioModels();
                    item.id_tipoUsuario = Int32.Parse(dr["id_tipoUsuario"].ToString());
                    item.tipoUsuario = dr["tipoUsuario"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public UsuarioModels ObtenerUsuarios(UsuarioModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_CatUsuariosAdmin");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaUsuario = ds.Tables[0];
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
        public UsuarioModels ObtenerUsuariosXID(UsuarioModels datos)
        {
            try
            {
                object[] parametros = { datos.id_usuario };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_CatUsuariosAdminXID", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaUsuario = ds.Tables[0];
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
        public UsuarioModels ObtenerDetalleUsuarioxID(UsuarioModels datos)
        {
            try
            {
                object[] parametros = { datos.id_usuario };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleUsuarioxID", parametros);
                while (dr.Read())
                {
                    datos.id_usuario = dr["id_usuario"].ToString();
                    datos.id_tipoUsuario = Int32.Parse(dr["id_tipoUsuario"].ToString());
                    datos.tipoUsuario = dr["tipoUsuario"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.apPat = dr["apPat"].ToString();
                    datos.apMat = dr["apMat"].ToString();
                    datos.fechaNac = DateTime.Parse(dr["fechaNac"].ToString());
                    datos.direccion = dr["direccion"].ToString();
                    datos.codigoPostal = dr["codigoPostal"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.email = dr["email"].ToString();
                    datos.url_foto = dr["url_foto"].ToString();
                    datos.cuenta = dr["cuenta"].ToString();
                    datos.password = "dc89sd989sdd";
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


        public UsuarioModels AbcCatUsuarios(UsuarioModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_usuario, datos.id_tipoUsuario, datos.nombre, datos.apPat,
                    datos.apMat, datos.fechaNac, datos.direccion, datos.codigoPostal, datos.telefono, datos.email,
                    datos.url_foto, datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.cuenta, datos.password, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatUsuarios", parametros);
                datos.id_usuario = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public string ObtenerTipoUsuarioByUserName(UsuarioModels usuario)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(usuario.conexion, "spCSLDB_get_tipoUsuarioByUserName", usuario.cuenta);
                return aux.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public bool CheckUserName(UsuarioModels usuario)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(usuario.conexion, "spCSLDB_get_CheckUserName", usuario.cuenta);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CheckEmail(UsuarioModels usuario)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(usuario.conexion, "spCSLDB_get_CheckEmail", usuario.email);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public UsuarioModels ResetPassword(UsuarioModels usuario)
        {
            try
            {
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(usuario.conexion, "spCSLDB_get_PasswordReset", usuario.email2);
                while (dr.Read())
                {
                    usuario.activo = dr["activo"].ToString().Equals("1") ? true : false;
                    usuario.cuenta = dr["usuario"].ToString();
                    usuario.password = dr["password"].ToString();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                usuario.activo = false;
                return usuario;
            }
        }


        public bool CheckUsuarioArchivoNameUsuario(UsuarioModels Usuario)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(Usuario.conexion, "spCSLDB_get_CheckUsuarioArchivoName", Usuario.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
