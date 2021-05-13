using System;
using System.Collections.Generic;
using Models;

namespace DAL
{
    public interface IDataDAL
    {
        public void RecordToCSV(string userId,string sceneName, List<MyVector3> userCoord);
    }
}
