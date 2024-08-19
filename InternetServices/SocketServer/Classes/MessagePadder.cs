using InternetServices.AppSettingsReader;

namespace InternetServices.SocketServer.Classes
{
    public class MessagePadder
    {
        private readonly IConfiguration Configuration;
        private readonly string? prePadding = string.Empty;
        private readonly string? postPadding = string.Empty;

        public MessagePadder(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.prePadding = new AppsettingsReader<string>(this.Configuration).GetClassValue<string>("Padding", "PrePadding");
            this.postPadding = new AppsettingsReader<string>(Configuration).GetClassValue<string>("Padding", "PostPadding");
        }


        public string AddPadding(string message)
        { 
            return this.prePadding + message + this.postPadding;
        }

        public string RemovePadding(string message)
        {
            return message.Trim();
        }
    }
}
