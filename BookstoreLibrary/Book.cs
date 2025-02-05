namespace BookstoreLibrary
{
    public class Book 
    {
        String Title { get; set}
        String AuthorName { get; set}
        String ISBN { get; set}
        int Price { get; set}

        public Book(String title, string authorName, string isbn, int price) 
        {
            Title = title;
            AuthorName = authorName;
            ISBN = isbn;
            Price = price;
        }
        
        public override ToString() 
        {
            return $"Title: {Title}, Author: {AuthorName}, ISBN: {ISBN}, Price: {Price}";
            }
    }
}