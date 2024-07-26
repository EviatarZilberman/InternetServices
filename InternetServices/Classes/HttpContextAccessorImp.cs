using InternetServices.Interfaces;

namespace InternetServices.Classes
{
    public class HttpContextAccessorImp : IHttpContextAccessorAble
    {
        private HttpContextAccessor? ContextAccessor { get; set; } = null;
        public HttpContextAccessorImp(HttpContextAccessor? contextAccessor)
        {
            ContextAccessor = contextAccessor;
        }

       /* public void a()
        {
            this.ContextAccessor;
        }*/
    }
}
