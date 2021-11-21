using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("States")]
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string StateName { get; set; }

        public State(int stateID, int countryID, string stateName)
        {
            StateID = stateID;
            CountryID = countryID;
            StateName = stateName;
        }
    }
}
