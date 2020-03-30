using DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GodFMRepository : IRepository<int, GodFM>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void Add(GodFM entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_AddGodFM";
                    command.Parameters.AddWithValue("@Person1Id", entity.Person1Id);
                    command.Parameters.AddWithValue("@Person2Id", entity.Person2Id);
                    connection.Open();
                    entity.GodFMId = (int)command.ExecuteScalar();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_DeleteGodFM";
                    command.Parameters.AddWithValue("@GodFMId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<GodFM> Get()
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GodFMGetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new GodFM()
                            {
                                GodFMId = (int)reader["GodFMId"],
                                Person1Id = (int)reader["Person1Id"],
                                Person2Id = (int)reader["Person2Id"]
                            };
                        }
                    }
                }
            }
        }

        public GodFM Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GodFMGetOne";
                    command.Parameters.AddWithValue("GodFMId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new GodFM()
                            {
                                GodFMId = (int)reader["GodFMId"],
                                Person1Id = (int)reader["Person1Id"],
                                Person2Id = (int)reader["Person2Id"]
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void Update(int id, GodFM entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GodFMUpdate";
                    command.Parameters.AddWithValue("@GodFMId", id);
                    command.Parameters.AddWithValue("@Person1Id", entity.Person1Id);
                    command.Parameters.AddWithValue("@Person2Id", entity.Person2Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
