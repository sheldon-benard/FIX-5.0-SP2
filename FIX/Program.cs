using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIX
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "Acceptor")
                (new FIXAcceptor()).start();
            else if (args[0] == "Initiator")
                (new FIXInitiator()).start();
            else
                throw new Exception("Provide FIX Type in command-line args. Type=Acceptor/Initiator");
              
        }
    }
}
