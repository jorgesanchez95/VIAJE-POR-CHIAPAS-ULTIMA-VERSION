using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ClienteDatos
    {
        public ClienteModels ObtenerListaClientes(ClienteModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatClientes");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaClientes = ds.Tables[0];
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
        public ClienteModels ObtenerDetalleClientexId(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.id_cliente };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatClienteXId", parametros);
                while (dr.Read())
                {
                    datos.id_cliente = dr["id_cliente"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.apPat = dr["apePat"].ToString();
                    datos.apMat = dr["apeMat"].ToString();
                    datos.nombreCompleto = dr["nombre"].ToString() + " " + dr["apePat"].ToString() + " " + dr["apeMat"].ToString(); 
                    datos.id_pais = Convert.ToInt32(dr["id_pais"].ToString());
                    datos.id_estado = Convert.ToInt32(dr["id_estado"].ToString());
                    datos.id_municipio = Convert.ToInt32(dr["id_municipio"].ToString());
                    datos.colonia = dr["colonia"].ToString();
                    datos.fechaNac = Convert.ToDateTime(dr["fechaNacimiento"].ToString());
                    datos.id_genero = Convert.ToInt32(dr["id_genero"].ToString());
                    datos.id_ocupacion = Convert.ToInt32(dr["id_ocupacion"].ToString());
                    datos.curp = dr["curp"].ToString();
                    datos.email = dr["correoelectronico"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.password = dr["clvpass"].ToString();
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ClienteModels AbcCatCliente(ClienteModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_cliente, 1, datos.nombre, datos.apPat, datos.apMat,
                    143, datos.id_estado, datos.id_municipio, datos.colonia, datos.fechaNac, datos.id_genero,
                    datos.curp, datos.telefono, datos.password, datos.id_ocupacion, datos.email,datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatClientes", parametros);
                datos.id_cliente = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClienteModels> ObtenerComboClientesxGrupo(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.id_grupo };
                List<ClienteModels> lista = new List<ClienteModels>();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_CatClientesxIdGrupo", parametros);
                while (dr.Read())
                {
                    var item = new ClienteModels();
                    item.id_cliente = dr["correo"].ToString();
                    item.nombre = dr["nombreCorreo"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClienteModels> ObtenerComboClientesAll(ClienteModels datos)
        {
            try
            {
                List<ClienteModels> lista = new List<ClienteModels>();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_CatClientesAll");
                while (dr.Read())
                {
                    var item = new ClienteModels();
                    item.id_cliente = dr["correo"].ToString();
                    item.nombre = dr["nombreCorreo"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Login
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
        #endregion
        #region LoginPagina
        public ClienteModels ObtenerConfigLogin(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigLogin", parametros);
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
        #region MiCuenta
        public ClienteModels ObtenerConfigMiCuenta(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_cliente, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigMiCuenta", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaClientes = ds.Tables[1];
                            datos.tablaSeccion = ds.Tables[2];
                            datos.tablaSecciones = ds.Tables[3];
                            datos.tablaCotizacionesRecientes = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.TablaPaquetesPopulares = ds.Tables[6];
                            datos.TablaFormasDePago = ds.Tables[7];
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
        public ClienteModels ObtenerConfigDetalleSolicitud(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_cliente,datos.id_solicitud, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigDetalleSolicitud", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.TablaPaquetesPopulares = ds.Tables[1];
                            datos.TablaFormasDePago = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.id_tipoSolicitud = Convert.ToInt32(ds.Tables[6].Rows[0][0]);
                            if (datos.id_tipoSolicitud == 1)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[7];
                                datos.tablaDetalleSolicitdHabitacion = ds.Tables[8];
                                datos.tablaRedesSociales = ds.Tables[9];
                                datos.tablaItinerario = ds.Tables[10];
                            }
                            else if (datos.id_tipoSolicitud == 2)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[7];
                                datos.tablaRedesSociales = ds.Tables[8];
                            }
                            else if (datos.id_tipoSolicitud == 3)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[7];
                                datos.tablaDetalleSolicitdHabitacion = ds.Tables[8];
                                datos.tablaRedesSociales = ds.Tables[9];
                            }
                            else if (datos.id_tipoSolicitud == 4)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[7];
                                datos.tablaRedesSociales = ds.Tables[8];
                            }
                            else if (datos.id_tipoSolicitud == 5)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[7];
                                datos.tablaDetalleSolicitdHabitacion = ds.Tables[8];
                                datos.tablaRedesSociales = ds.Tables[9];
                                datos.tablaItinerario = ds.Tables[10];
                            }
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
        public ClienteModels ObtenerSolicitudesxCliente(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.id_cliente, datos.offset, datos.fetchNext };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_SolicitudesXCliente", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaCotizaciones = ds.Tables[0];
                            datos.numeroSolicitudes = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
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
        public ClienteModels cancelacionSolicitud(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.id_solicitud, datos.id_cliente};
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_b_Solicitud", parametros);
                datos.id_solicitud = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ClienteModels ObtenerConfigResetPassword(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigResetPasword", parametros);
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
        public ClienteModels ResetPasswordCliente(ClienteModels cliente)
        {
            try
            {
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(cliente.conexion, "spCSLDB_reset_password", cliente.email);
                while (dr.Read())
                {
                    cliente.activo = dr["activo"].ToString().Equals("1") ? true : false;
                    cliente.email = dr["correo"].ToString();
                    cliente.password = dr["contraseña"].ToString();
                }
                return cliente;
            }
            catch (Exception ex)
            {
                cliente.activo = false;
                cliente.email = "";
                cliente.password = "";
                return cliente;
            }
        }
        public ClienteModels ObtenerConfigCotizacionesSolicitud(ClienteModels cliente)
        {
            try
            {
                object[] parametros = { cliente.idioma, cliente.id_seccion, cliente.id_solicitud, cliente.id_metaTags, cliente.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(cliente.conexion, "spCSLDB_get_ConfigCotizacionesSolicitudes", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            cliente.tablaDatosGenerales = ds.Tables[0];
                            cliente.tablaSeccion = ds.Tables[1];
                            cliente.tablaSecciones = ds.Tables[2];
                            cliente.tablaCotizaciones = ds.Tables[3];
                            cliente.tablaMetaTags = ds.Tables[4];
                            cliente.TablaPaquetesPopulares = ds.Tables[5];
                            cliente.TablaFormasDePago = ds.Tables[6];
                        }
                    }
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ClienteModels ObtenerConfigComprarCotizacionesSolicitud(ClienteModels cliente)
        {
            try
            {
                object[] parametros = { cliente.idioma, cliente.id_seccion, cliente.id_solicitud, cliente.id_cotizacion, cliente.id_metaTags, cliente.id_tipo};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(cliente.conexion, "spCSLDB_get_ConfigComprarCotizacionesSolicitudes", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            cliente.tablaDatosGenerales = ds.Tables[0];
                            cliente.tablaSeccion = ds.Tables[1];
                            cliente.tablaSecciones = ds.Tables[2];
                            cliente.tablaFormaPago = ds.Tables[3];
                            cliente.tablaDetalleSolicitud = ds.Tables[4];
                            cliente.tablaMetaTags = ds.Tables[5];
                            cliente.TablaPaquetesPopulares = ds.Tables[6];
                            cliente.TablaFormasDePago = ds.Tables[7];
                        }
                    }
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ClienteModels ObtenerConfigTipoPagoComprarCotizacionesSolicitud(ClienteModels cliente)
        {
            try
            {
                object[] parametros = { cliente.id_solicitud, cliente.id_cotizacion };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(cliente.conexion, "spCSLDB_get_ConfigTipoPagoComprarCotizacionesSolicitudes", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            cliente.tablaFormaPago = ds.Tables[0];
                            cliente.verificador = true;
                        }
                    }
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ClienteModels VentaServicio(ClienteModels cliente)
        {
            try
            {
                object[] parametros = { cliente.id_solicitud, cliente.id_cotizacion };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(cliente.conexion, "spCSLDB_set_ComprarSolicitudCotizacionWeb", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            cliente.id_venta = ds.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion






        public ClienteModels RegistrarPagoComprarCotizacionesSolicitudPaypal(ClienteModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_solicitud, datos.id_pagoOnline, datos.anticipo, datos.URL, 0
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_pagoPaypal", parametros);
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModels ObtenerConfigPagoRealizado(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPagoRealizado", parametros);
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

        public static bool IsEmpresa(string Conexion, string id_usuario)
        {
            try
            {
                object[] parametros = { id_usuario };
                return Convert.ToBoolean(SqlHelper.ExecuteScalar(Conexion, "spCSLDB_isEmpresa", parametros));
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public ClienteModels ObtenerConfigpanelCorreo(ClienteModels datos)
        {
            try
            {
                object[] parametros = { datos.id_solicitud };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPanelCorreo", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.id_tipoSolicitud = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                            if (datos.id_tipoSolicitud == 1)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[1];
                                datos.tablaDetalleSolicitdHabitacion = ds.Tables[2];
                                datos.tablaRedesSociales = ds.Tables[3];
                                datos.tablaItinerario = ds.Tables[4];
                                datos.TablaPaquetesPopulares = ds.Tables[5];
                            }
                            else if (datos.id_tipoSolicitud == 2)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[1];
                                datos.tablaRedesSociales = ds.Tables[2];
                                datos.TablaPaquetesPopulares = ds.Tables[3];
                            }
                            else if (datos.id_tipoSolicitud == 3)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[1];
                                datos.tablaDetalleSolicitdHabitacion = ds.Tables[2];
                                datos.tablaRedesSociales = ds.Tables[3];
                                datos.TablaPaquetesPopulares = ds.Tables[4];
                            }
                            else if (datos.id_tipoSolicitud == 4)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[1];
                                datos.tablaRedesSociales = ds.Tables[2];
                                datos.TablaPaquetesPopulares = ds.Tables[3];
                            }
                            else if (datos.id_tipoSolicitud == 5)
                            {
                                datos.tablaDetalleSolicitud = ds.Tables[1];
                                datos.tablaDetalleSolicitdHabitacion = ds.Tables[2];
                                datos.tablaRedesSociales = ds.Tables[3];
                                datos.tablaItinerario = ds.Tables[4];
                                datos.TablaPaquetesPopulares = ds.Tables[5];
                            }
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
