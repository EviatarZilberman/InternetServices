using InternetServices.Interfaces;

namespace InternetServices.Models
{
    public class HttpContextAccessorImp : IHttpContextAccessorAble
    {
        private HttpContextAccessor? ContextAccessor { get; set; } = null;
        public HttpContextAccessorImp(HttpContextAccessor? contextAccessor)
        {
            ContextAccessor = contextAccessor;
        }

        
    }
}
