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
    }
}
