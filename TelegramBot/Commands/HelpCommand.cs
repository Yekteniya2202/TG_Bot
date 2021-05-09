using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace TelegramBot.Commands
{
    public class HelpCommand : Command
    {
        public override string[] Name => new string[] { "help"};
        public override string Description => "shows current available commands";
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            //TODO: Bot logic -_-
            StringBuilder InfoReplyBuilder = new StringBuilder();
            string InfoReply;

            foreach(var command in Bot.Commands)
            {
                InfoReplyBuilder.Append('/' + command.Name[0] + '@' + Bot.Name + ' ' + command.Description + '\n');
            }
            InfoReply = InfoReplyBuilder.ToString();
            await client.SendTextMessageAsync(chatId, InfoReply, replyToMessageId: messageId);
        }
    }
}
