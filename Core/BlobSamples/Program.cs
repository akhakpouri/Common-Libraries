using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobSamples
{
    public class Program
    {
        public static void Main()
        {
            const string accountName = @"akhakpouristorage";
            const string accountKey = @"K4b0OABVmkzZKC3FqtcULa59Q4iz9mY93bZ99i2Bzmbts/MkwAjLn6tO+hJriLXeHaJb7FDkBLHI9qTrhjrMvA==";

            try
            {
                var creds = new StorageCredentials(accountName, accountKey);
                var account = new CloudStorageAccount(creds, true);
                var client = account.CreateCloudBlobClient();
                var container = client.GetContainerReference("images");
                container.CreateIfNotExists();
                var blob = container.GetBlockBlobReference("baltimore.jpg");
                using (var file = File.OpenRead("Baltimore.jpg"))
                {
                    blob.UploadFromStream(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Done.. Press a key to exit.");
            Console.ReadKey();
        }
    }
}
