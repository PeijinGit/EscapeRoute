using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business
{
    public interface IFileBLL
    {
        public Stream PreSurveyAcquire();
        public Stream AfterSurveyAcquire();
        public Stream CoordinateAcquire();
        public Stream AllInOneAcquire();
        public Tuple<string, string, string> AcquireFileSize();
        public int DeleteAll(); 
    }
}
