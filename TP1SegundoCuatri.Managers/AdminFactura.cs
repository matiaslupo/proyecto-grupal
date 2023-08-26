using TP1SegundoCuatri.Datos;
using TP1SegundoCuatri.Modelo;

namespace TP1SegundoCuatri.Managers;

public class AdminFactura
{
	private readonly FacturaDatos _datos= new FacturaDatos();
	private readonly DetalleFacturaDatos _datosDetalles= new DetalleFacturaDatos();

    public bool SeConecta()
    {
		try
		{
			return Conexion.ChequearConexion() ;
		}
		catch (Exception)
		{
			throw;
		}
    }

    public IEnumerable<Factura> TraerFacturas()
    {
		try
		{
			List<Factura> facturas= _datos.ListarFacturas().ToList();
			foreach (var factura in facturas)
			{
				factura.ListaFactu = _datosDetalles.ObtenerDetallesPorFactura(factura.Id).ToList();
			}
			return facturas;
		}
		catch (Exception)
		{
			throw;
		}
    }

	public int CrearFactura(double totBruto, double totNeto, string receptor, char tipo)
	{
		Factura factura = new Factura()
		{
			TotBruto = totBruto,
			TotNeto = totNeto,
			Tipo = tipo,
			Receptor = receptor
		};

		return _datos.CrearFactura(factura);
	}

}
