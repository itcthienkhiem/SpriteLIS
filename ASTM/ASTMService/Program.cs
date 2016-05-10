using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ASTMService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
          

            #if (!DEBUG)
    System.ServiceProcess.ServiceBase[] ServicesToRun;
    ServicesToRun = new System.ServiceProcess.ServiceBase[] { new ASTMService() };
    System.ServiceProcess.ServiceBase.Run(ServicesToRun);
#else
    // Debug code: this allows the process to run as a non-service.
    // It will kick off the service start point, but never kill it.
    // Shut down the debugger to exit
    ASTMService service = new ASTMService();
    service.Start();
    // Put a breakpoint on the following line to always catch
    // your service when it has finished its work
  
#endif 
        }
    }
}
