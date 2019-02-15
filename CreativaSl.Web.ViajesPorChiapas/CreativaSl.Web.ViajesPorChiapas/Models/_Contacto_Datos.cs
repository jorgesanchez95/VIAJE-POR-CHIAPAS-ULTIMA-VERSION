using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ContactoDatos
    {
        public ContactoModels ObtenerListaContacto(ContactoModels datos)
        {
            try 
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_Contacto");
                if(ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaContacto = ds.Tables[0];
                        }
                    }
                }
                return datos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ContactoModels ObtenerDetalleContactoXId(ContactoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_contacto };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleContactoXId", parametros);
                while (dr.Read())
                {
                    datos.id_contacto = dr["id_contacto"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.correo = dr["correo"].ToString();
                    datos.telefono = dr["telefono"].ToString();
                    datos.mensaje = dr["mensaje"].ToString();
                    datos.respuesta = dr["respuesta"].ToString();
                    datos.asunto = dr["asunto"].ToString();
                    datos.horarioContacto = dr["horarioContacto"].ToString();
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcContacto(ContactoModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_contacto, datos.id_seccion, datos.nombre, datos.correo, datos.telefono,
                    datos.mensaje, datos.respuesta,datos.asunto, datos.horarioContacto, datos.user
                 };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_Contacto", parametros);
                datos.id_contacto = aux.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable ObtenerRedesSociales(ContactoModels seccion)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(seccion.conexion, "spCSLDB_get_ConfigRedesSociales");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            seccion.tablaRedesSociales = ds.Tables[0];
                            seccion.TablaPaquetesPopulares = ds.Tables[1];

                        }
                    }
                }
                return seccion.tablaRedesSociales;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        #region Pagina
        public ContactoModels ObtenerConfigContacto(ContactoModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigContacto", parametros);
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
