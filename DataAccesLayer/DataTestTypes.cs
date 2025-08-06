using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using clsDataAccessSettings;
using System.Diagnostics;
namespace DataAccesLayer
{
    public class DataTestTypes
    {
        public static DataTable GetAllTestTypes()
        {
            string SourceName = "DvLD";
            DataTable TT = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "Select * From TestTypes order by TestTypeID;";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    TT.Load(reader);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) 
            {
                string msg = $"Error For TestTypes : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return TT;
        }
        public static bool GetTestTypesByID(int ID, ref string TestTypeTitle, ref string TestTypeDescription, ref float Fees)
        {
            string SourceName = "DvLD";
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "select * from TestTypes Where TestTypeID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    TestTypeTitle = Reader["TestTypeTitle"] != DBNull.Value ? (string)Reader["TestTypeTitle"] : "null";
                    TestTypeDescription = Reader["TestTypeDescription"] != DBNull.Value ? (string)Reader["TestTypeDescription"] : "null";
                    Fees = Reader["TestTypeFees"] != DBNull.Value ? Convert.ToSingle(Reader["TestTypeFees"]) : 0.0f;
                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error For TestTypes : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;
            string SourceName = "DvLD";
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                string msg = $"Error For TestTypes : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }
        public static bool UpdateTestTypes(int ID, string title, string Description, float Fees)
        {
            string SourceName = "DvLD";
            int rowsffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = @"UPDATE TestTypes SET 
                        TestTypeTitle = @TestTypeTitle,
                        TestTypeDescription = @TestTypeDescription,
                        TestTypeFees = @Fees
                        WHERE TestTypeID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeTitle", title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowsffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = $"Error For TestTypes : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return (rowsffected > 0);
        }
    }
}
