using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Candidate
{
    public class CandidateDTO
    {
        public long CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public CandidateDTO(long candidateID, string firstName, string lastName, DateTime birthday, string email, string phoneNumber)
        {
            CandidateID = candidateID;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
    public class CreateCandidateDTO
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

        public CreateCandidateDTO(string firstName, string lastName, DateTime birthday, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
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

        public UpdateCandidateDTO(string firstName, string lastName, DateTime birthday, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
