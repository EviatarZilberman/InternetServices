using InternetServices.Enums;
using System.Security.Claims;

namespace InternetServices.Interfaces
{
    public interface IHttpContextAble
    {
        public string? GetIPv4();
        public string? GetIPv6();
        public string? GetLocalIpv4();
        public string? GetLocalIpv6();
        public string? GetSessionId();
        public void ClearSession();
        public bool SetSessionKeyValue(string key, object value);
        public object? GetSessionValue(string key);
        public void RemoveKeyFromSession(string key);
        public void AddRequestItem(string key, object value);
        public object? GetRequestItem(string key);
        public void RemoveRequestItem(string key);
        public void ClearRequestItems();
        public IRequestCookieCollection? GetAllCookies();
        public Task<ReturnCodes> CreateCookies(DateTimeOffset? expiration, Claim[]? claims = null, bool isPersistCookie = false, string? scheme = null, string? authType = null, string claimName = ClaimsIdentity.DefaultNameClaimType, string claimRole = ClaimsIdentity.DefaultRoleClaimType);
        public string? GetCookie(string key);
    }
}
