namespace todoapp_api.Models
{
    public class Todo
    {
        public int id { get; set; }
        public string task { get; set; }
        public string status { get; set; } = "new";
        public string description { get; set; }
        public DateTime? created { get; set; } = DateTime.Now;
        public DateTime? updated { get; set; } = DateTime.Now;
    }
}
