using Fooxboy.VKMessagerUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI;

namespace Fooxboy.VKMessagerUWP
{
    public class Logger
    {
        public static List<LogElement> StackLog { get; set; }

        public static Logger Instanse { get; set; }

        public static void NewLogger()
        {
            Instanse = new Logger();
        }

        public Logger(List<LogElement> elements = null)
        {
            if (elements == null) StackLog = new List<LogElement>();
            else StackLog = elements;
        }

        public delegate void ChangedLogger(LogElement element);
        public event ChangedLogger ChangedLoggerEvent;

        public static void Error(string error, Exception e = null)
        {
            string text;
            if (e == null) text = error;
            else text = $"{error}: {e.ToString()}";
            var element = new LogElement()
            {
                Color = Colors.Red,
                Type = TypeLog.Error,
                Text = text,
                Time = DateTime.Now
            };
            Instanse.ChangedLoggerEvent?.Invoke(element);
            StackLog.Add(element);
        }

        public static void Json(string json)
        {
            var element = new LogElement()
            {
                Text = json,
                Color = Colors.Gray,
                Time = DateTime.Now,
                Type = TypeLog.Json
            };
            Instanse.ChangedLoggerEvent?.Invoke(element);

            StackLog.Add(element);
        }

        public static void Waring(string message)
        {
            var element = new LogElement()
            {
                Text = message,
                Color = Colors.Yellow,
                Type = TypeLog.Waring,
                Time = DateTime.Now
            };
            Instanse.ChangedLoggerEvent?.Invoke(element);

            StackLog.Add(element);
        }

        public static void Info(string information)
        {
            LogElement element = new LogElement()
            {
                Text = information,
                Color = Colors.White,
                Type = TypeLog.Info,
                Time = DateTime.Now
            };
            Instanse.ChangedLoggerEvent?.Invoke(element);

            StackLog.Add(element);
        }

        public static void New(LogElement element) => StackLog.Add(element);
        //Интерфейсы и модели
        public interface ILogElement
        {
            string Text { get; set; }
            TypeLog Type { get; set; }
            Color Color { get; set; }
            DateTime Time { get; set; }
        }
        public class LogElement: ILogElement
        {
            public string Text { get; set; }
            public TypeLog Type { get; set; }
            public Color Color { get; set; }
            public DateTime Time { get; set; }
        }
    }
}
