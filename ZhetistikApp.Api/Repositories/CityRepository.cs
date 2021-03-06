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
            string sql = @"INSERT INTO Cities (CountryID, CityName)
            VALUES (@countryId, @cityName) SET @CityID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@countryId", city.CountryID));
                command.Parameters.Add(new SqlParameter("@cityName", city.CityName));

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

        public async Task DeleteCityAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Countries WHERE CountryID = @id";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                int rows = await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }


        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "SELECT* FROM Cities";
                var cities = await connection.QueryAsync<City>(sql);
                return cities;
            }
        }

        public async Task<City> GetCityAsync(int cityId)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = $"SELECT* FROM Cities WHERE CityID = @id";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", cityId));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new City(
                    (int)reader[0],
                    (int)reader[1],
                    (string)reader[2]
                );
            }
        }

        public async Task<City> GetCityAsync(string cityName)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = $"SELECT* FROM Cities WHERE CityName = @cityName";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@cityName", cityName));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new City(
                    (int)reader[0],
                    (int)reader[1],
                    (string)reader[2]
                );
            }
        }

        public async Task UpdateCityAsync(int id, City city)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Cities " +
                    $"SET CityName = '{city.CityName}', CountryID = {city.CountryID}" +
                    $"WHERE CityID = {id}";
                var rows = await connection.ExecuteAsync(query);
            }
        }
    }
}
