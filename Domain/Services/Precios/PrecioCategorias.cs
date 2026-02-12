namespace Domain.Services.Precios
{
	public static class PrecioCategorias
	{
		public static ICalcularPrecioClientes ObtenerPrecioCat(int? categoria)
		{
			return categoria switch
			{
				1 => new PrecioClienteDePaso(),
				3 => new PrecioClienteVip(),
				_ => new PrecioClienteHabitual()
			};
		}
	}
}