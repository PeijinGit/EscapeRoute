using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Surveys
{

    public class ReceivedPostSurveyInfo
    {
        public string userId { get; set; }
        public ReceivedPostSurvey ReceivedPostSurvey { get; set; }
    }

    public class ReceivedPostSurvey
    {
        public string Open1 { get; set; }
        public string Open2 { get; set; }
        public string Open3 { get; set; }
        public string Open4 { get; set; }
        public int Que1 { get; set; }
        public int Que2 { get; set; }
        public int Que3 { get; set; }
        public int Que4 { get; set; }
        public int Que5 { get; set; }
        public int Que6 { get; set; }
        public int Que7 { get; set; }
        public int Que8 { get; set; }
        public int Que9 { get; set; }
        public int Que10 { get; set; }
        public int Que11 { get; set; }
        public int Que12 { get; set; }
        public int Que13 { get; set; }
        public int Que14 { get; set; }
        public int Que15 { get; set; }
        public int Que16 { get; set; }
        public int Que17 { get; set; }
        public int Que18 { get; set; }
    }

}
