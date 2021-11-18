using ZhetistikApp.Api.DTOs.Candidate;

namespace ZhetistikApp.Api.DTOs
{
    public static class Extensions
    {
        public static CandidateDTO AsDto(this ZhetistikApp.Api.Models.Candidate candidate)
        {
            return new CandidateDTO(
            candidate.CandidateID,
            candidate.UserID,
            candidate.FirstName,
            candidate.LastName,
            candidate.Birthday,
            candidate.Email,
            candidate.PhoneNumber
            );
        }
    }
}
