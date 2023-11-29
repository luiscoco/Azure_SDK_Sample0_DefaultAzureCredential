# Azure SDK Sample0 DefaultAzureCredential

## 0. Prerequisites

Login in Azure Portal and create a new Azure Storage account and inside create a new Blob container.

## 1. Create a new console C# application in VSCode

Open VSCode and run this command to create a new C# console application with .NET 8:

```
dotnet new console --framework net8.0
```

## 2. Load the libraries

Run these commands to load the "Azure.Identity" and the "Azure.Storage.Blobs" libraries:



## 3. Input the application source code

```csharp
using System;
using System.Threading.Tasks;

using Azure.Identity;
using Azure.Storage.Blobs;

//Prerequisite: create an Azure Storage Account and inside create a new Azure Blob container
string storageAccountName = "mynewstorageaccount1999";
string blobContainerName = "newblob";

var uri = new Uri("https://"+ storageAccountName + ".blob.core.windows.net/" + blobContainerName);
var cred = new DefaultAzureCredential();

// Create a BlobContainerClient
var containerClient = new BlobContainerClient(uri, cred);

// (OPTIONAL) Create the blob container if it doesn't exist
await containerClient.CreateIfNotExistsAsync();

// Create a BlobClient and set the blob name
var blobClient = containerClient.GetBlobClient("blob.txt");

// Upload the file into the blob
await blobClient.UploadAsync("blob.txt");

Console.WriteLine("File uploaded to Blob conatiner successfully!");
```

## 4. Build and run the application

In the Terminal Window in VSCode type the command:

```
dotnet run
```


