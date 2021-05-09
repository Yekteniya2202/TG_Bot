using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands
{
    public class StartCommand : Command
    {
        public override string[] Name => new string[] { "start" };

        public override string Description => "starts bot";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Bot logic -_-
            if (Bot.IsStarted) return;
            Bot.IsStarted = true;
            await client.SendTextMessageAsync(chatId, "Hello everyone!\nReady to work!", replyToMessageId: messageId);
        }
    }
}
