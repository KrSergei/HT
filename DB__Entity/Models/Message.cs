namespace DB__Entity.Models
{
    public class Message
    {
        public int id_message { get; set; }
        public string text { get; set; }
        public bool isReceived { get; set; }
        public int? ToUserId { get; set; }
        public int? FromUserId { get; set; }
        public virtual User? ToUser { get; set; }
        public virtual User? FromUser { get; set; }
    }
}
