using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands
{
    public class TimeUTCCommand : Command
    {
        public override string[] Name => new string[] { "timeUTC", "TimeUTC", "time_UTC" };

        public override string Description => "<hours> sends user current time for input UTC";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            string[] words = message.Text.Split(' ');
            if (words.Length != 2)
            {
                await client.SendTextMessageAsync(chatId, "Invalid time command format!\nPlease try again", replyToMessageId: messageId);
                return;
            }
            int hours = default;
            if (!int.TryParse(words[1], out hours) || hours < -12 || hours > 12)
            {
                await client.SendTextMessageAsync(chatId, "Invalid UTC format!\nPlease try again", replyToMessageId: messageId);
                return;
            }

            char sign = '+';
            if (hours < 0)
            {
                sign = '-';
                hours *= -1;
            }
            await client.SendTextMessageAsync(chatId, "Current time for UTC" + sign + hours + " is " + System.DateTime.Now.AddHours(-3 + hours).ToString(), replyToMessageId: messageId);

        }
    }
}
