namespace BookstoreLibrary 
{

    // Klasse for å kunne lagre informasjon om en kunde
    public class Customer
    {
        public string FirstName { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public List<Book> PurchaseHistory { get; set; } = new List<Book>();

        // Konstruktør for å kunne opprette en kunde
        public Customer(string firstName, string id, string email)
        {
            FirstName = firstName;
            Id = Guid.NewGuid().ToString();
            Email = email;
        }

        // Metode for å kunne vise informasjon om kunden
        public override string ToString()
        {
            return $"Hello {FirstName}, your ID is: {Id}, and email: {Email}";
        }
    }
}