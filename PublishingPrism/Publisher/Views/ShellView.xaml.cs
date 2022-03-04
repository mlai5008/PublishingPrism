using Publisher.Infrastructure.Interfaces.Views;
using System.Windows;

namespace Publisher.Views
{
    /// <summary>
    /// Логика взаимодействия для ShellView.xaml
    /// </summary>
    public partial class ShellView : Window, IShellView
    {
        #region Ctor
        public ShellView()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
