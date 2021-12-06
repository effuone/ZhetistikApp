using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly DapperContext _context;

        public UniversityRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUniversityAsync(University university)
        {
            string sql = "INSERT INTO Universities " +
                "(UniversityName, UniversityDescription, LocationID, FoundationYear, StudentCount, UniversityTypeID)" +
                "VALUES (@universityName, @universityDescription, @locationId, @foundationYear, @studentsCount, @universityTypeId)" +
                "SET UniversityID = SCOPE_IDENTITY();";
            using(var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                //danniye o universitete
                //kak v bd sohranen
                command.Parameters.Add(new SqlParameter("universityName", university.UniversityName));
                command.Parameters.Add(new SqlParameter("universityDescription", university.UniversityDescription));
                command.Parameters.Add(new SqlParameter("locationId", university.LocationID));
                command.Parameters.Add(new SqlParameter("foundationYear", university.FoundationYear));
                command.Parameters.Add(new SqlParameter("studentsCount", university.StudentsCount));
                command.Parameters.Add(new SqlParameter("universityTypeId", university.UniversityTypeID));
                var outputParam = new SqlParameter
                {
                    ParameterName = "@UniversityID",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);
                await command.ExecuteNonQueryAsync();
                return (int)outputParam.Value;
            }
        }

        public async Task DeleteUniversityAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM Universities WHERE UniversityID = @id";
                connection.Open();
                var command = new SqlCommand(sql, (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                int rows = await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<IEnumerable<University>> GetUniversitiesAsync()
        {
            var query = $"SELECT* FROM Universities";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var universities = await connection.QueryAsync<University>(query);
                return universities;
            }
        }


        public async Task<University> GetUniversityAsync(int id)
        {
            var query = $"SELECT * FROM Universities WHERE UniversityID = {id}";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new University(
                    (int)reader[0],
                    (string)reader[1],
                    (string)reader[2],
                    (int)reader[3],
                    (DateTime)reader[4],
                    (int)reader[5],
                    (int)reader[6]
                );
            }
        }

        public async Task<University> GetUniversityAsync(string universityName)
        {
            var query = $"SELECT * FROM Universities WHERE UniversityName = '{universityName}'";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var command = new SqlCommand(query, (SqlConnection)connection);
                var reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }
                await reader.ReadAsync();
                return new University(
                    (int)reader[0],
                    (string)reader[1],
                    (string)reader[2],
                    (int)reader[3],
                    (DateTime)reader[4],
                    (int)reader[5],
                    (int)reader[6]
                );
            }
        }

        public async Task UpdateUniversityAsync(int id, University university)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var query = $"UPDATE Universities SET UniversityName = {university.UniversityName}, " +
                    $"UniversityDescription = '{university.UniversityDescription}', LocationID = '{university.LocationID}', " +
                    $"FoundationYear = '{university.FoundationYear}', StudentsCount = '{university.StudentsCount}', " +
                    $"UniversityTypeID = '{university.UniversityTypeID}' WHERE UniversityID = {id}";
                var command = new SqlCommand(
                    "UPDATE Candidates " +
                    "SET UserID = @userId, " +
                    "FirstName = @firstName," +
                    "LastName = @lastName, " +
                    "Birthday = @birthday, " +
                    "Email = @email, " +
                    "Phone = @phoneNumber " +
                    " WHERE CandidateID = @id", (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("universityName", university.UniversityName));
                command.Parameters.Add(new SqlParameter("universityDescription", university.UniversityDescription));
                command.Parameters.Add(new SqlParameter("locationId", university.LocationID));
                command.Parameters.Add(new SqlParameter("foundationYear", university.FoundationYear));
                command.Parameters.Add(new SqlParameter("studentsCount", university.StudentsCount));
                command.Parameters.Add(new SqlParameter("universityTypeId", university.UniversityTypeID));
                var rows = await connection.ExecuteAsync(query);
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
