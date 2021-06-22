using Models;
using Models.Surveys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface ISurveyBLL
    {
        public int RecordToPreCSV(ReceivedSurveyInfo receivedSurveyInfo);
        public int RecordToPostCSV(ReceivedSurveyInfo receivedSurveyInfo);
    }
}
