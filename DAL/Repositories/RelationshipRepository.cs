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
    public class RelationshipRepository : IRelationshipRepository<int, Relationship>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void Add(Relationship entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_AddRelationship";
                    command.Parameters.AddWithValue("@Person1Id", entity.Person1Id);
                    command.Parameters.AddWithValue("@Person2Id", entity.Person2Id);
                    command.Parameters.AddWithValue("@StartDate", entity.StartDate);
                    command.Parameters.AddWithValue("@EndDate", entity.EndDate);
                    command.Parameters.AddWithValue("@IsUnisex", entity.IsUnisex);
                    command.Parameters.AddWithValue("@RelationshipTypeCode", entity.RelationshipTypeCode);
                    command.Parameters.AddWithValue("@TreeId", entity.TreeId);
                    connection.Open();
                    entity.RelationshipId = (int)command.ExecuteScalar();
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
                    command.CommandText = "SP_DeleteRelationship";
                    command.Parameters.AddWithValue("@RelationshipId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRelationshipsId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_DeleteRelationshipsId";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Relationship> Get()
        {
            List<Relationship> relationshipList = new List<Relationship>();

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_RelationshipGetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Relationship r = new Relationship();
                            r.RelationshipId = (int)reader["RelationshipId"];
                            r.Person1Id = (int)reader["Person1Id"];
                            r.Person2Id = (int)reader["Person2Id"];
                            r.StartDate = (DateTime)reader["StartDate"];
                            if (!DBNull.Value.Equals(reader["EndDate"]))
                            {
                                r.EndDate = (DateTime)reader["EndDate"];
                            }
                            else r.EndDate = null;
                            r.IsUnisex= (bool)reader["IsUnisex"];
                            r.RelationshipTypeCode = (string)reader["RelationshipTypeCode"];
                            r.TreeId = (int)reader["TreeId"];
                            relationshipList.Add(r);

                        }

                    }
                }
            }
            return relationshipList;
        }

        public Relationship Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_RelationshipGetOne";
                    command.Parameters.AddWithValue("@RelationshipId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Relationship r = new Relationship();
                            r.RelationshipId = (int)reader["RelationshipId"];
                            r.Person1Id = (int)reader["Person1Id"];
                            r.Person2Id = (int)reader["Person2Id"];
                            r.StartDate = (DateTime)reader["StartDate"];
                            if (!DBNull.Value.Equals(reader["EndDate"]))
                            {
                                r.EndDate = (DateTime)reader["EndDate"];
                            }
                            else r.EndDate = null;
                            r.IsUnisex = (bool)reader["IsUnisex"];
                            r.RelationshipTypeCode = (string)reader["RelationshipTypeCode"];
                            r.TreeId = (int)reader["TreeId"];
                            return r;

                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
        }

        public IEnumerable<Relationship> GetRelationships(int id)
        {
            List<Relationship> relationshipList = new List<Relationship>();

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GetRelationships";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Relationship r = new Relationship();
                            r.RelationshipId = (int)reader["RelationshipId"];
                            r.Person1Id = (int)reader["Person1Id"];
                            r.Person2Id = (int)reader["Person2Id"];
                            r.StartDate = (DateTime)reader["StartDate"];
                            if (!DBNull.Value.Equals(reader["EndDate"]))
                            {
                                r.EndDate = (DateTime)reader["EndDate"];
                            }
                            else r.EndDate = null;
                            r.IsUnisex = (bool)reader["IsUnisex"];
                            r.RelationshipTypeCode = (string)reader["RelationshipTypeCode"];
                            r.TreeId = (int)reader["TreeId"];
                            relationshipList.Add(r);
                        }
                    }

                }
            }
            return relationshipList;
        }

        public IEnumerable<Relationship> GetRelationshipsFromTree(int id)
        {
            List<Relationship> relationshipList = new List<Relationship>();

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GetRelationshipsFromTree";
                    command.Parameters.AddWithValue("@TreeId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Relationship r = new Relationship();
                            r.RelationshipId = (int)reader["RelationshipId"];
                            r.Person1Id = (int)reader["Person1Id"];
                            r.Person2Id = (int)reader["Person2Id"];
                            r.StartDate = (DateTime)reader["StartDate"];
                            if (!DBNull.Value.Equals(reader["EndDate"]))
                            {
                                r.EndDate = (DateTime)reader["EndDate"];
                            }
                            else r.EndDate = null;
                            r.IsUnisex = (bool)reader["IsUnisex"];
                            r.RelationshipTypeCode = (string)reader["RelationshipTypeCode"];
                            r.TreeId = (int)reader["TreeId"];
                            relationshipList.Add(r);
                        }
                    }

                }
            }
            return relationshipList;
        }

        public void Update(int id, Relationship entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_UpdateRelationship";
                    command.Parameters.AddWithValue("@RelationshipId", id);
                    command.Parameters.AddWithValue("@Person1Id", entity.Person1Id);
                    command.Parameters.AddWithValue("@Person2Id", entity.Person2Id);
                    command.Parameters.AddWithValue("@StartDate", entity.StartDate);
                    command.Parameters.AddWithValue("@EndDate", entity.EndDate);
                    command.Parameters.AddWithValue("@IsUnisex", entity.IsUnisex);
                    command.Parameters.AddWithValue("@RelationshipTypeCode", entity.RelationshipTypeCode);
                    command.Parameters.AddWithValue("@TreeId", entity.TreeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
