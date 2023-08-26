using MySql.Data.MySqlClient;
using TP1SegundoCuatri.Modelo;

namespace TP1SegundoCuatri.Datos;

public class DetalleFacturaDatos
{
    public IEnumerable<DetalleFactura> ObtenerDetallesPorFactura(int idFactura)
    {
        List<DetalleFactura> detalles = new List<DetalleFactura>();
        using (var con= Conexion.Conectar())
        {
            var query = "SELECT * FROM detallesfacturas WHERE id_factura= @id";
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("id", idFactura);
            con.Open();
            try
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DetalleFactura factura = new DetalleFactura()
                    {
                        Id = reader.GetInt32("id"),
                        Producto = reader.GetString("producto"),
                        CostBruto = reader.GetDouble("costbruto"),
                        Cantidad = reader.GetInt32("cantidad"),
                        IdFactura = reader.GetInt32("id_factura")
                    };
                    detalles.Add(factura);
                }
                return detalles;
            }
            catch (Exception)
            {
                throw;
            }
            finally { con.Close(); }
        }
    
    }

    public int CrearDetalle(DetalleFactura detalleFactura)
    {
        int id = 0;
        using (MySqlConnection con = Conexion.Conectar())
        {
            var query = "INSERT INTO detallesfacturas(producto, costbruto, cantidad, id_factura)" +
                "Values (@Producto, @CostBruto, @Cantidad, @id_factura);" +
                "SELECT LAST_INSERT_ID() AS id;";
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;
            con.Open();
            try
            {
                cmd.Parameters.AddWithValue("@producto", detalleFactura.Producto);
                cmd.Parameters.AddWithValue("@costbruto", detalleFactura.CostBruto);
                cmd.Parameters.AddWithValue("@cantidad", detalleFactura.Cantidad);
                cmd.Parameters.AddWithValue("@id_factura", detalleFactura.IdFactura);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32("id");
                    
                }
                con.Close();
                return id;
            }
            catch (Exception)
            {
                con.Close();
                return id;
            }
        }
    }
}
