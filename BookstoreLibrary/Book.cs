namespace BookstoreLibrary
{
    /// <summary>
    /// Represents a book in the bookstore.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets the title of the book.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the name of the author.
        /// </summary>
        public string AuthorName { get; }

        /// <summary>
        /// Gets the ISBN number of the book.
        /// </summary>
        public string ISBN { get; }

        /// <summary>
        /// Gets the price of the book.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Gets the available stock quantity.
        /// </summary>
        public int StockQuantity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="authorName">The author of the book.</param>
        /// <param name="isbn">The ISBN number of the book.</param>
        /// <param name="price">The price of the book.</param>
        /// <param name="stockQuantity">The quantity available in stock.</param>
        /// <exception cref="ArgumentException">Thrown when any argument is invalid.</exception>
        public Book(string title, string authorName, string isbn, decimal price, int stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("Title, author name, and ISBN cannot be empty.");
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");
            if (stockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative.");

            Title = title;
            AuthorName = authorName;
            ISBN = isbn;
            Price = price;
            StockQuantity = stockQuantity;
        }

        /// <summary>
        /// Reduces the stock quantity by one.
        /// </summary>
        public void ReduceStock()
        {
            if (StockQuantity > 0)
            {
                StockQuantity--;
            }
        }

        /// <summary>
        /// Returns a string representation of the book.
        /// </summary>
        /// <returns>A formatted string containing book details.</returns>
        public override string ToString()
        {
            return $"{Title} by {AuthorName}, ISBN: {ISBN}, Price: {Price:C}, Stock: {StockQuantity}";
        }
    }
}
