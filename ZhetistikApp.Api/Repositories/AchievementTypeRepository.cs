using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class AchievementTypeRepository : IAchievementTypeRepository
    {
        private readonly DapperContext _context;

        public AchievementTypeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAchievementTypeAsync(string achievementTypeName)
        {
            string sql = @"INSERT INTO AchievementTypes (AchievementTypeName)
            VALUES (@item) SET @AchievementTypeID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@item", achievementTypeName));

                var outputParam = new SqlParameter
                {
                    ParameterName = "@AchievementTypeID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return (int)outputParam.Value;
            }
        }

        public async Task DeleteAchievementTypeAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string deleteTypes = "DELETE FROM AchievementTypes WHERE AchievementTypeID = @id";
                string deleteAchievements = "DELETE FROM Achievements WHERE AchievementTypeID = @id";
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

        public async Task<AchievementType> GetAchievementTypeAsync(int achievementTypeId)
        {
            var query = $"SELECT* FROM AchievementTypes WHERE AchievementTypeID = @id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", achievementTypeId));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new AchievementType(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<AchievementType> GetAchievementTypeAsync(string achievementTypeName)
        {
            var query = $"SELECT* FROM AchievementTypes WHERE AchievementTypeName = @name";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@name", achievementTypeName));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new AchievementType(
                    (int)reader[0],
                    (string)reader[1]
                );
            }
        }

        public async Task<IEnumerable<AchievementType>> GetAchievementTypesAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "SELECT* FROM AchievementTypes";
                var types = await connection.QueryAsync<AchievementType>(sql);
                return types;
            }
        }

        public async Task UpdateAchievementTypeAsync(int id, string achievementTypeName)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var updateTypes = $"UPDATE AchievementTypes SET AchievementTypeName = '{achievementTypeName}' WHERE AchievementTypeID = {id}";
                await connection.ExecuteAsync(updateTypes);
            }
        }
    }
}
