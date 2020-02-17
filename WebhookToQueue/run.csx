#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ICollector<string> outputQueueItem, ILogger log)
{
    try {
        
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        outputQueueItem.Add(requestBody);

        return (ActionResult)new OkObjectResult("Sent to Queue");
    }
    catch
    {
        return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
    }
}
