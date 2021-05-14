using Models;
using System;
using System.Collections.Generic;

namespace Business
{
    public interface IDataBLL
    {
        public int RecordToCSV(ReceiveModel receiveModel);
        public int RecordToBlobCSV(ReceiveModel receiveModel);
    }
}
