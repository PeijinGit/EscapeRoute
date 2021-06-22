using DAL;
using Models;
using Models.Surveys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class SurveyRecBLL : ISurveyBLL
    {
        ISurveyDAL surveyDAL;

        public SurveyRecBLL(ISurveyDAL surveyDAL)
        {
            this.surveyDAL = surveyDAL;
        }

        public int RecordToPostCSV(ReceivedSurveyInfo receivedSurveyInfo)
        {
            throw new NotImplementedException();
        }

        public int RecordToPreCSV(ReceivedSurveyInfo receivedSurveyInfo)
        {
            if (receivedSurveyInfo.userId == "")
                receivedSurveyInfo.userId = Guid.NewGuid().ToString("N");
            
            int passCode = surveyDAL.RecordToPreCSV(receivedSurveyInfo.userId, receivedSurveyInfo.receivedPreSurvey);
            return passCode;
        }
    }
}
