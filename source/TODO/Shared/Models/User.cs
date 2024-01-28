
namespace Shared.Models
{
    public class User
    {
        private int user_id;
        private string name;
        private string lastname;
        private string password;

        public int GetSetUserId
        {
            get => user_id; 
            set => user_id = value;
        }

        public string GetSetName
        {
            get { return name; }
            set { name = value; }
        }

        public string GetSetLastname
        {
            get => lastname;
            set => lastname = value;
        }

        public string GetSetPassword
        {
            get => password;
            set => password = value;
        }

        public User() { }

        public User(int user_id, string name, string lastname, string password)
        {
            this.user_id = user_id;
            this.name = name;
            this.lastname = lastname;
            this.password = password;
        }

        public User(string name, string lastname, string password)
        {
            this.name = name;
            this.lastname = lastname;
            this.password = password;
        }

        public override string ToString()
        {
            return "User ID: " + user_id + ", Name: " + name + ", Lastname: " + lastname + ", Password: " + password;
        }
    }
}
