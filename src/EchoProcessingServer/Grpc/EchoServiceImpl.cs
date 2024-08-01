using EchoServiceNamespace;
using Grpc.Core;

namespace EchoProcessingServer.Grpc;

public class EchoServiceImpl : EchoService.EchoServiceBase
{
    public override Task<EchoResponse> ProcessEcho(EchoRequest request, ServerCallContext context)
    {
        // İşleme mantığınızı buraya ekleyin
        var receivedMessage = request.Message;
        Console.WriteLine($"Received message: {receivedMessage}");

        return Task.FromResult(new EchoResponse
        {
            Message = "Echo processed successfully"
        });
    }
}