using SistemaGimnasioV2.Models;

public class InventoryAlertService
{
    private readonly HttpClient _httpClient;

    public InventoryAlertService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<InventoryItem>> GetExpiringItemsAsync()
    {
        var response = await _httpClient.GetAsync("api/Inventory/Expiring");
        if (response.IsSuccessStatusCode)
        {
            // Manejo seguro del valor devuelto en caso de null
            var items = await response.Content.ReadFromJsonAsync<List<InventoryItem>>();
            return items ?? new List<InventoryItem>(); // Devuelve una lista vacía si es null
        }
        throw new HttpRequestException("Error al obtener los equipos próximos a vencer.");
    }
}
