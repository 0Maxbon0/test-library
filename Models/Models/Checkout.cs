namespace Models
{
    public class Checkout
    {
        public int CheckoutID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Returned { get; set; } 
        public Book Book { get; set; }
        public Member Member { get; set; }
        public Return Return { get; set; }
        public Penalty Penalty { get; set; }
    }

}
