using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Business
{
    public class AcquireFile : IBlobBLL
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AcquireFile(BlobServiceClient blobServiceClient) 
        {
            this._blobServiceClient = blobServiceClient;
        }

        public Task<BlobInfo> GetBlobAsync(string name)
        {
            throw new NotImplementedException();
        }

        public  async Task<BlobDownloadInfo> GetBlobAsync2(string name)
        {
            var containerClinent = _blobServiceClient.GetBlobContainerClient("newblob");
            var blobClient = containerClinent.GetBlobClient(name);
            var blobDownloadInfo =  blobClient.DownloadAsync();

            return blobDownloadInfo.Result;
        }
    }
}
