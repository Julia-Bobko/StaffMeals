using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using StaffMeals.Entities;
using StaffMeals.Helpers;

namespace StaffMeals.Repositories
{
    public class AccountRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["smdb"].ConnectionString;

        public bool Register(Client client)
        {
            if (IsValidUser(client) && !IsExistUser(client))
            {
                var sql = @"INSERT INTO Client(fio, login, password)
                            VALUES(@Fio, @Login, @Password)";
                client.Password = Decripting.GetMD5Hash(client.Password);
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var status = conn.Execute(sql, new { client.Fio, client.Login, client.Password });
                    return status == 1 ? true : false;
                }
            }
            return false;
        }

        public Client Authorize(string login, string password)
        {
            var passwordHash = Decripting.GetMD5Hash(password);
            var sql = @"SELECT * FROM Client WHERE login = @Login AND Password = @passwordHash";            
            using (var conn = new SqlConnection(ConnectionString))
            {
                var user = conn.Query<Client>(sql, new { login, passwordHash }).FirstOrDefault();
                return user;
            }
        }

        private bool IsValidUser(Client client)
        {
            if (!String.IsNullOrEmpty(client.Fio) && !String.IsNullOrEmpty(client.Login) && !String.IsNullOrEmpty(client.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsExistUser(Client client)
        {
            var sql = @"SELECT * FROM Client WHERE login = @Login";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var currentClient = conn.Query<Client>(sql, new { client.Login }).FirstOrDefault();
                return currentClient != null ? true : false;
            }
        }
    }
}
