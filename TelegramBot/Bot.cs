using System;
using System.Collections.Generic;
using System.Text;
using TelegramBot.Commands;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    public static class Bot
    {
        public static TelegramBotClient client = new TelegramBotClient(AppSettings.Key);
        public static string Name = AppSettings.Name;
        private static List<Command> commands = new List<Command>();
        public static string DirectoryPath { get; set; }
        public static IReadOnlyList<Command> Commands { get => commands.AsReadOnly(); }
        public static void AddCommand(Command cmd)
        {
            commands.Add(cmd);
        }
    }
}
