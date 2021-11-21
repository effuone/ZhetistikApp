using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;
using ZhetistikApp.Api.ViewModels;

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
            string sql = @"INSERT INTO Locations (CountryID, StateID, CityID)
            VALUES (@countryId, @stateId, @cityId) SET @LocationID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@countryId", location.CountryID));
                command.Parameters.Add(new SqlParameter("@stateId", location.StateID));
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
        public async Task<bool> DeleteLocationAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Locations WHERE LocationID = @id";
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
                connection.Close();
                return new Location(
                    (int)reader[0],
                    (int)reader[1],
                    (int)reader[2],
                    (int)reader[3]
                );
            }
        }

        public async Task<Location> GetLocationAsync(string cityName)
        {
            var query = "SELECT loc.LocationID, loc.CountryID, loc.StateID, loc.CityID" +
                " FROM Locations as loc, Countries, Cities, States" +
                " WHERE loc.CountryID = Countries.CountryID" +
                " and loc.CityID = Cities.CityID " +
                "and loc.StateID = States.StateID" +
                "and Cities.CityName = @cityName";
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
                return new Location(
                    (int)reader[0],
                    (int)reader[1],
                    (int)reader[2],
                    (int)reader[3]
                );
            }
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            var queryDefault = $"SELECT* FROM Locations";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var Locations = await connection.QueryAsync<Location>(queryDefault);
                connection.Close();
                return Locations;
            }
        }

        public async Task<LocationViewModel> GetLocationViewModelAsync(int locationId)
        {
            var query = "SELECT loc.LocationID, co.CountryName, st.StateName, ct.CityName" +
                " FROM Locations AS loc, Countries AS co, Cities AS ct, States AS st" +
                " WHERE loc.CountryID = co.CountryID" +
                " and loc.CityID = ct.CityID" +
                " and loc.StateID = st.StateID" +
                " and loc.LocationID = @id";
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
                connection.Close();
                return new LocationViewModel(
                    (int)reader[0],
                    (string)reader[1],
                    (string)reader[2],
                    (string)reader[3]
                );
            }
        }

        public async Task<IEnumerable<LocationViewModel>> GetLocationViewModelByCityAsync(string cityName)
        {
            var query = "SELECT loc.LocationID, co.CountryName, st.StateName, ct.CityName" +
                " FROM Locations AS loc, Countries AS co, Cities AS ct, States AS st" +
                " WHERE loc.CountryID = co.CountryID" +
                " and loc.CityID = ct.CityID" +
                " and loc.StateID = st.StateID" +
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
                var list = new List<LocationViewModel>();
                while (await reader.ReadAsync())
                {
                    list.Add(new LocationViewModel(
                    (int)reader[0],
                    (string)reader[1],
                    (string)reader[2],
                    (string)reader[3]
                ));
                }
                connection.Close();
                return list;

            }           
        }

        public async Task<IEnumerable<LocationViewModel>> GetLocationViewModelsAsync()
        {
            var query = "SELECT loc.LocationID, co.CountryName, st.StateName, ct.CityName" +
                " FROM Locations AS loc, Countries AS co, Cities AS ct, States AS st" +
                " WHERE loc.CountryID = co.CountryID" +
                " and loc.CityID = ct.CityID" +
                " and loc.StateID = st.StateID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<LocationViewModel>(query);
                return candidates;
            }
        }
        
        public async Task<int> UpdateLocationAsync(int id, Location location)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query =
                    $"UPDATE Locations " +
                    $"SET CountryID = {location.CountryID}, State = {location.StateID}, CityID = {location.CityID}" +
                    $"WHERE LocationID = {id}";
                var rows = await connection.ExecuteAsync(query);
                connection.Close();
                return rows;
            }
        }
    }
}
