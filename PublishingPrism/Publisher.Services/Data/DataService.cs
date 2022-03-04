using Prism.Events;
using Publisher.Infrastructure.Data.Events;
using Publisher.Infrastructure.Data.Models;
using Publisher.Infrastructure.Interfaces.Models;
using Publisher.Infrastructure.Interfaces.Services;

namespace Publisher.Services.Data
{
    public class DataService : IDataService
    {
        #region Ctor
        public DataService(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<BookСhangeEvent>().Subscribe(BookReceived);
            SetBook();
        }
        #endregion

        #region Properties
        public IBook Book { get; set; } = new Book();
        #endregion

        #region Methods
        public IBook GetData() => Book;

        private void SetBook()
        {
            Book = new Book()
            {
                Title = "CLR via C#",
                Author = "Jeffrey Richter",
                Publisher = "Microsoft Press",
                Released = 2012,
                ISBN = 9780735668737,
                Description = "Dig deep and master the intricacies of the common language runtime, C#, and .NET development. Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft .NET team - you’ll gain pragmatic insights for building robust, reliable, and responsive apps and components"
            };
        }

        private void SetBook(IBook book)
        {
            ((Book)Book).Title = book.Title;
            ((Book)Book).Author = book.Author;
            ((Book)Book).Publisher = book.Publisher;
            ((Book)Book).Released = book.Released;
            ((Book)Book).ISBN = book.ISBN;
            ((Book)Book).Description = book.Description;
        }

        private void BookReceived(IBook book)
        {
            SetBook(book);
        }
        #endregion
    }
}