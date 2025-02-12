using Blazored.LocalStorage;
using LotteryManager.UI.Authentication;
using LotteryManger.Domain.Models.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LotteryManager.UI
{
    public class ApiClient(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager, AuthenticationStateProvider authStateProvider)
    {
        public async Task SetAuthorizeHeader()
        {
            LoginResponseModel? sessionState = (await localStorage.GetItemAsync<LoginResponseModel>("sessionState"));

            if (sessionState is null || string.IsNullOrWhiteSpace(sessionState.Token))
            {
                return;
            }

            if (sessionState.TokenExpired < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            {
                await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                navigationManager.NavigateTo("/login");
            }
            else if (sessionState.TokenExpired < DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
            {
                LoginResponseModel? loginResponse = await httpClient.GetFromJsonAsync<LoginResponseModel>($"/api/Auth/loginByRefeshToken?refreshToken={sessionState.RefreshToken}");

                if (loginResponse != null)
                {
                    await ((CustomAuthStateProvider)authStateProvider).MarkUserAsAuthenticated(loginResponse);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
                }
                else
                {
                    await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                    navigationManager.NavigateTo("/login");
                }
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionState.Token);
            }
        }

        public async Task<T> GetFromJsonAsync<T>(string path)
        {
            await SetAuthorizeHeader();
            return await httpClient.GetFromJsonAsync<T>(path);
        }

        public async Task<T1> PostAsync<T1, T2>(string path, T2 postModel)
        {
            await SetAuthorizeHeader();

            var res = await httpClient.PostAsJsonAsync(path, postModel);
            if (res != null && res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
            }
            return default;
        }

        public async Task<T1> PutAsync<T1, T2>(string path, T2 postModel)
        {
            await SetAuthorizeHeader();
            var res = await httpClient.PutAsJsonAsync(path, postModel);
            if (res != null && res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
            }
            return default;
        }

        public async Task<T> DeleteAsync<T>(string path)
        {
            await SetAuthorizeHeader();
            return await httpClient.DeleteFromJsonAsync<T>(path);
        }
    }
}