using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WindowsFormsApplication1.Entity;

namespace WindowsFormsApplication1.Util
{
    class DBEngine
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        

        //Constructor       
        public DBEngine()
        {
            // TODO: Complete member initialization
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "audio_fingerprint";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }        

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        public List<string>[] Select()
        {
            return null;
        }

        //Count statement
        public int Count()
        {
            return 0;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Close();                
                connection.Open();
                Console.WriteLine("Connection Opened");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.                
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Connection Closed");
                return true;
            }
            catch (MySqlException ex)
            {               
                return false;
            }
        }

        public List<AudioType> getAllAudioType()
        {
            string query = "SELECT * FROM audio_type";

            //Create a list to store the result
            List<AudioType> Audios = new List<AudioType>();

            
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    AudioType audioType = new AudioType();
                    audioType.Type_id = dataReader["type_id"] + "";
                    audioType.Type_name = dataReader["type_name"] + "";
                    Audios.Add(audioType);           
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return Audios;
            }
            else
            {
                return null;
            }
        }



        public List<LogAudioDetection> getAllLogAudioDetectionShortByDateForDataGrid()
        {
            string query = "SELECT log_audio_detected.log_id, audio_type.type_name,log_audio_detected.log_detected_time,log_audio_detected.log_message,log_audio_detected.log_seen_status from log_audio_detected,audio_type,fingerprint where log_audio_detected.fingerprint_id = fingerprint.fingerprint_id AND fingerprint.type_id = audio_type.type_id ORDER BY log_audio_detected.log_detected_time DESC ";
            List<LogAudioDetection> LogAudios = new List<LogAudioDetection>();

            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    LogAudioDetection logAudioDetection = new LogAudioDetection();
                    FingerPrint fingerPrint = new FingerPrint();
                    AudioType audioType = new AudioType();

                    //audioType.Type_ = dataReader["type_id"] + "";
                    //audioType.Type_name = dataReader["type_name"] + "";
                    logAudioDetection.LogId = dataReader["log_id"] + "";
                    audioType.Type_name = dataReader["type_name"] + "";
                    fingerPrint.AudioType = audioType;
                    logAudioDetection.FingerprintId = fingerPrint;
                    logAudioDetection.LogDetectionTime = dataReader["log_detected_time"] + "";
                    logAudioDetection.LogSeenStatus = dataReader["log_seen_status"] + "";
                    logAudioDetection.LogMessage = dataReader["log_message"] + "";

                    LogAudios.Add(logAudioDetection);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return LogAudios;
            }
            else
            {
                return null;
            }
        }

        public void insertLogSoundDetected(List<LogAudioDetection> insertValue)
        {
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText = "INSERT INTO log_audio_detected " +
                "values (@logId,@fingerprintId,@logDetectedTime,@logSeenStatus,@logMessage)";

            MySqlParameter logIdParam = new MySqlParameter("@logId", MySqlDbType.String);
            MySqlParameter fingerprintIdParam = new MySqlParameter("@fingerprintId", MySqlDbType.Int32);
            MySqlParameter logDetectedTimeParam = new MySqlParameter("@logDetectedTime", MySqlDbType.String);
            MySqlParameter logSeenStatusParam = new MySqlParameter("@logSeenStatus", MySqlDbType.String);
            MySqlParameter logMessageParam = new MySqlParameter("@logMessage", MySqlDbType.String);

            command.Parameters.Add(logIdParam);
            command.Parameters.Add(fingerprintIdParam);
            command.Parameters.Add(logDetectedTimeParam);
            command.Parameters.Add(logSeenStatusParam);
            command.Parameters.Add(logMessageParam);

            foreach (LogAudioDetection log in insertValue)
            {
                command.Parameters[0].Value = log.LogId;
                command.Parameters[1].Value = log.FingerprintId.FingerPrintData;
                command.Parameters[2].Value = log.LogDetectionTime;
                command.Parameters[3].Value = log.LogSeenStatus;
                command.Parameters[4].Value = log.LogMessage;

                command.Prepare();
                command.ExecuteNonQuery();

            }
        }


        public List<LogAudioDetection> getAllLogAudioDetectionShortByDate()
        {
            string query = "SELECT * FROM log_audio_detected ORDER BY log_audio_detected.LOG_DETECTED_TIME DESC ";

            //Create a list to store the result
            List<LogAudioDetection> LogAudios = new List<LogAudioDetection>();


            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    LogAudioDetection logAudioDetection = new LogAudioDetection();
                    //audioType.Type_ = dataReader["type_id"] + "";
                    //audioType.Type_name = dataReader["type_name"] + "";
                    //logAudioDetection.LogId = 
                        Console.WriteLine(dataReader["log_id"] + "");

                   logAudioDetection.FingerprintId = getFingerPrintById(dataReader["fingerprint_id"]+"");

                    //logAudioDetection.LogDetectionTime = 
                      Console.WriteLine(dataReader["log_detected_time"] +"");
                    //logAudioDetection.LogSeenStatus = 
                      Console.WriteLine(dataReader["log_seen_status"] + "");
                    //logAudioDetection.LogMessage = 
                      Console.WriteLine(dataReader["log_message"] + "");                    

                    LogAudios.Add(logAudioDetection);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return LogAudios;
            }
            else
            {
                return null;
            }
        }

        public FingerPrint getFingerPrintById(String id)
        {
            string query = "SELECT * FROM fingerprint WHERE FINGERPRINT_ID = "+id+" ";

            //Create a list to store the result
            FingerPrint fingerPrint = new FingerPrint();


            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd1 = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader1.Read())
                {                                        
                    fingerPrint.FingerPrintId = dataReader1["fingerprint_id"] + "";
                    fingerPrint.AudioType = getAudioTypeById(dataReader1["type_id"] + "");                    
                }

                //close Data Reader
                dataReader1.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return fingerPrint;
            }
            else
            {
                return null;
            }
        }

        private AudioType getAudioTypeById(String id )
        {
            string query = "SELECT * FROM audio_type WHERE TYPE_ID = "+id+" ";

            //Create a list to store the result
            AudioType audioType = new AudioType();


            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd2 = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader2 = cmd2.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader2.Read())
                {
                    audioType.Type_id = dataReader2["type_id"] + "";
                    audioType.Type_name = dataReader2["type_name"] + "";                    
                }

                //close Data Reader
                dataReader2.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return audioType;
            }
            else
            {
                return null;
            }
        }
    }
}
