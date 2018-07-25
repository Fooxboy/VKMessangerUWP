using System.Collections.ObjectModel;
using Fooxboy.VKMessagerUWP.Model;
using static Fooxboy.VKMessagerUWP.Logger;

namespace Fooxboy.VKMessagerUWP.ViewModel
{
    public class ConsoleViewModel : BaseViewModel
    {
        public ConsoleViewModel()
        {
            itemsLogs = new ObservableCollection<ConsoleLogElementModel>();
            Logger.Info("Инициализация данных консоли...");
            //Logger.Instanse.ChangedLoggerEvent += AddNewMessage;
            foreach (var element in Logger.StackLog)
            {
                AddNewMessage(element);
            }
        }

        public void AddNewMessage(LogElement args)
        {
            if (ItemsLogs is null) return;
            var element = new ConsoleLogElementModel()
            {
                Color = args.Color,
                Text = args.Text,
                Time = args.Time,
                Type = args.Type
            };
            ItemsLogs.Add(element);
        }

        private ObservableCollection<ConsoleLogElementModel> itemsLogs;
        public ObservableCollection<ConsoleLogElementModel> ItemsLogs
        {
            get => itemsLogs;
            set
            {
                if (value == itemsLogs) return;

                itemsLogs = value;
                Changed("ItemsLogs");
            }
        }
    }
}
