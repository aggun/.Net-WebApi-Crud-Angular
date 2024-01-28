using CaseWork.DataAcces.Interface;
using CaseWork.DataAcces.Sql;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CaseWork.DataAcces.Service
{
    public class BaseService<T> : IService<T> where T : class
    {
        private readonly string _connectionString = "conenciton string";

        public void Add(T entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string columns = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => p.Name));
                    string values = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"@{p.Name}"));
                    string query = $"INSERT INTO {typeof(T).Name}s ({columns}) VALUES ({values})";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var property in typeof(T).GetProperties().Where(p => p.Name != "Id"))
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity) ?? DBNull.Value);
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM {typeof(T).Name}s WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {typeof(T).Name}s";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                yield return MapToEntity(reader);
                            }
                        }
                    }
                }
            }
            finally
            {

            }
        }

        public T GetById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapToEntity(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return null;
        }

        public void Update(T entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string setClause = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"{p.Name} = @{p.Name}"));
                    string query = $"UPDATE {typeof(T).Name}s SET {setClause} WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", typeof(T).GetProperty("Id").GetValue(entity));

                        foreach (var property in typeof(T).GetProperties().Where(p => p.Name != "Id"))
                        {
                            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity));
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> where)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var tableName = typeof(T).Name; // Assuming T's type name is the same as the table name

                var whereClause = ExpressionToSqlTranslator.Translate(where); // You need to implement a translator for Expression to SQL

                string sql = $"SELECT * FROM {tableName}s WHERE {whereClause}";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<T> result = new List<T>();
                        while (reader.Read())
                        {
                            // Map data from SqlDataReader to your entity type T
                            T item = MapToEntity(reader);
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }


        private T MapToEntity(SqlDataReader reader)
        {
            try
            {
                var entity = (T)Activator.CreateInstance(typeof(T));

                foreach (var property in typeof(T).GetProperties())
                {
                    var readerValue = reader[property.Name];
                    if (readerValue != DBNull.Value)
                    {
                        var convertedValue = Convert.ChangeType(readerValue, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                        property.SetValue(entity, convertedValue);
                    }
                    else
                    {
                        property.SetValue(entity, null);
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
