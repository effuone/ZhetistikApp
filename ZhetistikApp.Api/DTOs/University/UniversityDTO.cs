namespace ZhetistikApp.Api.DTOs.University
{
    public class UniversityDTO
    {
        public string UniversityName { get; set; }
        public string UniversityDescription { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public DateTime FoundationYear { get; set; }
        public string UniversityTypeName { get; set; }
        public int StudentsCount { get; set; }

        public UniversityDTO(string universityName, string universityDescription, string countryName, string cityName, DateTime foundationYear, string universityTypeName, int studentsCount)
        {
            UniversityName = universityName;
            UniversityDescription = universityDescription;
            CountryName = countryName;
            CityName = cityName;
            FoundationYear = foundationYear;
            UniversityTypeName = universityTypeName;
            StudentsCount = studentsCount;
        }
        public UniversityDTO()
        {

        }
    }
}
