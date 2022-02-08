namespace ProjectAPI.Models
{
    public enum Task_Priority
    {
        Low,
        Medium,
        High
    }

    public enum Task_Status
    {
        To_Do,
        In_Progress,
        Done
    }

    public class Task
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Task_Status Task_Status { get; set; }
        public Task_Priority Task_Priority { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
    }
}
