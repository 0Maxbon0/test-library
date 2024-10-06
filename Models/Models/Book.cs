namespace Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int CopiesAvailable { get; set; }
        public int TotalCopies { get; set; }

        // Navigation Properties
        public ICollection<Checkout> Checkouts { get; set; }
    }

}
