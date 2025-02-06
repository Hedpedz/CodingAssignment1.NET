namespace BookstoreLibrary
{
    public class BookStoreManager
    {
        // Liste for å kunne vise tilgjengelige bøker
        private List<Book> _books = new List<Book>();

        // Metode for å kunne legge til bøker i listen
        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine($"Book {book} added to the store");
        }

        // Metode for å kunne vise alle bøker i listen basert på ISBN eller tittel
    public Book? FindBook(string titleOrISBN)
    {
        return _books.FirstOrDefault(b => b.Title.Equals(titleOrISBN, StringComparison.OrdinalIgnoreCase) 
        || b.ISBN.Equals(titleOrISBN, StringComparison.OrdinalIgnoreCase));
    }


        // Metode for å kunne kjøpe en bok hvis den er tilgjengelig
        public bool PurchaseBook(string isbn, Customer customer)
        {
            var book = FindBook(isbn);
            if (book != null)
            {
                _books.Remove(book);
                Console.WriteLine($"Book {book} purchased by {customer.FirstName} {customer.LastName}");
                return true;
            }
            Console.WriteLine($"Book with ISBN {isbn} not found");  
            return false;
        }

        // Metode for å kunne vise alle tilgengelige bøker i listen
        public void DisplayBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("No books available");
            }
            else
            {
                Console.WriteLine("Available books:");
                foreach (var book in _books)
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}