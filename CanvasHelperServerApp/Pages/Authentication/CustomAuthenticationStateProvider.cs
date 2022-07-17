using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CanvasHelperServerApp.Pages.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService) {
            _sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
             
            var username = await _sessionStorageService.GetItemAsStringAsync("username");
            ClaimsIdentity identity = username != null
                ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "basic_user")
                : new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkAsAuthenticated(string username) {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "basic_user");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkAsLoggedOut() {
            _sessionStorageService.RemoveItemAsync("username");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }
    }
}
