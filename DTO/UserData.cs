namespace ApiVersionControl.DTO
{
    public class User 
    {
        public string? ID { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Picture { get; set; }
    }

    public class UserResponseData
    {
        public User[]? Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
