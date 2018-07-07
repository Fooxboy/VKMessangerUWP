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

    public enum TwoFactorAuthorizationResult
    {
        CodeEnter =1,
        CodeEnterCancel=2
    }


    public sealed partial class TwoFactorAuthorizationContentDialog : ContentDialog
    {
        public TwoFactorAuthorizationResult Result { get; private set; }

        public string Code { get; private set; }

        public TwoFactorAuthorizationContentDialog()
        {
            this.InitializeComponent();
        }

#pragma warning disable S1144 // Unused private types or members should be removed
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (string.IsNullOrEmpty(TextBoxCode.Text))
            {
                NoEnterCode.Visibility = Visibility.Visible;
            }else
            {
                ContentDialogButtonClickDeferral deferral = args.GetDeferral();

                Result = TwoFactorAuthorizationResult.CodeEnter;
                Code = TextBoxCode.Text;

                 deferral.Complete();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Result = TwoFactorAuthorizationResult.CodeEnterCancel;
            Code = null;
            ContentDialogButtonClickDeferral deferral = args.GetDeferral();
            deferral.Complete();

        }
#pragma warning restore S1144
    }
}
