using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Collections.Generic;
using TelegramBot.Commands;

//ПРИВЕТ ВАНЯ!!!!!!!!!
namespace TelegramBot
{
    public class Program
    {
        static int Main(string[] args)
        {
            Bot.client = new TelegramBotClient(AppSettings.Key);
            Bot.AddCommand(new HelloCommand());
            Bot.AddCommand(new HelpCommand());
            Bot.client.StartReceiving();
            Bot.client.OnMessage += OnMessageHandler;

            Console.ReadLine();
            Bot.client.StopReceiving();

            return 0;
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом {msg.Text}");
                foreach(var command in Bot.Commands)
                {
                    if (command.Contains(msg.Text))
                    {
                        command.Execute(msg, Bot.client);
                        break;
                    }
                }
            }
        }
    }
}
