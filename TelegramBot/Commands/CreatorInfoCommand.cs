using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace TelegramBot.Commands
{
    public class CreatorInfoCommand : Command
    {
        public override string[] Name => new string[] { "creatorinfo", "CreatorInfo", "creator_info" };

        public override string Description => "send user an info about the bot's creator";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Bot logic -_-

            await client.SendPhotoAsync(chatId, photo: "https://sun9-37.userapi.com/impg/U24RTcpVwHl0Vpgh67neRI0FoY0r0qw5tYbMGQ/b5bKkd9HLL4.jpg?size=320x320&quality=96&sign=b634077a02433bd957b525fde35e3781&type=album",
                caption: "Michael Babaev, 19 y.o., student of BSTU, group 19-IVT-1-PO-B\n" +
                "VK page - https://vk.com/id157286382",
                replyToMessageId: messageId
                );
        }
    }
}
