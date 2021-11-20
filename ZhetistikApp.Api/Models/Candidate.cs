using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Candidates")]
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Candidate()
        {

        }

        public Candidate(int candidateID, int userID, string firstName, string lastName, DateTime birthday, string email, string phoneNumber)
        {
            CandidateID = candidateID;
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
