using Fooxboy.VKMessagerUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private string _textSearch;
        public string TextSearch
        {
            get => _textSearch;
            set
            {
                if (_textSearch == value) return;

                _textSearch = value;
                Changed("TextSearch");
            }
        }

        private DialogsViewModel vm = DialogsViewModel.GetVM();

        public async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await GetResultSearch();
        }

        private async Task GetResultSearch()
        {
            if(TextSearch == " " || TextSearch == "" || TextSearch == string.Empty || TextSearch == null)
            {
                await vm.GetDialogs();
            }else
            {
                var collection = vm.ItemsDialogs;
                var newCollection = collection.Where(x => x.Title.StartsWith(TextSearch));
                vm.ItemsDialogs = (LoadingCollection<DialogsElementModel>)newCollection;
                vm.ItemsDialogs.HasMoreItemsRequested = () => false;
            }    
        }
    }
}
