#r "..\bin\Function.Library.dll"

using System;
using System.Diagnostics;
using Function.Library;

public static void Run(Stream myBlob, string name, TraceWriter log)
{
    var faceKey = System.Environment.GetEnvironmentVariable("FaceKey", EnvironmentVariableTarget.Process);


    var analyzer = new PhotoAnalyzer(faceKey);

    log.Info($"C# Timer trigger function starting: {DateTime.Now}");
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    analyzer.ProcessImage(myBlob, name).Wait();

    stopWatch.Stop();

    log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
}
