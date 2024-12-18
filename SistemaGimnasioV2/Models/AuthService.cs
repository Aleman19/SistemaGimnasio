namespace SistemaGimnasioV2.Models
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponse?> LoginAsync(string username, string password)
        {
            var loginRequest = new LoginRequest
            {
                Username = username,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();
                return userResponse; // Devuelve la respuesta del servidor
            }

            return null; // En caso de error
        }
    }
}
