using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleApp.Helpers.Enum;
using TrackerEnabledDbContext.Common.Models;
using SexType = SimpleApp.DataLayer.Model.SexType;

namespace SimpleApp.Models
{
    public class PatientVM
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
        [NotMapped]
        public virtual List<AuditLog> AuditLogs { get; set; }
    }
}