using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1SegundoCuatri.Datos;
using TP1SegundoCuatri.Modelo;

namespace TP1SegundoCuatri.Managers
{
    public class AdminDetalleFactura
    {
        private readonly DetalleFacturaDatos _datos = new DetalleFacturaDatos();
        
        public int CrearDetalle(string producto, double costbruto, int cantidad, int idFactura)
        {
            DetalleFactura detalle = new DetalleFactura()
            {
                Cantidad = cantidad,
                Producto = producto,
                CostBruto = costbruto,
                IdFactura = idFactura
            };
           return _datos.CrearDetalle(detalle);
        }
    }
}
