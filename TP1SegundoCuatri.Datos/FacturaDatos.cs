using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1SegundoCuatri.Modelo;

namespace TP1SegundoCuatri.Datos
{
    public class FacturaDatos
    {
        public int CrearFactura(Factura factura)
        {
            int id = 0;
            using (MySqlConnection con = Conexion.Conectar())
            {
                var query = "INSERT INTO facturas(tipo, totbruto, totneto, receptor)" +
                    "Values (@Tipo, @TotBruto, @TotNeto, @Receptor);" +
                    "SELECT LAST_INSERT_ID() AS id;";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Tipo", factura.Tipo);
                    //cmd.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                    cmd.Parameters.AddWithValue("@TotBruto", factura.TotBruto);
                    cmd.Parameters.AddWithValue("@TotNeto", factura.TotNeto);
                    cmd.Parameters.AddWithValue("@Receptor", factura.Receptor);
                    var reader = cmd.ExecuteReader();                    
                    while (reader.Read()) {
                        id= reader.GetInt32("id");
                    }
                    con.Close();
                    return id;
                }
                catch (Exception)
                {
                    con.Close();
                    throw;
                }
            }
        }

        public bool ActualizarFactura(Factura factura)
        {
            using (MySqlConnection con = Conexion.Conectar())
            {
                var query = "UPDATE facturas SET tipo = @TIPO, fechaemision=@FechaEmision, totbruto=@TotBruto, totneto=@TotNeto, receptor=@Receptor";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Tipo", factura.Tipo);
                    cmd.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                    cmd.Parameters.AddWithValue("@TotBruto", factura.TotBruto);
                    cmd.Parameters.AddWithValue("@TotNeto", factura.TotNeto);
                    cmd.Parameters.AddWithValue("@Receptor", factura.Receptor);
                    var reader = cmd.ExecuteNonQuery();                    
                    con.Close();
                    return true;
                }
                catch (Exception)
                {
                    con.Close();                    
                    throw;
                }
            }
        }

        public IEnumerable<Factura> ListarFacturas() 
        {
            List<Factura> facturas = new List<Factura>();
            using (var con= Conexion.Conectar())
            {
                var query = "SELECT * FROM facturas";
                MySqlCommand cmd= con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {  
                    var reader = cmd.ExecuteReader(); 
                    while (reader.Read())
                    {
                        Factura factura = new Factura()
                        {
                            Id = reader.GetInt32("id"),
                            FechaEmision = reader.GetDateTime("fechaEmision"),
                            TotBruto = reader.GetDouble("totbruto"),
                            TotNeto = reader.GetDouble("totneto"),
                            Receptor = reader.GetString("receptor"),
                            Emisor = reader.GetString("emisor"),
                            Tipo = reader.GetChar("tipo")
                        };
                        facturas.Add(factura);
                    }
                    return facturas;
                }
                catch (Exception)
                {
                    throw;
                }
                finally { con.Close(); }
            }
        }

    }
}
