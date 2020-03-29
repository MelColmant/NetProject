using DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TreeRepository : IRepository<int, Tree>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void Add(Tree entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_AddTree";
                    command.Parameters.AddWithValue("@TreeName", entity.TreeName);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@UserId", entity.UserId);
                    connection.Open();
                    try 
                    {
                        entity.TreeId = (int)command.ExecuteScalar();
                    }catch (NullReferenceException ex)
                    {
                        Debug.WriteLine("Only an admin can build a tree!");
                    }
                    
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
                    command.CommandText = "SP_DeleteTree";
                    command.Parameters.AddWithValue("@TreeId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Tree> Get()
        {
            List<Tree> treeList = new List<Tree>();

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_TreeGetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tree t = new Tree();
                            t.TreeId = (int)reader["TreeId"];
                            t.TreeName = (string)reader["TreeName"];
                            if (!DBNull.Value.Equals(reader["Description"]))
                            {
                                t.Description = (string)reader["Description"];
                            }
                            else t.Description = null;
                            t.UserId = (int)reader["UserId"];
                            treeList.Add(t);
                        }
                    }
                }

            }
            return treeList;
            
        }

        public Tree Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_TreeGetOne";
                    command.Parameters.AddWithValue("@TreeId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Tree t = new Tree();
                            t.TreeId = (int)reader["TreeId"];
                            t.TreeName = (string)reader["TreeName"];
                            if (!DBNull.Value.Equals(reader["Description"]))
                            {
                                t.Description = (string)reader["Description"];
                            }
                            else t.Description = null;
                            t.UserId = (int)reader["UserId"];
                            return t;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void Update(int id, Tree entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_UpdateTree";
                    command.Parameters.AddWithValue("@TreeId", id);
                    command.Parameters.AddWithValue("@TreeName", entity.TreeName);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
