using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;
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
            string sql = @"INSERT INTO Candidates (UserID, FirstName, LastName, Birthday, Email, PhoneNumber)
      VALUES (@userID, @firstName, @lastName, @birthday, @email, @phoneNumber) SET @CandidateID = SCOPE_IDENTITY();";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@userID", candidate.UserID));
                command.Parameters.Add(new SqlParameter("@firstName", candidate.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", candidate.LastName));
                command.Parameters.Add(new SqlParameter("@birthday", candidate.Birthday));
                command.Parameters.Add(new SqlParameter("@email", candidate.Email));
                command.Parameters.Add(new SqlParameter("@phoneNumber", candidate.PhoneNumber));

                var outputParam = new SqlParameter
                {
                    ParameterName = "@CandidateID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                return (int)outputParam.Value;
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
            var query = $"SELECT* FROM Candidates WHERE CandidateID = @id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new Candidate(
                    (int)reader[0],
                    (int)reader[1],
                    (string)reader[2],
                    (string)reader[3],
                    (DateTime)reader[4],
                    (string)reader[5],
                    (string)reader[6]
                );
            }
        }

        public async Task<Candidate> GetCandidateByName(string firstName, string lastName)
        {
            var query = $"SELECT * FROM Candidates WHERE FirstName = @firstName and LastName = @lastName";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@firstName", firstName));
                command.Parameters.Add(new SqlParameter("@lastName", lastName));
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new Candidate(
                    (int)reader[0],
                    (int)reader[1],
                    (string)reader[2],
                    (string)reader[3],
                    (DateTime)reader[4],
                    (string)reader[5],
                    (string)reader[6]
                );
            }
        }

        public async Task UpdateCandidateAsync(int id, Candidate candidate)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query = $"UPDATE Candidates SET UserID = {candidate.UserID}, " +
                    $"FirstName = '{candidate.FirstName}', LastName = '{candidate.LastName}', " +
                    $"Birthday = '{candidate.Birthday}', Email = '{candidate.Email}', " +
                    $"PhoneNumber = '{candidate.PhoneNumber}' WHERE CandidateID = {id}";
                var command = new SqlCommand(
                    "UPDATE Candidates " +
                    "SET UserID = @userId, " +
                    "FirstName = @firstName," +
                    "LastName = @lastName, " +
                    "Birthday = @birthday, " +
                    "Email = @email, " +
                    "Phone = @phoneNumber " +
                    " WHERE CandidateID = @id", (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@userId", candidate.UserID));
                command.Parameters.Add(new SqlParameter("@firstName", candidate.FirstName));
                command.Parameters.Add(new SqlParameter("@lastName", candidate.LastName));
                command.Parameters.Add(new SqlParameter("@birthday", candidate.Birthday));
                command.Parameters.Add(new SqlParameter("@email", candidate.Email));
                command.Parameters.Add(new SqlParameter("@phoneNumber", candidate.PhoneNumber));
                var rows = await connection.ExecuteAsync(query);
                connection.Close();
                //if (rows <= 0)
                //{
                //    return false;
                //}
                //return true;
            }
        }
        public async Task DeleteCandidateAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Candidates WHERE CandidateID = @id";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                int rows = await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }
    }
}
