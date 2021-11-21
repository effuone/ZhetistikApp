namespace ZhetistikApp.Api.ViewModels
{
    public class LocationViewModel
    {
        public int LocationID { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        

        public LocationViewModel(int locationID, string countryName, string stateName, string cityName)
        {
            LocationID = locationID;
            CityName = cityName;
            CountryName = countryName;
        }
    }
}
