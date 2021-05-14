using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBlobBLL
    {
        public Task<BlobInfo> GetBlobAsync(string name);
        public Task<BlobDownloadInfo> GetBlobAsync2(string name);
    }
}
