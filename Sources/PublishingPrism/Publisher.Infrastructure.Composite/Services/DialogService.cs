using Prism.Ioc;
using Publisher.Infrastructure.Interfaces.EventArguments;
using Publisher.Infrastructure.Interfaces.Service;
using Publisher.Infrastructure.Interfaces.ViewModels;
using Publisher.Infrastructure.Interfaces.Views;
using Publisher.Infrastructure.Interfaces.Views.Base;
using System;
using System.Linq;
using System.Windows;

namespace Publisher.Infrastructure.Composite.Services
{
    public class DialogService : IDialogService
    {
        private readonly IContainerProvider _container;

        public DialogService(IContainerProvider container)
        {
            _container = container;
        }

        public bool ShowDialog<TView>(TView dialogView) where TView : IView
        {
            IMainDialogWindowView ownerView = _container.Resolve<IMainDialogWindowView>();

            InitializeDialogCloseRequestHandler(ownerView, (IDialogViewModel)dialogView.DataContext);
            SetDialogOwner(ownerView);
            ownerView.Content = dialogView;
            ownerView.DataContext = dialogView.DataContext;

            //*******************
            //ownerView.Closed += OwnerViewOnClosed;
            //*************

            bool hhh = ownerView?.ShowDialog() ?? false;
            return hhh;

            //return ownerView?.ShowDialog() ?? false;
        }

        //private void OwnerViewOnClosed(object? sender, EventArgs e)
        //{
        //    IMainDialogWindowView ownerView = sender as IMainDialogWindowView;
        //    //ownerView.Close();
        //    ownerView.DialogResult = false;
        //}

        private void SetDialogOwner(IMainDialogWindowView ownerView)
        {
            ownerView.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        }

        private void InitializeDialogCloseRequestHandler(IMainDialogWindowView ownerView, IDialogViewModel viewModel)
        {
            EventHandler<IDialogCloseRequestedEventArgs> handler = null;

            // Handler on event DialogCloseRequest
            handler = (sender, e) =>
            {
                viewModel.CloseRequested -= handler;

                if (e.DialogResult.HasValue)
                {
                    ownerView.DialogResult = e.DialogResult;
                }
                else
                {
                    ownerView.Close();
                }
            };

            viewModel.CloseRequested += handler;
        }
    }
}