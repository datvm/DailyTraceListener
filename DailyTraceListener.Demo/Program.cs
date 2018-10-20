using System;
using System.Diagnostics;

namespace DailyTraceListener.Demo
{
    class Program
    {

        static void Main(string[] args)
        {
            var traceListener = new DailyTraceListener("Logs")
                .UseHeader()
                .UseUtc();
            Trace.Listeners.Add(traceListener);

            Trace.TraceInformation("Hello");
            Trace.TraceWarning("Some warning");
            Trace.TraceError(new Exception("A complete \"error\" message with\r\nmultiple lines.").ToString());

            Trace.WriteLine("Something...");
        }

    }
}
