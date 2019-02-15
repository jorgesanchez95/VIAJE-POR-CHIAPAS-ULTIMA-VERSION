using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class _Testimoniales_Datos
    {
        public TestimonialesModels ObtenerListaTestimoniales(TestimonialesModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_Testimoniales");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.TablaTestimoniales = ds.Tables[0];
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
        public TestimonialesModels AbcTestimoniales(TestimonialesModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_testimoniales,datos.nombre, datos.comentario, datos.urlimagen, datos.webver,
                    datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_Testimoniales", parametros);
                datos.id_testimoniales = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TestimonialesModels ObtenerDetalleComentarioTestimoniales(TestimonialesModels datos)
        {
            try
            {
                object[] parametros = { datos.id_testimoniales };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleComentarioTestimonialXId", parametros);
                while (dr.Read())
                {
                    datos.id_testimoniales = dr["id_testimonial"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.comentario = dr["comentario"].ToString();
                    datos.urlimagen = dr["urlimagen"].ToString();
                    //datos.webver = dr["webver"].ToString();
                    
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