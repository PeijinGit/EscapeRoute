using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CoordinateRecBLL : IDataBLL
    {
        IDataDAL dataDAL;

        public CoordinateRecBLL(IDataDAL dataDAL) 
        {
            this.dataDAL = dataDAL;
        }

        public int RecordToCSV(ReceiveModel receiveModel)
        {
            int returnCode = -1;
            string uuid = receiveModel.Uuid;
            string sceneName = receiveModel.Scene;
            SendData[] sendDatas = receiveModel.SendData;
            if (uuid != null && sceneName!=null && sendDatas!=null) 
            {
                returnCode = dataDAL.RecordToCSV(uuid, sceneName, sendDatas);
            }
            return returnCode;
        }

        
    }
}
