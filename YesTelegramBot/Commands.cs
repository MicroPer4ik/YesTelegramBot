using PRTelegramBot.Attributes;
using PRTelegramBot.InlineButtons;
using PRTelegramBot.Interface;
using PRTelegramBot.Models;
using PRTelegramBot.Models.CallbackCommands;
using PRTelegramBot.Models.InlineButtons;
using PRTelegramBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups; 

namespace YesTelegramBot
{
    public class Commands
    {
        #region Replay
        [ReplyMenuHandler("qq")]
        public static async Task Example(ITelegramBotClient botClient, Update update)
        {
           
            var message = "Hello world!";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, update.Message.Chat.Id.ToString()); 
            

        }


        #endregion

        #region Menu
        [ReplyMenuHandler("Меню")]
        public static async Task MenuButtons(ITelegramBotClient client, Update update)
        {
            string message = "Меню";
            //var menuList = new List<KeyboardButton>();
            var menuListString = new List<string>();

            var ran = new Random().Next(0, 1000);

            menuListString.Add("Меню");
            menuListString.Add($"Меню {ran}");

            //     *KEYBOARD BUTTON*
            //menuList.Add(new KeyboardButton("Меню 1"));
            //menuList.Add(new KeyboardButton("Меню 2"));
            //menuList.Add(new KeyboardButton("Меню 3"));
            //menuList.Add(new KeyboardButton("Меню 4"));
            //menuList.Add(new KeyboardButton("Меню 5"));
            //menuList.Add(new KeyboardButton("Меню 6"));

            var menu = MenuGenerator.ReplyKeyboard(2, menuListString);

            var option = new OptionMessage();
            option.MenuReplyKeyboardMarkup = menu;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(client, update, message, option);


        }
        #endregion

        #region slash
        


        [SlashHandler("/set")]
        [ReplyMenuHandler("get")]
        public static async Task Get(ITelegramBotClient botClient, Update update)
        {
            var message = "Пример /get и /get_1";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);

        }

        [SlashHandler("/get")]
        public static async Task GetSlash(ITelegramBotClient botClient, Update update)
        {
            
            if (update.Message.Text.Contains("_"))
            {
                var spl = update.Message.Text.Split("_");
                if (spl.Length > 1)
                {
                    var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, $"Команда /get и параметр {spl[1]}");
                }
                else
                {
                    var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, "Команда /get");
                }
            }
            else
            {
                var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, "Команда /get");
            }
                
            

        }
        #endregion

        #region Inine
        [ReplyMenuHandler("inline")]
        public static async Task Inline(ITelegramBotClient botClient, Update update)
        {
            var message = "Пример inline";

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineCallback("Пример 1", CustomInlineComand.ExampleOne);
            var url = new InlineURL("Google", "https://google.com");
            var webApp = new InlineWebApp("WebApp", "https://prethink.github.io/telegram/webapp.html");

            var exampleTwo = new InlineCallback<EntityTCommand<long>>("Название кнопки 2", CustomInlineComand.ExampleTwo, new EntityTCommand<long>(5));
            var exampleThree = new InlineCallback<EntityTCommand<long>>("Название кнопки 3", CustomInlineComand.ExampleTwo, new EntityTCommand<long>(3));

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(webApp);
            menu.Add(url);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var options = new OptionMessage();
            options.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage =  await PRTelegramBot.Helpers.Message.Send(botClient, update, message, options);
        }
        #endregion
    }
}
