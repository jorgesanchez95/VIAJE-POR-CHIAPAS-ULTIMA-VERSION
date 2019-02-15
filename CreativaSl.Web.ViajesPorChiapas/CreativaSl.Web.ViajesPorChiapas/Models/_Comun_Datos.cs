using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class ComunDatos
    {
        public List<PaisModels> ObtenerComboCatPaises(PaisModels datos)
        {
            try
            {
                List<PaisModels> lista = new List<PaisModels>();
                PaisModels item;
                //object[] parametros = { 143 };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatPaises_CH");
                while (dr.Read())
                {
                    item = new PaisModels();
                    item.id_pais = Convert.ToInt32(dr["id_pais"].ToString());
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
        public List<EstadoModels> ObtenerComboCatEstados(EstadoModels datos)
        {
            try
            {
                List<EstadoModels> lista = new List<EstadoModels>();
                EstadoModels item;
                object[] parametros = { datos.id_pais };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatEstados", parametros);
                while (dr.Read())
                {
                    item = new EstadoModels();
                    item.id_estado = Convert.ToInt32(dr["id_estado"].ToString());
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

        public List<MunicipioModels> ObtenerComboCatMunicipios(MunicipioModels datos)
        {
            try
            {
                List<MunicipioModels> lista = new List<MunicipioModels>();
                MunicipioModels item;
                object[] parametros = { datos.id_pais, datos.id_estado };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatMunicipios2", parametros);
                while (dr.Read())
                {
                    item = new MunicipioModels();
                    item.id_municipio = Convert.ToInt32(dr["id_municipio"].ToString());
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

        public List<TipoPaqueteModels> ObtenerComboCatTipoPaquete(TipoPaqueteModels datos)
        {
            try
            {
                List<TipoPaqueteModels> lista = new List<TipoPaqueteModels>();
                TipoPaqueteModels item;
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

        public List<TipoHabitacionModels> ObtenerComboCatTipoHabitacion(TipoHabitacionModels datos)
        {
            try
            {
                List<TipoHabitacionModels> lista = new List<TipoHabitacionModels>();
                TipoHabitacionModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoHabitacion");
                while (dr.Read())
                {
                    item = new TipoHabitacionModels();
                    item.id_tipoHabitacion = Convert.ToInt32(dr["id_tipohabitacion"].ToString());
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

        public List<TipoClienteModels> ObtenerComboCatTipoCliente(TipoClienteModels datos)
        {
            try
            {
                List<TipoClienteModels> lista = new List<TipoClienteModels>();
                TipoClienteModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatTipoCliente");
                while (dr.Read())
                {
                    item = new TipoClienteModels();
                    item.id_tipoCliente = Convert.ToInt32(dr["id_tipoCliente"].ToString());
                    item.tipoCliente = dr["tipoCliente"].ToString();
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatOcupacionesModels> ObtenerComboCatOcupaciones(CatOcupacionesModels datos)
        {
            try
            {
                List<CatOcupacionesModels> lista = new List<CatOcupacionesModels>();
                CatOcupacionesModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatOcupaciones");
                while (dr.Read())
                {
                    item = new CatOcupacionesModels();
                    item.id_ocupacion = Convert.ToInt32(dr["id_ocupacion"].ToString());
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

        public List<CatGeneroModels> ObtenerComboCatGenero(CatGeneroModels datos)
        {
            try
            {
                List<CatGeneroModels> lista = new List<CatGeneroModels>();
                CatGeneroModels item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatGeneros");
                while (dr.Read())
                {
                    item = new CatGeneroModels();
                    item.id_genero = Convert.ToInt32(dr["id_genero"].ToString());
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

        public List<CorreosUsuarioModels> ObtenerComboIntegrantesGrupo(IntegrantesGrupoModels datos)
        {
            try
            {
                object[] parametros = { datos.id_grupo };
                List<CorreosUsuarioModels> lista = new List<CorreosUsuarioModels>();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_ComboCatClientes", parametros);
                while (dr.Read())
                {
                    var item = new CorreosUsuarioModels();
                    item.id_cliente = dr["id_cliente"].ToString();
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
    }
}
