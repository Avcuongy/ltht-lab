using System;
using System.IO;
using System.IO.Pipes;

public class q5_3
{
    // Using TCP
    // Run in two console windows by using separate into two process and run one as server and another as client
    public static void Solution(string[] args)
    {
        // Run the server first, then the client in program arguments,not here
        TcpClient.Run();
        TcpServer.Run();
    }
}
