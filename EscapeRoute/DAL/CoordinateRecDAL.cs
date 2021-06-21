using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL
{
    public class CoordinateRecDAL : IDataDAL
    {

        private readonly BlobServiceClient _blobServiceClient;

        public CoordinateRecDAL(BlobServiceClient blobServiceClient)
        {
            this._blobServiceClient = blobServiceClient;
        }

        public int RecordToCSV(string userId, string sceneName, SendData[] userCoords)
        {
            int passCode = -1;
            string FileName = "Temp/" + "Recording" + ".csv";

            if (!File.Exists(FileName))
            {
                using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        string dataHead = string.Empty;
                        dataHead = "UserID,Scene,X,Y,Z,Time";
                        sw.WriteLine(dataHead);
                        StringBuilder csvStr = new StringBuilder();
                        for (int i = 0; i < userCoords.Length; i++)
                        {
                            csvStr.Clear();
                            csvStr.Append(string.Format("{0},{1},{2},{3},{4},{5}", userId, sceneName, userCoords[i].x, userCoords[i].y, userCoords[i].z, userCoords[i].seq));
                            sw.WriteLine(csvStr);
                        }
                        fs.Flush();
                        passCode = 100;
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(FileName, true, Encoding.Default))
                {
                    StringBuilder csvStr = new StringBuilder();
                    for (int i = 0; i < userCoords.Length; i++)
                    {
                        csvStr.Clear();
                        csvStr.Append(string.Format("{0},{1},{2},{3},{4},{5}", userId, sceneName, userCoords[i].x, userCoords[i].y, userCoords[i].z, userCoords[i].seq));
                        sw.WriteLine(csvStr);
                    }
                    passCode = 100;
                }

            }
            return passCode;
        }

    }
}
