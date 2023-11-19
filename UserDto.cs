namespace JwtWebAPI
{
    public class UserDto
    {
        public string Username {  get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public long Phone { get; set; }

        public string Password { get; set; } = String.Empty;
    }
}
