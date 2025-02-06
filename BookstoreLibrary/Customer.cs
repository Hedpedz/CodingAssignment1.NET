namespace BookstoreLibrary 
{
    public class Customer
    {
        public string FirstName { get; set }
        public string LastName { get; set }
        public string Email { get; set }

        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}, Last Name: {LastName}, Email: {Email}";
        }
    }
}