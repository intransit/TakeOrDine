namespace TakeOrDine.AzureStorageHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage;

    public enum PictureType
    {
        Host,
        Event
    }

    public class ImageStorageHelpers
    {
        public CloudStorageAccount StorageAccount;
        public CloudBlobClient BlobClient;
        public CloudBlobContainer EventsContainer;
        public CloudBlobContainer HostsContainer;

        public ImageStorageHelpers()
        {
            var connStr = ConfigurationManager.ConnectionStrings["AzureStorageAccount"].ConnectionString;
            StorageAccount = CloudStorageAccount.Parse(connStr);
            BlobClient = StorageAccount.CreateCloudBlobClient();
            
            EventsContainer = BlobClient.GetContainerReference("events");
            EventsContainer.CreateIfNotExists();

            HostsContainer = BlobClient.GetContainerReference("hosts");
            HostsContainer.CreateIfNotExists();
        }

        public bool UploadPicture(PictureType type, int id, string fileToUpload)
        {
            var containerRef = type == PictureType.Host ? HostsContainer : EventsContainer;
            if (!File.Exists(fileToUpload))
            {
                throw new ArgumentException("Incorrect file");
            }

            try
            {
                var blobPath = Path.Combine(id.ToString(), Path.GetFileName(fileToUpload));
                var blob = containerRef.GetBlockBlobReference(blobPath);
                using (var fileStream = File.OpenRead(fileToUpload))
                {
                    blob.UploadFromStream(fileStream);
                }

                return true;
            }
            catch (Exception ex)
            {
                // TODO: Add logging.
            }

            return false;
        }

        public List<Byte[]> DownloadPicture(PictureType type, int id)
        {
            var pics = new List<Byte[]>();
            var containerRef = type == PictureType.Host ? HostsContainer : EventsContainer;
            try
            {
                var blobRef = containerRef.GetDirectoryReference(id.ToString());
                var blobItems = blobRef.ListBlobs();
                foreach (var blobItem in blobItems)
                {
                    using (var stream = new MemoryStream())
                    {
                        ((CloudBlockBlob)blobItem).DownloadToStream(stream);
                        
                        pics.Add(stream.ToArray());
                        stream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Add logging.
            }

            return pics;
        }

        public void DeletePicture(PictureType type, int id)
        {
            var containerRef = type == PictureType.Host ? HostsContainer : EventsContainer;
            try
            {
                var blobDirectory = containerRef.GetDirectoryReference(id.ToString());
                foreach (var blobItem in blobDirectory.ListBlobs())
                {
                    ((CloudBlockBlob) blobItem).DeleteIfExists();
                }

                // TODO: Finally delete the directory for the Id.
            }
            catch (Exception ex)
            {
                // TODO: Add logging.
            }
        }
    }
     
}