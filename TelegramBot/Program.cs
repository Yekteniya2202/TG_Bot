using System;
using Telegram.Bot;
using Telegram.Bot.Args;

//ПРИВЕТ ВАНЯ!!!!!!!!!
namespace TelegramBot
{
    class Program
    {
        private static string token { get; set; } = "1695496258:AAHCOaKu-xuC-mziYWaRQBRmQLvi8pLV1EA";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;

            Console.ReadLine();
            client.StopReceiving();

        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом {msg.Text}");
                await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
            }
        }
    }
}
