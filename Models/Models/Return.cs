namespace Models
{
    public class Return
    {
        public int ReturnID { get; set; }
        public int CheckoutID { get; set; }
        public DateTime ReturnDate { get; set; }

        // Navigation Properties
        public Checkout Checkout { get; set; }
    }

}
