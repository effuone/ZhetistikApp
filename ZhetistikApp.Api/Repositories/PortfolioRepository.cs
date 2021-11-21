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
                "PlacementID, " +
                "AchievementID, " +
                "IsPublished, " +
                "CreatedDate)" +
                "VALUES (@candidateID, @placementID, @achievementID," +
                "@isPublished, @createdDate) SET @PortfolioID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@candidateID", portfolio.CandidateID));
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

        public async Task<Portfolio> GetPortfolioByIdAsync(int id)
        {
            var query = $"SELECT* FROM Portfolios WHERE PortfolioID = {id}";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var portfolios = await connection.QueryAsync<Portfolio>(query);
                return portfolios.FirstOrDefault();
            }
        }

        public async Task<Portfolio> GetPortfolioByPersonAsync(string firstName, string lastName)
        {
            var query = $"SELECT * FROM Portfolios WHERE FirstName = '{firstName}' and LastName = '{lastName}' ";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<Portfolio>(query);
                return candidates.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosByLocationAsync(string countryName, string cityName)
        {
            var query = "SELECT por.PortofolioID, por.CandidateID, por.LocationID, por.AchievementID, por.IsPublished, por.CreatedDate " +
                "FROM Portfolios as por, Locations as plac " +
                "WHERE por.PlacementID = plac.PlacementID " +
                "AND plac.CityID = (SELECT c.CityID FROM Cities as c WHERE CityName = @cityName and CountryID = " +
                "(SELECT co.CountryID FROM Countries as co WHERE co.CountryName = @countryName)) ";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<Portfolio>(query);
                return candidates;
            }
        }

        public async Task<IEnumerable<Portfolio>> GetPublishedPortfolios(bool isPublished)
        {
            string query = $"SELECT * FROM Portfolios AS P WHERE P.IsPublished = {isPublished}";
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
