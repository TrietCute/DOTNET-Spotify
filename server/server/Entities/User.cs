namespace server.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Name, Email, Password);
        }
    }
}
