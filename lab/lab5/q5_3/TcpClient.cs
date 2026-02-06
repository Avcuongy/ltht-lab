using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpClient
{
    private string v1;
    private int v2;

    public TcpClient(string v1, int v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public static void Run()
    {
        string serverIp = "127.0.0.1";
        int serverPort = 5000;

        using (var client = new System.Net.Sockets.TcpClient())
        {
            client.Connect(serverIp, serverPort);

            NetworkStream stream = client.GetStream();

            // Lấy thông tin endpoint
            IPEndPoint clientEndPoint =
                client.Client.LocalEndPoint as IPEndPoint;
            IPEndPoint serverEndPoint =
                client.Client.RemoteEndPoint as IPEndPoint;

            Console.WriteLine("[CLIENT] Connected to server");
            Console.WriteLine($"[CLIENT] My endpoint     : {clientEndPoint.Address}:{clientEndPoint.Port}");
            Console.WriteLine($"[CLIENT] Server endpoint : {serverEndPoint.Address}:{serverEndPoint.Port}\n");

            string message = "Hello Server";
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"[CLIENT] Received: {response}");
        }
    }
}
