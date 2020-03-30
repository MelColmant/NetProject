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
    public class Person_RessourceRepository : IRepository<int, Person_Ressource>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void Add(Person_Ressource entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_AddPerson_Ressource";
                    command.Parameters.AddWithValue("@PersonId", entity.PersonId);
                    command.Parameters.AddWithValue("@RessourceId", entity.RessourceId);
                    connection.Open();
                    entity.Person_RessourceId = (int)command.ExecuteScalar();
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
                    command.CommandText = "SP_DeletePerson_Ressource";
                    command.Parameters.AddWithValue("Person_RessourceId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Person_Ressource> Get()
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_Person_RessourceGetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Person_Ressource()
                            {
                                Person_RessourceId = (int)reader["Person_RessourceId"],
                                PersonId = (int)reader["PersonId"],
                                RessourceId = (int)reader["RessourceId"]
                            };
                        }
                    }
                }
            }
        }

        public Person_Ressource Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_Person_RessourceGetOne";
                    command.Parameters.AddWithValue("@Person_RessourceId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Person_Ressource()
                            {
                                Person_RessourceId = (int)reader["Person_RessourceId"],
                                PersonId = (int)reader["PersonId"],
                                RessourceId = (int)reader["RessourceId"]
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

        public void Update(int id, Person_Ressource entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_UpdatePerson_Ressource";
                    command.Parameters.AddWithValue("Person_RessourceId", id);
                    command.Parameters.AddWithValue("PersonId", entity.PersonId);
                    command.Parameters.AddWithValue("RessourceId", entity.RessourceId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
