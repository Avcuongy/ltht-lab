using System;
using System.IO;
using System.IO.Pipes;

public class PipeClientIPC
{
    public static void Run()
    {
        NamedPipeClientStream client = null;
        StreamReader reader = null;
        StreamWriter writer = null;
        try
        {
            client = new NamedPipeClientStream(
                ".",
                "DemoPipe",
                PipeDirection.InOut
            );

            client.Connect();

            reader = new StreamReader(client);
            writer = new StreamWriter(client) { AutoFlush = true };

            writer.WriteLine("Hello from Client !");
            Console.WriteLine("Sent message.");

            string response = reader.ReadLine();
            Console.WriteLine($"Response: {response}");
        }
        finally
        {
            if (writer != null)
                writer.Dispose();
            if (reader != null)
                reader.Dispose();
            if (client != null)
                client.Dispose();
        }
    }
}
