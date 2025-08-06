using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class clsLicenceClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }
        public clsLicenceClass()
        {
            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;
        }
        private clsLicenceClass(int licenseClassID, string className, string classDescription, byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }
        public static DataTable GetAllLicenceClass()
        {
            return DataLicenceClass.GetAllLicenceClass();
        }
        public static clsLicenceClass FindByID(int ID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinimumAllowedAge = 0; byte DefaultValidityLength = 0;
            float ClassFees = 0;
            bool Found = DataLicenceClass.GetClassLicenceByID(ID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees);
            if (Found)
            {
                return new clsLicenceClass(ID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }
        public static clsLicenceClass FindByName(string ClassName)
        {
            string ClassDescription = "";
            int ID = -1;
            byte MinimumAllowedAge = 0; byte DefaultValidityLength = 0;
            float ClassFees = 0;
            bool Found = DataLicenceClass.GetClassLicenceByClassName(ref ID,ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees);
            if (Found)
            {
                return new clsLicenceClass(ID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = DataLicenceClass.AddNewLicenceClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return (this.LicenseClassID != -1);
        }
        private bool _UpdateLicenceClass()
        {
            return DataLicenceClass.UpdateLicecneClass(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateLicenceClass();

            }

            return false;
        }
    }
}
