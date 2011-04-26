using System;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseCommand : ICommand
    {
        protected IConsoleFacade console;
        protected IGTDConfiguration gConfig;
        protected ICachedNoteStore note;
        protected string cmdName;
        protected string tagName;

        public BaseCommand(string cmdName, string tagName, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
        {
            this.console = console;
            this.gConfig = gConfig;
            this.note = note;
            this.cmdName = cmdName;
            this.tagName = tagName;
        }

        protected IEnumerable<string> MonthTagNames()
        {
            var jan1 = DateTime.Parse("1/1/2000");
            for (int month = 0; month < 12; month++)
            {
                var dt = jan1.AddMonths(month);
                yield return string.Format("{0:00}-{1:MMM}", month + 1, dt);
            }
        }

        protected IEnumerable<string> DayTagNames()
        {
            for (int day = 1; day < 32; day++)
            {
                yield return gConfig.GetTagForDay(day);
            }
        }

        public string Name
        {
            get { return cmdName; }
        }

        public abstract void Execute(IEnumerable<string> parameters);
    }
}
