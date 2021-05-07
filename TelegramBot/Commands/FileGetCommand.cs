using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBot.Commands
{
    public class FileGetCommand : Command
    {
        public override string Name => "fileget";

        public override string Description => "gets a file by name input";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            string[] words = message.Text.Split(' ');
            //TODO: Bot logic -_-
            if (words.Length == 2)
            {
                Console.WriteLine("File name is " + words[1]);
                try
                {
                    var stream = System.IO.File.Open(words[1], System.IO.FileMode.Open);
                    InputOnlineFile iof = new InputOnlineFile(stream);
                    iof.FileName = words[1];
                    var send = await client.SendDocumentAsync(message.Chat.Id, iof, "Сообщение");
                    stream.Close();
                }
                catch
                {
                    await client.SendTextMessageAsync(chatId, "No such file!\nPlease try again", replyToMessageId: messageId);
                }
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Invalid file command!\nPlease try again", replyToMessageId: messageId);
            }
        }
    }
}
