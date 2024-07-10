using Books.Domain.Models;
using Books.Web.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Books.Web.Repositories
{
    public class BookAdoRepository : IBookRepository
    {
        private readonly string _connectionString;
        public BookAdoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int Add(Book book)
        {
            int newBookId = 0;
            string query = "INSERT INTO Book (Book, Author, ReleaseYear) OUTPUT INSERTED.BookID VALUES (@Book, @Author, @ReleaseYear)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Book", book.BookName);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@ReleaseYear", book.ReleaseYear);

                connection.Open();
                newBookId = (int)command.ExecuteScalar();
            }

            return newBookId;

        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Book WHERE BookID = @BookID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public Book GetById(int id)
        {
            Book book = null;
            string query = "SELECT * FROM Book WHERE BookID = @BookID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    book = new Book
                    {
                        BookId = Convert.ToInt32(reader["BookID"]),
                        BookName = reader["Book"].ToString(),
                        Author = reader["Author"].ToString(),
                        ReleaseYear = reader["ReleaseYear"].ToString()
                    };
                }
                reader.Close();
            }

            return book;

        }

        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            string query = "SELECT * FROM Book";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book
                    {
                        BookId = Convert.ToInt32(reader["BookID"]),
                        BookName = reader["Book"].ToString(),
                        Author = reader["Author"].ToString(),
                        ReleaseYear = reader["ReleaseYear"].ToString()
                    };
                    books.Add(book);
                }
                reader.Close();
            }

            return books;

        }

        public void Update(Book book)
        {
            string query = "UPDATE Book SET Book = @Book, Author = @Author, ReleaseYear = @ReleaseYear WHERE BookID = @BookID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Book", book.BookName);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@ReleaseYear", book.ReleaseYear);
                command.Parameters.AddWithValue("@BookID", book.BookId);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
