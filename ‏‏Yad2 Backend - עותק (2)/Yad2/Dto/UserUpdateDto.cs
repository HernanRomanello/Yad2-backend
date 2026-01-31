namespace Book_Store.Dto
{
    public class UserUpdateDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public string ?City { get; set; }

        public string ?Street { get; set; }

        public int HouseNumber { get; set; }

        public string ?Picture { get; set; }
    }
}
