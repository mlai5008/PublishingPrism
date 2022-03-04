using Publisher.Infrastructure.Interfaces.Views;
using System.Windows.Controls;

namespace Publisher.Views.Views.DialogViews
{
    /// <summary>
    /// Логика взаимодействия для MyDialogView.xaml
    /// </summary>
    public partial class DialogView : UserControl, IDialogView
    {
        #region Ctor
        public DialogView()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
