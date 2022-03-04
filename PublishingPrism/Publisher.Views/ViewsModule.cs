using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Publisher.Infrastructure.Constants.RegionName;
using Publisher.Infrastructure.Interfaces.ViewModels;
using Publisher.Infrastructure.Interfaces.Views;
using Publisher.Infrastructure.Managers;
using Publisher.Views.Views;
using Publisher.Views.Views.DialogViews;
using Publisher.Views.Views.DialogWindow;

namespace Publisher.Views
{
    public class ViewsModule : IModule
    {
        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterMainViews(containerRegistry);
            RegisterDialogs(containerRegistry);
            RegisterDialogWindows(containerRegistry);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            RegisterViewWithRegionManager.RegisterViewWithRegion(regionManager, RegionNamesConstants.MainRegion, typeof(IMainView));
        }

        private void RegisterMainViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMainView, MainView>();
            containerRegistry.RegisterSingleton<IBookView, BookView>();
            containerRegistry.RegisterSingleton<IAuthorView, AuthorView>();
        }

        private void RegisterDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DialogView, IDialogViewModel>(nameof(DialogView));
        }

        private void RegisterDialogWindows(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialogWindow<ShowDialogWindowView>(nameof(ShowDialogWindowView));
        }
        #endregion
    }
}