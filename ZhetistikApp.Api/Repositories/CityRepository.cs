using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DapperContext _context;
        public CityRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCityAsync(City city)
        {
            string sql = @"INSERT INTO Cities (CountryID, CityName, PostalCode)
            VALUES (@countryID, @cityName, @postalCode) SET @CityID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@countryName", city.CountryID));
                command.Parameters.Add(new SqlParameter("@cityName", city.CityName));
                command.Parameters.Add(new SqlParameter("@postalCode", city.PostalCode));
                var outputParam = new SqlParameter
                {
                    ParameterName = "@CityID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return (int)outputParam.Value;
            }
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Cities WHERE CityID = @id";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                int rows = await command.ExecuteNonQueryAsync();
                connection.Close();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<City> GetCityAsync(int cityId)
        {
            var query = $"SELECT* FROM Cities WHERE CityID = @id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", cityId));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                connection.Close();
                return new City(
                    (int)reader[0],
                    (int)reader[1],
                    (string)reader[2],
                    (string)reader[3]
                );
            }
        }

        public async Task<City> GetCityAsync(string cityName)
        {
            var query = $"SELECT* FROM Cities WHERE CityName = @cityName";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@cityName", cityName));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                connection.Close();
                return new City(
                    (int)reader[0],
                    (int)reader[1],
                    (string)reader[2],
                    (string)reader[3]
                );
            }
        }

        public async Task<int> UpdateCityAsync(int id, City city)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Cities " +
                    $"SET CountryID = {city.CountryID}, " +
                    $"CityName = '{city.CityName}'," +
                    $"PostalCode = '{city.CityName}' " +
                    $"WHERE CityID = {id}";
                var rows = await connection.ExecuteAsync(query);
                connection.Close();
                return rows;
            }
        }
    }
}
