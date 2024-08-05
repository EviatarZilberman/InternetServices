using InternetServices.Interfaces;

namespace InternetServices.Classes
{
    public class HttpContextAccessorImp : IHttpContextAccessorAble
    {
        private HttpContextAccessor? ContextAccessor { get; set; } = null;
        private HttpContextImp? Context { get; set; } = null;
        public HttpContextAccessorImp(HttpContextAccessor? contextAccessor)
        {
            ContextAccessor = contextAccessor;
            Context = new HttpContextImp(this?.ContextAccessor?.HttpContext);
        }
    }
}
