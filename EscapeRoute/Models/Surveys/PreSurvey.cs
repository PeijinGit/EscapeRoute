using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

    public class PreSurvey
    {
        public List<string> survey;

        private string ethnicgroup = "Ethnic Group";
        private string q1= "How frequently have you practiced in a fire drill?";
        private string q2= "How would you rate your preparedness or awareness of the correct actions required in a fire?";
        private string q3 = "How often do you play video games?";
        private string q4 = "Have you ever used Virtual Reality?";
        private string age ="Age";
        private string gender= "Gender";
        private string weight = "Weight";
        private string height ="Height" ;
        private string que1 = "I am confident that I am able to effectively deal with a fire emergency";
        private string que2 = "Thanks to my resources, I know how to manage in a fire emergency";
        private string que3 = "I would be able to deal with a fire emergency even if I find flame and smoke along the way";
        private string que4 = "I would be able to deal with a fire emergency even if I find objects that may harm me along the way";
        private string que5 = "The consequences of a fire emergency on my safety would be severe";
        private string que6 = "The consequences of a fire emergency would be harmful";
        private string que7 = "I would be vulnerable during a fire emergency";

        public PreSurvey() 
        {
            survey = new List<string>() {
            gender,age,ethnicgroup,height,weight,q1,q2,q3,q4,que1,que2,que3,que4,que5,que6,que7
            };
        }

        public override string ToString()
        {
            string surveyHead = "";
            survey.ForEach((head)=> {
                surveyHead += head + ',';
            });
            surveyHead = surveyHead.TrimEnd(',').Replace(" ","_");
            return surveyHead;
        }
    }
}
