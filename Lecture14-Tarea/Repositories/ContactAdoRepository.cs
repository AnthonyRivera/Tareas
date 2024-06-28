using Lecture14_Tarea.Contracts;
using Lecture14_Tarea.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Lecture14_Tarea.Repositories
{
    public class ContactAdoRepository : IContactRepository
    {
        private readonly string _connectionString;
        public ContactAdoRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ContactesDbCnn"].ConnectionString;
        }

        public int Add(Contact contact)
        {
            int newContactId = 0;
            string query = "INSERT INTO Contact (Name, LastName, Email) OUTPUT INSERTED.ContactID VALUES (@Name, @LastName, @Email)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Email", contact.Email);

                connection.Open();
                newContactId = (int)command.ExecuteScalar();
            }

            return newContactId;

        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Contact WHERE ContactID = @ContactID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactID", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close() ;

            }
        }

        public Contact GetById(int id)
        {
            Contact contact = null;
            string query = "SELECT * FROM Contact WHERE ContactID = @ContactID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    contact = new Contact
                    {
                        ContactId = Convert.ToInt32(reader["ContactID"]),
                        Name = reader["Name"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
                reader.Close();
            }

            return contact;

        }

        public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            string query = "SELECT * FROM Contact";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        ContactId = Convert.ToInt32(reader["ContactID"]),
                        Name = reader["Name"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                    contacts.Add(contact);
                }
                reader.Close();
            }

            return contacts;

        }

        public void Update(Contact contact)
        {
            string query = "UPDATE Contact SET Name = @Name, LastName = @LastName, Email = @Email WHERE ContactID = @ContactID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@ContactID", contact.ContactId);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
