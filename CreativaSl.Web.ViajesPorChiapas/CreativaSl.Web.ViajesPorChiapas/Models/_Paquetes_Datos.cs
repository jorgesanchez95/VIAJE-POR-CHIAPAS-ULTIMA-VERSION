using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class PaquetesDatos
    {
        #region Admin

        public PaquetesModels ObtenerListaPaquetes(PaquetesModels datos)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatPaquete");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaPaquetes = ds.Tables[0];
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
        public PaquetesModels ObtenerListaPaquetesPrecios(PaquetesModels datos)
        {
            try
            {
                object[] parametros = {datos.id_paquete};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ListaCatPaquetesPrecios", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaPaquetes = ds.Tables[0];
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
        public PaquetesModels ObtenerDetallePaquetexId(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.id_paquete };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_DetalleCatPaqueteXId", parametros);
                while (dr.Read())
                {
                    datos.id_paquete = dr["id_paquete"].ToString();
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
                    datos.pathImg = dr["pathImg"].ToString();
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
        public PaquetesModels AbcCatPaquetes(PaquetesModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.opcion, datos.id_paquete, datos.id_seccion, datos.nombre, datos.nombreIngles, datos.descripcion, datos.descripcionIngles,datos.id_tipoPaquete,
                    datos.incluye,datos.incluyeIngles, datos.noIncluye,datos.noIncluyeIngles, datos.finDeServicios, datos.finDeServiciosIngles, datos.cantidadDias,
                    datos.cantidadNoches, datos.horaLlegada, datos.minutosLlegada, datos.id_pais, datos.id_estado,
                    datos.id_municipio, datos.latitud, datos.longitud,datos.pathImg, datos.alt, datos.title, datos.nombreArchivo, datos.tipoArchivo, datos.nombre_pagina, datos.user
                    };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_abc_CatPaquetes", parametros);
                datos.id_paquete = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PaquetesModels InsertarPaquetePrecio(PaquetesModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.id_paquete, datos.id_tipoHabitacion, datos.numeroEstrellas, datos.adultoAlta,
                    datos.ninioAlta, datos.adultoBaja, datos.ninioBaja, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_set_PaquetePrecio_sp", parametros);
                datos.id_paquete = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PaquetesModels ObtenerDetallePaquetePreciosxId(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.id_paquete, datos.id_tipoHabitacion, datos.numeroEstrellas };
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
        public PaquetesModels ModificarPaquetePrecio(PaquetesModels datos)
        {
            try
            {
                object[] parametros =
                {
                    datos.id_paquete, datos.id_tipoHabitacion, datos.numeroEstrellas, datos.adultoAlta,
                    datos.ninioAlta, datos.adultoBaja, datos.ninioBaja, datos.user
                };
                object aux = SqlHelper.ExecuteScalar(datos.conexion, "spCSLDB_set_ModificarPaquetePrecio_sp", parametros);
                datos.id_paquete = aux.ToString();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckPqqueteArchivoNamePaquete(PaquetesModels paquete)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(paquete.conexion, "spCSLDB_get_CheckCatPaquetesArchivoName", paquete.nombreArchivo);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
        public bool CheckPaqueteArchivoNnombreEsP(PaquetesModels paquete)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(paquete.conexion, "spCSLDB_get_CheckCatPaquetesArchivoNombreES", paquete.nombre);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CheckPaqueteArchivoNnombreIng(PaquetesModels paquete)
        {
            try
            {
                object aux = SqlHelper.ExecuteScalar(paquete.conexion, "spCSLDB_get_CheckCatPaquetesArchivoNombreING", paquete.nombreIngles);
                return aux.ToString().Equals("1") ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region Pagina
        public PaquetesModels ObtenerConfigPaquete(PaquetesModels datos)
        {
            try
            {
                DataSet ds = null;

                ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_get_ConfigPaquete",
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
                            datos.tablaPaquetes = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.numeroPaquetes = Convert.ToInt32(ds.Tables[6].Rows[0][0]);
                            datos.totalPaquetes = Convert.ToInt32(ds.Tables[7].Rows[0][0]);
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
        public PaquetesModels ObtenerConfigDetallePaquete(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.nombre_pagina, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigDetallePaquete", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaPaquetes = ds.Tables[1];
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
        public PaquetesModels ObtenerConfigPaquetes(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.nombre_pagina, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPaqueteNew", parametros);
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
        public PaquetesModels ObtenerConfigPaquetesVip(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_paquete, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPaqueteVipNew", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                           
                            datos.tablaSeccion = ds.Tables[1];
                            datos.tablaSecciones = ds.Tables[2];
                            datos.tablaSeccionesEstadosCotizar = ds.Tables[3];
                            datos.tablaLugaresTuristicosMunicipiosCotizar = ds.Tables[4];
                            datos.tablaTipoVehiculosCotizar = ds.Tables[5];
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
        public PaquetesModels ObtenerConfigPaqueteBusqueda(PaquetesModels datos)
        {
            try
            {
                DataSet ds = null;

                ds = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "spCSLDB_get_ConfigPaqueteBusqueda2",
                  new SqlParameter("@leguaje", datos.idioma),
                  new SqlParameter("@id_seccion", datos.id_seccion),
                  new SqlParameter("@offset", datos.offset),
                  new SqlParameter("@fetchNext", datos.fetchNext),
                  new SqlParameter("@tablaTagsSelecionados", datos.tablaTagsSelecionados),
                  new SqlParameter("@id_metaTags", datos.id_metaTags),
                  new SqlParameter("@id_tipoMetaTags", datos.id_tipo),
                  new SqlParameter("@id_estado", datos.id_estado),
                  new SqlParameter("@idPais", datos.id_pais),
                  new SqlParameter("@idtipopaquete", datos.modalidad)
                  );
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaTags = ds.Tables[1];
                            datos.tablaPaquetes = ds.Tables[2];
                            datos.tablaSeccion = ds.Tables[3];
                            datos.tablaSecciones = ds.Tables[4];
                            datos.tablaMetaTags = ds.Tables[5];
                            datos.numeroPaquetes = Convert.ToInt32(ds.Tables[6].Rows[0][0]);
                            datos.totalPaquetes = Convert.ToInt32(ds.Tables[7].Rows[0][0]);
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
        public PaquetesModels CotizarPaquete(ref PaquetesModels datos)
        {
            try
            {
                  datos.verificadorCotizar = 3;
                  DataSet Datos = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "cotizarPaquete_sp",
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
                              datos.tablaItinerario = Datos.Tables[4];
                              datos.TablaPaquetesPopulares = Datos.Tables[5];
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
        public PaquetesModels ObtenerConfigCotizarFinalizar(PaquetesModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigCotizarFinalizar", parametros);
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
        public PaquetesModels CotizarPaqueteVip(ref PaquetesModels datos)
        {
            try
            {
                  datos.verificadorCotizar = 3;
                  DataSet Datos = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "cotizarPaqueteVip_sp",
                  new SqlParameter("@id_seccion", datos.id_seccion),
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
                  new SqlParameter("@numeroPersonasCamaCotizar", datos.numeroPersonasCamaCotizar),
                  new SqlParameter("@recorridoLugaresTuristicosCotizar", datos.recorridoLugaresTuristicosCotizar),
                  new SqlParameter("@id_TipoVehiculoCotizar", datos.id_TipoVehiculoCotizar),
                  new SqlParameter("@observacionesCotizar", datos.observacionesCotizar)
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
                              datos.tablaItinerario = Datos.Tables[4];
                              datos.TablaPaquetesPopulares = Datos.Tables[5];
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

        public List<MunicipioModels> ObtenerComboCatLugares(MunicipioModels datos)
        {
            try
            {
                List<MunicipioModels> lista = new List<MunicipioModels>();
                MunicipioModels item;
                object[] parametros = { datos.id_estado, datos.id_pais };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatLugares", parametros);
                while (dr.Read())
                {
                    item = new MunicipioModels();
                    item.id_municipio2 = dr["id_municipio2"].ToString();
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Combos Paquete Vip
        public List<MunicipioModels> ObtenerComboCatMunicipios(MunicipioModels datos)
        {
            try
            {
                List<MunicipioModels> lista = new List<MunicipioModels>();
                MunicipioModels item;
                object[] parametros = { datos.id_estado };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatMunicipiosSecciones", parametros);
                while (dr.Read())
                {
                    item = new MunicipioModels();
                    item.id_municipio2 = dr["id_municipio2"].ToString();
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LugaresTuristicosModels> ObtenerComboCatLugaresTuristicos(LugaresTuristicosModels datos)
        {
            try
            {
                List<LugaresTuristicosModels> lista = new List<LugaresTuristicosModels>();
                LugaresTuristicosModels item;
                object[] parametros = { datos.id_pais, datos.id_estado, datos.id_municipio, datos.idioma };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatLugaresTuristicosMunicipiosSecciones", parametros);
                while (dr.Read())
                {
                    item = new LugaresTuristicosModels();
                    item.id_lugar = dr["id_lugar"].ToString();
                    item.nombre = dr["nombre"].ToString();
                    item.pathImg = dr["pathImg"].ToString();
                    item.latitud = dr["latitud"].ToString();
                    item.longitud = dr["longitud"].ToString();
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoPaqueteModels> ObtenerComboCatLugaresTuristicosHome(LugaresTuristicosModels datos)
        {
            try
            {
                List<TipoPaqueteModels> lista = new List<TipoPaqueteModels>();
                TipoPaqueteModels item;
                object[] parametros = { datos.id_pais, datos.id_estado, datos.idioma };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoPaquete");
                while (dr.Read())
                {
                    item = new TipoPaqueteModels();
                    item.id_tipoPaquete = Convert.ToInt32(dr["id_tipoPaquete"].ToString());
                    item.descripcion = dr["descripcion"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LugaresTuristicosModels> ObtenerComboCatLugaresTuristicosHomeTours(LugaresTuristicosModels datos)
        {
            try
            {
                List<LugaresTuristicosModels> lista = new List<LugaresTuristicosModels>();
                LugaresTuristicosModels item;
                object[] parametros = { datos.id_pais, datos.id_estado, datos.idioma };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatLugaresTuristicosHomeTours", parametros);
                while (dr.Read())
                {
                    item = new LugaresTuristicosModels();
                    item.id_lugar = dr["id_lugar"].ToString();
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

        public List<LugaresTuristicosModels> ObtenerSelecte(LugaresTuristicosModels datos)
        {
            try
            {
                List<LugaresTuristicosModels> lista = new List<LugaresTuristicosModels>();
                LugaresTuristicosModels item;
                item = new LugaresTuristicosModels();
                item.id_lugar = "";
                item.nombre = "-Seleccione-";
                lista.Add(item);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
