using InternetServices.AppSettingsReader;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace InternetServices.SocketServer.Classes
{
    public class TCPServer
    {
        private readonly IConfiguration Configuration;
        private TcpListener Listener { get; set; }
        public TCPServer()
        {
            this.StartServer();
        }

       public void StartServer()
        {
            AppsettingsReader<int> intReader = new AppsettingsReader<int>(this.Configuration);
            AppsettingsReader<string> stringReader = new AppsettingsReader<string>(this.Configuration);

            var port = (int)intReader.GetStructValue<int>("SocketData", "Host");
            var hostAddress = IPAddress.Parse(stringReader.GetClassValue<string>("SocketData", "Port"));
            this.Listener = new TcpListener(hostAddress, port);
            this.Listener.Start();

            byte[] buffer = new byte[256];
            string recievedMessage = string.Empty;

            using TcpClient client = this.Listener.AcceptTcpClient();

            var tcpStream = client.GetStream();
            int readTotal = 0;

            MessagePadder messagePadder = new(this.Configuration);
            while((readTotal = tcpStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string incomingMessage = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Trim();
                string unPaddedIncomingMessage = messagePadder.RemovePadding(incomingMessage);
                Console.WriteLine(incomingMessage);

                if (!string.IsNullOrEmpty(incomingMessage))
                {
                    string responseMessage = "SUCCESSFULLY RESPOND!".Trim();
                    string paddedResponseMessage = messagePadder.AddPadding(responseMessage);
                    byte[] response = Encoding.UTF8.GetBytes(paddedResponseMessage);
                    tcpStream.Write(response, 0, response.Length);
                }


            }
        }
    }
}
