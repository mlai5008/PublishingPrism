using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Publisher.Infrastructure.Data.Models;
using Publisher.Infrastructure.Interfaces.Models;
using Publisher.Infrastructure.Interfaces.ViewModels;
using System;

namespace Publisher.ViewModels.ViewModels.DialogView
{
    public class DialogViewModel : BindableBase, IDialogViewModel
    {
        #region Fields
        private string _titleBook;
        private string _author;
        private string _publisher;
        private int _released;
        private long _isbn;
        private string _description;
        #endregion

        #region Ctor
        public DialogViewModel()
        {
            OkDialogCommand = new DelegateCommand<string>(OkCommandExecution);
            CancelCommand = new DelegateCommand<string>(CancelCommandExecution);
        }
        #endregion

        #region Commands
        public DelegateCommand<string> OkDialogCommand { get; }
        public DelegateCommand<string> CancelCommand { get; }
        #endregion

        #region Properties
        public string Title => "Edit book";

        public string TitleBook
        {
            get => _titleBook;
            set => SetProperty(ref _titleBook, value);
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
        private void OkCommandExecution(string parameter)
        {
            //IDialogParameters parameters = new DialogParameters();
            //dynamic data = new { Name = Name, Age = Age };
            //parameters.Add(nameof(data), data);

            IDialogParameters parameters = new DialogParameters();
            IBook book = GetCurrentBook();
            parameters.Add(nameof(book), book);
            RaiseRequestClose(new DialogResult(ButtonResult.OK, parameters));
        }

        private IBook GetCurrentBook()
        {
            return new Book()
            {
                Title = TitleBook,
                Author = Author,
                Publisher = Publisher,
                Released = Released,
                ISBN = Isbn,
                Description = Description,
            };
        }

        private void CancelCommandExecution(string obj)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.No));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }
        
        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            //dynamic data = parameters.GetValue<dynamic>(nameof(data));
            //Name = data.Name;
            //Age = data.Age;

            IBook book = parameters.GetValue<IBook>(nameof(book));
            SetBook(book);
        }

        private void SetBook(IBook book)
        {
            TitleBook = book.Title;
            Author = book.Author;
            Publisher = book.Publisher;
            Released = book.Released;
            Isbn = book.ISBN;
            Description = book.Description;
        }
        #endregion

        #region Events
        public event Action<IDialogResult> RequestClose; 
        #endregion
    }
}