using Models;
using System;
using System.Collections.Generic;

namespace Business
{
    public interface IDataBLL
    {
        public void RecordToCSV(ReceiveModel receiveModel);
    }
}
