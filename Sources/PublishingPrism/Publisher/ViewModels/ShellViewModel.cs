using Prism.Mvvm;
using Publisher.Infrastructure.Interfaces.ViewModels;

namespace Publisher.ViewModels
{
    public class ShellViewModel : BindableBase, IShellViewModel
    {
        #region Properties
        public string Title => "ShellView";
        #endregion
    }
}