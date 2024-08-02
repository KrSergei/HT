namespace DB__Entity.Models
{
    public class User
    {   
        public int ID_user { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> ToMessages { get; set; }
        public virtual ICollection<Message> FromMessages { get; set; }
    }
}
