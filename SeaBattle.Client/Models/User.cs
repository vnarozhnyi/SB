namespace SeaBattle.Client.Models
{
    public class User
    {
        public string Username { get; set; }

        public bool IsOnline { get; set; }

        public bool IsReady { get; set; }

        public string ConnectionId { get; set; }

        public User()
        {

        }

        public User(string username)
        {
            Username = username;
        }
    }
}