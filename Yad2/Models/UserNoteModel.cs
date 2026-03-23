namespace Yad2.Models
{
    public class UserNoteModel
    {
        public Guid Id { get; set; }

        public string ?UserId { get; set; }

        public int  AdID  {get;set;}

        public string ?Note { get; set; }
    }
}
