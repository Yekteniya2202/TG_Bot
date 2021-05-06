using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBot
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);
        }
    }
}
