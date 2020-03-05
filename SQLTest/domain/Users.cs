namespace SQLTest.domain {
    public class Users {
        private long id;
        private string username;
        private string password;

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Users( string username, string password) {
            Username = username;
            Password = password;
        }

        public override string ToString() {
            return "users {" + $" id = {Id}, username = {Username}, password = {Password}"+" }";
        }
    }
}