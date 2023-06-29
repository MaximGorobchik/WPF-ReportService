namespace ReportServiceWPF.Model
{
    public class Categories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public Categories(int id, string name, int depId)
        {
            ID = id;
            Name = name;
            DepartmentID = depId;
        }
    }
}
