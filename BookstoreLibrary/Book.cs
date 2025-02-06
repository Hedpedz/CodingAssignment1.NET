namespace BookstoreLibrary
{

    // Klasse for å kunne lagre informasjon om en bok
    public class Book 
    {
        public String Title { get; set; }
        public String AuthorName { get; set; }
        public String ISBN { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Konstruktør for å kunne opprette en bok
        public Book(String title, string authorName, string isbn, decimal price, int stockQuantity) 
        {
            Title = title;
            AuthorName = authorName;
            ISBN = isbn;
            Price = price;
            StockQuantity = stockQuantity;
        }

        // Metode for å kunne vise informasjon om boken
        public override string ToString() 
        {
            return $"Title: {Title}, Author: {AuthorName}, ISBN: {ISBN}, Price: {Price}, Stock Quantity: {StockQuantity}";
            }
    }
}