using Publisher.Infrastructure.Interfaces.Views;
using System.Windows.Controls;

namespace Publisher.Views.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorView.xaml
    /// </summary>
    public partial class AuthorView : UserControl, IAuthorView
    {
        #region Ctor
        public AuthorView()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
