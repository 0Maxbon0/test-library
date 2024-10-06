namespace Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateJoined { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; } // Admin flag to differentiate between regular members and admins

        // Navigation Properties
        public ICollection<Checkout> Checkouts { get; set; }
    }

}
