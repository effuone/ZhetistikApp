using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.DTOs.Candidate;
using ZhetistikApp.Api.DTOs.Location;
using ZhetistikApp.Api.DTOs.Portfolio;
using ZhetistikApp.Api.Models;
using ZhetistikApp.Api.ViewModels;

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
        public static LocationDTO AsDto(this LocationViewModel location)
        {
            return new LocationDTO(location.LocationID, location.CountryName, location.StateName, location.CityName);
        }
    }
}
