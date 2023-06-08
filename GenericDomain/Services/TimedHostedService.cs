using System.Diagnostics;
using System.Text;
using log4net;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericDomain.Services;

public class TimedHostedService : IHostedService, IDisposable
{
    private int executionCount = 0;
    private readonly ILogger<TimedHostedService> _logger;
    public Timer? _timer = null;

    // private StringBuilder _temps = new();
    static ProcessStartInfo startInfo = new()
    {
        FileName = "/bin/bash", 
        Arguments = "sensors -h",
        UseShellExecute = false,
        RedirectStandardOutput = true
    };
    private Process _tempsProcess = new() { StartInfo = startInfo, };

    private static readonly ILog log = LogManager.GetLogger(typeof(TimedHostedService));
    Process proc = Process.GetCurrentProcess();
    
    public TimedHostedService(ILogger<TimedHostedService> logger)
    {
        _logger = logger;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Hosted Service Running.");
        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));
        
        _tempsProcess.Start();
        
        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref executionCount);
        _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);
        
        log.Info(Environment.MachineName + " is using " + (proc.PrivateMemorySize64 / 1024 / 1024) + "Mb of memory.");
        log.Info(_tempsProcess.StandardOutput.ReadToEnd());
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}