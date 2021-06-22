using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Surveys
{
    public class ReceivedSurveyInfo
    {
        public string userId { get; set; }
        public ReceivedPreSurvey receivedPreSurvey { get; set; }
    }
}
