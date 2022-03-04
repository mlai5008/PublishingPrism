using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using Publisher.Infrastructure.Constants.RegionName;
using Publisher.Infrastructure.Constants.ViewName;
using Publisher.Infrastructure.Data.Events;
using Publisher.Infrastructure.Interfaces.Models;
using Publisher.Infrastructure.Interfaces.Services;
using Publisher.Infrastructure.Interfaces.ViewModels;
using Publisher.Infrastructure.Interfaces.Views;
using Publisher.Infrastructure.Managers;

namespace Publisher.ViewModels.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        #region Constants
        private const string NameView = "DialogView";
        private const string NameDialogWindow = "ShowDialogWindowView"; 
        #endregion

        #region Fields
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IContainerProvider _container;
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Ctor
        public MainViewModel()
        {
            BooksCommand = new DelegateCommand(BooksCommandExecution);
            AuthorCommand = new DelegateCommand(AuthorCommandExecution);
            ShowDialogCommand = new DelegateCommand(ShowDialogCommandExecution);
            ShowDialogWindowCommand = new DelegateCommand(ShowDialogWindowCommandExecution);
        }

        public MainViewModel(IRegionManager regionManager, IDialogService dialogService , IContainerProvider container, IEventAggregator eventAggregator) : this()
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            _container = container;
            _eventAggregator = eventAggregator;
        }
        #endregion

        #region Properties
        public string Title { get; set; } 
        #endregion

        #region Commands
        public DelegateCommand BooksCommand { get; }
        public DelegateCommand AuthorCommand { get; }
        public DelegateCommand ShowDialogCommand { get; }
        public DelegateCommand ShowDialogWindowCommand { get; }
        #endregion

        #region Methods
        private void BooksCommandExecution()
        {
            RegisterViewWithRegionManager.RegisterViewWithRegion(_regionManager, RegionNamesConstants.InternalRegion, typeof(IBookView));
            RegionNavigationManager.Navigate(_regionManager, RegionNamesConstants.InternalRegion, ViewNamesConstants.BookView);
        }

        private void AuthorCommandExecution()
        {
            RegisterViewWithRegionManager.RegisterViewWithRegion(_regionManager, RegionNamesConstants.InternalRegion, typeof(IAuthorView));
            RegionNavigationManager.Navigate(_regionManager, RegionNamesConstants.InternalRegion, ViewNamesConstants.AuthorView);
        }

        private void ShowDialogCommandExecution()
        {
            IDialogParameters parameters = new DialogParameters();
            //dynamic data = GetDynamicData();
            //parameters.Add(nameof(data), data);

            IBook book = _container.Resolve<IDataService>().GetData();
            parameters.Add(nameof(book), book);

            _dialogService.ShowDialog(NameView, parameters, callback =>
            {
                if (callback.Result == ButtonResult.None)
                {
                }
                    
                else if (callback.Result == ButtonResult.OK)
                {
                    //dynamic data = callback.Parameters.GetValue<dynamic>(nameof(data));
                    IBook book = callback.Parameters.GetValue<IBook>(nameof(book));
                    _eventAggregator.GetEvent<BookСhangeEvent>().Publish(book);
                }
                else if (callback.Result == ButtonResult.Cancel)
                {
                }
                else
                {
                }
            });
        }

        private void ShowDialogWindowCommandExecution()
        {
            IDialogParameters parameters = new DialogParameters();
            //dynamic data = GetDynamicData();
            //parameters.Add(nameof(data), data);

            IBook book = _container.Resolve<IDataService>().GetData();
            parameters.Add(nameof(book), book);

            _dialogService.ShowDialog(NameView , parameters, callback =>
            {
                if (callback.Result == ButtonResult.None)
                {
                }
                else if (callback.Result == ButtonResult.OK)
                {
                    IBook book = callback.Parameters.GetValue<IBook>(nameof(book));
                    _eventAggregator.GetEvent<BookСhangeEvent>().Publish(book);
                }
                else
                {
                }
            }, NameDialogWindow);
        }

        private dynamic GetDynamicData()
        {
            return new { Name = "Old", Age = 300 };
        }
        #endregion
    }
}