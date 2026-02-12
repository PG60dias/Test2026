namespace Domain.Services.Precios
{
	public interface ICalcularPrecioClientes
	{
		decimal Calcular(decimal pvpBase);
	}

	public class PrecioClienteDePaso : ICalcularPrecioClientes { public decimal Calcular(decimal p) => p * 1.10m; }
	public class PrecioClienteHabitual : ICalcularPrecioClientes { public decimal Calcular(decimal p) => p; }
	public class PrecioClienteVip : ICalcularPrecioClientes { public decimal Calcular(decimal p) => p * 0.75m; }
}