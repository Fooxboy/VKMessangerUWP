using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class SettingsViewModel: BaseViewModel
    {
        private string _photo;
        public string Photo
        {
            get => _photo;
            set
            {
                if (value == _photo) return;

                _photo = value;
                Changed("Photo");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;

                _name = value;
                Changed("Name");
            }
        }
    }
}
