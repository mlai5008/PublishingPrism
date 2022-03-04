using Publisher.Infrastructure.Interfaces.Views;
using System.Windows.Controls;

namespace Publisher.Views.Views
{
    /// <summary>
    /// Логика взаимодействия для BookView.xaml
    /// </summary>
    public partial class BookView : UserControl, IBookView
    {
        #region Ctor
        public BookView()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
