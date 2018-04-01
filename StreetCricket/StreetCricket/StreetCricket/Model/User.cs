using SQLite;

namespace StreetCricket.Model
{
   public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public bool UserValidation()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password))
            {
                return true;
            }
            else { return false; }
        }
    }
}
