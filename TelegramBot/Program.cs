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
            Bot.DirectoryPath = @"C:\Users\79679\source\repos\RGR\TelegramBot\bin\Debug\netcoreapp3.1\bfolder";
            Bot.AddCommand(new StartCommand());
            Bot.AddCommand(new StopCommand());
            Bot.AddCommand(new HelloCommand());
            Bot.AddCommand(new HelpCommand());
            Bot.AddCommand(new TimeUTCCommand());
            Bot.AddCommand(new CreatorInfoCommand());
            Bot.AddCommand(new CreatorGreetingsCommand());
            Bot.AddCommand(new FileGetCommand());
            Bot.AddCommand(new FileUploadCommand());
            Bot.AddCommand(new FileListCommand());
            
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
                    if (command is StartCommand ^ command is StopCommand && command.Contains(msg.Text))
                    {
                        command.Execute(msg, Bot.client);
                    }
                    if (msg.Text != null && command.Contains(msg.Text) && Bot.IsStarted)
                    {
                        command.Execute(msg, Bot.client);
                        break;
                    }
                    else if (msg.Caption != null && command.Contains(msg.Caption) && Bot.IsStarted)
                    {
                        command.Execute(msg, Bot.client);
                        break;
                    }
                }
            }
        }
    }
}
