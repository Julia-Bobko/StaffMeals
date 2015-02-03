using StaffMeals.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace StaffMeals.Repositories
{
    public  class ClientRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["smdb"].ConnectionString;

        public  IEnumerable<Client> GetClients()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var clients = conn.Query<Client>("select * from client");
                return clients;
            }
        }


        public  Client GetClient(string fio)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var client = conn.Query<Client>("select * from client where fio=@fio", new { fio }).First();
                return client;
            }
        }
    }
}
