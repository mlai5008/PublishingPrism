using System;
using Publisher.Infrastructure.Interfaces.EventArguments;

namespace Publisher.Infrastructure.Composite.EventArguments
{
    public class DialogCloseRequestedEventArgs : EventArgs, IDialogCloseRequestedEventArgs
    {
        #region ctor
        public DialogCloseRequestedEventArgs()
        {
        }

        public DialogCloseRequestedEventArgs(bool? dialogResult)
        {
            DialogResult = dialogResult;
        }
        #endregion

        #region Properties
        public bool? DialogResult { get; protected set; }
        #endregion
    }
}