using Dapper;
using Dapper.Contrib.Extensions;
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
            string sql = "INSERT INTO Achievements (AchievementTypeID, AchievementDescription, AchievementDate, Score, Image, URL) " +
                "VALUES(@portfolioId, @typeId, @description, @achievementDate, @score, @image, @url) SET @id = SCOPE_IDENTITY(); ";
            var p = new DynamicParameters();
            p.Add("@typeId", achievement.AchievementTypeID);
            p.Add("description", achievement.Description);
            p.Add("achievementDate", achievement.AchievementDate);
            p.Add("score", achievement.Score);
            p.Add("image", achievement.Image);
            p.Add("url", achievement.URL);
            p.Add("id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _context.CreateConnection())
            {
                var records = await connection.QueryAsync(sql, p);
                achievement.AchievementID = p.Get<int>("@id");
                return achievement.AchievementID;
            }
        }

        public async Task<bool> DeleteAchievementAsync(int id)
        {
            using(var connection = _context.CreateConnection())
            {
                connection.Open();
                var achievement = await connection.GetAsync<Achievement>(id);
                var result = await connection.DeleteAsync<Achievement>(achievement);
                return result;
            }
        }

        public async Task<Achievement> GetAchievementByIdAsync(int id)
        {
            var query = $"SELECT* FROM Achievements WHERE AchievementID = {id}";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var achievement = await connection.QueryFirstAsync<Achievement>(query);
                return achievement;
            }
        }

        public async Task<IEnumerable<Achievement>> GetAllAchievementsAsync()
        {
            var query = $"SELECT* FROM Achievements";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var achievements = await connection.QueryAsync<Achievement>(query);
                return achievements;
            }
        }

        public async Task<bool> UpdateAchievementAsync(int id, Achievement achievement)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                achievement.AchievementID = id;
                var result = await connection.UpdateAsync<Achievement>(achievement);
                return result;
            }
        }
    }
}
