using InternetServices.Interfaces;

namespace InternetServices.Models
{
    public class WebHostEnvironmentImp : IWebHostEnvironmentAble
    {
        private IWebHostEnvironment? Environment { get; set; } = null;
        public WebHostEnvironmentImp(IWebHostEnvironment environment)
        {
            this.Environment = environment;
        }

        public void SetEnvironmentName(string? name)
        {
            if (string.IsNullOrEmpty(name)) return;
            if (this != null && this.Environment != null)
            {
                this.Environment.EnvironmentName = name;
            }
        }

        public string? GetEnvironmentName()
        {
            if (this != null && this.Environment != null)
            {
                return Environment.EnvironmentName;
            }
            return null;
        }

        public void SetApplicationName(string? name)
        {
            if (string.IsNullOrEmpty(name)) return;
            if (this != null && this.Environment != null)
            {
                this.Environment.ApplicationName = name;
            }
        }

        public string? GetApplicationName()
        {
            if (this != null && this.Environment != null)
            {
                return Environment.ApplicationName;
            }
            return null;
        }

        public string? GetWebRootPath()
        {
            if (this != null && this.Environment != null)
            {
                return Environment.WebRootPath;
            }
            return null;
        }

        public void SetWebRootPath(string? newPath)
        {
            if (string.IsNullOrEmpty(newPath)) return;
            if (this != null && this.Environment != null)
            {
                this.Environment.WebRootPath = newPath;
            }
        }
    }
}
