using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class TransportacionDatos
    {
        #region Admin
        #endregion
        #region Pagina
        public TransportacionModels ObtenerConfigDetalleVehiculo(TransportacionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo, datos.nombre_pagina };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigDetalleVehiculo", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaVehiculos= ds.Tables[1];
                            datos.tablaSeccion = ds.Tables[2];
                            datos.tablaSecciones = ds.Tables[3];
                            datos.tablaMetaTags = ds.Tables[4];
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
        public TransportacionModels ObtenerConfigVehiculo(TransportacionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo, datos.offset, datos.fetchNext };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigVehiculos", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaVehiculos = ds.Tables[1];
                            datos.tablaSeccion = ds.Tables[2];
                            datos.tablaSecciones = ds.Tables[3];
                            datos.tablaMetaTags = ds.Tables[4];
                            datos.numeroPaquetes = Convert.ToInt32(ds.Tables[5].Rows[0][0]);
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
        public TransportacionModels ObtenerConfigTransportacion(TransportacionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_tipoGaleria, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigTransportacionNew", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaCaracteristicasEmpresa = ds.Tables[1];
                            datos.tablaArticulos = ds.Tables[2];
                            datos.tablaGaleria = ds.Tables[3];
                            datos.tablaSeccion = ds.Tables[4];
                            datos.tablaSecciones = ds.Tables[5];
                            datos.tablaTipoVehiculosCotizar = ds.Tables[6];
                            datos.tablaMetaTags = ds.Tables[7];
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
        public TransportacionModels ObtenerConfigTransportacionEmpresa(TransportacionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigTransportacionEmpresaNew", parametros);
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
        #endregion
        #region Cotizacion
        public TransportacionModels CotizarTransporte(ref TransportacionModels datos)
        {
            try
            {
                datos.verificadorCotizar = 3;
                DataSet Datos = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "cotizarTransportacion_sp",
                new SqlParameter("@id_seccion", datos.id_seccion),
                new SqlParameter("@idClienteCotizar", datos.idClienteCotizar),
                new SqlParameter("@nombreCotizar", datos.nombreCotizar),
                new SqlParameter("@apellidoPaternoCotizar", datos.apellidoPaternoCotizar),
                new SqlParameter("@apellidoMaternoCotizar", datos.apellidoMaternoCotizar),
                new SqlParameter("@emailCotizar", datos.emailCotizar),
                new SqlParameter("@telefonoCotizar", datos.telefonoCotizar),
                new SqlParameter("@id_TipoVehiculoCotizar", datos.id_vehiculo),
                new SqlParameter("@fechaLlegadaCotizar", datos.fechaLlegadaCotizar),
                new SqlParameter("@horaLlegadaCotizar", datos.horaLlegadaCotizar),
                new SqlParameter("@fechaSalidaCotizar", datos.fechaSalidaCotizar),
                new SqlParameter("@horaSalidaCotizar", datos.horaSalidaCotizar),
                new SqlParameter("@numeroPersonasCotizar", datos.numeroPersonasCotizar),
                new SqlParameter("@numeroAdultoCotizar", datos.numeroAdultoCotizar),
                new SqlParameter("@numeroNiños511Cotizar", datos.numeroNiños511Cotizar),
                new SqlParameter("@numeroNiños14Cotizar", datos.numeroNiños14Cotizar),
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
        public TransportacionModels CotizarTransporteEmpresa(ref TransportacionModels datos)
        {
            try
            {
                datos.verificadorCotizar = 3;
                DataSet Datos = SqlHelper.ExecuteDataset(datos.conexion, CommandType.StoredProcedure, "cotizarTransportacionEmpresa_sp",
                new SqlParameter("@id_seccion", datos.id_seccion),
                new SqlParameter("@idClienteCotizar", datos.idClienteCotizar),
                new SqlParameter("@nombreCotizar", datos.nombreCotizar),
                new SqlParameter("@apellidoPaternoCotizar", datos.apellidoPaternoCotizar),
                new SqlParameter("@apellidoMaternoCotizar", datos.apellidoMaternoCotizar),
                new SqlParameter("@emailCotizar", datos.emailCotizar),
                new SqlParameter("@telefonoCotizar", datos.telefonoCotizar),
                new SqlParameter("@id_TipoVehiculoCotizar", datos.id_TipoVehiculoCotizar),
                new SqlParameter("@fechaLlegadaCotizar", datos.fechaLlegadaCotizar),
                new SqlParameter("@horaLlegadaCotizar", datos.horaLlegadaCotizar),
                new SqlParameter("@fechaSalidaCotizar", datos.fechaSalidaCotizar),
                new SqlParameter("@horaSalidaCotizar", datos.horaSalidaCotizar),
                new SqlParameter("@numeroPersonasCotizar", datos.numeroPersonasCotizar),
                new SqlParameter("@numeroAdultoCotizar", datos.numeroAdultoCotizar),
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

        #region Promociones
        public TransportacionModels ObtenerConfigPromociones(TransportacionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo, datos.offset, datos.fetchNext };
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigPromocionesNew", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaPromociones = ds.Tables[1];
                            datos.tablaSeccion = ds.Tables[2];
                            datos.tablaSecciones = ds.Tables[3];
                            datos.tablaMetaTags = ds.Tables[4];
                            datos.numeroPromociones = Convert.ToInt32(ds.Tables[5].Rows[0][0]);
                            datos.TablaPromocionesPopulares = ds.Tables[6];
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

        public TransportacionModels ObtenerConfigDetallePromociones(TransportacionModels datos)
        {
            try
            {
                object[] parametros = { datos.idioma, datos.id_seccion, datos.id_metaTags, datos.id_tipo, datos.nombre_pagina};
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(datos.conexion, "spCSLDB_get_ConfigDetallePromocion", parametros);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            datos.tablaDatosGenerales = ds.Tables[0];
                            datos.tablaPromociones = ds.Tables[1];
                            datos.tablaSeccion = ds.Tables[2];
                            datos.tablaSecciones = ds.Tables[3];
                            datos.tablaMetaTags = ds.Tables[4];
                            datos.TablaPromocionesPopulares = ds.Tables[5];
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
        #endregion
    }
}
