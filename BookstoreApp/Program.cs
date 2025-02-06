using System;
using BookstoreLibrary;

class Program
{
    /// <summary>
    /// Entry point for the bookstore application.
    /// </summary>
    static void Main()
    {
        // Initializes a bookstore manager implementing IBookstoreService
        IBookstoreService store = new BookStoreManager();
        var customer = new Customer("Hedda Nilsen", "heddanilsen@mail.com");

        try
        {
            // Adds books to the inventory
            store.AddBook(new Book("C# for Beginners", "John Doe", "123456", 299.99m, 5));
            store.AddBook(new Book("Framework Design Guidelines", "Brad Abrams", "654321", 499.99m, 3));
            store.AddBook(new Book("Code Complete", "Steve McConnell", "333666", 399.99m, 7));

            // Displays available books
            Console.WriteLine("\nAvailable books:");
            store.GetAllBooks().ForEach(Console.WriteLine);

            // Searches for a book by ISBN
            Console.WriteLine("\nSearching for '123456'...");
            var foundBooks = store.FindBook("123456");
            foundBooks.ForEach(Console.WriteLine);

            // Processes a book purchase
            Console.WriteLine("\nAttempting to purchase '123456'...");
            store.PurchaseBook("123456", customer);

            // Displays stock after purchase
            Console.WriteLine("\nStock after purchase:");
            store.GetAllBooks().ForEach(Console.WriteLine);

            // Displays customer's purchase history
            Console.WriteLine("\nPurchase history:");
            customer.PurchaseHistory.ForEach(Console.WriteLine);
        }
        catch (Exception ex)
        {
            // Handles any unexpected errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
