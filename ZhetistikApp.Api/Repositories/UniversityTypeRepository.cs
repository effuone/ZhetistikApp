using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class UniversityTypeRepository : IUniversityTypeRepository
    {
        private readonly DapperContext _context;

        public UniversityTypeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUniversityTypeAsync(string universityTypeName)
        {
            string sql = @"INSERT INTO UniversityTypes (UniversityTypeName)
            VALUES (@item) SET @UniversityTypeID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@item", universityTypeName));

                var outputParam = new SqlParameter
                {
                    ParameterName = "@UniversityTypeID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return (int)outputParam.Value;
            }
        }

        public async Task DeleteUniversityTypeAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string deleteTypes = "DELETE FROM UniversityTypes WHERE UniversityTypeID = @id";
                string deleteAchievements = "DELETE FROM Universities WHERE UniversityTypeID = @id";
                connection.Open();
                var command = new SqlCommand(deleteTypes, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                await command.ExecuteNonQueryAsync();
                command = new SqlCommand(deleteAchievements, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<UniversityType> GetUniversityTypeAsync(int universityTypeId)
        {
            var query = $"SELECT* FROM UniversityTypes WHERE UniversityTypeID = @id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", universityTypeId));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new UniversityType(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<UniversityType> GetUniversityTypeAsync(string universityTypeName)
        {
            var query = $"SELECT* FROM UniversityTypes WHERE UniversityTypeName = @name";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@name", universityTypeName));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new UniversityType(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<IEnumerable<UniversityType>> GetUniversityTypesAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "SELECT* FROM UniversityTypes";
                var universities = await connection.QueryAsync<UniversityType>(sql);
                return universities;
            }
        }

        public async Task UpdateUniversityTypeAsync(int id, string universityTypeName)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var updateTypes = $"UPDATE UniversityTypes SET UniversityTypeName = '{universityTypeName}' WHERE UniversityTypeID = {id}";
                await connection.ExecuteAsync(updateTypes);
            }
        }
    }
}
