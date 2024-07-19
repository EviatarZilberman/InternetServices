namespace InternetServices.Interfaces
{
    public interface IWebHostEnvironmentAble
    {
        public void SetEnvironmentName(string? name);
        public string? GetEnvironmentName();
        public void SetApplicationName(string? name);
        public string? GetApplicationName();
        public string? GetWebRootPath();
        public void SetWebRootPath(string? newPath);

    }
}
