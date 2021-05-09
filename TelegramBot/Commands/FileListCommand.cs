using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBot.Commands
{
    public class FileListCommand : Command
    {
        public override string[] Name => new string[] { "filelist", "FileList", "file_list" };

        public override string Description => "sends user current file list";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var dir = new DirectoryInfo(Bot.DirectoryPath);
            string reply = "";
            foreach (FileInfo file in dir.GetFiles())
            {
                reply += Path.GetFileName(file.FullName) + '\n';
            }
            await client.SendTextMessageAsync(chatId, reply, replyToMessageId: messageId);
        }
    }
}
