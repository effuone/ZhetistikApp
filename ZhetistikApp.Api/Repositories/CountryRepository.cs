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

        public async Task DeleteCountryAsync(int id)
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

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "SELECT* FROM Countries";
                var country = await connection.QueryAsync<Country>(sql);
                return country;
            }
        }


        public async Task<Country> GetCountryAsync(int countryId)
        {
            var query = $"SELECT* FROM Countries WHERE CountryID = @id";
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
                return new Country(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<Country> GetCountryByCityAsync(string cityName)
        {
            var query = "SELECT co.CountryID, co.CountryName" +
                " FROM Countries as co, Cities as ct " +
                "WHERE co.CountryID = ct.CountryID" +
                " and ct.CityName = @cityName";
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
                return new Country(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<Country> GetCountryByStateAsync(string stateName)
        {
            var query = "SELECT co.CountryID, co.CountryName" +
                " FROM Countries as co, States as st " +
                "WHERE co.CountryID = st.CountryID" +
                " and st.StateName = @stateName";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@stateName", stateName));
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

        public async Task UpdateCountryAsync(int id, Country country)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Countries " +
                    $"SET CountryName = '{country.CountryName}' " +
                    $"WHERE CountryID = {id}";
                var rows = await connection.ExecuteAsync(query);
            }
        }
    }
}
