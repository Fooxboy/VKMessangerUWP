using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class InfoUserDialogViewModel :BaseViewModel
    {
        public long UserId;

        public InfoUserDialogViewModel(long id)
        {
            UserId = id;
        }

        private Uri photo;
        public Uri Photo
        {
            get => photo;
            set
            {
                if (value == photo) return;

                photo = value;
                Changed("Photo");
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == name) return;
                name = value;
                Changed("Name");
            }
        }

        bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (value = isLoading) return;

                isLoading = value;
                Changed("IsLoading");
            }
        }

        Visibility visibilityLoadingGrid;
        public Visibility VisibilityLoadingGrid
        {
            get => visibilityLoadingGrid;
            set
            {
                if (value == visibilityLoadingGrid) return;

                visibilityLoadingGrid = value;
                Changed("VisibilityLoadingGrid");
            }
        }


        Visibility visibilityInfoGrid;
        public Visibility VisibilityInfoGrid
        {
            get => visibilityInfoGrid;
            set
            {
                if (value == visibilityInfoGrid) return;

                visibilityInfoGrid = value;
                Changed("VisibilityInfoGrid");
            }
        }
    }
}
