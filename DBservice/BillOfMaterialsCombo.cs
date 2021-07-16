using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_projekt_nr_2.DBservice
{
    public class BillOfMaterialsCombo
    {
        public int ID_SteelJoint { get; set; }
        public int ID_Facility { get; set; }
        public string JointName { get; set; }
        public int ID_Bolt { get; set; }
        public int ID_Diameter { get; set; }
        public int ID_Lenght { get; set; }
        public int BoltWasherFirst { get; set; }
        public int BoltWasherSecond { get; set; }
        public int BoltWasherThird { get; set; }
        public int ID_Nut { get; set; }
        public int NumberOfSteelJoint { get; set; }
        public int PiecesOfSteelJoint { get; set; }
        public string WasherStandardWTF { get; set; }
        public string WasherStandardWTS { get; set; }
        public string WasherStandardWTT { get; set; }

        public int Kits => NumberOfSteelJoint * PiecesOfSteelJoint;

        //BoltType
        //public int ID_Bolt { get; set; }
        public string BoltName { get; set; }
        public string BoltStandard { get; set; }
        public string BoltDescription { get; set; }

        //DiamterType
        //public int ID_Diameter { get; set; }
        public string Diameter { get; set; }

        //LenghtType
        //public int ID_Lenght { get; set; }
        public string BoltLenght { get; set; }

        //NutType
        //public int ID_Nut { get; set; }
        public string NutName { get; set; }
        public string NutStandard { get; set; }
        public string NutDescription { get; set; }

        //WasherType
        //public int ID_Washer { get; set; }
        public string WasherName { get; set; }
        public string WasherStandard { get; set; }
        public string WasherDescription { get; set; }



    }
}
