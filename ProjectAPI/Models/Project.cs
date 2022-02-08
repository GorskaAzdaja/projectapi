namespace ProjectAPI.Models
{
    public enum Project_Priority
    {
        Low,
        Medium,
        High
    }

    public enum Project_Status
    {
        Not_Started,
        Active,
        Completed
    }

    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime? Completion_Date { get; set; }
        public Project_Status Project_Status { get; set; }
        public Project_Priority Project_Priority { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
