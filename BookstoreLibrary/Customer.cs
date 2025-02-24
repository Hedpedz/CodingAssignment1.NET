using System;
using System.Collections.Generic;

namespace BookstoreLibrary
{
    /// <summary>
    /// Represents a customer in the bookstore system.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets the first name of the customer.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets the unique customer ID.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the email address of the customer.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the purchase history of the customer.
        /// </summary>
        public List<Book> PurchaseHistory { get; } = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="firstName">The customer's first name.</param>
        /// <param name="email">The customer's email address.</param>
        /// <exception cref="ArgumentException">Thrown when input parameters are invalid.</exception>
        public Customer(string firstName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Customer name and email cannot be empty.");

            FirstName = firstName;
            Email = email;
            Id = Guid.NewGuid().ToString(); // Automatically generates a unique ID
        }

        /// <summary>
        /// Returns a string representation of the customer.
        /// </summary>
        /// <returns>A formatted string containing customer details.</returns>
        public override string ToString()
        {
            return $"Customer: {FirstName}, ID: {Id}, Email: {Email}";
        }
    }
}
