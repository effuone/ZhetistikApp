using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DapperContext _context;
        public LocationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateLocationAsync(Location location)
        {
            string sql = @"INSERT INTO Locations (CountryID, CityID)
            VALUES (@countryId, @cityId) SET @LocationID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@countryId", location.CountryID));
                command.Parameters.Add(new SqlParameter("@cityId", location.CityID));

                var outputParam = new SqlParameter
                {
                    ParameterName = "@LocationID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return (int)outputParam.Value;
            }
        }

        public async Task DeleteLocationAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Locations WHERE LocationID = @id";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                int rows = await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<Location> GetLocationAsync(int locationId)
        {
            var query = $"SELECT* FROM Locations WHERE LocationID = @id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", locationId));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new Location(
                    (int)reader[0],
                    (int)reader[1],
                    (int)reader[2]
                );
            }
        }

        public async Task<Location> GetLocationAsync(string cityName)
        {
            var query = $"SELECT* FROM Locations WHERE CityID = " +
                $"(SELECT ct.CityID FROM Cities AS ct WHERE ct.CityName = @cityName)";
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
                return new Location(
                    (int)reader[0],
                    (int)reader[1],
                    (int)reader[2]
                );
            }
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "SELECT* FROM Locations";
                var locations = await connection.QueryAsync<Location>(sql);
                return locations;
            }
        }

        public async Task UpdateLocationAsync(int id, Location location)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Countries " +
                    $"SET CountryID = {location.CountryID}, " +
                    $"CityID = {location.CityID} " +
                    $"WHERE LocationID = {id}";
                var rows = await connection.ExecuteAsync(query);
            }
        }
    }
}
