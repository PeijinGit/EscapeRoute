using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL
{
    public class SurveyRecDAL : ISurveyDAL
    {
        public int RecordToPostCSV(string userID,ReceivedPreSurvey receivedPreSurvey)
        {
            throw new NotImplementedException();
        }

        public int RecordToPreCSV(string userID, ReceivedPreSurvey receivedPreSurvey)
        {
            int passCode = -1;
            string FileName = "Temp/" + "PreSurvey" + ".csv";

            if (!File.Exists(FileName))
            {
                using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        string dataHead = string.Empty;
                        dataHead = new PreSurvey().ToString();
                        sw.WriteLine(dataHead);
                        StringBuilder csvStr = new StringBuilder();
                        csvStr.Clear();
                        csvStr.Append(PreStringAppender(userID, receivedPreSurvey));
                        sw.WriteLine(csvStr);
                        fs.Flush();
                        passCode = 100;
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(FileName, true, Encoding.Default))
                {
                    StringBuilder csvStr = new StringBuilder();
                    csvStr.Clear();
                    csvStr.Append(PreStringAppender(userID, receivedPreSurvey)); ;
                    sw.WriteLine(csvStr);
                    passCode = 100;
                }

            }
            return passCode;
        }

        private string PreStringAppender(string userID, ReceivedPreSurvey receivedPreSurvey) 
        {
            string appended = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}",
                                    userID,
                                    receivedPreSurvey.gender,
                                    receivedPreSurvey.age,
                                    receivedPreSurvey.Ethnicgroup,
                                    receivedPreSurvey.height,
                                    receivedPreSurvey.weight,
                                    receivedPreSurvey.Q1,
                                    receivedPreSurvey.Q2,
                                    receivedPreSurvey.Q3,
                                    receivedPreSurvey.Q4,
                                    receivedPreSurvey.que1,
                                    receivedPreSurvey.que2,
                                    receivedPreSurvey.que3,
                                    receivedPreSurvey.que4,
                                    receivedPreSurvey.que5,
                                    receivedPreSurvey.que6,
                                    receivedPreSurvey.que7
                                    );

            return appended;
        }
    }
}

