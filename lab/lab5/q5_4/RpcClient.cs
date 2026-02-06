using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

public class RpcClient
{
    public static void Run()
    {
        try
        {
            using (var client = new System.Net.Sockets.TcpClient())
            {
                client.Connect("127.0.0.1", 5000);
                Console.WriteLine("Đã kết nối tới server");

                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Chuẩn bị request
                    var request = new { currency = "USD", amount = 200.0 };
                    string requestJson = JsonSerializer.Serialize(request);
                    writer.WriteLine(requestJson);
                    Console.WriteLine("Đã gửi: " + requestJson);

                    // Nhận kết quả
                    string responseJson = reader.ReadLine();
                    if (responseJson == null)
                    {
                        Console.WriteLine("Không nhận được phản hồi từ server.");
                        return;
                    }

                    Console.WriteLine("Nhận: " + responseJson);

                    var response = JsonSerializer.Deserialize<Response>(responseJson);
                    if (response != null)
                    {
                        Console.WriteLine($"Kết quả chuyển đổi: {response.result} VND");
                    }
                    else
                    {
                        Console.WriteLine("Phản hồi không hợp lệ từ server.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }
}
