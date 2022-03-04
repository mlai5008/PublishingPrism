using Prism.Ioc;
using Prism.Modularity;
using Publisher.Infrastructure.Interfaces.Services;
using Publisher.Services.Data;

namespace Publisher.Services
{
    public class ServicesModule : IModule
    {
        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterServices(containerRegistry);
        }

        public void OnInitialized(IContainerProvider containerProvider) { }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDataService, DataService>();
        } 
        #endregion
    }
}