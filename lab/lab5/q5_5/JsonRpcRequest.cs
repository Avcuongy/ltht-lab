using System;

public class JsonRpcRequest
{
    public string jsonrpc { get; set; } = "2.0";
    public int id { get; set; }
    public string method { get; set; } = "";
    public object[] @params { get; set; } = Array.Empty<object>();
}
