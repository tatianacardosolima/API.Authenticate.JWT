namespace API.Authenticate.JWT.Models
{
    public static class UserList
    {
        public static List<User> users = new List<User>(); 
    }
    public enum AllowedLevel
    { 
        Master =1, Medium =2,Common = 3
    }
    public class User
    {
        public User(string name, string password)
        {
            Name = name;
            Password  = password;

        }
        public string Id { get; set; }  
        public string Name { get; set; }    
        public string Password { get; set; }
        public AllowedLevel AllowedLevel { get; set; }

    }
}
