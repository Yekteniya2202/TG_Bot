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
        public override string[] Name => new string[] { "fileupload", "FileUpload", "file_upload" };

        public override string Description => "uploads file up to 20 Mb";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;


            //TODO: Bot logic -_-
            if (message.Document != null)
            {
                Console.WriteLine("File name is " + message.Document.FileName + ", caption is " + message.Caption);
                System.IO.FileStream fs = default;
                try
                {
                    if (message.Document.FileSize > 20 * 1024 * 1024)
                    {
                        throw new Exception("File is too big");
                    }
                    fs = System.IO.File.Create(Bot.DirectoryPath + @"\" + message.Document.FileName);
                    var file = await client.GetInfoAndDownloadFileAsync(message.Document.FileId, fs);
                    await client.SendTextMessageAsync(chatId, "I've got your file!", replyToMessageId: messageId);
                    Console.WriteLine("Got a file\n" + file.ToString());
                    fs.Close();
                }
                catch (Exception e)
                {
                    await client.SendTextMessageAsync(chatId, $"Error uploading file! ({e.Message})\nPlease try again", replyToMessageId: messageId);
                }
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Not found file!\nPlease try again", replyToMessageId: messageId);
            }
        }
    }
}
