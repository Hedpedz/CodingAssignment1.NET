namespace BookstoreLibrary
{
    public class BookStoreManager
    {
        // Lister for å kunne vise tilgjengelige bøker og kunders kjøp 
        private List<Book> _inventory = new List<Book>();
        private List<Customer> _customers = new List<Customer>();


        // Metode for å kunne legge til bøker i listen
        public void AddBook(Book book)
        {
            ValidateBook(book);

            if (_inventory.Any(b => b.ISBN == book.ISBN))
            {
                throw new ArgumentException($"Book with ISBN {book.ISBN} already exists");
            }
            _inventory.Add(book);
            Console.WriteLine($"Book {book} added to the store");
        }


        // Metode for å kunne vise alle bøker i listen basert på ISBN eller tittel
        public IEnumerable<Book> FindBook(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ArgumentException("Search term cannot be empty");
            }

            return _inventory.Where(b => 
                b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                b.ISBN == searchTerm);
        }


        // Metode for å kunne kjøpe en bok hvis den er tilgjengelig
        public bool PurchaseBook(string isbn, Customer customer)
        {
            var book = _inventory.FirstOrDefault(b => b.ISBN == isbn);
            
            if (book != null && book.StockQuantity > 0)
            {
                book.StockQuantity--;
                customer.PurchaseHistory.Add(book);
                Console.WriteLine($"Book '{book.Title}' purchased by {customer.FirstName}. Remaining stock: {book.StockQuantity}");

                if (book.StockQuantity == 0)
                {
                    _inventory.Remove(book); 
                }
                return true;
            }

            Console.WriteLine($"Book with ISBN {isbn} not found or out of stock.");
            return false;
        }

            
        



        // Metode for å kunne vise alle tilgengelige bøker i listen
        public void DisplayBooks()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine("No books available");
            }
            else
            {
                Console.WriteLine("Available books:");
                foreach (var book in _inventory)
                {
                    Console.WriteLine(book);
                }
            }
        }
        private void ValidateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (string.IsNullOrWhiteSpace(book.ISBN))
            {
                throw new ArgumentException("ISBN is required");
            }

            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new ArgumentException("Title is required");
            }

            if (book.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
        }
    }
}