using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class HotelesDatos
    {
        #region Admin
        public HotelesModels ObtenerListaHoteles(HotelesModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatHoteles");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaHoteles = ds.Tables[0];
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
        public HotelesModels ObtenerDetalleHotelesxId(HotelesModels datos)
        {
            try
            {
                object[] parametros = { datos.id_hotel };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatHotelesXId", parametros);
                while (dr.Read())
                {
                    datos.id_hotel = dr["id_hotel"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.nombre = dr["nombre"].ToString();
                    datos.encargado = dr["encargado"].ToString();
                    datos.telefonolocal = dr["telefonolocal"].ToString();
                    datos.telefonomovil = dr["telefonomovil"].ToString();
                    datos.correoelectronico = dr["correoelectronico"].ToString();
                    datos.direccion = dr["direccion"].ToString();
                    datos.id_pais = Convert.ToInt32(dr["id_pais"].ToString());
                    datos.id_estado = Convert.ToInt32(dr["id_estado"].ToString());
                    datos.id_municipio = Convert.ToInt32(dr["id_municipio"].ToString());
                    datos.latitud = dr["latitud"].ToString();
                    datos.longitud = dr["longitud"].ToString();
                    datos.numestrellas = Convert.ToInt32(dr["numestrellas"].ToString());
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcion_ingles = dr["descripcion_ingles"].ToString();
                    datos.pathMul = dr["pathMul"].ToString();
                    datos.alt = dr["alt"].ToString();
                    datos.title = dr["title"].ToString();
                    datos.nombreArchivo = dr["nombre_arc"].ToString();
                    datos.nombre_pagina = dr["nombre_pagina"].ToString();
                    if (datos.nombre_pagina == "")
                        datos.nombre_pagina = Comun.RemoverSignosAcentos(datos.nombre);
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HotelesModels AbcCatHoteles(HotelesModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_hotel, datos.id_seccion, datos.nombre, datos.encargado, 
                    datos.telefonolocal, datos.telefonomovil, datos.correoelectronico, datos.direccion,
                    datos.id_pais, datos.id_estado, datos.id_municipio, datos.latitud,datos.longitud,
                    datos.numestrellas, datos.descripcion, datos.descripcion_ingles, datos.nombre_pagina, datos.pathMul, datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatHoteles", parametros);
                datos.id_hotel = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckHotelArchivoNnombreEsP(HotelesModels hotel)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(hotel.conexion, "spCSLDB_get_CheckCatHotelesArchivoNombreEsp", hotel.nombre);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
        #region Pagina
        public HotelesModels ObtenerConfigHotel(HotelesModels datos)
        {
            try
            {
                DataSet ds = null;

                ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_get_ConfigHoteles",
                  new SqlParameter("@leguaje", datos.idioma),
                  new SqlParameter("@id_seccion", datos.id_seccion),
                  new SqlParameter("@offset", datos.offset),
                  new SqlParameter("@fetchNext", datos.fetchNext),
                  new SqlParameter("@tablaTagsSelecionados", datos.tablaTagsSelecionados),
                  new SqlParameter("@tablaEstrellasSeleccionadas", datos.tablaEstrellasSeleccionadas),
                  new SqlParameter("@id_metaTags", datos.id_metaTags),
                  new SqlParameter("@id_tipoMetaTags", datos.id_tipo)
                  );
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaTags = ds.Tables[3];
                            datos.tablaHoteles = ds.Tables[4];
                            datos.tablaSeccion = ds.Tables[5];
                            datos.tablaSecciones = ds.Tables[6];
                            datos.tablaMetaTags = ds.Tables[7];
                            datos.numeroPaquetes = Convert.ToInt32(ds.Tables[8].Rows[0][0]);
                            datos.totalPaquetes = Convert.ToInt32(ds.Tables[9].Rows[0][0]);
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
        public HotelesModels ObtenerConfigHoteles(HotelesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.nombre_pagina, datos.id_tipo};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigHotelNew", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.nombre = ds.Tables[6].Rows[0][0].ToString();
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
        #region Cotizacion
        public HotelesModels CotizarHoteles(ref HotelesModels datos)
        {
            try
            {
                datos.verificadorCotizar = 3;
                DataSet Datos = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "cotizarHotel_sp",
                new SqlParameter("@id_seccion", datos.id_seccion),
                new SqlParameter("@nombre_pagina", datos.nombre_pagina),
                new SqlParameter("@idClienteCotizar", datos.idClienteCotizar),
                new SqlParameter("@nombreCotizar", datos.nombreCotizar),
                new SqlParameter("@apellidoPaternoCotizar", datos.apellidoPaternoCotizar),
                new SqlParameter("@apellidoMaternoCotizar", datos.apellidoMaternoCotizar),
                new SqlParameter("@emailCotizar", datos.emailCotizar),
                new SqlParameter("@telefonoCotizar", datos.telefonoCotizar),
                new SqlParameter("@BoletoCotizar", datos.BoletoCotizar),
                new SqlParameter("@aeropuertoLlegadaCotizar", datos.aeropuertoLlegadaCotizar),
                new SqlParameter("@fechaLlegadaCotizar", datos.fechaLlegadaCotizar),
                new SqlParameter("@horaLlegadaCotizar", datos.horaLlegadaCotizar),
                new SqlParameter("@aeropuertoSalidaCotizar", datos.aeropuertoSalidaCotizar),
                new SqlParameter("@fechaSalidaCotizar", datos.fechaSalidaCotizar),
                new SqlParameter("@horaSalidaCotizar", datos.horaSalidaCotizar),
                new SqlParameter("@categoriaHotelCotizar", datos.categoriaHotelCotizar),
                new SqlParameter("@numeroPersonasCotizar", datos.numeroPersonasCotizar),
                new SqlParameter("@numeroAdultoCotizar", datos.numeroAdultoCotizar),
                new SqlParameter("@numeroNiños511Cotizar", datos.numeroNiños511Cotizar),
                new SqlParameter("@numeroNiños14Cotizar", datos.numeroNiños14Cotizar),
                new SqlParameter("@numeroHabitacionesCotizar", datos.numeroHabitacionesCotizar),
                new SqlParameter("@numeroPersonasCamaCotizar", datos.numeroPersonasCamaCotizar)
                );
                if (Datos.Tables[0] != null)
                {
                    foreach (DataRow aux in Datos.Tables[0].Rows)
                    {
                        datos.verificadorCotizar = Convert.ToInt32(aux["BanCotizacionSistema"].ToString());
                        if (datos.verificadorCotizar == 1 || datos.verificadorCotizar == 2)
                        {
                            datos.datosGeneralesCorreo = Datos.Tables[1];
                            datos.tablaRecamarasCorreo = Datos.Tables[2];
                            datos.tablaRedesSociales = Datos.Tables[3];
                            datos.TablaPaquetesPopulares = Datos.Tables[4];
                        }
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                datos.verificadorCotizar = 3;
                return datos;
            }
        }
        #endregion
    }
}
