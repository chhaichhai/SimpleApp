using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp.DataLayer.Model
{
    [TrackChanges]
    public class Patient
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [MaxLength(10)]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        public string DOB { get; set; }
        [SkipTracking]
        public SexType Sex { get; set; }
        public bool Insurance { get; set; }
        [DisplayName("California Resident")]
        public bool CaliforniaResident { get; set; }
        [DisplayName("Employment Status")]
        public string EmploymentStatus { get; set; }
    }

    public enum SexType
    {
        Male, Female, Unknown
    }
}
