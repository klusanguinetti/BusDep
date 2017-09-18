using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace BusDep.Web.BackOffice.Class
{
    public class BlobUtility
    {
        public CloudStorageAccount storageAccount;

        public BlobUtility()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        }

        public CloudBlockBlob UploadBlob(string BlobName, string ContainerName, Stream stream)
        {

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName.ToLower());

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(BlobName);

            blockBlob.Properties.ContentType = "image/jpg";

            try
            {
                blockBlob.UploadFromStream(stream);
                return blockBlob;
            }
            catch (Exception e)
            {
                var r = e.Message;
                return null;
            }

        }

        public void DeleteBlob(string BlobName, string ContainerName)
        {

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(BlobName);

            try
            {
                blockBlob.Delete();
            }
            catch (Exception)
            {

            }

        }

        public CloudBlockBlob DownloadBlob(string BlobName, string ContainerName)
        {
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(BlobName);
            // blockBlob.DownloadToStream(Response.OutputStream);
            return blockBlob;
        }
    }
}