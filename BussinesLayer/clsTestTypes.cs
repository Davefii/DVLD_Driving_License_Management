using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;

namespace BussinesLayer
{
    public class clsTestTypes
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsTestTypes.enTestType ID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        public clsTestTypes()
        {
            this.ID = enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            mode = enMode.AddNew;
        }
        public clsTestTypes(clsTestTypes.enTestType ID, string TestTypeTitle, string TestTypeDescription, float ApplicationFees)
        {
            this.ID = ID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = ApplicationFees;
            mode = enMode.Update;
        }
        public static DataTable GetAllTestTypes()
        {
            return DataTestTypes.GetAllTestTypes();
        }
        public static clsTestTypes Find(clsTestTypes.enTestType ID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            float ApplicationFees = 0;
            bool Found = DataTestTypes.GetTestTypesByID((int)ID, ref TestTypeTitle, ref TestTypeDescription, ref ApplicationFees);
            if (Found)
            {
                return new clsTestTypes(ID, TestTypeTitle, TestTypeDescription, ApplicationFees);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewTestType()
        {
            this.ID = (clsTestTypes.enTestType)DataTestTypes.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            return (this.TestTypeTitle != "");
        }
        private bool _UpdateTestType()
        {
            return DataTestTypes.UpdateTestTypes((int)ID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        public bool Save()
        {
            return _UpdateTestType();
        }
        public bool save()
        {
            switch(mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                        return true;
                    else
                        return false;
                case enMode.Update:
                    return _UpdateTestType();
            }
            return false;
        }
    }
}
