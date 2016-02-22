using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrackerEnabledDbContext.Common.Models;

namespace SimpleApp.DataLayer.Model
{
    [TrackChanges]
    public class Donor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [MaxLength(10)]
        public string LastName { get; set; }
        public string Hospital { get; set; }
        [DisplayName("Date of Birth")]
        public string DOB { get; set; }
        public SexType Sex { get; set; }
        [Required]
        [DisplayName("Organ Type")]
        public string OrganType { get; set; }
        [DisplayName("Death Date-Time")]
        public DateTime DeathDateTime { get; set; }
        public string Status { get; set; }
        [DataType(DataType.MultilineText)]
        [MaxLength(30)]
        public string Comments { get; set; }

        public virtual List<AuditLog> AuditLogs { get; set; }
    }
}