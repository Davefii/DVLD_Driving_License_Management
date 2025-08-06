using DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class clsApplicationTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string ApplicationTitleTypes { get; set; }
        public float ApplicationTypesFee { get; set; }
        public clsApplicationTypes()
        {
            this.ID = -1;
            this.ApplicationTitleTypes = "";
            this.ApplicationTypesFee = 0;
            Mode = enMode.AddNew;
        }
        public clsApplicationTypes(int ID, string Applicationtypetitle, float ApplicationFees)
        {
            this.ID = ID;
            this.ApplicationTitleTypes = Applicationtypetitle;
            this.ApplicationTypesFee = ApplicationFees;
            Mode = enMode.Update;
        }
        public static DataTable GetAllAppliaction()
        {
            return DataApplicationTypes.GetAllApplicationTypes();
        }
        public static clsApplicationTypes Find(int ID)
        {
            string Applicationtypetitle = "";
            float ApplicationFees = -1;
            bool Found = DataApplicationTypes.GetApplicationTypeByID((int)ID, ref Applicationtypetitle, ref ApplicationFees);
            if (Found)
            {
                return new clsApplicationTypes(ID, Applicationtypetitle, ApplicationFees);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 
            this.ID = DataApplicationTypes.AddNewApplicationType(this.ApplicationTitleTypes, this.ApplicationTypesFee);
            return (this.ID != -1);
        }
        private bool _UpdateApplicationTypes()
        {
            return DataApplicationTypes.UpdateApplicationTypes(this.ID, this.ApplicationTitleTypes, this.ApplicationTypesFee);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationTypes();

            }
            return false;
        }
    }
}
