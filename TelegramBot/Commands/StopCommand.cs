using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands
{
    public class StopCommand : Command
    {
        public override string[] Name => new string[] { "stop" };

        public override string Description => "stops bot";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Bot logic -_-
            if (!Bot.IsStarted) return;
            Bot.IsStarted = false;
            await client.SendTextMessageAsync(chatId, "It's time to sleep\nSee you later...", replyToMessageId: messageId);
        }
    }
}