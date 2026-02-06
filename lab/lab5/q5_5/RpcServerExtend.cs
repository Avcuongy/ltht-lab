using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

public class RpcServerExtend
{
    public static double MoneyExchange(string currency, double amount)
    {
        if (currency.ToUpper() == "USD")
            return amount * 26000;

        throw new Exception("Không hỗ trợ loại tiền tệ này");
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static JsonRpcResponse CreateErrorResponse(int id, int code, string message)
    {
        return new JsonRpcResponse
        {
            id = id,
            error = new JsonRpcError { code = code, message = message }
        };
    }

    public static JsonRpcResponse Handle(JsonRpcRequest request)
    {
        try
        {
            if (request.@params == null || request.@params.Length == 0)
                throw new Exception("Params is required");

            var paramElements = request.@params.Select(param => (JsonElement)param).ToArray();

            if (request.method == "MoneyExchange")
            {
                if (paramElements.Length != 2)
                    throw new Exception("MoneyExchange requires 2 parameters");

                string currency = paramElements[0].GetString()
                    ?? throw new Exception("Currency must be string");

                double amount = paramElements[1].TryGetDouble(out double val)
                    ? val
                    : throw new Exception("Amount must be number");

                return new JsonRpcResponse
                {
                    id = request.id,
                    result = MoneyExchange(currency, amount)
                };
            }
            else if (request.method == "Add")
            {
                if (paramElements.Length != 2)
                    throw new Exception("Add requires 2 parameters");

                double a = paramElements[0].TryGetDouble(out double va) ? va : throw new Exception("a must be number");
                double b = paramElements[1].TryGetDouble(out double vb) ? vb : throw new Exception("b must be number");

                return new JsonRpcResponse
                {
                    id = request.id,
                    result = Add(a, b)
                };
            }
            else
            {
                return CreateErrorResponse(request.id, -32601, "Method not found");
            }
        }
        catch (Exception ex)
        {
            return CreateErrorResponse(request.id, -32603, ex.Message);
        }
    }

    public static void Run()
    {
        System.Net.Sockets.TcpListener server = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, 5000);
        server.Start();
        Console.WriteLine("JSON-RPC Server đang chạy tại port 5000");

        while (true)
        {
            System.Net.Sockets.TcpClient client = server.AcceptTcpClient();
            try
            {
                using (System.IO.Stream stream = client.GetStream())
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(stream) { AutoFlush = true })
                {
                    string requestJson = reader.ReadLine();
                    if (requestJson == null) return;

                    Console.WriteLine("Nhận: " + requestJson);

                    var request = System.Text.Json.JsonSerializer.Deserialize<JsonRpcRequest>(requestJson);
                    if (request == null) return;

                    var response = Handle(request);
                    string responseJson = System.Text.Json.JsonSerializer.Serialize(response);

                    writer.WriteLine(responseJson);
                    Console.WriteLine("Trả: " + responseJson);
                }
            }
            finally
            {
                client.Close();
            }
        }
    }
}
