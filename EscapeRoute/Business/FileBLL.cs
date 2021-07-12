using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business
{
    public class FileBLL : IFileBLL
    {
        private const string filePath = "Temp/";

        public Stream AllInOneAcquire()
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            System.Diagnostics.Debug.WriteLine("System.Diagnostics.Debug.WriteLine System.Diagnostics.Debug.WriteLine");
            return -100;
        }
        public Tuple<string, string, string> AcquireFileSize()
        {
            return new Tuple<string, string, string>(
                GetFileSize("PreSurvey.csv"),
                GetFileSize("AfterSurvey.csv"),
                GetFileSize("Recording.csv")
                );
        }
        public Stream PreSurveyAcquire()
        {
            string path = "PreSurvey.csv";
            return AcquireFile(path);
        }

        public Stream AfterSurveyAcquire()
        {
            string path = "PostSurvey.csv";
            return AcquireFile(path);
        }

        public Stream CoordinateAcquire()
        {
            string path = "Recording.csv";
            return AcquireFile(path);
        }

        private Stream AcquireFile(string fileName)
        {
            string path = filePath + fileName;
            var fileExist = File.Exists(path);
            if (fileExist)
                return new FileStream(path, FileMode.Open);
            else
                return null;
        }

        private string GetFileSize(string fileName)
        {
            string path = filePath + fileName;
            var fileExist = File.Exists(path);
            if (fileExist)
            {
                var fileInfo = new FileInfo(path);
                var fileSizeNum = Math.Ceiling(fileInfo.Length / 1024.0);
                var fileSize = fileSizeNum > 1024 ? fileSizeNum / 1024.0 + "mb" : fileSizeNum + "kb";

                return fileSize;
            }
            else
                return 0 + "kb";
        }
    }
}
