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

        public Task<int> CreateCityAsync(City city)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DoesExist(string countryName, string stateName, string cityName)
        {
            string sql = "SELECT ct.CityID, ct.CountryID, ct.CityName" +
                " FROM Countries as co, Cities as ct, States as st" +
                " WHERE co.CountryID = ct.CountryID" +
                " and st.CountryID = co.CountryID" +
                " and ct.CityName = @cityName" +
                " and st.StateName = @stateName" +
                " and co.CountryName = @countryName";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("countryName", countryName));
                command.Parameters.Add(new SqlParameter("stateName", stateName));
                command.Parameters.Add(new SqlParameter("cityName", cityName));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return false;
                }
                return true;
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

        public async Task<int> UpdateCityAsync(int id, City city)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Cities " +
                    $"SET CityName = {city.CityName}, CountryID = {city.CountryID}" +
                    $"WHERE CityID = {id}";
                var rows = await connection.ExecuteAsync(query);
                connection.Close();
                return rows;
            }
        }
    }
}
