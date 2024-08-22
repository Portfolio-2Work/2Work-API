namespace _2Work_API.Application.Users.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TP_User { get; set; }
        public string ST_Record { get; set; }

        public CreateUserRequest()
        {
            Name = "";
            Email = "";
            Password = "";
            TP_User = "";
            ST_Record = "";
        }
    }
}
