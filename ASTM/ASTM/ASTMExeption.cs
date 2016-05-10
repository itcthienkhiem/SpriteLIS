namespace ASTM
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Windows.Forms;

  //  using ASTMConfig;

    using Microsoft.SqlServer.MessageBox;

    /// <summary>
    /// this is fw exception and log to file
    /// </summary>
    public class ASTMExeption : Exception
    {
        #region Constructors

        public ASTMExeption()
            : base()
        {
        }

        public ASTMExeption(string message)
            : base(message)
        {
            ASTMGlobal.Logger.LogError(message);
        }

        public ASTMExeption(string format, params object[] args)
            : base(string.Format(format, args))
        {
            ASTMGlobal.Logger.LogError(format);
        }

        public ASTMExeption(string message, Exception innerException)
            : base(message, innerException)
        {
            ASTMGlobal.Logger.LogError(message);
                ASTMGlobal.Logger.LogException(innerException);
        }

        public ASTMExeption(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
            ASTMGlobal.Logger.LogError(format);
                ASTMGlobal.Logger.LogException(innerException);
        }

        public ASTMExeption(string message, string sourcetext, Exception ex, object form)
            : base(message)
        {
            ASTMGlobal.Logger.LogError(message);
                ASTMGlobal.Logger.LogException(ex);

                ExceptionMessageBox box = showDialog(sourcetext, ex) as ExceptionMessageBox;
                box.Show(form as Form);
        }

        protected ASTMExeption(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Constructors

        #region Methods

        private object showDialog(string sourcetext, Exception ex)
        {
            string str = "Action failed. What do you want to do?";
            ApplicationException exTop = new ApplicationException(str, ex);
            exTop.Source = sourcetext;

            // Show the exception message box with three custom buttons.
            ExceptionMessageBox box = new ExceptionMessageBox(exTop);

            // Set the names of the three custom buttons.
            box.SetButtonText("Skip", "Retry", "Stop Processing");

            // Set the Retry button as the default.
            box.DefaultButton = ExceptionMessageBoxDefaultButton.Button2;
            box.Symbol = ExceptionMessageBoxSymbol.Question;
            box.Buttons = ExceptionMessageBoxButtons.Custom;

            // Do something, depending on the button that the user clicks.
            switch (box.CustomDialogResult)
            {
                case ExceptionMessageBoxDialogResult.Button1:
                    // Skip action
                    break;
                case ExceptionMessageBoxDialogResult.Button2:
                    // Retry action
                    break;
                case ExceptionMessageBoxDialogResult.Button3:
                    // Stop processing action
                    break;
            }
            return box;
        }

        #endregion Methods
    }
}