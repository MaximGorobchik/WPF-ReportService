using System;
namespace ReportServiceWPF.Model
{
    public class Employees
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }
    }
}
