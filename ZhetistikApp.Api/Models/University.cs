namespace ZhetistikApp.Api.Models
{
    public class University
    {
        public long UniversityID { get; set; }
        public string UniversityName { get; set; }
        public DateOnly FoundationYear { get; set; }

        public long StudentsCount { get; set; }
        public long CountryID { get; set; }
        public long CityID { get; set; }

    }
}
