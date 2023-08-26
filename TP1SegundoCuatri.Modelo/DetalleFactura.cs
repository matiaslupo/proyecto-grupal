using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1SegundoCuatri.Modelo
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public double CostBruto { get; set; }
        public int Cantidad { get; set; }
        public string Producto { get; set; }
        public int IdFactura { get; set; }

        public override string ToString()
        {
            var resultado = $"Producto: {Producto}\nSubtotal bruto: {CostBruto}\nCantidad: {Cantidad}";
            return resultado;
        }
    }
}
