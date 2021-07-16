using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace P4_projekt_nr_2.DBservice
{
    public class myDB
    {
        private readonly IDbConnection myDBconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbBAN"].ConnectionString);

        public IEnumerable<Facility> GetFacilities()
        {
            using (myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                return myDBconnection.Query<Facility>("SELECT * FROM BAN.Facility").ToList();
            }
        }

        public bool InsterFacility(Facility ObiektB)
        {
            using (IDbConnection dbConnection = myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                var result = myDBconnection.Execute("INSERT INTO BAN.Facility (Facility_Name, FacilityDescription, SAP) VALUES ( @Name, @DESCRIPTION, @SAP)",
                    new
                    {
                        Name = ObiektB.Facility_Name,
                        DESCRIPTION = ObiektB.FacilityDescription,
                        SAP = ObiektB.SAP
                    });

                return result == 1;
            }
        }

        public bool UpdateFacility(Facility ObiektB)
        {
            using (IDbConnection dbConnection = myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                var result = myDBconnection.Execute("UPDATE BAN.Facility SET Facility_Name = @Name , FacilityDescription = @Description, SAP = @Sap WHERE ID_Facility = @IDf",
                    new
                    {
                        IDf = ObiektB.ID_Facility,
                        Name = ObiektB.Facility_Name,
                        DESCRIPTION = ObiektB.FacilityDescription,
                        SAP = ObiektB.SAP
                    });

                return result == 1;
            }
        }

        public bool DeleteFacility(int ObiektIDf)
        {
            using (IDbConnection dbConnection = myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                var result = myDBconnection.Execute(@"DELETE FROM BAN.Facility WHERE ID_Facility = @IDf",
                    new
                    {
                        IDf = ObiektIDf
                    });

                return result == 1;
            }
        }



        public IEnumerable<BoltType> GetBoltType()
        {
            using (myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                return myDBconnection.Query<BoltType>("SELECT * FROM BAN.BoltType").ToList();
            }
        }

        public IEnumerable<LenghtType> GetLenghtType()
        {
            using (myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                return myDBconnection.Query<LenghtType>("SELECT * FROM BAN.LenghtType").ToList();
            }
        }
        public IEnumerable<DiameterType> GetDiameterType()
        {
            using (myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                return myDBconnection.Query<DiameterType>("SELECT * FROM BAN.DiameterType").ToList();
            }
        }

        public IEnumerable<NutType> GetNutType()
        {
            using (myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                return myDBconnection.Query<NutType>("SELECT * FROM BAN.NutType").ToList();
            }
        }
        public IEnumerable<WasherType> GetWasherType()
        {
            using (myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                return myDBconnection.Query<WasherType>("SELECT * FROM BAN.WasherType").ToList();
            }
        }

        public IEnumerable<BillOfMaterialsCombo> GetBillOfMaterials(int IDfacility)
        {
            using (myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                return myDBconnection.Query<BillOfMaterialsCombo>(@"SELECT*
                                                                    FROM BAN.BillOfMaterials AS BOM 
                                                                    INNER JOIN BAN.BoltType AS BT ON BOM.ID_Bolt=BT.ID_Bolt
                                                                    INNER JOIN BAN.LenghtType AS LT ON BOM.ID_Lenght=LT.ID_Lenght
                                                                    INNER JOIN BAN.DiameterType AS DT ON BOM.ID_Diameter=DT.ID_Diameter
                                                                    INNER JOIN BAN.NutType AS NT ON BOM.ID_Nut=NT.ID_Nut
                                                                    INNER JOIN BAN.WasherType AS WTF ON BOM.BoltWasherFirst=WTF.ID_Washer
                                                                    INNER JOIN BAN.WasherType AS WTS ON BOM.BoltWasherSecond=WTS.ID_Washer
                                                                    INNER JOIN BAN.WasherType AS WTT ON BOM.BoltWasherThird=WTT.ID_Washer
                                                                    WHERE BOM.ID_Facility=@IDf", new { IDf = IDfacility }).ToList();
            }
        }


        public bool InsterPosition(BillOfMaterials pos)
        {
            using (IDbConnection dbConnection = myDBconnection)
            {
                if (myDBconnection.State == ConnectionState.Closed)
                    myDBconnection.Open();
                var result = myDBconnection.Execute(@"INSERT INTO BAN.BillOfMaterials (
                                                    ID_Facility, 
                                                    JointName, 
                                                    ID_Bolt, 
                                                    ID_Diameter, 
                                                    ID_Lenght, 
                                                    BoltWasherFirst, 
                                                    BoltWasherSecond, 
                                                    BoltWasherThird, 
                                                    ID_Nut, 
                                                    NumberOfSteelJoint, 
                                                    PiecesOfSteelJoint
                                                    ) 
                                                    VALUES (@IDf, @Name, @IDb, @IDd, @IDl, @BWF, @BWS, @BWT, @IDn, @NOSJ, @POSJ)",
                    new
                    {
                        IDf = pos.ID_Facility,
                        Name = pos.JointName,
                        IDb = pos.ID_Bolt,
                        IDd = pos.ID_Diameter,
                        IDl = pos.ID_Lenght,
                        BWF = pos.BoltWasherFirst,
                        BWS = pos.BoltWasherSecond,
                        BWT = pos.BoltWasherThird,
                        IDn = pos.ID_Nut,
                        NOSJ = pos.NumberOfSteelJoint,
                        POSJ = pos.PiecesOfSteelJoint
                        //Name = ObiektB.Facility_Name,
                        //DESCRIPTION = ObiektB.FacilityDescription,
                        //SAP = ObiektB.SAP
                    });

                return result == 1;
            }
        }
    }
}
