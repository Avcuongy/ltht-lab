using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpServer
{
    public static void Run()
    {
        IPAddress serverIp = IPAddress.Loopback;
        int serverPort = 5000;

        TcpListener listener = new TcpListener(serverIp, serverPort);
        listener.Start();

        Console.WriteLine($"[SERVER] Listening on {serverIp}:{serverPort}");
        Console.WriteLine("[SERVER] Waiting for client...\n");

        System.Net.Sockets.TcpClient client = listener.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        // info endpoint
        IPEndPoint clientEndPoint =
            client.Client.RemoteEndPoint as IPEndPoint;
        IPEndPoint serverEndPoint =
            client.Client.LocalEndPoint as IPEndPoint;

        Console.WriteLine("[SERVER] Connection established");
        Console.WriteLine($"[SERVER] My endpoint     : {serverEndPoint.Address}:{serverEndPoint.Port}");
        Console.WriteLine($"[SERVER] Client endpoint : {clientEndPoint.Address}:{clientEndPoint.Port}\n");

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        Console.WriteLine($"[SERVER] Received: {message}");

        string response = "Hello from TCP Server";
        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
        stream.Write(responseBytes, 0, responseBytes.Length);

        client.Close();
        listener.Stop();
    }
}

