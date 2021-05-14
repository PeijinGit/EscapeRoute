using System;
using System.Collections.Generic;
using Models;

namespace DAL
{
    public interface IDataDAL
    {
        public int RecordToCSV(string userId,string sceneName, SendData[] userCoords);
        
        public int RecordToBlobCSV(string userId, string sceneName, SendData[] userCoords);
    }
}
