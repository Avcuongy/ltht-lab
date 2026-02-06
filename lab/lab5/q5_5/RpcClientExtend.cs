using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

public class RpcClientExtend
{
    public static void Run()
    {
        System.Net.Sockets.TcpClient client = null;
        NetworkStream stream = null;
        StreamWriter writer = null;
        StreamReader reader = null;
        try
        {
            client = new System.Net.Sockets.TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();
            writer = new StreamWriter(stream) { AutoFlush = true };
            reader = new StreamReader(stream);

            var request = new JsonRpcRequest
            {
                id = 1,
                method = "MoneyExchange",
                @params = new object[] { "USD", 200.0 }
            };

            string requestJson = JsonSerializer.Serialize(request);
            writer.WriteLine(requestJson);
            Console.WriteLine("Gửi: " + requestJson);

            string responseJson = reader.ReadLine();
            Console.WriteLine("Nhận: " + responseJson);

            var response = JsonSerializer.Deserialize<JsonRpcResponse>(responseJson);

            if (response != null && response.error != null)
            {
                Console.WriteLine($"Lỗi RPC: {response.error.message}");
            }
            else
            {
                Console.WriteLine($"Kết quả: {(response != null ? response.result : "No response")}");
            }
        }
        finally
        {
            if (reader != null) reader.Dispose();
            if (writer != null) writer.Dispose();
            if (stream != null) stream.Dispose();
            if (client != null) client.Dispose();
        }
    }
}
