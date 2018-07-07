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

    public enum CaptchaContentDialogResult
    {
        CodeEnter =1,
        CodeEnterCancel=2
    }

    public sealed partial class CaptchaContentDialog : ContentDialog
    {
        public CaptchaContentDialogResult Result { get; private set; }
        public string CaptchaCode { get; private set; }

        public CaptchaContentDialog(Stream stream, bool IsFalse=false)
        {
            this.InitializeComponent();
            if(IsFalse)
            {
                NoEnter.Text = "Вы указали неверный код!";
                NoEnter.Visibility = Visibility.Visible;
            }
            ImagePic.SetSource(stream.AsRandomAccessStream());
        }


#pragma warning disable S1186 // Methods should not be empty
#pragma warning disable S1144 // Unused private types or members should be removed
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(string.IsNullOrEmpty(TextCode.Text))
            {
                NoEnter.Text = "Вы не ввели капчу!";
                NoEnter.Visibility = Visibility.Visible;
            }
            else
            {
                Result = CaptchaContentDialogResult.CodeEnter;
                CaptchaCode = TextCode.Text;
                ContentDialogButtonClickDeferral deferral = args.GetDeferral();
                deferral.Complete();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Result = CaptchaContentDialogResult.CodeEnterCancel;
            ContentDialogButtonClickDeferral deferral = args.GetDeferral();
            deferral.Complete();
        }
#pragma warning restore S1186 // Methods should not be empty
#pragma warning restore S1144 // Unused private types or members should be removed
    }
}
