namespace DemoAPI.Models
{
    public class UserService
    {
        private List<User> _users = new List<User>
    {
        new User { Username = "ashish", Password = "password1" },
        
    };

        public User Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
