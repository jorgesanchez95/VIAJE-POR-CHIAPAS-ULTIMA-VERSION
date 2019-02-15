using System;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class LoginDatos
    {
        public UsuarioModels ValidarUsuario(UsuarioModels datos)
        {
            try
            {                
                object[] parametros = { datos.user, datos.password };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "Login_sp", parametros);
                while (dr.Read())
                {
                    datos.opcion = Convert.ToInt32(dr[0].ToString());
                    if(datos.opcion == 1)
                    {
                        datos.id_usuario = dr["Id_U"].ToString();
                        datos.nombre = dr["U_Nombre"].ToString();
                        datos.apPat = dr["U_Apellidop"].ToString();
                        datos.apMat = dr["U_Apellidom"].ToString();
                        datos.id_tipoUsuario = Convert.ToInt32(dr["Id_Tu"].ToString());
                        datos.tipoUsuario = dr["CTU_TipoUsuario"].ToString();
                        datos.user = dr["Cu_User"].ToString();
                        datos.password = dr["Cu_Pass"].ToString();
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ClienteModels ValidarCliente(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.email, datos.password };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "LoginCliente_sp", parametros);
                while (dr.Read())
                {
                    datos.opcion = Convert.ToInt32(dr[0].ToString());
                    if (datos.opcion == 1)
                    {
                        datos.id_cliente = dr["Id_U"].ToString();
                        datos.nombreCompleto = dr["U_NombreCompleto"].ToString();
                        datos.password = dr["Cu_Pass"].ToString();
                        datos.email = dr["correo"].ToString();
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
