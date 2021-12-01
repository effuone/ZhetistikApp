using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly DapperContext _context;

        public AchievementRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAchievementAsync(Achievement achievement)
        {
            string sql = @"INSERT INTO Achievements (CountryID, CityID)
            VALUES (@countryId, @cityId) SET @LocationID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                //command.Parameters.Add(new SqlParameter("@countryId", achievement.CountryID));
                //command.Parameters.Add(new SqlParameter("@cityId", achievement.CityID));

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

        public Task DeleteAchievementAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Achievement> GetAchievementByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Achievement>> GetAllAchievementsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAchievementAsync(int id, Achievement achievement)
        {
            throw new NotImplementedException();
        }
    }
}
