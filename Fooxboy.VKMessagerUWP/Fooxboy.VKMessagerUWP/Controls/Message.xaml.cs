using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace Fooxboy.VKMessagerUWP.Controls
{
    public sealed partial class Message : UserControl
    {
        public static readonly DependencyProperty SourceImageProperty =
            DependencyProperty.Register("ImageUser", typeof(Uri), typeof(Message), new PropertyMetadata(new Uri("ms-appx:///Images/PhotoUser.jpg"), (d, e) =>
            {
                var control = (Message)d;
                if (e.OldValue == null || e.NewValue == null || !e.OldValue.Equals(e.NewValue)) return;
                var newImage = e.NewValue as Uri;
                var oldImage = e.OldValue as Uri;
                if (newImage.AbsolutePath == oldImage.AbsolutePath) return;
                control.SetImage(newImage);
            }));

        public static readonly DependencyProperty NameUserProperty =
            DependencyProperty.Register("NameUser", typeof(string), typeof(Message), new PropertyMetadata("", (d, e) =>
            {
                var control = (Message)d;
                if (e.OldValue == null || e.NewValue == null || !e.OldValue.Equals(e.NewValue)) return;
                var newName = e.NewValue as string;
                control.SetName(newName);
            }));

        public static readonly DependencyProperty BodyMessageProperty =
            DependencyProperty.Register("BodyText", typeof(string), typeof(Message), new PropertyMetadata("", (d, e) =>
            {
                var control = (Message)d;
                if (e.OldValue == null || e.NewValue == null || !e.OldValue.Equals(e.NewValue)) return;
                var newBody = e.NewValue as string;
                control.SetBody(newBody);
            }));

        public static readonly DependencyProperty DateMessagePropery =
            DependencyProperty.Register("Date", typeof(string), typeof(Message), new PropertyMetadata("", (d, e) =>
            {
                var control = (Message)d;
                if (e.OldValue == null || e.NewValue == null || !e.OldValue.Equals(e.NewValue)) return; 
                var newDate = e.NewValue as string;
                control.SetDate(newDate);
            }));

        private void SetImage(Uri uri)=> ImageUser.Source = uri;
        private void SetName(string name) => NameUserText.Text = name;
        private void SetBody(string body) => RunBody.Text = body;
        private void SetDate(string date) => DateText.Text = date;


        public string NameUser
        {
            get => (string)GetValue(NameUserProperty);
            set => SetValue(NameUserProperty, value);
        }
        public string Date
        {
            get => (string)GetValue(DateMessagePropery);
            set => SetValue(DateMessagePropery, value);
        }

        public string TextMessage
        {
            get => (string)GetValue(BodyMessageProperty);
            set => SetValue(BodyMessageProperty, value);
        }

        public Uri PhotoUser
        {
            get => (Uri)GetValue(SourceImageProperty);
            set => SetValue(SourceImageProperty, value);
        }

        public Message()
        {
            this.InitializeComponent();
        }
    }
}
