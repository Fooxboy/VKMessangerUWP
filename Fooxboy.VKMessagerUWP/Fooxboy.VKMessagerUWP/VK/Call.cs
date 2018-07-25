using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Fooxboy.VKMessagerUWP.VK.Models;
using Fooxboy.VKMessagerUWP.Exceptions;

namespace Fooxboy.VKMessagerUWP.VK
{
    public static class Call<T>
    {
       
        public async static Task<T> Method(string method, Dictionary<string, string> parametrs, bool conf = false)
        {
            Logger.Info($"Обращение к ВКонтакте. Метод: {method}");
            var json = await Request.GetAsync(method, parametrs);
            Logger.Json(json);
            var response = JsonConvert.DeserializeObject<Response<T>>(json);
            Logger.Info("Десериализация полученных данных...");
            //проверка на значение по умолчанию
            if(EqualityComparer<T>.Default.Equals(response.response, default(T)))
            {
                var error = JsonConvert.DeserializeObject<Error>(json);
                Logger.Error($"Произошла ошибка ВКонтакте. Код: {error.error.error_code} Сообщение: {error.error.error_msg}");

                switch (error.error.error_code)
                {
                    case 1:
                        throw new UnknownErrorException("Попробуйте повторить запрос позже.");
                    case 2:
                        throw new AppOfflineException("Необходимо включить приложение в настройках https://vk.com/editapp?id= {Ваш API_ID} или использовать тестовый режим (test_mode=1)");
                    case 3:
                        throw new UnknownMethodException("Проверьте, правильно ли указано название вызываемого метода: http://vk.com/dev/methods");
                    case 4:
                        throw new VkException("Неверная подпись.");
                    case 5:
                        throw new NoAuthException("Убедитесь, что Вы используете верную схему авторизации.");
                    case 6:
                        throw new MoreRequestException("Задайте больший интервал между вызовами или используйте метод execute. Подробнее об ограничениях на частоту вызовов см. на странице http://vk.com/dev/api_requests.");
                    case 7:
                        throw new NoAccessException("Проверьте синтаксис запроса и список используемых параметров (его можно найти на странице с описанием метода).");
                    case 8:
                        throw new VkException("Проверьте синтаксис запроса и список используемых параметров (его можно найти на странице с описанием метода).");
                    case 9:
                        Logger.Info("Начало обхода...");
                        await Task.Delay(1000);
                        return await Call<T>.Method(method, parametrs, true);
                        //throw new MoreRequestException("Нужно сократить число однотипных обращений. Для более эффективной работы Вы можете использовать execute или JSONP.");
                    case 10:
                        throw new NativeCoreVkException("Попробуйте повторить запрос позже");
                    case 11:
                        throw new VkException("Выключите приложение в настройках https://vk.com/editapp?id={Ваш API_ID}");
                    case 14:
                        throw new CaptchaException("Требуется ввод кода с картинки (Captcha).");
                    case 15:
                        throw new NoAccessException("Убедитесь, что Вы используете верные идентификаторы, и доступ к контенту для текущего пользователя есть в полной версии сайта.");
                    case 16:
                        throw new VkException("Чтобы избежать появления такой ошибки, в Standalone-приложении Вы можете предварительно проверять состояние этой настройки у пользователя методом account.getInfo.");
                    case 17:
                        throw new InvalidUserException("Действие требует подтверждения — необходимо перенаправить пользователя на служебную страницу для валидации.");
                    case 18:
                        throw new UserBannedException("Страница пользователя была удалена или заблокирована");
                    case 20:
                        throw new VkException("Если ошибка возникает несмотря на то, что Ваше приложение имеет тип Standalone, убедитесь, что при авторизации Вы используете redirect_uri=https://oauth.vk.com/blank.html. Подробнее см. http://vk.com/dev/auth_mobile.");
                    case 21:
                        throw new VkException("Данное действие разрешено только для Standalone и Open API приложений");
                    case 23:
                        throw new VkException("Метод был выключен.");
                    case 24:
                        if(conf)
                        {
                            throw new ConfirmationUserException("Требуется подтверждение со стороны пользователя.");
                        }else
                        {
                            parametrs.Add("confirm", "1");
                            return await Call<T>.Method(method, parametrs, true);
                        }        
                    case 27:
                        throw new VkException("Ключ доступа сообщества недействителен");
                    case 28:
                        throw new VkException("Ключ доступа приложения недействителен");
                    case 29:
                        throw new DataLimitException("Достигнут количественный лимит на вызов метода");
                    case 100:
                        throw new VkException("Один из необходимых параметров был не передан или неверен. ");
                    case 101:
                        throw new VkException("Неверный API ID приложения. ");
                    case 113:
                        throw new VkException("Неверный идентификатор пользователя.");
                    case 150:
                        throw new VkException("Неверный timestamp.");
                    case 200:
                        throw new NoAccessPhotoAlbumException("Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id положительный, для сообществ — отрицательный), и доступ к запрашиваемому контенту для текущего пользователя есть в полной версии сайта.");
                    case 201:
                        throw new NoAccessAudioException("Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id положительный, для сообществ — отрицательный), и доступ к запрашиваемому контенту для текущего пользователя есть в полной версии сайта.");
                    case 203:
                        throw new NoAccessGroupException("Убедитесь, что текущий пользователь является участником или руководителем сообщества (для закрытых и частных групп и встреч).");
                    case 300:
                        throw new VkException("Перед продолжением работы нужно удалить лишние объекты из альбома или использовать другой альбом.");
                    case 500:
                        throw new VkException("Проверьте настройки приложения: https://vk.com/editapp?id={Ваш API_ID}&section=payments");
                    case 600:
                        throw new VkException("Нет прав на выполнение данных операций с рекламным кабинетом");
                    case 603:
                        throw new VkException("Произошла ошибка при работе с рекламным кабинетом");
                    default:
                        throw new UnknownErrorException("Неизвестная ошибка.");
                }
            }else
            {
                return response.response;
            }
        }
    }
}
