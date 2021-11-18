using Dapper;
using Dapper.Contrib.Extensions;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DapperContext _context;

        public CandidateRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCandidate(Candidate candidate)
        {
            var query = "SET IDENTITY_INSERT Candidates ON";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                await connection.QueryAsync(query);
                var id = await connection.InsertAsync(candidate);
                return id;
            }
        }

        public async Task DeleteCandidateAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var isSuccess = await connection.DeleteAsync(new Candidate { CandidateID = id });
                //if(!isSuccess)
                //{
                //    _logger.LogError($"Delete operation of candidate {id} is failed");
                //}
            }
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            var query = $"SELECT* FROM Candidates";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<Candidate>(query);
                return candidates;
            }
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            var query = $"SELECT* FROM Candidates WHERE CandidateID = {id}";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<Candidate>(query);
                return candidates.FirstOrDefault();
            }
        }

        public async Task<Candidate> GetCandidateByName(string firstName, string lastName)
        {
            var query = $"SELECT * FROM Candidates WHERE FirstName = '{firstName}' and LastName = '{lastName}' ";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<Candidate>(query);
                return candidates.FirstOrDefault();
            }
        }

        public async Task<Candidate> GetCandidateByUserIdAsync(int userId)
        {
            var query = $"SELECT* FROM Candidates WHERE UserID = {userId}";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var candidates = await connection.QueryAsync<Candidate>(query);
                return candidates.FirstOrDefault();
            }
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.UpdateAsync(new Candidate
                {
                    UserID = candidate.UserID,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Birthday = candidate.Birthday,
                    Email = candidate.Email,
                    PhoneNumber = candidate.PhoneNumber
                });
                //if (!result)
                //{
                //    _logger.LogError($"UPDATE operation of candidate {candidate.CandidateID} is failed");
                //}
            }
        }
    }
}
