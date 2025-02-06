using System;
using BookstoreLibrary; 

class Program
{
    static void Main()
    {
        var store = new BookStoreManager(); 
        var book1 = new Book("C# for Beginners", "John Doe", "123456", 299);
        var book2 = new Book("Advanced C#", "Jane Smith", "789101", 499);
        var customer = new Customer("Ola Nordmann", "ola@example.com", "12345678");

        store.AddBook(book1);
        store.AddBook(book2);

        store.DisplayBooks(); // Viser bøker i lageret

        Console.WriteLine("\nSøker etter bok:");
        var foundBook = store.FindBook("123456");
        Console.WriteLine(foundBook != null ? $"Fant: {foundBook}" : "Bok ikke funnet.");

        Console.WriteLine("\nPrøver å kjøpe en bok:");
        store.PurchaseBook("123456", customer);

        store.DisplayBooks(); // Viser bøker etter kjøpet
    }
}
