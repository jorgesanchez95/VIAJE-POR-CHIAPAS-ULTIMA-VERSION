using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public class Sitemap_Datos
    {
        public DataSet ObtenerListaUrl(string Conexion)
        {
            try
            {
                DataSet ds = null;
                ds = SqlHelper.ExecuteDataset(Conexion, "spCSLDB_get_Sitemaps");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}