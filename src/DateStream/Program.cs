using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 67; // Dinlenecek port

using var server = new TcpListener(IPAddress.Any, port);
server.Start();

Console.WriteLine("Sunucu başlatıldı. Port: " + port);

while (true)
{
    var client = server.AcceptTcpClient();
    Console.WriteLine("Yeni bir istemci bağlandı.");

    var thread = new Thread(() =>
    {
        var stream = client.GetStream();

        while (true)
        {
            var currentTime = DateTime.Now.ToString();
            var data = Encoding.UTF8.GetBytes(currentTime);
            stream.Write(data, 0, data.Length);

            // Her dakika bir kez göndermek için
            Thread.Sleep(60000);
        }
    });
    thread.Start();
}