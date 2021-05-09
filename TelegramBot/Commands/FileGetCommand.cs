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
        public override string[] Name => new string[] { "fileget", "FileGet", "file_get" };

        public override string Description => "<filename> gets a file by name input";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            string[] words = message.Text.Split(' ');
            //TODO: Bot logic -_-
            if (words.Length >= 2)
            {
                string fileName = "";
                for (int i = 1; i < words.Length; i++)
                {
                    if (i != words.Length - 1)
                    {
                        fileName += words[i] + ' ';
                    }
                    else
                    {
                        fileName += words[i];
                    }
                }
                Console.WriteLine("File name is " + fileName);
                try
                {
                    var stream = System.IO.File.Open(Bot.DirectoryPath + @"\" + fileName, System.IO.FileMode.Open);
                    InputOnlineFile iof = new InputOnlineFile(stream);
                    iof.FileName = fileName;
                    var send = await client.SendDocumentAsync(message.Chat.Id, iof);
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
