# How to use DefaultAzureCredential() for uploading a file to an Azure Blob container

## 0. Prerequisites

Login in Azure Portal and create a new Azure Storage account and inside create a new Blob container.

First we create the Azure Storage account

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/aecfadad-ed4e-488c-acd5-6b2f3e73c067)

We input the new Storage account data

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/fb0c169f-cc4b-4036-a404-31d35e4c0aad)

We press the "Review" button and then the "Create" button

Go to the new Storage account:

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/1e889101-164a-40e3-8207-b2b9f8f9d15c)

Now we have to grant permission to the storage account as "**Storage Blob Data Contributor**"

In the Storage account left menu we select "**Access Control (IAM)**" and then we press the button "**Add role assignment**"

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/9a6c0bba-961c-4f1b-bd61-f47ac0a888e7)

We select the "**Storage Blob Data Contributor**" role

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/f9fd6c51-8f4f-4d9d-94b2-ac12ceceabd2)

Then we select **user**

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/63698c3c-e761-4489-8b84-b7fb204bbbf2)

Finally, we press the button "**Review + assign**"

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/3076e9e3-eb19-4076-89e4-ef09eaf9f721)

Now we have to create the Blob container:

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/fda24b86-991d-4306-8fb0-21798df748e3)

Then we set the Blob container name:

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/3478ff54-0d74-4998-bd93-ff5eed56f0ef)

See the new Blob container:

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/fbe1d46a-d624-45b6-94b9-76b165980314)

We also have to place the "blob.txt" file in the application folder to upload it:

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/a65becfa-7d7d-4ff6-9c26-5e5a08a9d381)

## 1. Create a new console C# application in VSCode

Open VSCode and run this command to create a new C# console application with .NET 8:

```
dotnet new console --framework net8.0
```

## 2. Login in Azure with VSCode Terminal window

In the VSCode Terminal window run the command

```
az login
```

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/051cddda-793f-45e2-a3f0-8f00aba4c7fd)

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/c40b9788-35f4-4477-86d5-7f237f264d45)

## 3. Load the libraries

In your internet browser navigate to the Nuget package web page: https://www.nuget.org/packages, and look for the libraries.

Run these commands to load the "Azure.Identity" and the "Azure.Storage.Blobs" libraries:

```
dotnet add package Azure.Identity --version 1.10.4
dotnet add package Azure.Storage.Blobs --version 12.19.1
```

After then run the command:

```
dotnet restore
```

And confirm in the **csproj** file the libraries are included:

![image](https://github.com/luiscoco/Azure_SDK_Sample0_DefaultAzureCredential/assets/32194879/39b2da74-4d7d-416d-9c30-7adcccf44808)

## 4. Input the application source code

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

## 5. Build and run the application

In the Terminal Window in VSCode type the command:

```
dotnet run
```

## 6. Another source code sample

```csharp
using System;
using System.Threading.Tasks;

using Azure.Identity;
using Azure.Storage.Blobs;

//Prerequisite: create an Azure Storage Account and inside create a new Azure Blob container
string storageAccountName = "mynewstorageaccount1974";
string blobContainerName = "newblob";

var uri = new Uri("https://" + storageAccountName + ".blob.core.windows.net/" + blobContainerName).ToString();

var blobServiceClient = new BlobServiceClient(new Uri(uri), new DefaultAzureCredential());

// Replace "your_container_name" with the name of your container
var containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

// Replace "your_blob_name" with the name you want to give to the blob
var blobClient = containerClient.GetBlobClient("blob.txt");

// Replace "path_to_your_local_file" with the path to the file you want to upload
using (var fileStream = File.OpenRead("C:\\Azure SDK for .NET\\sampleDefaultAzureCredential\\blob.txt"))
{
    blobClient.Upload(fileStream, true);
}

Console.WriteLine("File uploaded successfully!");
```

