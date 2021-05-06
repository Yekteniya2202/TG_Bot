using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override string Description => "greets a user with \"Hello\" message";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Bot logic -_-

            await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
}
