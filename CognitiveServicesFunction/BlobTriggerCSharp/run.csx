#r "..\bin\Function.Library.dll"

using System;
using System.Diagnostics;
using Function.Library;

public static void Run(Stream myBlob, string name, TraceWriter log)
{
    var faceKey = System.Environment.GetEnvironmentVariable("FaceKey", EnvironmentVariableTarget.Process);

    var docDBEndpoint = System.Environment.GetEnvironmentVariable("DocDBEndpoint", EnvironmentVariableTarget.Process);
    var docDBKey = System.Environment.GetEnvironmentVariable("DocDBKey", EnvironmentVariableTarget.Process);
    var collectionName = System.Environment.GetEnvironmentVariable("CollectionName", EnvironmentVariableTarget.Process);
    var databaseName = System.Environment.GetEnvironmentVariable("DatabaseName", EnvironmentVariableTarget.Process);


    var analyzer = new PhotoAnalyzer(faceKey, docDBEndpoint, docDBKey, databaseName, collectionName);

    log.Info($"C# Timer trigger function starting: {DateTime.Now}");
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    analyzer.ProcessImage(myBlob, name).Wait();

    stopWatch.Stop();

    log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
}
