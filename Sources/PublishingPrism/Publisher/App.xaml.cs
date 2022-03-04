using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using Publisher.Infrastructure.Interfaces.ViewModels;
using Publisher.Infrastructure.Interfaces.Views;
using Publisher.Services;
using Publisher.ViewModels;
using Publisher.Views;
using System;
using System.Reflection;
using System.Windows;

namespace Publisher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        #region Methods
        #region Override Methods
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                string viewName = viewType.FullName?.Replace(".Views.", ".ViewModels.");
                string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName?.Replace(".Views", ".ViewModels");
                string viewModelName = $"{viewName}Model, {viewAssemblyName}".Replace(".Views.", ".ViewModels.");
                return Type.GetType(viewModelName);
            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterViews(containerRegistry);
            RegisterViewModels(containerRegistry);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ViewsModule>();
            moduleCatalog.AddModule<ViewModelsModule>();
            moduleCatalog.AddModule<ServicesModule>();

            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override Window CreateShell()
        {
            return (ShellView)Container.Resolve<IShellView>();
        }
        #endregion

        #region Private Methods
        private void RegisterViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellView, ShellView>();
        }

        private void RegisterViewModels(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellViewModel, ShellViewModel>();
        }
        #endregion
        #endregion
    }
}