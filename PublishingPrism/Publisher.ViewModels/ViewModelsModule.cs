using Prism.Ioc;
using Prism.Modularity;
using Publisher.Infrastructure.Interfaces.ViewModels;
using Publisher.ViewModels.ViewModels;
using Publisher.ViewModels.ViewModels.DialogView;

namespace Publisher.ViewModels
{
    public class ViewModelsModule : IModule
    {
        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterViewModels(containerRegistry);
            RegisterDialogsViewModels(containerRegistry);
        }

        public void OnInitialized(IContainerProvider containerProvider) { }

        private void RegisterViewModels(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMainViewModel, MainViewModel>();
            containerRegistry.RegisterSingleton<IBookViewModel, BookViewModel>();
        }

        private void RegisterDialogsViewModels(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDialogViewModel, DialogViewModel>();
        }
        #endregion
    }
}