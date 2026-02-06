using System;
using System.IO;
using System.IO.Pipes;

public class PipeServerIPC
{
    public static void Run()
    {
        NamedPipeServerStream server = null;
        StreamReader reader = null;
        StreamWriter writer = null;
        try
        {
            server = new NamedPipeServerStream(
                "DemoPipe",
                PipeDirection.InOut
            );

            Console.WriteLine("Server waiting for client...");
            server.WaitForConnection();

            reader = new StreamReader(server);
            writer = new StreamWriter(server) { AutoFlush = true };

            string message = reader.ReadLine();
            Console.WriteLine($"Received: {message}");

            writer.WriteLine("Hello from Server!");
        }
        finally
        {
            if (writer != null)
                writer.Dispose();
            if (reader != null)
                reader.Dispose();
            if (server != null)
                server.Dispose();
        }
    }
}

