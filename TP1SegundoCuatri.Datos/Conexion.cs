using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1SegundoCuatri.Datos
{
    public static class Conexion
    {
        private static string _connectionString = "datasource=localhost;port=3306;username=root;password=;database=clase12cuatri;";

        public static MySqlConnection Conectar()
        {
            return new MySqlConnection(_connectionString);
        }

        public static bool ChequearConexion() 
        { 
            bool conectable = false;
            MySqlConnection con = null;
            try
            {
                con = Conectar();
                con.Open();
                conectable = true;
                return conectable;
            }
            catch (MySqlException mex) 
            { 
                string mensaje = $"Mensaje: {mex.Message}\n Source: {mex.Source}\n Numero: {mex.Number}";
                switch (mex.Number)
                {
                    case 1042: mensaje += "\nServidor o puerto";
                        break;
                    case 0: mensaje += "\nAcceso denegado (usuario pass)";
                        break;
                    default: break;
                }
                throw new InvalidOperationException(mensaje);
            }
            catch (Exception)
            {
                throw;
            }
            finally { con?.Close(); }
        }
    }
}