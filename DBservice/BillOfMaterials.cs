using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_projekt_nr_2.DBservice
{
    public class BillOfMaterials
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
    }
}
