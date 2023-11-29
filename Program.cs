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

// Create a BlobClient
var blobClient = containerClient.GetBlobClient("blob.txt");

// Upload the blob
await blobClient.UploadAsync("blob.txt");

Console.WriteLine("File uploaded to Blob conatiner successfully!");
