# CognitiveServicesFunction

Sample Azure Function Project using the Face API. 

Sample appsettings.json which configures environment settings for the function: 

```json
{
  "IsEncrypted": false,
  "Values": {
    "FaceKey": "46b90asdfaa383416b40eb545d21",
    "AzureWebJobsDashboard": "",
    "AzureWebJobsStorage": "DefaultEndpointsProtocol=https;AccountName=incomingimages;AccountKey=asdfasdfdfH/Iv7/Y9Sl4/P4hu+cDwSQn4AXbybwzxuc/LzbdxS4UFmlaQyAJ6xVKR6d4w==;EndpointSuffix=core.windows.net"
  }
}
```

This file should be placed adjacent to BlobTriggerCSharp