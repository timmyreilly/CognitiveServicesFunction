# CognitiveServicesFunction

Sample Azure Function Project using the Face API. 

Sample appsettings.json which configures environment settings for the function: 

Now that we have Cosmos DB we need to update our appsettings.json

```json
{
  "IsEncrypted": false,
  "Values": {
    "FaceKey": "46b90asdfaa383416b40eb545d21",
    "AzureWebJobsDashboard": "",
    "AzureWebJobsStorage": "DefaultEndpointsProtocol=https;AccountName=incomingimages;AccountKey=asdfasdfdfH/Iv7/Y9Sl4/P4hu+cDwSQn4AXbybwzxuc/LzbdxS4UFmlaQyAJ6xVKR6d4w==;EndpointSuffix=core.windows.net",        
    "DocDBEndpoint": "https://cosmosdb.documents.azure.com:443/",
    "DocDBKey": "supersecretdVqNa2VJAJL9qrd9GpP6yWunaSbT28uGrJIxmeJZOvPknYv2u2BebJEQsxzwCcu0AWDIyKQ==",
    "CollectionName": "image-metadata",
    "DatabaseName": "imagedata"
  }
}
```

This file should be placed adjacent to the BlobTriggerCSharp directory