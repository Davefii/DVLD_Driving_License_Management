using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using clsDataAccessSettings;
namespace DataAccesLayer
{
    public class DataLayer
    {
        public static DataTable GelAllPeople()
        {
            DataTable People = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string query = @"
                    select PersonID,NationalNo, FirstName,SecondName,LastName,DateOfBirth,Gendor =
                    CASE
                        WHEN Gendor=0 THEN 'Male'
                        WHEN Gendor=1 THEN 'Female'
                        ELSE 'Unknown'
                    END
                    , Address , Phone, Email,  Countries.CountryName, ImagePath
                    from People INNER JOIN 
                    		 Countries On People.NationalityCountryID = Countries.CountryID
                    		 order by People.FirstName;";
            SqlCommand command = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    People.Load(reader);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) {  }
            return People;
        }
        public static bool GetContactByID(int ID,ref string NationalNo,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,ref DateTime DateOfBirth,ref byte Gendor,ref string Address,ref string Phone,ref string Email,ref int NationalityCountryID,ref string imagePath)
        {
            string SourceName = "DvLD";
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "Select * From People Where PersonID = @ID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    if (reader["SecondName"] != DBNull.Value)
                    { SecondName = (string)reader["SecondName"]; }
                    else
                    { SecondName = ""; }
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "";
                    Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "";
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != System.DBNull.Value)
                        imagePath = (string)reader["ImagePath"];
                    else
                        imagePath = "";
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string msg = $"Error For Peoplesec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool GetContactByNationalNo(ref int ID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string imagePath)
        {
            string SourceName = "DvLD";
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "Select * From People Where NationalNo = @No;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@No", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    if (reader["SecondName"] != DBNull.Value)
                    { SecondName = (string)reader["SecondName"]; }
                    else
                    { SecondName = ""; }
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "";
                    Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "";
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != System.DBNull.Value)
                        imagePath = (string)reader["ImagePath"];
                    else
                        imagePath = "";
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string msg = $"Error For PeopleSec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static int AddNewPerson(string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, int gendor, string address, string phone, string email, int nationalityCountryID, string ImagePath)
        {
            string SourceName = "DvLD";
            //this function will return the new contact id if succeeded and -1 if not.
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID)
                     VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);
            if(thirdName != "" || thirdName != null)
                command.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gendor", gendor);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);
            if (ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error For PeopleSec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally {connection.Close();}
            return ContactID;
        }
        public static bool DeletePerson(int ID)
        {
            string SourceName = "DvLD";
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);

            string query = @"DELETE FROM People WHERE PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = $"Error For PeopleSec : {ex.Message}";
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

            return (rowsAffected > 0);
        }
        public static bool UpdatePerson(int ID, string nationalNo, string firstName, string secondName,
        string thirdName, string lastName, DateTime dateOfBirth, int gendor, string address,
        string phone, string email, int nationalityCountryID, string ImagePath)
        {
            string SourceName = "DvLD";
            int RowsAffected = 0;
            string query = @"UPDATE People SET 
                        NationalNo = @nationalNo,
                        FirstName = @firstName,
                        SecondName = @secondName,
                        ThirdName = @thirdName,
                        LastName = @lastName,
                        DateOfBirth = @dateOfBirth,
                        Gendor = @gendor,
                        Address = @address,
                        Phone = @phone,
                        Email = @email,
                        NationalityCountryID = @nationalityCountryID,
                        ImagePath = @ImagePath
                     WHERE PersonID = @ID";

            using (SqlConnection connection = new SqlConnection(DataAccessSetting.conniction))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@nationalNo", nationalNo);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@secondName", secondName);
                command.Parameters.AddWithValue("@thirdName", thirdName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@gendor", gendor);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@nationalityCountryID", nationalityCountryID);
                command.Parameters.AddWithValue("@ImagePath", ImagePath == "" ? (object)DBNull.Value : ImagePath);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string msg = $"Error For PeopleSec : {ex.Message}";
                    if (!EventLog.SourceExists(SourceName))
                    {
                        EventLog.CreateEventSource(SourceName, "DVLD");
                    }
                    EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
                }
            }
            return (RowsAffected > 0);
        }
        public static bool IsPersonExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool IsPersonExist(string Nationalno)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);

            string query = "SELECT Found=1 FROM People WHERE NationalNo = @No";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@No", Nationalno);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllUsers()
        {
            DataTable User = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = @"
                    select Users.UserID , Users.PersonID,
                    FullName= People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName ,
                    Users.UserName, Users.IsActive FROM Users INNER JOIN 
                    People On Users.PersonID = People.PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    User.Load(Reader);
                }
                Reader.Close();
                connection.Close();
            }
            catch { }
            finally { connection.Close(); }
            return User;
        }
        public static bool GetUserById(int ID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string SourceName = "DvLD";
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "Select * From Users Where UserID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    PersonID = (int)Reader["PersonID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error For userSec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool GetUserByPersonId(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string SourceName = "DvLD";
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "Select * From Users Where PersonID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    UserID = (int)Reader["UserID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex) { string msg = $"Error For userSec : {ex.Message}"; if (!EventLog.SourceExists(SourceName)) { EventLog.CreateEventSource(SourceName, "DVLD"); } EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error); }
            finally { connection.Close(); }
            return isFound;
        }
        public static int AddNewUser(int PersonID, string UserName, string Password,bool IsActive)
        {
            string SourceName = "DvLD";
            int UserID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                     VALUES (@PersonID, @UserName, @Password, @IsActive);
                     SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
                //if (Reader != null && int.TryParse(UserID.ToString(), out int insertedID))
                ////if ((Reader != null && int.TryParse(Reader.ToString(), out int insertedID)))
                //{
                //    UserID = insertedID;
                //}
            }
            catch (Exception ex) { string msg = $"Error For userSec : {ex.Message}"; if (!EventLog.SourceExists(SourceName)) { EventLog.CreateEventSource(SourceName, "DVLD"); } EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error); }
            finally { connection.Close(); }
            return UserID;
        }
        public static bool DeleteUser(int UserID)
        {
            string SourceName = "DvLD";
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection( DataAccessSetting.conniction);
            string Query = @"DELETE FROM Users WHERE UserID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", UserID);
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = $"Error For userSec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return (RowsAffected > 0);
        }
        public static bool UpdateUser(int ID,int PersonID, string UserName, bool IsActive)
        {
            string SourceName = "DvLD";
            int RowAffeced = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string query = "UPDATE Users SET PersonID = @PersonID,UserName = @UserName,IsActive = @IsActive where UserID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                RowAffeced = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = $"Error For usersec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return (RowAffeced > 0);
        }
        public static bool UpdateUserPassword(int ID, string Password)
        {
            string SourceName = "DvLD";
            int RowAffeced = 0;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string query = @"UPDATE Users SET Password = @Password WHERE UserID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                RowAffeced = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = $"Error For userSec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return (RowAffeced > 0);
        }
        public static bool isUserExist(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string query = "SELECT Found=1 FROM Users WHERE UserID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        // Login
        public static bool SearchUserForLogin(ref int UserID,ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string SourceName = "DvLD";
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSetting.conniction);
            string Query = "Select * From Users Where UserName = @UserName and Password = @Password;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception ex)
            {
                string msg = $"Error For UserSec : {ex.Message}";
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "DVLD");
                }
                EventLog.WriteEntry(SourceName, msg, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return isFound;
        }
    }
}