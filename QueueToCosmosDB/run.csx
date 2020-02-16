using System;

public static void Run(string myQueueItem, out object outputDocument, ILogger log)
{
    log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

    outputDocument = new {
        queueItem = $"{myQueueItem}",
        isStored = false
    };
}