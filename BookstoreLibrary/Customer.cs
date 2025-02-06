namespace BookstoreLibrary 
{

    // Klasse for å kunne lagre informasjon om en kunde
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Konstruktør for å kunne opprette en kunde
        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // Metode for å kunne vise informasjon om kunden
        public override string ToString()
        {
            return $"First Name: {FirstName}, Last Name: {LastName}, Email: {Email}";
        }
    }
}