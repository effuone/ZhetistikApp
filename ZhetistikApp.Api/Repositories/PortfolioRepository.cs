using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly DapperContext _context;

        public PortfolioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePortfolioAsync(Portfolio portfolio)
        {
            string sql = "INSERT INTO Portfolios " +
                "(CandidateID, " +
                "LocationID, " +
                "AchievementID, " +
                "IsPublished, " +
                "CreatedDate)" +
                "VALUES (@candidateID, @locationID, @achievementID," +
                "@isPublished, @createdDate) SET @PortfolioID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@candidateID", portfolio.CandidateID));
                command.Parameters.Add(new SqlParameter("@locationID", portfolio.LocationID));
                command.Parameters.Add(new SqlParameter("@achievementID", portfolio.AchievementID));
                command.Parameters.Add(new SqlParameter("@isPublished", portfolio.IsPublished));
                command.Parameters.Add(new SqlParameter("@createdDate", portfolio.CreatedDate));

                var outputParam = new SqlParameter
                {
                    ParameterName = "@PortfolioID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                return (int)outputParam.Value;
            }
        }

        public async Task DeletePortfolioAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Portfolios WHERE PortfolioID = @id";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                int rows = await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<Portfolio> GetPortfolioAsync(int id)
        {
            var query = $"SELECT* FROM Portfolios WHERE PortfolioID = {id}";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var portfolios = await connection.QueryAsync<Portfolio>(query);
                return portfolios.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosAsync()
        {
            var query = "SELECT * FROM Portfolios";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<Portfolio>(query);
                return candidates;
            }
        }

        public async Task UpdatePortfolioAsync(int id, Portfolio portfolio)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Candidates " +
                    "SET CandidateID = @candidateId, " +
                    "LocationID = @locationId," +
                    "AchievementID = @achievementId, " +
                    "IsPublished = @isPublished, " +
                    "CreatedDate = @createdDate, " +
                    " WHERE CandidateID = @id", (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@candidateId", portfolio.CandidateID));
                command.Parameters.Add(new SqlParameter("@locationId", portfolio.LocationID));
                command.Parameters.Add(new SqlParameter("@achievementId", portfolio.AchievementID));
                command.Parameters.Add(new SqlParameter("@isPublished", portfolio.IsPublished));
                command.Parameters.Add(new SqlParameter("@createdDate", portfolio.CreatedDate));

                int rows = await command.ExecuteNonQueryAsync();
                connection.Close();
                //if (rows <= 0)
                //{
                //    return false;
                //}
                //return true;
            }
        }
    }
}
