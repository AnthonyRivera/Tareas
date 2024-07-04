using CodingChallenge_1.Interfaces;
using CodingChallenge_1.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Configuration;

namespace CodeChallenge_1.Repositories
{
    public class AuthorAdoRepository : IAuthorRepository
    {
        private readonly string _connectionString;
        public AuthorAdoRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BibliotecaDbCnn"].ConnectionString;
        }

        public int Add(Author author)
        {
            int newAuthorId = 0;
            string query = "INSERT INTO Author (FirstName, LastName) OUTPUT INSERTED.AuthorID VALUES (@FirstName, @LastName)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", author.Name);
                command.Parameters.AddWithValue("@LastName", author.LastName);

                connection.Open();
                newAuthorId = (int)command.ExecuteScalar();
            }

            return newAuthorId;

        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Author WHERE AuthorID = @AuthorID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AuthorID", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public Author GetById(int id)
        {
            Author author = null;
            string query = "SELECT * FROM Author WHERE AuthorID = @AuthorID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AuthorID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    author = new Author
                    {
                        AuthorId = Convert.ToInt32(reader["AuthorID"]),
                        Name = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                }
                reader.Close();
            }

            return author;

        }

        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            string query = "SELECT * FROM Author";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Author author = new Author
                    {
                        AuthorId = Convert.ToInt32(reader["AuthorID"]),
                        Name = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    authors.Add(author);
                }
                reader.Close();
            }

            return authors;

        }

        public void Update(Author author)
        {
            string query = "UPDATE Author SET FirstName = @FirstName, LastName = @LastName WHERE AuthorID = @AuthorID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", author.Name);
                command.Parameters.AddWithValue("@LastName", author.LastName);
                command.Parameters.AddWithValue("@AuthorID", author.AuthorId);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
