using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Country;
using DataAccesLayer;
using static BussinesLayer.clsPerson.clsUser;
namespace BussinesLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public static enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry CountyInfo;
        private string _ImagePath;
        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }
        public clsPerson()
        {
            ID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = -1;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";
            Mode = enMode.AddNew;
        }
        private clsPerson(int id, string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, int gendor, string address, string phone, string email, int nationalityCountryID, string ImagePath)
        {
            this.ID = id;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.CountyInfo = clsCountry.FindByID(this.NationalityCountryID);
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }
        public class clsUser
        {
            public enum enModeUser { AddNew = 0, Update = 1 }

            public static enModeUser UserMode = enModeUser.AddNew;
            public int UserID { get; set; }
            public int PersonID { get; set; }
            public string userName { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
            public clsUser() 
            {
                UserID = -1;
                PersonID = -1;
                userName = "";
                Password = "";
                IsActive = false;
                UserMode = enModeUser.AddNew;
            }
            private clsUser(int UserID,int PersonID, string UserName, string Password, bool IsActive)
            {
                this.UserID = UserID;
                this.PersonID = PersonID;
                this.userName = UserName;
                this.Password = Password;
                this.IsActive = IsActive;
                UserMode = enModeUser.Update;
            }
            private static string ComputeSha256Hash(string text)
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    byte[] hashbyt = sHA256.ComputeHash(Encoding.UTF8.GetBytes(text));
                    string passhashed = BitConverter.ToString(hashbyt).Replace("-", "");
                    var sbps = new StringBuilder();
                    foreach (byte b in passhashed)
                    {
                        sbps.Append(b.ToString("x2"));
                    }
                    return sbps.ToString();
                }
            }
            public static DataTable GetAllUsers()
            {
                return DataLayer.GetAllUsers();
            }
            public static clsUser Find(int ID)
            {
                string UserName = "", Password = "";
                int PersonID = 0;
                bool isActive = false;
                bool isFound = DataLayer.GetUserById(ID, ref PersonID, ref UserName, ref Password, ref isActive);
                if (isFound)
                    return new clsUser(ID, PersonID, UserName, Password, isActive);
                else
                    return null;
            }
            public static clsUser FindbyPersonID(int PersonID)
            {
                string UserName = "", Password = "";
                int UserID = 0;
                bool isActive = false;
                bool isFound = DataLayer.GetUserByPersonId(PersonID, ref UserID, ref UserName, ref Password, ref isActive);
                if (isFound)
                    return new clsUser(UserID, PersonID, UserName, Password, isActive);
                else
                    return null;
            }
            private bool _addNewUsers()
            {
                this.UserID = DataLayer.AddNewUser(this.PersonID,this.userName, this.Password, this.IsActive);
                return (this.UserID != -1);
            }
            public static bool DeleteUser(int ID)
            {
                return DataLayer.DeleteUser(ID);
            }
            private bool _UpdateUser()
            {
                return DataLayer.UpdateUser(this.UserID,this.PersonID,this.userName,this.IsActive);
            }
            public bool SaveForUsers()
            {
                switch(UserMode)
                {
                    case enModeUser.AddNew:
                        if (_addNewUsers())
                        {
                            UserMode = enModeUser.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case enModeUser.Update:
                        return _UpdateUser();
                }
                return false;
            }
            public static bool isUserExist(int UserID)
            {
                return DataLayer.isUserExist(UserID);
            }
            public static bool UpdateUserPassword(int ID, string Password)
            {
                string passhashed = ComputeSha256Hash(Password);
                return DataLayer.UpdateUserPassword(ID, passhashed);
            }
            public static clsUser Login(string UserName, string Password)
            {
                //string PasswHash = ComputeSha256Hash(Password);
                int UserID = 0, PersonID = 0;
                bool IsActive = false;
                bool Found = DataLayer.SearchUserForLogin(ref UserID, ref PersonID, ref UserName, ref Password /*PasswHash*/, ref IsActive);
                if (Found)
                    return new clsUser(UserID, PersonID, UserName, Password, IsActive);
                else
                    return null;
            }
        }
        public static clsPerson Find(int ID)
        {
            string nationalNo = "", firstName = "", secondName = "", thirdName = "", lastName = "";
            string address = "", phone = "", email = "", imagePath = "";
            int nationalityCountryID = 0;
            byte gender = 0;
            DateTime dateOfBirth = DateTime.Now;
            bool found = DataLayer.GetContactByID(
                ID, ref nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName,
                ref dateOfBirth, ref gender, ref address, ref phone, ref email,
                ref nationalityCountryID, ref imagePath
            );
            if (found)
            {
                return new clsPerson(ID, nationalNo, firstName, secondName, thirdName,
                                  lastName, dateOfBirth, gender, address, phone, email,
                                  nationalityCountryID, imagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson Find(string nationalNo)
        {
            int ID = -1;
            string firstName = "", secondName = "", thirdName = "", lastName = "";
            string address = "", phone = "", email = "", imagePath = "";
            int nationalityCountryID = 0;
            byte gender = 0;
            DateTime dateOfBirth = DateTime.Now;
            bool found = DataLayer.GetContactByNationalNo(
                ref ID, nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName,
                ref dateOfBirth, ref gender, ref address, ref phone, ref email,
                ref nationalityCountryID, ref imagePath
            );
            if (found)
            {
                return new clsPerson(ID, nationalNo, firstName, secondName, thirdName,
                                  lastName, dateOfBirth, gender, address, phone, email,
                                  nationalityCountryID, imagePath);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllPeoples()
        {
            return DataLayer.GelAllPeople();
        }
        private bool _addNewPeople()
        {
            this.ID = DataLayer.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,this.LastName, this.DateOfBirth, this.Gendor, this.Address,this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.ID != -1);
        }
        public static bool DeletePeople(int ID)
        {
            return DataLayer.DeletePerson(ID);
        }
        private bool _UpdatePeople()
        {
            return DataLayer.UpdatePerson(this.ID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }
        public bool save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_addNewPeople())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                     return _UpdatePeople();
            }
            return false;
        }
        public static bool isPersonExist(int ID)
        {
            return DataLayer.IsPersonExist(ID);
        }
    }
}
