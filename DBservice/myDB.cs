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
    }
}
