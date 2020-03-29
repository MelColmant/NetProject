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
    public class PersonRepository : IPersonRepository<int, Person>
    {
        private string _constring = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public void Add(Person entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_AddPerson";
                    command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@LastName", entity.LastName);
                    command.Parameters.AddWithValue("@Gender", entity.Gender);
                    command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                    command.Parameters.AddWithValue("@DeathDate", entity.DeathDate);
                    command.Parameters.AddWithValue("@TreeId", entity.TreeId);
                    connection.Open();
                    entity.PersonId = (int)command.ExecuteScalar();
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
                    command.CommandText = "SP_DeletePerson";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Person> Get()
        {
            List<Person> personList = new List<Person>();

            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_PersonGetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person p = new Person();
                            p.PersonId = (int)reader["PersonId"];
                            p.FirstName = (string)reader["FirstName"];
                            p.LastName = (string)reader["LastName"];
                            p.Gender = (string)reader["Gender"];
                            p.BirthDate = (DateTime)reader["BirthDate"];
                            if (!DBNull.Value.Equals(reader["DeathDate"]))
                            {
                                p.DeathDate = (DateTime)reader["DeathDate"];
                            }
                            else p.DeathDate = null;
                            p.TreeId = (int)reader["TreeId"];
                            personList.Add(p);

                        }

                    }
               
                }
            }

            return personList;
        }

        public Person Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_PersonGetOne";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Person p = new Person();
                            p.PersonId = (int)reader["PersonId"];
                            p.FirstName = (string)reader["FirstName"];
                            p.LastName = (string)reader["LastName"];
                            p.Gender = (string)reader["Gender"];
                            p.BirthDate = (DateTime)reader["BirthDate"];
                            if (!DBNull.Value.Equals(reader["DeathDate"]))
                            {
                                p.DeathDate = (DateTime)reader["DeathDate"];
                            }
                            else p.DeathDate = null;
                            p.TreeId = (int)reader["TreeId"];
                            return p;

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public IEnumerable<Person> GetAllFromTree(int id)
        {
            List<Person> personList = new List<Person>();
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_PersonGetAllFromTree";
                    command.Parameters.AddWithValue("@TreeId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person p = new Person();
                            p.PersonId = (int)reader["PersonId"];
                            p.FirstName = (string)reader["FirstName"];
                            p.LastName = (string)reader["LastName"];
                            p.Gender = (string)reader["Gender"];
                            p.BirthDate = (DateTime)reader["BirthDate"];
                            if (!DBNull.Value.Equals(reader["DeathDate"]))
                            {
                                p.DeathDate = (DateTime)reader["DeathDate"];
                            }
                            else p.DeathDate = null;
                            p.TreeId = (int)reader["TreeId"];
                            personList.Add(p);
                        }
                    
                    }
                }
            }
            return personList;
        }

        public IEnumerable<Person> GetChildren(int id)
        {
            List<Person> personList = new List<Person>();
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GetChildren";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person p = new Person();
                            p.PersonId = (int)reader["PersonId"];
                            p.FirstName = (string)reader["FirstName"];
                            p.LastName = (string)reader["LastName"];
                            p.Gender = (string)reader["Gender"];
                            p.BirthDate = (DateTime)reader["BirthDate"];
                            if (!DBNull.Value.Equals(reader["DeathDate"]))
                            {
                                p.DeathDate = (DateTime)reader["DeathDate"];
                            }
                            else p.DeathDate = null;
                            p.TreeId = (int)reader["TreeId"];
                            personList.Add(p);
                        }
                        
                    }
                }
            }
            return personList;
        }

        public IEnumerable<Person> GetParents(int id)
        {
            List<Person> personList = new List<Person>();
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GetParents";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person p = new Person();
                            p.PersonId = (int)reader["PersonId"];
                            p.FirstName = (string)reader["FirstName"];
                            p.LastName = (string)reader["LastName"];
                            p.Gender = (string)reader["Gender"];
                            p.BirthDate = (DateTime)reader["BirthDate"];
                            if (!DBNull.Value.Equals(reader["DeathDate"]))
                            {
                                p.DeathDate = (DateTime)reader["DeathDate"];
                            }
                            else p.DeathDate = null;
                            p.TreeId = (int)reader["TreeId"];
                            personList.Add(p);
                        }
                      
                    }
                }
            }
            return personList;
        }

        public IEnumerable<Person> GetSiblings(int id)
        {
            List<Person> personList = new List<Person>();
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_GetSiblings";
                    command.Parameters.AddWithValue("@PersonId", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person p = new Person();
                            p.PersonId = (int)reader["PersonId"];
                            p.FirstName = (string)reader["FirstName"];
                            p.LastName = (string)reader["LastName"];
                            p.Gender = (string)reader["Gender"];
                            p.BirthDate = (DateTime)reader["BirthDate"];
                            if (!DBNull.Value.Equals(reader["DeathDate"]))
                            {
                                p.DeathDate = (DateTime)reader["DeathDate"];
                            }
                            else p.DeathDate = null;
                            p.TreeId = (int)reader["TreeId"];
                            personList.Add(p);
                        }
                      
                    }
                }
            }
            return personList;
        }

        public void Update(int id, Person entity)
        {
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_PersonUpdate";
                    command.Parameters.AddWithValue("@PersonId", id);
                    command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@LastName", entity.LastName);
                    command.Parameters.AddWithValue("@Gender", entity.Gender);
                    command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                    command.Parameters.AddWithValue("@DeathDate", entity.DeathDate);
                    command.Parameters.AddWithValue("@TreeId", entity.TreeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
