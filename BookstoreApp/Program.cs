using System;
using BookstoreLibrary; // Importerer biblioteket

class Program
{
    static void Main()
    {
        // Oppretter en ny bokhandel
        var store = new BookStoreManager();

        // Lager noen bøker
        var book1 = new Book("C# for Beginners", "John Doe", "123456", 299.99m, 5);
        var book2 = new Book("Advanced C#", "Jane Smith", "789101", 499.99m, 3);
        var book3 = new Book("Mastering .NET", "Emily White", "112233", 599.99m, 2);

        // Legger til bøkene i butikken
        store.AddBook(book1);
        store.AddBook(book2);
        store.AddBook(book3);

        // Viser alle bøker i butikken
        Console.WriteLine("\n📚 Tilgjengelige bøker i butikken:");
        store.DisplayBooks();

        // Oppretter en kunde
        var customer = new Customer("", "Ola Nordmann", "ola@example.com");

        // Søk etter en bok
        Console.WriteLine("\n🔎 Søker etter bok med ISBN '123456':");
        var foundBooks = store.FindBook("123456");
        foreach (var book in foundBooks)
        {
            Console.WriteLine($"Fant bok: {book}");
        }

        // Kjøp en bok
        Console.WriteLine("\n🛒 Ola kjøper 'C# for Beginners'...");
        bool purchaseSuccess = store.PurchaseBook("123456", customer);

        // Sjekk om kjøpet var vellykket
        if (purchaseSuccess)
        {
            Console.WriteLine($"✅ Kjøpet var vellykket! {customer.FirstName} har kjøpt en bok.");
        }
        else
        {
            Console.WriteLine("❌ Kjøpet mislyktes.");
        }

        // Viser bøker etter kjøp
        Console.WriteLine("\n📦 Lagerstatus etter kjøpet:");
        store.DisplayBooks();

        // Viser kundens kjøpshistorikk
        Console.WriteLine("\n🛍️ Ola sin kjøpshistorikk:");
        foreach (var book in customer.PurchaseHistory)
        {
            Console.WriteLine(book);
        }
    }
}
