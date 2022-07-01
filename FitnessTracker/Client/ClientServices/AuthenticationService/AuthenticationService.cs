using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using FitnessTracker.Client.Authentication;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FitnessTracker.Client.ClientServices.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IToastService _toastService;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient,
            AuthenticationStateProvider authStateProvider,
            ILocalStorageService localStorage,
            IToastService toastService)
        {
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<bool> RegisterUser(UserModel model)
        {
            var data = new { model.FirstName, model.LastName, model.EmailAddress, model.Password, model.Nationality, model.GenderId, model.Age };

            using (HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Register", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    return false;
                }

                return true;
            }
        }

        public async Task<AuthenticatedUser> Login(AuthenticatingUser userToBeAuthenticated)
        {
            string inputJson = JsonConvert.SerializeObject(userToBeAuthenticated);
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");

            using (var authResult = await _httpClient.PostAsync($"/token", inputContent))
            {
                if (authResult.IsSuccessStatusCode == false)
                {
                    _toastService.ShowWarning($"Unable to login", $"{authResult.ReasonPhrase}");
                    return null;
                }
                else
                {
                    var result = JsonSerializer.Deserialize<AuthenticatedUser>(
                        await authResult.Content.ReadAsStringAsync(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    await _localStorage.SetItemAsync("auth_token", result.Access_Token);
                    await _localStorage.SetItemAsync("credentials", userToBeAuthenticated);
                    ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Access_Token);

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Access_Token);

                    return result;
                }
            }
        }

        public async Task<List<Gender>> GetGenders()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Gender>>>("api/Identity");
            return result?.Data;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("auth_token");
            await _localStorage.RemoveItemAsync("credentials");

            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
