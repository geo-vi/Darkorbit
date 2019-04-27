using System;
using DotNetEnv;
using MySql.Data.MySqlClient;

namespace Darkorbit.Commons.MySQL
{
    public class DatabaseManager : Singleton<DatabaseManager>
    {
        public MySqlConnection Connection { get; set; }
        
        public DatabaseManager()
        {
            Env.Load();
            var host = Env.GetString("DB_HOST", "localhost");
            var password = Env.GetString("DB_PASSWORD", String.Empty);
            var username = Env.GetString("DB_USERNAME", "root");
            var database = Env.GetString("DB_DATABASE", "seafight");

            Connection = new MySqlConnection($"Server={host};Database={database};Uid={username};Pwd={password};");
        }
        

    }
}
