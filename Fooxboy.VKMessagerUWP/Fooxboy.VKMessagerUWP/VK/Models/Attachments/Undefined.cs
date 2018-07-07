using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.VKMessagerUWP.VK.Models.Attachments
{
    public class Undefined
    {
        public string title
        {
            get => "Тип этого вложения не поддерживается.";
        }

        public override string ToString()
        {
            return "Вложение";
        }

        public string ToMore() => "Вложений";
    }
}
