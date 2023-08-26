using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1SegundoCuatri.Modelo
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public double TotBruto { get; set; }
        public double TotNeto { get; set; }
        public string Receptor { get; set; }
        public string Emisor { get; set; }
        public char Tipo { get; set; }
        public List<DetalleFactura> ListaFactu { get; set;} = new List<DetalleFactura>();

        public override string ToString()
        {
            var resultado = $"Tipo: {Tipo}, Fecha: {FechaEmision.ToShortDateString()}\nNeto: {TotNeto}\nBruto: {TotBruto}";
            resultado += $"\nReceptor: {Receptor}\nEmisor: {Emisor}\n";
            foreach (var item in ListaFactu)
            {
                resultado += item.ToString() ;
            }
            return resultado;
        }
    }
}
