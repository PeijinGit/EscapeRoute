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

        public int PlayerSurveyCheck(string playerUuid)
        {
            int passCode = surveyDAL.PlayerSurveyCheck(playerUuid);

            return passCode;
        }

        public int RecordToPostCSV(ReceivedPostSurveyInfo receivedSurveyInfo)
        {
            int passCode = -100;
            if (receivedSurveyInfo.userId != "" || receivedSurveyInfo.userId != null)
                passCode = surveyDAL.RecordToPostCSV(receivedSurveyInfo.userId, receivedSurveyInfo.ReceivedPostSurvey);

            return passCode;
        }

        public int RecordToPreCSV(ReceivedSurveyInfo receivedSurveyInfo)
        {
            int passCode = -100;
            if (receivedSurveyInfo.userId != "" || receivedSurveyInfo.userId != null)
                //receivedSurveyInfo.userId = Guid.NewGuid().ToString("N");
                 passCode = surveyDAL.RecordToPreCSV(receivedSurveyInfo.userId, receivedSurveyInfo.receivedPreSurvey);

            return passCode;
        }
    }
}
