using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class ChatReminderItem : ReminderItem
    {
        public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage, string сhatName, string аccountName) :
            base(alarmDate, alarmMessage)
        {
            ChatName = сhatName;
            AccountName = аccountName;
        }

        public string ChatName { get; set; }
        public string AccountName { get; set; }

        public override void WriteProperties()
        {
            Console.WriteLine(this.GetType().ToString());
            Console.WriteLine(Properties);
            Console.WriteLine($"Chat name: {ChatName}");
            Console.WriteLine($"Account name: {AccountName}\n");
        }
    }
}
