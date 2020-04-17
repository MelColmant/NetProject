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
    public class ParentChildRepository : IParentChildRepository<int, ParentChild>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void Add(ParentChild entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_AddParentChild";
                    command.Parameters.AddWithValue("@Person1Id", entity.Person1Id);
                    command.Parameters.AddWithValue("@Person2Id", entity.Person2Id);
                    command.Parameters.AddWithValue("@IsAdopted", entity.IsAdopted);
                    command.Parameters.AddWithValue("@TreeId", entity.TreeId);
                    connection.Open();
                    entity.ParentChildId = (int)command.ExecuteScalar();
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
                    command.CommandText = "SP_DeleteParentChild";
                    command.Parameters.AddWithValue("@ParentChildId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteParentChildId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_DeleteParentChildId";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ParentChild> Get()
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_ParentChildGetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new ParentChild()
                            {
                                ParentChildId = (int)reader["ParentChildId"],
                                Person1Id = (int)reader["Person1Id"],
                                Person2Id = (int)reader["Person2Id"],
                                IsAdopted = (bool)reader["IsAdopted"],
                                TreeId = (int)reader["TreeId"]
                            };
                        }
                    }
                }
            }
        }

        public ParentChild Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_ParentChildGetOne";
                    command.Parameters.AddWithValue("@ParentChildId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ParentChild()
                            {
                                ParentChildId = (int)reader["ParentChildId"],
                                Person1Id = (int)reader["Person1Id"],
                                Person2Id = (int)reader["Person2Id"],
                                IsAdopted = (bool)reader["IsAdopted"],
                                TreeId = (int)reader["TreeId"]
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

        public IEnumerable<ParentChild> GetParentChildFromTree(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_ParentChildGetFromTree";
                    command.Parameters.AddWithValue("@TreeId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new ParentChild()
                            {
                                ParentChildId = (int)reader["ParentChildId"],
                                Person1Id = (int)reader["Person1Id"],
                                Person2Id = (int)reader["Person2Id"],
                                IsAdopted = (bool)reader["IsAdopted"],
                                TreeId = (int)reader["TreeId"]
                            };
                        }
                    }
                }
            }
        }

        public void Update(int id, ParentChild entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_UpdateParentChild";
                    command.Parameters.AddWithValue("@ParentChildId", id);
                    command.Parameters.AddWithValue("@Person1Id", entity.Person1Id);
                    command.Parameters.AddWithValue("@Person2Id", entity.Person2Id);
                    command.Parameters.AddWithValue("@IsAdopted", entity.IsAdopted);
                    command.Parameters.AddWithValue("@TreeId", entity.TreeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
