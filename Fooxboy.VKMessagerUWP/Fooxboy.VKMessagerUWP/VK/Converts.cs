using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK
{
    public static class Converts
    {
        public static string LastSeenPlatform(int i)
        {
            switch(i)
            {
                case 1:
                    return "телефона";
                case 2:
                    return "iPhone";
                case 3:
                    return "iPad";
                case 4:
                    return "android";
                case 5:
                    return "windows phone";
                case 6:
                    return "windows 10";
                case 7:
                    return "компьютера";
                case 8:
                    return "VK Mobile";
                default:
                    return "компьютера";
            }
        }

        public static string Month(int i)
        {
            switch(i)
            {
                case 1:
                    return "Янв.";
                case 2:
                    return "Фев.";
                case 3:
                    return "Мар.";
                case 4:
                    return "Апр.";
                case 5:
                    return "Мая";
                case 6:
                    return "Июн.";
                case 7:
                    return "Июл.";
                case 8:
                    return "Авг.";
                case 9:
                    return "Сен.";
                case 10:
                    return "Окт.";
                case 11:
                    return "Ноя.";
                case 12:
                    return "Дек.";
                default:
                    return i.ToString();
            }
        }
    }
}
