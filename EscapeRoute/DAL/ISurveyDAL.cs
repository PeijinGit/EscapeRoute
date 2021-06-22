using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ISurveyDAL
    {
        public int RecordToPreCSV(string userID,ReceivedPreSurvey receivedPreSurvey);
        public int RecordToPostCSV(string userID,ReceivedPreSurvey receivedPreSurvey);
    }
}
