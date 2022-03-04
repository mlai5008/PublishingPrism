using Publisher.Infrastructure.Interfaces.Models;

namespace Publisher.Infrastructure.Data.Models
{
    public class Book : IBook
    {
        #region Ctor
        public Book() { }

        public Book(string title, string author, string publisher, int released, long isbn, string description)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Released = released;
            ISBN = isbn;
            Description = description;
        } 
        #endregion

        #region Properties
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Released { get; set; }
        public long ISBN { get; set; }
        public string Description { get; set; } 
        #endregion
    }
}