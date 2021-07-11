using Microsoft.Extensions.Options;
using Models;
using Models.Surveys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DAL
{
    public class SurveyRecDAL : BaseDAL, ISurveyDAL
    {
        public SurveyRecDAL(IOptions<AppSettingModels> appSettings) : base(appSettings)
        {
        }

        public int RecordToPostCSV(string userID, ReceivedPostSurvey receivedPostSurvey)
        {
            int passCode = -1;
            string FileName = "Temp/" + "PostSurvey" + ".csv";

            if (!File.Exists(FileName))
            {
                using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        string dataHead = string.Empty;
                        string surverHead = new PostSurvey().ToString();
                        dataHead = "PlayerID,"+ surverHead;
                        sw.WriteLine(dataHead);
                        StringBuilder csvStr = new StringBuilder();
                        csvStr.Clear();
                        csvStr.Append(PostStringAppender(userID, receivedPostSurvey));
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
                    csvStr.Append(PostStringAppender(userID, receivedPostSurvey)); ;
                    sw.WriteLine(csvStr);
                    passCode = 100;
                }
            }
            return passCode;
        }

        public int RecordToPreCSV(string playerID, ReceivedPreSurvey receivedPreSurvey)
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
                        string surverHead = new PreSurvey().ToString();
                        dataHead = "PlayerID," + surverHead;
                        sw.WriteLine(dataHead);
                        StringBuilder csvStr = new StringBuilder();
                        csvStr.Clear();
                        csvStr.Append(PreStringAppender(playerID, receivedPreSurvey));
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
                    csvStr.Append(PreStringAppender(playerID, receivedPreSurvey)); ;
                    sw.WriteLine(csvStr);
                    passCode = 100;
                }

            }
            int effectRow = -1;
            if (passCode == 100)
            {
                effectRow = StorePlayerId(playerID);
            }
            passCode = effectRow != -1 ? 100 : -1;
            return passCode;
        }

        public int PlayerSurveyCheck(string playerUuid)
        {
            int effectRow = -1;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("playerChecked", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@PlayerUUID", playerUuid));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader == null)
                        {
                            return -1;
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                effectRow = (int)reader["NUM"];
                            }
                            return effectRow;
                        }
                    }
                }
            }
            return effectRow;
        }

        private int StorePlayerId(string playerUuid)
        {
            int effectRow = -1;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("playerInsert", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@PlayerUUID", playerUuid));
                    effectRow = command.ExecuteNonQuery();
                }
            }
            return effectRow;
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
                                    receivedPreSurvey.Q2 - 4,
                                    receivedPreSurvey.Q3,
                                    receivedPreSurvey.Q4,
                                    receivedPreSurvey.que1 - 4,
                                    receivedPreSurvey.que2 - 4,
                                    receivedPreSurvey.que3 - 4,
                                    receivedPreSurvey.que4 - 4,
                                    receivedPreSurvey.que5 - 4,
                                    receivedPreSurvey.que6 - 4,
                                    receivedPreSurvey.que7 - 4
                                    );

            return appended;
        }

        private string PostStringAppender(string userID, ReceivedPostSurvey receivedPostSurvey)
        {
            string appended = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}",
                                    userID,
                                    receivedPostSurvey.Open1,
                                    receivedPostSurvey.Open2,
                                    receivedPostSurvey.Open3,
                                    receivedPostSurvey.Open4,
                                    receivedPostSurvey.Que1 - 4,
                                    receivedPostSurvey.Que2 - 4,
                                    receivedPostSurvey.Que3 - 4,
                                    receivedPostSurvey.Que4 - 4,
                                    receivedPostSurvey.Que5 - 4,
                                    receivedPostSurvey.Que6 - 4,
                                    receivedPostSurvey.Que7 - 4,
                                    receivedPostSurvey.Que8 - 4,
                                    receivedPostSurvey.Que9 - 4,
                                    receivedPostSurvey.Que10 - 4,
                                    receivedPostSurvey.Que11 - 4,
                                    receivedPostSurvey.Que12 - 4,
                                    receivedPostSurvey.Que13 - 4,
                                    receivedPostSurvey.Que14 - 4,
                                    receivedPostSurvey.Que15 - 4,
                                    receivedPostSurvey.Que16 - 4,
                                    receivedPostSurvey.Que17 - 4,
                                    receivedPostSurvey.Que18 - 4
                                    );
            return appended;
        }
    }
}

