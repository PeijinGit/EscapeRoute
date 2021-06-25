using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Surveys
{
    public class PostSurvey
    {
        public List<string> survey;

        private string q1 = "For the 1st case, why have you chosen this exit ?";
        private string q2 = "For the 2nd case, why have you chosen this exit ?";
        private string q3 = "For the 3rd case, why have you chosen this exit ?";
        private string q4 = "For the 4th case, why have you chosen this exit ?";
        private string que1 = "I believed I really was the player in the VR scenario";
        private string que2 = "After finishing the game, it takes a long time for me to return to the real word psychologically and emotionally.";
        private string que3 = "My emotion often varies with the VR story’s progress";
        private string que4 = "This experience makes me feel scared or fearful";
        private string que5 = "Overall, this experience makes me feel tense or nervous";
        private string que6 = "Overall, this experience makes me feel anxious";
        private string que7 = "The VR scenario was engaging";
        private string que8 = "I found running this VR scenario easy";
        private string que9 = "The virtual world was adequate or realistic";
        private string que10 = "The virtual fire scenario was adequate or realistic";
        private string que11 = "The interaction with other virtual people was adequate or realistic";
        private string que12 = "I would act the same way in real life during the fire emergency";
        private string que17 = "I felt part of a group during the simulation";
        private string que13 = "I felt it was important to get out as quickly as possible regardless of other people";
        private string que18 = "I felt the urgency to act/do something during the fire emergency";
        private string que14 = "I felt to be unsafe while I was in the virtual building";
        private string que15 = "I believed that the fire emergency was severe";
        private string que16 = "I believed that the fire was harmful";

        public PostSurvey()
        {
            survey = new List<string>() {
            q1,q2,q3,q4,que1,que2,que3,que4,que5,que6,que7,que8,que9,que10,que11,que12,que17,que13,que18,que14,que15,que16
            };
        }

        public override string ToString()
        {
            string surveyHead = "";
            survey.ForEach((head) => {
                surveyHead += head + ',';
            });
            surveyHead = surveyHead.TrimEnd(',').Replace(" ", "_");
            return surveyHead;
        }
    }
}
