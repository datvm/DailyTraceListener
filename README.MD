`DailyTraceListener` is a small and simple and highly customizable [`TraceListener`](https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/trace-listeners) for .NET that writes log files by day.

This package is written in .NET Standard 2.0 so it can be used by both .NET Framework 4.6.2 and .NET Core 2.0 upward.

You can check [the Demo file here](https://github.com/datvm/DailyTraceListener/blob/master/DailyTraceListener.Demo/Program.cs).

# Installation

You can get the package from [NuGet](https://www.nuget.org/packages/DailyTraceListener/):

> Install-Package DailyTraceListener

# Getting Started

You can use it as any other `TraceListener`:

```
var traceListener = new DailyTraceListener("Logs");
Trace.Listeners.Add(traceListener);
```

In the above code, `"Logs"` parameter is the path to the folder where the log files are written. If the folder does not exist, the class will create it automatically.

Now you can use `Trace`:

```
Trace.TraceInformation("Hello");
Trace.TraceWarning("Some warning");
Trace.TraceError(new Exception("A complete \"error\" message with\r\nmultiple lines.").ToString());
```

By default implementation, `DailyTraceListener` write a format similar to CSV so you can always change the extension to `.csv` and read with Excel or any program of your choice.

# Options

Currently there are two options you can use in addition. Please note both options should be set up before using for consistency:

```
var traceListener = new DailyTraceListener("Logs")
    .UseHeader()
    .UseUtc();
```

## UseHeader()

This option will write a header to the log file when it write a new file. The header is simply a string, and by default implementation, it's a CSV header. You can override this behavior by overriding the [`WriteHeader`](https://github.com/datvm/DailyTraceListener/blob/master/DailyTraceListener/DailyTraceListener.cs) method.

## UseUtc()

Use UTC time instead of local machine time.

# Customization

The following methods are `virtual` meaning you can override them if you need: `WriteHeader`, `FormatTime` (used by default `TraceEvent` implementation of `DailyTraceListener`). In addition, `TraceEvent`, `Write` and `WriteLine` are already virtual by its base class `TraceListener`.