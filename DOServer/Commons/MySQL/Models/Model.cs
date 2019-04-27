using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;

namespace Darkorbit.Commons.MySQL.Models
{
    public class Model<T>
    {
        protected string primaryKey = "id";
        protected string table = String.Empty;

        public Model()
        {
            if (table.Equals(String.Empty))
                table = GetType().Name.ToLower();
        }

        public List<T> ReadAll()
        {
            var connection = DatabaseManager.Instance.Connection;
            return connection.Query<T>($"SELECT * FROM {table};").ToList();
        }
        public List<T> ReadAllWhere(int id)
        {
            var connection = DatabaseManager.Instance.Connection;
            return connection.Query<T>($"SELECT * FROM {table} where {primaryKey} = {id};").ToList();
        }
        public T First()
        {
            var connection = DatabaseManager.Instance.Connection;
            return connection.Query<T>($"SELECT * FROM {table};").First();
        }
        
        public T Find(int id)
        {
            var connection = DatabaseManager.Instance.Connection;
            return connection.Query<T>($"SELECT * FROM {table} where {primaryKey} = {id};").First();
        }

        public void Update()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.CanRead && prop.CanWrite)
                .Where(prop => prop.GetGetMethod(true).IsPublic)
                .Where(prop => prop.GetSetMethod(true).IsPublic);
            var connection = DatabaseManager.Instance.Connection;

            Console.WriteLine(properties);


            //connection.Query<T>($"UPDATE {table} SET {}")

        }

    }
}
