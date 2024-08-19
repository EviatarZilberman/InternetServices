using System.Numerics;

namespace InternetServices.AppSettingsReader
{
    /// <summary>
    /// Reads the appsettings.json for specific project that provides the Iconfiguration argument.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        public T? GetStructValue<T>(string tag, string key) where T : struct
        {
            return this._Configuration?.GetValue<T>(GenerateSetting(tag, key));
        }

        public T? GetClassValue<T>(string tag, string key) where T: class
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
