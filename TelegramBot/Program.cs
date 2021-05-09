using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Collections.Generic;
using TelegramBot.Commands;
using System.Threading;

//ПРИВЕТ ВАНЯ!!!!!!!!!
namespace TelegramBot
{
    public class SenderAndMessage
    {
        public object sender;
        public MessageEventArgs e;
    }

    public class Program
    {
        static int Main(string[] args)
        {
            Bot.client = new TelegramBotClient(AppSettings.Key);
            Bot.AddCommand(new HelloCommand());
            Bot.AddCommand(new HelpCommand());
            Bot.AddCommand(new TimeUTCCommand());
            Bot.AddCommand(new CreatorInfoCommand());
            Bot.AddCommand(new CreatorGreetingsCommand());
            Bot.AddCommand(new FileGetCommand());
            Bot.AddCommand(new FileUploadCommand());
            
            Bot.client.StartReceiving();
            Bot.client.OnMessage += OnMessageHandler;

            Console.ReadLine();
            Bot.client.StopReceiving();

            return 0;
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            SenderAndMessage sm = new SenderAndMessage();
            sm.e = e;
            sm.sender = sender;
            Thread thread = new Thread(new ParameterizedThreadStart(OnMessageHandlerThread));
            thread.Start(sm);
        }
        private static void OnMessageHandlerThread(object SenderMessage)
        {
            SenderAndMessage sm = (SenderAndMessage)SenderMessage;

            MessageEventArgs e = sm.e;

            var msg = e.Message;


            if (msg.Text != null || msg.Caption != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом {msg.Text}");
                foreach (var command in Bot.Commands)
                {
                    if (msg.Text != null && command.Contains(msg.Text))
                    {
                        command.Execute(msg, Bot.client);
                        break;
                    }
                    else if (msg.Caption != null && command.Contains(msg.Caption))
                    {
                        command.Execute(msg, Bot.client);
                        break;
                    }
                }
            }
        }
    }
}
