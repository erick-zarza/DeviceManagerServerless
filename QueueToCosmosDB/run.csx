using System;


public static void Run(string myQueueItem, out object outputDocument, ILogger log)
{
    log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

    //Get a number from 1 to 10 to simulate the 10 seeded Device Ids.
    Random rnd = new Random();
    int id = rnd.Next(1, 11);

    //Get a number from 1 to 100 for degrees
    int temperature = rnd.Next(1, 101);

    //Get air humidity 
    int airHumidity = rnd.Next(1, 11) * rnd.Next(7, 22);

    //Get carbon monoxide
    int carbonMonoxide = rnd.Next(1, 21);

    //Get health status
    string healthStatus = "";
    int caseSwitch = rnd.Next(1,5);
      
    switch (caseSwitch)
    {
        case 1:
            healthStatus = "health_good_mucho_calor";
            break;
        case 2:
            healthStatus = "needs_service";
            break;
        case 3:
            healthStatus = "needs_new_filter";
            break;
        case 4:
            healthStatus = "gas_leak";
            break;
        default:
            healthStatus = "health_good_mucho_calor";
            break;
    }

    //Get status
    
    //Get hook_id to simulate the DeviceStatusInstance, function is barfing because it doesn't fing newton.json
    //dynamic data = JsonConvert.DeserializeObject(myQueueItem);
    //string hook_id = data.hook_id ? data.hook_id : null;

    outputDocument = new {
        deviceId = id.ToString(),
        temperaturC = temperature.ToString(),
        airHumidity = airHumidity.ToString(),
        carbonMonoxide = carbonMonoxide.ToString(),
        healthStatus = healthStatus,
        queueItem = $"{myQueueItem}",
        isProcessed = false
    };
}