using DAL.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository<int, User>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void AddUser(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_Add_User";
                    command.Parameters.AddWithValue("@UserName", entity.UserName);
                    command.Parameters.AddWithValue("@Password", entity.Password);
                    command.Parameters.AddWithValue("@IsAdmin", entity.IsAdmin);
                    connection.Open();
                    entity.UserId = (int)command.ExecuteScalar();
                }
            }
        }

        public void RemoveUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_RemoveUser";
                    command.Parameters.AddWithValue("@UserId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public User CheckUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_CheckUser2";
                    command.Parameters.AddWithValue("@userName", username);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User()
                            {
                                UserId = (int)reader["UserId"],
                                UserName = (string)reader["UserName"],
                                Password = "***********",
                                IsAdmin = (bool)reader["IsAdmin"]
                            };
                        }
                        else
                        {
                            return new User()
                            {
                                UserId = 0,
                                UserName = "invalid",
                                Password = "***********",
                                IsAdmin = false
                            };
                        }
                    }

                }
            }
        }
    }
}
