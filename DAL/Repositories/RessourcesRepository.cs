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
    public class RessourcesRepository : IRepository<int, Ressources>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void Add(Ressources entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_AddRessource";
                    command.Parameters.AddWithValue("@Format", entity.Format);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@Link", entity.Link);
                    connection.Open();
                    entity.RessourceId = (int)command.ExecuteScalar();
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
                    command.CommandText = "SP_DeleteRessource";
                    command.Parameters.AddWithValue("RessourceId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Ressources> Get()
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_RessourcesGetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Ressources()
                            {
                                RessourceId = (int)reader["RessourceId"],
                                Format = (string)reader["Format"],
                                Description = (string)reader["Description"],
                                Link = (string)reader["Link"]
                            };
                        }
                    }
                      
                }
            }
        }

        public Ressources Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_RessourcesGetOne";
                    command.Parameters.AddWithValue("@RessourceId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Ressources()
                            {
                                RessourceId = (int)reader["RessourceId"],
                                Format = (string)reader["Format"],
                                Description = (string)reader["Description"],
                                Link = (string)reader["Link"]
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

        public void Update(int id, Ressources entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_UpdateRessource";
                    command.Parameters.AddWithValue("@RessourceId", id);
                    command.Parameters.AddWithValue("@Format", entity.Format);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@Link", entity.Link);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
