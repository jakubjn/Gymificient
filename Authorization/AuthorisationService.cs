using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace GymSystem.Authorization
{
    public class AuthorisationService : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthorisationService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null) return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimsPrinciple = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrinciple));
            } catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrinciple;

            if(userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrinciple = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
            } else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrinciple = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrinciple)));
        }

        public async Task<UserSession> GetUserSessionAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                return userSession;
            } catch
            {
                return new UserSession();
            }
        }
    }
}
