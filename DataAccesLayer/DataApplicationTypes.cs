using clsDataAccessSettings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DataApplicationTypes
    {
        public static bool GetApplicationTypeByID(int ID, ref string Applicationtypetitle, ref float ApplicationFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    Applicationtypetitle = Reader["ApplicationTypeTitle"] != DBNull.Value ? (string)Reader["ApplicationTypeTitle"] : "null";
                    ApplicationFees = Reader["ApplicationFees"] != DBNull.Value ? Convert.ToSingle(Reader["ApplicationFees"]) : 0.0f;
                }
                else
                {
                    isFound = false;
                }
            }
            catch { }
            finally { connection.Close(); }
            return isFound;
        }
        public static DataTable GetAllApplicationTypes()
        {
            DataTable AA = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "Select * From ApplicationTypes;";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    AA.Load(reader);
                }
                reader.Close();
                connection.Close();
            }
            catch { }
            finally { connection.Close(); }
            return AA;
        }
        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;

        }
        public static bool UpdateApplicationTypes(int ID, string Applicationtypetitle, float ApplicationFees)
        {
            int rowsffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = @"UPDATE ApplicationTypes SET 
                        ApplicationTypeTitle = @Applicationtypetitle,
                        ApplicationFees = @ApplicationFees
                        WHERE ApplicationTypeID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Applicationtypetitle", Applicationtypetitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowsffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }
            return (rowsffected > 0);
        }
    }
}
