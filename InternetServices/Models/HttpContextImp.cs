using InternetServices.Enums;
using InternetServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace InternetServices.Models
{
    public class HttpContextImp : IHttpContextAble
    {
        private HttpContext? Context { get; set; } = null;

        public HttpContextImp(HttpContext? context)
        {
            this.Context = context;
        }

        public string? GetIPv4()
        {
            return this.Context?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();
        }

        public string? GetIPv6()
        {
            return this.Context?.Connection?.RemoteIpAddress?.MapToIPv6().ToString();
        }

        public string? GetLocalIpv4()
        {
            return this.Context?.Connection?.LocalIpAddress?.MapToIPv4().ToString();
        }

        public string? GetLocalIpv6()
        {
            return this.Context?.Connection?.LocalIpAddress?.MapToIPv6().ToString();
        }

        public string? GetSessionId()
        {
            return this.Context?.Session.Id;
        }

        public void ClearSession()
        {
            this.Context?.Session.Clear();
        }

        public bool SetSessionKeyValue(string key, object value)
        {
            if (string.IsNullOrEmpty(key) || value == null)
            {
                return false;
            }
            try
            {
                string? stringValue = value?.ToString();
                if (string.IsNullOrEmpty(stringValue))
                {
                    return false;
                }
                byte[] bytesValue = Convert.FromBase64String(stringValue);
                this.Context?.Session.Set(key, bytesValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public object? GetSessionValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            return this.Context?.Session.Get(key);
        }

        public void RemoveKeyFromSession(string key)
        {
            if (!string.IsNullOrEmpty(key)) return;
            this.Context?.Session.Remove(key);
        }

        public void AddSessionItem(string key, object value)
        {
            if (string.IsNullOrEmpty(key)) return;
            this.Context?.Items.Add(key, value);
        }

        public object? GetSessionItem(string key)
        {
            if (!string.IsNullOrEmpty(key)) throw new NullReferenceException(ReturnCodes.INVALID_PROVIDED_KEY.ToString());
            object? value = null;
            this.Context?.Items.TryGetValue(key, out value);
            return value;
        }

        public void RemoveSessionItem(string key)
        {
            if (!string.IsNullOrEmpty(key)) throw new NullReferenceException(ReturnCodes.INVALID_PROVIDED_KEY.ToString());
            this.Context?.Items.Remove(key);
        }

        public void ClearSessionItems()
        {
            this.Context?.Items.Clear();
        }

        public IRequestCookieCollection? GetAllCookies()
        {
            return this.Context?.Request.Cookies;
        }

        public async Task<ReturnCodes> CreateCookies(DateTimeOffset? expiration, Claim[]? claims = null, bool isPersistCookie = false, string? scheme = null, string? authType = null, string claimName = ClaimsIdentity.DefaultNameClaimType, string claimRole = ClaimsIdentity.DefaultRoleClaimType)
        {
            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistCookie,
                ExpiresUtc = expiration
            };
            var identity = new ClaimsIdentity(claims, authType, claimName, claimRole);
            try
            {
                if (this.Context != null)
                {
                    await this.Context.SignInAsync(scheme, new ClaimsPrincipal(identity), authenticationProperties /*8- Makes the cookie still aliveable.*/);
                    return ReturnCodes.SUCCESS;
                }
                return ReturnCodes.UNINITIALIZED_INSTANCE;
            }
            catch
            {
                return ReturnCodes.FAILED_TO_CREATE_COOKIES;
            }
        }
        public string? GetCookie(string key)
        {
            ClaimsPrincipal? claimUser = this.Context?.User;

            if (claimUser != null && claimUser.Identity != null)
            {
                if (claimUser.Identity.IsAuthenticated)
                {
                    return claimUser.Claims.ToList().FirstOrDefault(c => c.Type == key)?.Value;
                }
            }
            return null;
        }
    }
}