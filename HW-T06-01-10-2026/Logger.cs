using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace HW_T06_01_10_2026;

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}

public class LoggerConfig
{
    public string LogFileName { get; set; } = "log.txt";
    public bool AppendToFile { get; set; } = true;
    public int QueueNumber { get; set; } = 3;

    public static LoggerConfig Load(string jsonPath = "appsettings.json")
    {
        if (!File.Exists(jsonPath)) return new LoggerConfig();
        string json = File.ReadAllText(jsonPath);
        return JsonSerializer.Deserialize<LoggerConfig>(json) ?? new LoggerConfig();
    }
}

// 1. Sealed
// 2. Do not allove to be created via "new" from outside.
// 3. Be 1000% sure only ONE object is created. -> static -> 1) Only one instance. 2) "Lazy" loading.
// 4. Get the single reference (via property OR method (when thread safe)).

internal sealed class Logger
{
    private readonly string logPath = string.Empty;
    private int recordsNumber = 0;
    private object lockObject = new object();

    private readonly LoggerConfig config;
    private readonly Queue<string> logQueue = new Queue<string>();

    public static Logger Instance { get; } = new();


    private Logger()
    {
        config = LoggerConfig.Load();

        logPath = Path.Combine(Directory.GetCurrentDirectory(), config.LogFileName);

        if (!config.AppendToFile && File.Exists(logPath))
        {
            File.Delete(logPath);
        }
    }

    static Logger()
    {
    }

    // Formats:
    // [DateTime] : [Thread ID] : [Process Id] : [Log levels] | [Functionality] : [Method] - "Some error"
    // 23.06.2025 19:14:53 : [UI] : [Debug]     | Music playback : StartPlayback(...) - Playback was started with no errors. 
    // 23.06.2025 19:14:58 : [UI] : [Warning]   | Music playback : GetNetxBufferPart(...) - Cannot load all the bytes data in time. Method completed with timout. 
    // 1. Playback was started with no errors. 
    // 2. Playback was started with no errors.

    public void LogData(LogLevel logLevel, string message)
    {
        string formattedTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
        string data = $"{formattedTime} [{logLevel}] : {message}";

        Debug.WriteLine(data);

        lock (lockObject)
        {
            logQueue.Enqueue(data);

            if (logQueue.Count >= config.QueueNumber)
            {
                FlushQueue();
            }
        }

        recordsNumber++;
    }

    public void Flush()
    {
        lock (lockObject)
        {
            FlushQueue();
        }
    }

    private void FlushQueue()
    {
        if (logQueue.Count == 0) return;

        List<string> linesToWrite = new List<string>();
        while (logQueue.Count > 0)
        {
            linesToWrite.Add(logQueue.Dequeue());
        }

        File.AppendAllLines(logPath, linesToWrite);
    }
}