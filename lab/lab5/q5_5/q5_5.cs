using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class q5_5
{
    // Using RpcClientExtend and RpcServerExtend to implement a simple RPC system
    // Run in two console windows by using separate into two process and run one as server and another as client
    public static void Solution(string[] args)
    {
        // Run the server first, then the client in program arguments,not here
        RpcClientExtend.Run();
        RpcServerExtend.Run();
    }
}
