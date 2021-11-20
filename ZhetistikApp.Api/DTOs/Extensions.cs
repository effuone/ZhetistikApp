using ZhetistikApp.Api.DTOs.Candidate;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.DTOs
{
    public static class Extensions
    {
        public static CandidateDTO AsDto(this ZhetistikApp.Api.Models.Candidate candidate)
        {
            return new CandidateDTO(
            candidate.CandidateID,
            candidate.FirstName,
            candidate.LastName,
            candidate.Birthday,
            candidate.Email,
            candidate.PhoneNumber
            );
        }
    }
}
