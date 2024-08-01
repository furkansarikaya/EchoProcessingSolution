using System.Net.Sockets;
using System.Text;
using EchoServiceNamespace;
using Grpc.Net.Client;

const string tcpServerAddress = "localhost";
const int tcpServerPort = 67; // Echo sunucusu

// TCP istemcisi oluşturma ve bağlanma
// TCP istemcisi oluşturma ve bağlanma
using var tcpClient = new TcpClient();

try
{
    await tcpClient.ConnectAsync(tcpServerAddress, tcpServerPort);
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to connect to TCP server: {ex.Message}");
    return;
}

var networkStream = tcpClient.GetStream();

// gRPC istemcisi oluşturma
var channel = GrpcChannel.ForAddress("https://localhost:7042"); // gRPC servisinize uygun adresi kullanın
var grpcClient = new EchoService.EchoServiceClient(channel);

var buffer = new byte[1024];
int bytesRead;
while ((bytesRead = await networkStream.ReadAsync(buffer)) != 0)
{
    var receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    Console.WriteLine($"Received data from TCP: {receivedData}");

    // gRPC servisine veri gönderme
    var request = new EchoRequest { Message = receivedData };
    var response = await grpcClient.ProcessEchoAsync(request);

    Console.WriteLine($"gRPC response: {response.Message}");
}