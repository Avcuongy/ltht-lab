using System;
using System.IO;
using System.IO.Pipes;

public class q5_2
{
    // Using Named Pipe for IPC
    // Run in two console windows by using separate into two process and run one as server and another as client
    public static void Solution(string[] args)
    {
        // Run the server first, then the client in program arguments,not here
        PipeServerIPC.Run();
        PipeClientIPC.Run();
    }
}
