using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1SegundoCuatri.Managers;
using TP1SegundoCuatri.Modelo;

namespace TP1SegundoCuatri.UI
{
    public class Vista
    {
        AdminDetalleFactura DetalleFactura = new AdminDetalleFactura();
        AdminFactura adminFactura = new AdminFactura();
        Factura factura;
        DetalleFactura detalle;
        int op = 0;
        int op2 = 0;
        double total = 0;
        public Vista() {
            do
            {
                Console.WriteLine("1) Crear factura");
                Console.WriteLine("2) Traer facturas");
                Console.WriteLine("0) Salir");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            try
                            {
                                factura = new Factura();
                                Console.WriteLine("Ingrese tipo de factura");
                                factura.Tipo = Convert.ToChar(Console.ReadLine());
                                Console.WriteLine("Ingrese el Cliente");
                                factura.Receptor = Console.ReadLine();
                                do
                                {
                                    Console.WriteLine("ingrese los productos");
                                    detalle = new DetalleFactura() { Producto = Console.ReadLine() };
                                    Console.WriteLine("ingrese el costo Neto");
                                    detalle.CostBruto = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("ingrese Cantidad");
                                    detalle.Cantidad = Convert.ToInt32(Console.ReadLine());
                                    factura.ListaFactu.Add(detalle);
                                    total += detalle.CostBruto * detalle.Cantidad;
                                    Console.WriteLine("presione 0 para salir sino presione cualquier tecla para continuar");
                                    op2 = Convert.ToInt32(Console.ReadLine());
                                } while (op2 != 0);
                                factura.TotNeto = total;
                                factura.TotBruto = Utilidades.CalcularBruto(total);
                                int id = adminFactura.CrearFactura(factura.TotBruto, factura.TotNeto, factura.Receptor, factura.Tipo);
                                foreach (var detalle in factura.ListaFactu)
                                    DetalleFactura.CrearDetalle(detalle.Producto, detalle.CostBruto, detalle.Cantidad, id);
                                Console.WriteLine("Se creo Correctaente");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("ocurrio un error al crear");
                            }                            
                        }
                        break;

                    case 2:
                        {
                            var facturas = adminFactura.TraerFacturas();
                            foreach (var fact in facturas)
                            {
                                Console.WriteLine(fact.ToString());
                            }
                        }
                        break;
                }
                
            } while (op != 0);
        }
    }
}
