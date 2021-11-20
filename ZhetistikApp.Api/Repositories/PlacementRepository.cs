using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class PlacementRepository : IPlacementRepository
    {
        private readonly DapperContext _context;

        public PlacementRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCityAsync(City city)
        {
            string sql = @"INSERT INTO Cities (CountryID, CityName, PostalCode)
            VALUES (@countryId, @cityName, @postalCode) SET @CityID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@countryID", city.CountryID));
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

        public async Task<int> CreatePlacementAsync(Placement placement)
        {
            string sql = @"INSERT INTO Placements (CityID)
            VALUES (@cityId) SET @PlacementID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@cityId", placement.CityID));

                var outputParam = new SqlParameter
                {
                    ParameterName = "@PlacementID",
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

        public async Task<bool> DeletePlacementAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Placements WHERE PlacementID = @id";
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

        public async Task<Placement> GetPlacementAsync(int placementId)
        {
            var query = $"SELECT* FROM Placements WHERE PlacementID = @id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", placementId));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                connection.Close();
                return new Placement(
                    (int)reader[0],
                    (int)reader[1]
                );
            }
        }

        public async Task<Placement> GetPlacementAsync(string cityName)
        {
            var query = "SELECT pl.PlacementID, pl.CityID" +
                " FROM Placements as pl, Cities as ct" +
                " WHERE pl.CityID = ct.CityID and ct.CityName = @cityName";
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
                return new Placement(
                    (int)reader[0],
                    (int)reader[1]
                );
            }
        }

        public async Task<IEnumerable<Placement>> GetPlacementsAsync()
        {
            var query = $"SELECT* FROM Placements";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var placements = await connection.QueryAsync<Placement>(query);
                connection.Close();
                return placements;
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

        public async Task<int> UpdatePlacementAsync(int id, Placement placement)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Placements " +
                    $"SET CityID = {placement.CityID}, " +
                    $"WHERE PlacementID = {id}";
                var rows = await connection.ExecuteAsync(query);
                connection.Close();
                return rows;
            }
        }
    }
}
