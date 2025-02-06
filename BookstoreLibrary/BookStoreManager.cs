using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreLibrary
{
    /// <summary>
    /// Manages the bookstore inventory and customer transactions.
    /// </summary>
    public class BookStoreManager : IBookstoreService
    {
        private readonly List<Book> _inventory = new List<Book>();
        private readonly List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Adds a book to the bookstore inventory.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if the book is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the book already exists in the inventory.</exception>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (_inventory.Any(b => b.ISBN == book.ISBN))
                throw new ArgumentException($"A book with ISBN {book.ISBN} already exists.");

            _inventory.Add(book);
            Console.WriteLine($"Book '{book.Title}' added successfully.");
        }

        /// <summary>
        /// Retrieves all books currently in the inventory.
        /// </summary>
        /// <returns>A list of all available books.</returns>
        public List<Book> GetAllBooks() => _inventory;

        /// <summary>
        /// Searches for books by title or ISBN.
        /// </summary>
        /// <param name="searchTerm">The title or ISBN to search for.</param>
        /// <returns>A list of books that match the search criteria.</returns>
        /// <exception cref="ArgumentException">Thrown if the search term is empty.</exception>
        public List<Book> FindBook(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("Search term cannot be empty.");

            var foundBooks = _inventory
                .Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) 
                         || b.ISBN.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!foundBooks.Any())
                Console.WriteLine($"No books found for '{searchTerm}'.");

            return foundBooks;
        }

        /// <summary>
        /// Processes the purchase of a book.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to purchase.</param>
        /// <param name="customer">The customer making the purchase.</param>
        /// <returns>True if the purchase was successful; otherwise, false.</returns>
        public bool PurchaseBook(string isbn, Customer customer)
        {
            var book = _inventory.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
            {
                Console.WriteLine($"Book with ISBN {isbn} not found.");
                return false;
            }

            if (book.StockQuantity == 0)
            {
                Console.WriteLine($"'{book.Title}' is out of stock.");
                return false;
            }

            book.ReduceStock();
            customer.PurchaseHistory.Add(book);
            Console.WriteLine($"{customer.FirstName} purchased '{book.Title}'. Remaining stock: {book.StockQuantity}");

            if (book.StockQuantity == 0)
            {
                _inventory.Remove(book);
                Console.WriteLine($"'{book.Title}' is now out of stock.");
            }

            return true;
        }
    }
}
