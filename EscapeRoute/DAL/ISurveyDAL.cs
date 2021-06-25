using Models;
using Models.Surveys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ISurveyDAL
    {
        public int RecordToPreCSV(string userID,ReceivedPreSurvey receivedPreSurvey);
        public int RecordToPostCSV(string userID, ReceivedPostSurvey receivedPreSurvey);
        public int PlayerSurveyCheck(string playerUuid);
    }
}
