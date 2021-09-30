using MySql.Data.MySqlClient;

namespace API.AluraFlix.Data
{
    public static class ApplicationContext
    {

        public static MySqlConnection conn() {
            string conn_string = "server=127.0.0.1; port=3306; user=root; password=; database=aluraflix; SslMode=none";
            MySqlConnection conn = new MySqlConnection(conn_string);
            return conn;
        }
    }
}
