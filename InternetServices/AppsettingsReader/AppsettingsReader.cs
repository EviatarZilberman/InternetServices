namespace InternetServices.AppsettingsReader
{
    public class AppsettingsReader<T>
    {
        private readonly IConfiguration? _Configuration = null;

        public AppsettingsReader(IConfiguration configuration)
        {
            this._Configuration = configuration;
        }

        private string GenerateSetting (string tag, string key)
        {
            return $"{tag}:{key}";
        }

        public T? GetAppValue<T>(string tag, string key) where T: class
        {
            return this._Configuration?.GetValue<T>(GenerateSetting(tag, key));
        }

        public T[]? GetAppSectionArray(string tag, string key)
        {
            return this._Configuration?.GetSection(GenerateSetting(tag, key)).Get<T[]>();
        }

        public List<T>? GetAppSectionList(string tag, string key)
        {
            return this._Configuration?.GetSection(GenerateSetting(tag, key)).Get<List<T>>();
        }
    }
}
