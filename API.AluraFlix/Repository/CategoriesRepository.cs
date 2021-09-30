using Api.Challenge.Alura.Models;
using API.AluraFlix.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace API.AluraFlix.Repository
{
    public class CategoriesRepository
    {

        public static bool InsertRP(Category category)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = @"INSERT INTO categories 
                VALUES(0, @titulo, @color)";
            query.Parameters.AddWithValue("@titulo", category.Titulo);
            query.Parameters.AddWithValue("@color", category.Color);

            conn.Open();

            try
            {
                query.ExecuteReader();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public static List<Category> ListRP()
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = " SELECT * FROM categories ";

            conn.Open();
            List<Category> categories = new List<Category>();
            try
            {
                using (MySqlDataReader rd = query.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Category category = new(rd);
                        categories.Add(category);
                    }
                    return categories;
                }
            }
            catch
            {
                throw;
            }
        }

        public static Category GetOneRP(int id)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM categories WHERE Id = @id";
            query.Parameters.AddWithValue("@id", id);
            conn.Open();
            try
            {
                using (MySqlDataReader rd = query.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        return new Category(rd);
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        public static bool UpdateRP(Category category)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = @"UPDATE categories 
                SET Titulo = @Titulo, Color = @Color
                WHERE Id = @Id";

            query.Parameters.AddWithValue("@Titulo", category.Titulo);
            query.Parameters.AddWithValue("@Color", category.Color);
            query.Parameters.AddWithValue("@Id", category.Id);

            conn.Open();
            try
            {
                using (query.ExecuteReader())
                {
                    return true;
                }

            }
            catch
            {
                throw;
            }
        }

        public static bool DeleteRP(int id)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "DELETE FROM categories WHERE Id = @Id ";
            query.Parameters.AddWithValue("@Id", id);
            conn.Open();
            try
            {
                using (query.ExecuteReader())
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }

        }
    }
}
