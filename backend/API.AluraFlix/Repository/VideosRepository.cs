using Api.Challenge.Alura.Models;
using API.AluraFlix.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace API.AluraFlix.Repository
{
    public class VideosRepository
    {

        public static bool InsertRP(Video video)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = @"INSERT INTO videos 
                VALUES(@id, @titulo,@categoriaId, @descricao,@url)";
            query.Parameters.AddWithValue("@id", video.Id);
            query.Parameters.AddWithValue("@titulo", video.Titulo);
            query.Parameters.AddWithValue("@categoriaId", video.CategoriaId);
            query.Parameters.AddWithValue("@descricao", video.Descricao);
            query.Parameters.AddWithValue("@url", video.Url);

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

        public static List<Video> ListRP(string filter, int page)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = " SELECT * FROM videos ";

            if (filter != null)
            {
                query.CommandText += " WHERE Titulo = @filter ";
                query.Parameters.AddWithValue("@filter", filter);
            }

            if (page > 0 ? true : false) {
                int offset;
                if (page == 1)
                     offset = 0;
                else 
                    offset = (page-1) * 5;

                query.CommandText += " LIMIT @limit OFFSET @offset ";
                query.Parameters.AddWithValue("@limit", 5);
                query.Parameters.AddWithValue("@offset", offset);
            }

            conn.Open();
            List<Video> videos = new List<Video>();
            try
            {
                using (MySqlDataReader rd = query.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Video video = new(rd);
                        videos.Add(video);  
                    }
                    return videos;
                }
            }
            catch
            {
                throw;
            }
        }

        public static List<Video> ListPaginationRP(int page)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = " SELECT * FROM videos ";
      
            conn.Open();
            List<Video> videos = new List<Video>();
            try
            {
                using (MySqlDataReader rd = query.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Video video = new(rd);
                        videos.Add(video);
                    }
                    return videos;
                }
            }
            catch
            {
                throw;
            }
        }

        public static List<Video> ListByCategoryRP(int id)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM videos WHERE CategoriaId = @id";
            query.Parameters.AddWithValue("@id", id);
            conn.Open();
            List<Video> videos = new List<Video>();
            try
            {
                using (MySqlDataReader rd = query.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Video video = new(rd);
                        videos.Add(video);
                    }
                    return videos;
                }
            }
            catch
            {
                throw;
            }
        }

        public static Video GetOneRP(int id)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM videos WHERE Id = @id";
            query.Parameters.AddWithValue("@id", id);
            conn.Open();
            try
            {
                using (MySqlDataReader rd = query.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        return new Video(rd);
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        public static bool UpdateRP(Video video)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = @"UPDATE videos 
                SET Titulo = @Titulo, CategoriaId = @CategoriaId, Descricao = @Descricao, Url = @Url 
                WHERE Id = @Id";
            query.Parameters.AddWithValue("@Titulo", video.Titulo);
            query.Parameters.AddWithValue("@CategoriaId", video.CategoriaId);
            query.Parameters.AddWithValue("@Descricao", video.Descricao);
            query.Parameters.AddWithValue("@Url", video.Url);
            query.Parameters.AddWithValue("@Id", video.Id);

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
                return false;
            }
        }

        public static bool DeleteRP(int id)
        {
            MySqlConnection conn = ApplicationContext.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "DELETE FROM videos WHERE Id = @Id";
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
                return false;
            }

        }
    }
}
