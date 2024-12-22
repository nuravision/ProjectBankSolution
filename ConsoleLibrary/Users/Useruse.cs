namespace ConsoleLibrary.Users
{
    public class Useruse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public Useruse(string username,string email)
        {
            UserName = username;
            Email = email;
        }

    }
}
