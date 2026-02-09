using Microsoft.AspNetCore.Components;
using Radzen;

namespace WebBlazor.Services
{
    public class ExportService(NavigationManager navigationManager)
    {
        public void Export(string table, string type, Query query = null)
        {
			var url = query != null
				? query.ToUrl($"/Clientes/export/{type}")
				: $"/Clientes/export/{type}";

			navigationManager.NavigateTo($"http://localhost:5000{url}", true);
		}
    }
}
