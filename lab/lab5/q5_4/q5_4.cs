using System;

public class q5_4
{
    // Using RPC over TCP to implement a simple money exchange service
    // Run in two console windows by using separate into two process and run one as server and another as client
    public static void Solution(string[] args)
    {
        // Run the server first, then the client in program arguments,not here
        RpcClient.Run();
        RpcServer.Run();
    }
}