using System;

public class JsonRpcResponse
{
    public string jsonrpc { get; set; } = "2.0";
    public int id { get; set; }
    public object result { get; set; }
    public JsonRpcError error { get; set; }
}
