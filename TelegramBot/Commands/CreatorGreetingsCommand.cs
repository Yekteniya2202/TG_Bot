using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBot.Commands
{
    public class CreatorGreetingsCommand : Command
    {
        public override string[] Name => new string[] { "creatorgreetings", "CreatorGreetings", "creator_greetings" };

        public override string Description => "sends user creator's videos with greetings";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            System.IO.FileStream stream = default;
            try
            {
                stream = System.IO.File.Open("greetings.mp4", System.IO.FileMode.Open);
            }
            catch
            {
                return;
            }
            InputOnlineFile iof = new InputOnlineFile(stream);
            iof.FileName = "greetings.mp4";
            var send = await client.SendVideoAsync(chatId, iof, replyToMessageId: messageId);
            stream.Close();
        }
    }
}
