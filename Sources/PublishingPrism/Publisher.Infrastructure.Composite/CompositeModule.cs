using Prism.Ioc;
using Prism.Modularity;
using Publisher.Infrastructure.Composite.Services;
using Publisher.Infrastructure.Interfaces.Service;

namespace Publisher.Infrastructure.Composite
{
    public class CompositeModule : IModule
    {
        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterComposites(containerRegistry);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        { }

        private void RegisterComposites(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDialogService, DialogService>();
        } 
        #endregion
    }
}