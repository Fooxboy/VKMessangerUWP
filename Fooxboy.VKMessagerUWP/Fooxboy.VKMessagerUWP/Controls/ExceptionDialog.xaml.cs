using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fooxboy.VKMessagerUWP.Controls
{
    public sealed partial class ExceptionDialog : ContentDialog
    {

        public Exception ExceptionInstanse { get; set; }

        public ExceptionDialog(Exception ex)
        {
            ExceptionInstanse = ex;
            this.InitializeComponent();
            Logger.Error("Необработанное исключение", ExceptionInstanse);
            this.Exception.Text = ExceptionInstanse.Source;
            this.ExceptionMessage.Text = ExceptionInstanse.Message;
            this.TextBox.Text = ExceptionInstanse.ToString();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Application.Current.Exit();
        }
    }
}
