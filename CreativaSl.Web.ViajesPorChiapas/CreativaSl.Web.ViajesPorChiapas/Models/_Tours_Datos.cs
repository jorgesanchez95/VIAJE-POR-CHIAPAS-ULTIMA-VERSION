using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ToursDatos
    {
        #region Admin
        public ToursModels ObtenerListaTours(ToursModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatTours");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaTours = ds.Tables[0];
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
        public ToursModels ObtenerDetalleTourxId(ToursModels datos)
        {
            try
            {
                object[] parametros = { datos.id_tour };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatToursXId", parametros);
                while (dr.Read())
                {
                    datos.id_tour = dr["id_tour"].ToString();
                    datos.id_seccion = dr["id_seccion"].ToString();
                    datos.id_tipoPaquete = Convert.ToInt32(dr["id_tipoPaquete"].ToString());
                    datos.id_pais = Convert.ToInt32(dr["id_pais"].ToString());
                    datos.id_estado = Convert.ToInt32(dr["id_estado"].ToString());
                    datos.id_municipio = Convert.ToInt32(dr["id_municipio"].ToString());
                    datos.nombre = dr["nombre"].ToString();
                    datos.nombreIngles = dr["nombreIngles"].ToString();
                    datos.descripcion = dr["descripcion"].ToString();
                    datos.descripcionIngles = dr["descripcionIngles"].ToString();
                    datos.latitud = dr["latitud"].ToString();
                    datos.longitud = dr["longitud"].ToString();
                    datos.incluye = dr["incluye"].ToString();
                    datos.incluyeIngles = dr["incluye_ingles"].ToString();
                    datos.noIncluye = dr["noincluye"].ToString();
                    datos.noIncluyeIngles = dr["noincluye_ingles"].ToString();
                   
                    datos.finDeServicios = dr["findeservicios"].ToString();
                    datos.finDeServiciosIngles = dr["findeservicios_ingles"].ToString();
                    datos.cantidadDias = Convert.ToInt32(dr["cantidaddias"].ToString());
                    datos.cantidadNoches = Convert.ToInt32(dr["cantidadnoches"].ToString());
                    datos.horaLlegada = Convert.ToInt32(dr["horallegada"].ToString());
                    datos.minutosLlegada = Convert.ToInt32(dr["minutosllegada"].ToString());
                    datos.adultoAlta = Convert.ToInt32(dr["minutosllegada"].ToString());
                    datos.minutosLlegada = Convert.ToInt32(dr["minutosllegada"].ToString());
                    datos.minutosLlegada = Convert.ToInt32(dr["minutosllegada"].ToString());
                    datos.minutosLlegada = Convert.ToInt32(dr["minutosllegada"].ToString());
                    datos.pathImg = dr["pathImg"].ToString();
                    datos.alt = dr["alt"].ToString();
                    datos.title = dr["title"].ToString();
                    datos.nombreArchivo = dr["nombre_arc"].ToString();
                    datos.nombre_pagina = dr["nombre_pagina"].ToString();
                    datos.observacionesingles = dr["observacionesingles"].ToString();
                    datos.observaciones = dr["observaciones"].ToString();
                   
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
        public ToursModels AbcCatTours(ToursModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_tour, datos.id_seccion, datos.nombre, datos.nombreIngles, datos.descripcion, datos.descripcionIngles, datos.id_tipoPaquete,
                    datos.incluye, datos.incluyeIngles, datos.noIncluye,datos.noIncluyeIngles,datos.finDeServicios, datos.finDeServiciosIngles, datos.cantidadDias,
                    datos.cantidadNoches, datos.horaLlegada, datos.minutosLlegada, datos.id_pais, datos.id_estado,
                    datos.id_municipio, datos.latitud, datos.longitud,datos.adultoAlta, datos.ninioAlta, datos.adultoBaja,
                    datos.ninioBaja,datos.pathImg, datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.nombre_pagina,datos.observaciones,datos.observacionesingles, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatTours", parametros);
                datos.id_tour = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ToursModels ObtenerDetalleTourPreciosxId(ToursModels datos)
        {
            try
            {
                object[] parametros = { datos.id_tour, 0, 0 };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetallePaquetePrecioXId", parametros);
                while (dr.Read())
                {
                    datos.adultoAlta = Convert.ToDecimal(dr["montoAltaA"].ToString());
                    datos.adultoBaja = Convert.ToDecimal(dr["montoBajaA"].ToString());
                    datos.ninioAlta = Convert.ToDecimal(dr["montoAltaN"].ToString());
                    datos.ninioBaja = Convert.ToDecimal(dr["montoBajaN"].ToString());
                }
                return datos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckToursArchivoNameTours(ToursModels tours)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(tours.conexion, "spCSLDB_get_CheckCatToursArchivoName", tours.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckToursArchivoNameEsp(ToursModels tours)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(tours.conexion, "spCSLDB_get_CheckCatToursArchivoNombreEsp", tours.nombre);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

         public bool CheckToursArchivoNameIng(ToursModels tours)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(tours.conexion, "spCSLDB_get_CheckCatToursArchivoNombreING", tours.nombreIngles);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
        #region Pagina
        public ToursModels ObtenerConfigTour(ToursModels datos)
        {
            try
            {
                DataSet ds = null;

                ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_get_ConfigTours",
                  new SqlParameter("@leguaje", datos.idioma),
                  new SqlParameter("@id_seccion", datos.id_seccion),
                  new SqlParameter("@offset", datos.offset),
                  new SqlParameter("@fetchNext", datos.fetchNext),
                  new SqlParameter("@tablaTagsSelecionados", datos.tablaTagsSelecionados),
                  new SqlParameter("@id_metaTags", datos.id_metaTags),
                  new SqlParameter("@id_tipoMetaTags", datos.id_tipo),
                  new SqlParameter("@id_estado", datos.id_estado),
                  new SqlParameter("@id_pais", datos.id_pais),
                   new SqlParameter("@id_tipoPaquete", datos.modalidad)
                  );
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaTags = ds.Tables[1];
                            datos.tablaTours = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.numeroPaquetes = Convert.ToInt32(ds.Tables[6].Rows[0][0]);
                            datos.totalTours = Convert.ToInt32(ds.Tables[7].Rows[0][0]);
                            datos.TablaPaquetesPopulares = ds.Tables[8];
                            datos.TablaFormasDePago = ds.Tables[9];
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
        public ToursModels ObtenerConfigDetalleTour(ToursModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.nombre_pagina, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigDetalleTour", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaTours = ds.Tables[1];
                            datos.tablaItinerario = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaLugares = ds.Tables[5];
                            datos.tablaMetaTags = ds.Tables[6];
                            datos.TablaPaquetesPopulares = ds.Tables[7];
                            datos.TablaFormasDePago = ds.Tables[8];
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
        public ToursModels ObtenerConfigTours(ToursModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.nombre_pagina, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigTourNew", parametros);
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
                            datos.nombre = ds.Tables[4].Rows[0][0].ToString();
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
        public List<ToursModels> ObtenerComboCatTours(ToursModels datos)
        {
            try
            {
                List<ToursModels> lista = new List<ToursModels>();
                ToursModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTours");
                while (dr.Read())
                {
                    item = new ToursModels();
                    item.id_tour = dr["id_tour"].ToString();
                    item.nombre = dr["nombre"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ToursModels ObtenerConfigToursEmpresa(ToursModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigTourEmpresaNew", parametros);
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
        public ToursModels ObtenerConfigTourBusqueda(ToursModels datos)
        {
            try
            {
                DataSet ds = null;

                ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_get_ConfigToursBusqueda",
                  new SqlParameter("@leguaje", datos.idioma),
                  new SqlParameter("@id_seccion", datos.id_seccion),
                  new SqlParameter("@offset", datos.offset),
                  new SqlParameter("@fetchNext", datos.fetchNext),
                  new SqlParameter("@tablaTagsSelecionados", datos.tablaTagsSelecionados),
                  new SqlParameter("@id_metaTags", datos.id_metaTags),
                  new SqlParameter("@id_tipoMetaTags", datos.id_tipo),
                  new SqlParameter("@id_estado", datos.id_estado),
                  new SqlParameter("@idPais", datos.id_pais),
                  new SqlParameter("@idLugar", datos.id_Lugar)
                  );
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaTags = ds.Tables[1];
                            datos.tablaTours = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.numeroPaquetes = Convert.ToInt32(ds.Tables[6].Rows[0][0]);
                            datos.totalTours = Convert.ToInt32(ds.Tables[7].Rows[0][0]);
                            datos.TablaPaquetesPopulares = ds.Tables[8];
                            datos.TablaFormasDePago = ds.Tables[9];
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
        public ToursModels CotizarTours(ref ToursModels datos)
        {
            try
            {
                datos.verificadorCotizar = 3;
                DataSet Datos = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "cotizarTour_sp",
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
                new SqlParameter("@numeroPersonasCotizar", datos.numeroPersonasCotizar),
                new SqlParameter("@numeroAdultoCotizar", datos.numeroAdultoCotizar),
                new SqlParameter("@numeroNiños511Cotizar", datos.numeroNiños511Cotizar),
                new SqlParameter("@numeroNiños14Cotizar", datos.numeroNiños14Cotizar)
                );
                if (Datos.Tables[0] != null)
                {
                    foreach (DataRow aux in Datos.Tables[0].Rows)
                    {
                        datos.verificadorCotizar = Convert.ToInt32(aux["BanCotizacionSistema"].ToString());
                        if (datos.verificadorCotizar == 1 || datos.verificadorCotizar == 2)
                        {
                            datos.datosGeneralesCorreo = Datos.Tables[1];
                            datos.tablaRedesSociales = Datos.Tables[2];
                            datos.TablaPaquetesPopulares = Datos.Tables[3];
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
        public ToursModels CotizarToursEmpresa(ref ToursModels datos)
        {
            try
            {
                datos.verificadorCotizar = 3;
                DataSet Datos = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "cotizarTourEmpresa_sp",
                new SqlParameter("@id_seccion", datos.id_seccion),
                new SqlParameter("@id_tour", datos.id_tour),
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
                new SqlParameter("@numeroPersonasCotizar", datos.numeroPersonasCotizar)
                );
                if (Datos.Tables[0] != null)
                {
                    foreach (DataRow aux in Datos.Tables[0].Rows)
                    {
                        datos.verificadorCotizar = Convert.ToInt32(aux["BanCotizacionSistema"].ToString());
                        if (datos.verificadorCotizar == 1 || datos.verificadorCotizar == 2)
                        {
                            datos.datosGeneralesCorreo = Datos.Tables[1];
                            datos.tablaRedesSociales = Datos.Tables[2];
                            datos.TablaPaquetesPopulares = Datos.Tables[3];
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
