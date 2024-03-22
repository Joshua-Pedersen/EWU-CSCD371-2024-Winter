using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput, string? StdError);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        string pingArg = Environment.OSVersion.Platform is PlatformID.Unix ? "-c" : "-n";
        StartInfo.Arguments = $"{pingArg} 4 {hostNameOrAddress}";
        StringBuilder? stdOutput = null;
        StringBuilder? stdErr = null;

        void updateStdOutput(string? line) =>
            (stdOutput??=new StringBuilder()).AppendLine(line);
        void updateError(string? line) =>
            (stdErr ??=new StringBuilder()).AppendLine(line);

        Process process = RunProcessInternal(StartInfo, updateStdOutput, updateError, default);
        return new PingResult( process.ExitCode, stdOutput?.ToString(), stdErr?.ToString());
    }

    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() => Run(hostNameOrAddress));
    }

    async public Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        try
        {
            PingResult result = await Task.Run(() => Run(hostNameOrAddress));
            return result;
        } catch (OperationCanceledException e) { throw new TaskCanceledException("cancel", e); }
        catch (AggregateException) { throw; } 
    }

    async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        StringBuilder? stringBuilder = new(); ;
        int exitcodes = 0;
        ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {
            Task<PingResult> task = RunAsync(item);
            
            lock (stringBuilder)
            {
                stringBuilder.AppendLine(task.Result.StdOutput?.Trim());
                exitcodes += task.Result.ExitCode;
            }

            await task.WaitAsync(cancellationToken);

            return task.Result.ExitCode;
        });

        await Task.WhenAll(all);
        
        return new PingResult(exitcodes, stringBuilder?.ToString().Trim(), default);
    }

    
    async public Task<PingResult> RunLongRunningAsync(
        ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken cancellationToken = default)
    {
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);

        int task = await Task.Factory.StartNew(() =>
        {
            return RunProcessInternal(startInfo, updateStdOutput, default, cancellationToken).ExitCode;
        }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Current);
        
        return new PingResult(task, stringBuilder?.ToString().Trim(), default);
    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}