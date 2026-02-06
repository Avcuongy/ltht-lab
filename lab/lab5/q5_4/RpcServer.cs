using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

public class RpcServer
{
    static double MoneyExchange(string currency, double amount)
    {
        if (currency.ToUpper() == "USD")
            return amount * 26000;  // Tỷ giá USD -> VND

        throw new Exception("Không hỗ trợ loại tiền tệ này");
    }

    public static void Run()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("Server đang lắng nghe tại port 5000...");

        while (true)
        {
            Console.WriteLine("Đang chờ client...");
            System.Net.Sockets.TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client đã kết nối");

            using (var stream = ((System.Net.Sockets.TcpClient)client).GetStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream) { AutoFlush = true })
            {
                // Nhận request từ client
                string requestJson = reader.ReadLine();
                if (requestJson == null)
                {
                    throw new Exception("Client disconnected or sent empty request.");
                }
                Console.WriteLine("Nhận request: " + requestJson);

                // Deserialize
                var request = JsonSerializer.Deserialize<Request>(requestJson);
                if (request == null)
                {
                    throw new Exception("Deserialization failed: request is null.");
                }

                // Thực thi hàm
                double result = MoneyExchange(request.currency, request.amount);

                // Tạo response
                string responseJson = JsonSerializer.Serialize(new { result });
                writer.WriteLine(responseJson);

                Console.WriteLine("Đã trả kết quả: " + responseJson);
            }

            client.Close();
        }
    }
}