using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBot.Commands
{
    public class FileUploadCommand : Command
    {
        public override string Name => "fileupload";

        public override string Description => "uploads file";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Bot logic -_-
            Console.WriteLine("File name is " + message.Document.FileName + ", caption is " + message.Caption);
            await client.SendTextMessageAsync(chatId, "I've got your file!", replyToMessageId: messageId);
            try
            {
                System.IO.FileStream fs = System.IO.File.Create("C:/Users/79679/source/repos/RGR/TelegramBot/bin/Debug/netcoreapp3.1/" + message.Document.FileName);
                var file = await client.GetInfoAndDownloadFileAsync(message.Document.FileId, fs);
                Console.WriteLine("Got a file\n" + file.ToString());
                fs.Close();
            }
            catch (Exception e)
            {
                await client.SendTextMessageAsync(chatId, e.Message, replyToMessageId: messageId);
            }
        }
    }
}
