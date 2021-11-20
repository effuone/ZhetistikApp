using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Candidate
{
    public record CandidateDTO(
    long candidateID, 
    string firstName,
    string lastName,
    DateTime birthday,
    string email,
    string phoneNumber 
    );
    public record CreateCandidateDTO(
    [Required] string firstName,
    [Required] string lastName,
    [Required] DateTime birthday,
    [Required] string email,
    [Required] string phoneNumber
    );
    public class UpdateCandidateDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
