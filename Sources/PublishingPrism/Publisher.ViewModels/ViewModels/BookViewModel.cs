using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Publisher.Infrastructure.Data.Events;
using Publisher.Infrastructure.Interfaces.Models;
using Publisher.Infrastructure.Interfaces.Services;
using Publisher.Infrastructure.Interfaces.ViewModels;

namespace Publisher.ViewModels.ViewModels
{
    public class BookViewModel : BindableBase, IBookViewModel
    {
        #region Fields
        private string _title;
        private string _author;
        private string _publisher;
        private int _released;
        private long _isbn;
        private string _description;
        #endregion

        #region Ctor
        public BookViewModel()
        { }

        public BookViewModel(IDataService dataService, IEventAggregator eventAggregator) : this()
        {
            eventAggregator.GetEvent<BookСhangeEvent>().Subscribe(BookReceived);
            SetBook(dataService.GetData());
        }
        #endregion

        #region Properties
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public string Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher, value);
        }

        public int Released
        {
            get => _released;
            set => SetProperty(ref _released, value);
        }

        public long Isbn 
        {
            get => _isbn;
            set => SetProperty(ref _isbn, value);
        }

        public string Description   
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        #endregion

        #region Methods
        private void BookReceived(IBook book)
        {
            SetBook(book);
        }

        private void SetBook(IBook book)
        {
            Title = book.Title;
            Author = book.Author;
            Publisher = book.Publisher;
            Released = book.Released;
            Isbn = book.ISBN;
            Description = book.Description;
        }
        #endregion
    }
}