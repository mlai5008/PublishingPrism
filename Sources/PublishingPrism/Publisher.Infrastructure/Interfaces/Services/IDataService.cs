using Publisher.Infrastructure.Data.Models;
using Publisher.Infrastructure.Interfaces.Models;

namespace Publisher.Infrastructure.Interfaces.Services
{
    public interface IDataService
    {
        #region Methods
        IBook GetData(); 
        #endregion
    }
}