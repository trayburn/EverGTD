using System;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseCommand
    {
        protected IConsoleFacade console;
        protected IGTDConfiguration gConfig;
        protected ICachedNoteStore note;

        public BaseCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
        {
            this.console = console;
            this.gConfig = gConfig;
            this.note = note;
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
                yield return string.Format("Day {0:00}", day);
            }
        }
    }
}
