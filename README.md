# EchoProcessingSolution

This solution consists of three projects:

1. **DateStream**: A TCP server that sends the current date and time every minute to connected clients.
2. **EchoProcessingServer**: A gRPC server that processes and responds to messages from clients.
3. **TcpToGrpcClient**: A client application that connects to the `DateStream` TCP server, forwards received data to the `EchoProcessingServer`, and processes the gRPC responses.

## Projects Overview

### 1. DateStream

`DateStream` is a TCP server that broadcasts the current date and time to connected clients every minute. This server uses basic TCP and threading operations to handle multiple clients.

#### Features

- Listens on port `67` for incoming TCP connections.
- Sends the current date and time every minute.

#### Running DateStream

1. **Navigate to the DateStream Directory**

   ```sh
   cd DateStream

2. **Run the Application**

   ```sh
   dotnet run

### 2. EchoProcessingServer
`EchoProcessingServer` is a gRPC server that receives messages, processes them, and sends back a response. It acts as a service that the `TcpToGrpcClient` interacts with.

#### Features

- Defines a gRPC service for message processing.
- Provides a response based on the received message.

#### Running EchoProcessingServer

1. **Navigate to the EchoProcessingServer Directory**

   ```sh
   cd EchoProcessingServer

2. **Run the Application**

   ```sh
   dotnet run

### 3. TcpToGrpcClient
`TcpToGrpcClient` is a client application that connects to the DateStream TCP server, receives date and time data, and forwards it to the `EchoProcessingServer` using gRPC. It then displays the gRPC responses.

#### Features

- Connects to the `DateStream` TCP server.
- Sends received data to the `EchoProcessingServer` via gRPC.
- Displays the response from the gRPC server.

#### Running TcpToGrpcClient

1. **Navigate to the TcpToGrpcClient Directory**

   ```sh
   cd TcpToGrpcClient

2. **Run the Application**

   ```sh
   dotnet run

## Solution Setup

### Cloning the Repository
Clone this repository to your local machine:
   ```sh
   git clone https://github.com/furkansarikaya/EchoProcessingSolution.git
  ```

### Building the Solution
Navigate to the solution directory and build the entire solution:
   ```sh
    dotnet build
  ```

### Configuration
Ensure that the `EchoProcessingServer` gRPC server URL in `TcpToGrpcClient` is correctly set.
For example:

   ```csharp
    var channel = GrpcChannel.ForAddress("https://localhost:7042");
  ```

### Dependencies
- .NET SDK (version 8.0 or later)
- Ensure all necessary NuGet packages are restored:
   ```sh
    dotnet restore
  ```