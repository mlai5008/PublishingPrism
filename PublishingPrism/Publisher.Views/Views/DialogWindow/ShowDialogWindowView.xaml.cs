using Prism.Services.Dialogs;
using Publisher.Infrastructure.Interfaces.Views;
using System.Windows;

namespace Publisher.Views.Views.DialogWindow
{
    /// <summary>
    /// Логика взаимодействия для ShowDialogWindowView.xaml
    /// </summary>
    public partial class ShowDialogWindowView : Window, IShowDialogWindowView
    {
        #region Ctor
        public ShowDialogWindowView()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public IDialogResult Result { get; set; } 
        #endregion
    }
}
