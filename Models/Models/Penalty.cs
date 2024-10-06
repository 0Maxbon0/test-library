namespace Models
{
    public class Penalty
    {
        public int PenaltyID { get; set; }
        public int CheckoutID { get; set; }
        public decimal PenaltyAmount { get; set; }
        public bool Paid { get; set; } // Flag to indicate if the penalty is paid

        // Navigation Properties
        public Checkout Checkout { get; set; }
    }

}
