namespace SimpleApp.DataLayer.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public bool Insurance { get; set; }
        public bool CaliforniaResident { get; set; }
        public string EmploymentStatus { get; set; }
    }
}
