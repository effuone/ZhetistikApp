using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DapperContext _context;

        public CountryRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCountryAsync(Country country)
        {
            string sql = @"INSERT INTO Countries (CountryName)
            VALUES (@countryName) SET @CountryID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@countryName", country.CountryName));

                var outputParam = new SqlParameter
                {
                    ParameterName = "@CountryID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return (int)outputParam.Value;
            }
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Countries WHERE CountryID = @id";
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

        public async Task<Country> GetCountryAsync(int countryId)
        {
            var query = $"SELECT* FROM Countries WHERE CityID = @id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", countryId));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                connection.Close();
                return new Country(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<Country> GetCountryAsync(string countryName)
        {
            var query = $"SELECT* FROM Countries WHERE CountryName = @countryName";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@countryName", countryName));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                connection.Close();
                return new Country(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<int> UpdateCountryAsync(int id, Country country)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Countries " +
                    $"SET CountryName = {country.CountryName}, " +
                    $"WHERE CountryID = {id}";
                var rows = await connection.ExecuteAsync(query);
                connection.Close();
                return rows;
            }
        }
    }
}
