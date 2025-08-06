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
    public class DataLicenceClass
    {
        public static DataTable GetAllLicenceClass()
        {
            DataTable TT = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "select * from LicenseClasses;";
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
            catch { }
            finally { connection.Close(); }
            return TT;
        }
        public static bool GetClassLicenceByID(int ID, ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "select * from LicenseClasses Where LicenseClassID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    ClassName = Reader["ClassName"] != DBNull.Value ? (string)Reader["ClassName"] : "null";
                    ClassDescription = Reader["ClassDescription"] != DBNull.Value ? (string)Reader["ClassDescription"] : "null";
                    MinimumAllowedAge = Reader["MinimumAllowedAge"] != DBNull.Value ? Convert.ToByte(Reader["MinimumAllowedAge"]) : (byte)0;
                    DefaultValidityLength = Reader["DefaultValidityLength"] != DBNull.Value ? (byte)Reader["DefaultValidityLength"] : (byte)0;
                    ClassFees = Reader["ClassFees"] != DBNull.Value ? Convert.ToSingle(Reader["ClassFees"]) : 0.0f;
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
        public static bool GetClassLicenceByClassName(ref int ID, string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "select * from LicenseClasses Where ClassName = @ClassName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    ID = Reader["LicenseClassID"] != DBNull.Value ? (int)Reader["LicenseClassID"] : -1;
                    ClassDescription = Reader["ClassDescription"] != DBNull.Value ? (string)Reader["ClassDescription"] : "null";
                    MinimumAllowedAge = Reader["MinimumAllowedAge"] != DBNull.Value ? Convert.ToByte(Reader["MinimumAllowedAge"]): (byte)0;
                    DefaultValidityLength = Reader["DefaultValidityLength"] != DBNull.Value ? (byte)Reader["DefaultValidityLength"] : (byte)0;
                    ClassFees = Reader["ClassFees"] != DBNull.Value ? Convert.ToSingle(Reader["ClassFees"]) : 0.0f;
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
        public static int AddNewLicenceClass(string ClassName,  string ClassDescription,  byte MinimumAllowedAge, byte DefaultValidityLength,  float ClassFees)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string query = @"Insert Into LicenseClasses (ClassName,ClassDescription,MinimumAllowedAge, DefaultValidityLength,ClassFees)
                            Values ( @ClassName,@ClassDescription,@MinimumAllowedAge, @DefaultValidityLength,@ClassFees)
                            where LicenseClassID = @LicenseClassID;
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            try
            {
                connection.Open();
                object Result = command.BeginExecuteNonQuery();
                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }
            catch { }
            finally { connection.Close(); }
            return ID;
        }
        public static bool UpdateLicecneClass(int ID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int rowsffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = @"UPDATE LicenseClasses SET 
                        ClassName = @ClassName,
                        ClassDescription = @ClassDescription,
                        MinimumAllowedAge = @MinimumAllowedAge,
                        DefaultValidityLength = @DefaultValidityLength,
                        ClassFees = @ClassFees
                        WHERE LicenseClassID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
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
