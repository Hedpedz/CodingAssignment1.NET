using System.Collections.Generic;

namespace BookstoreLibrary
{
    /// <summary>
    /// Defines the contract for a bookstore service.
    /// </summary>
    public interface IBookstoreService
    {
        /// <summary>
        /// Adds a book to the bookstore inventory.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        void AddBook(Book book);

        /// <summary>
        /// Searches for books by title or ISBN.
        /// </summary>
        /// <param name="searchTerm">The title or ISBN to search for.</param>
        /// <returns>A list of books that match the search criteria.</returns>
        List<Book> FindBook(string searchTerm);

        /// <summary>
        /// Processes the purchase of a book.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to purchase.</param>
        /// <param name="customer">The customer making the purchase.</param>
        /// <returns>True if the purchase was successful; otherwise, false.</returns>
        bool PurchaseBook(string isbn, Customer customer);

        /// <summary>
        /// Retrieves all books currently in the inventory.
        /// </summary>
        /// <returns>A list of all available books.</returns>
        List<Book> GetAllBooks();
    }
}
