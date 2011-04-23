using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public class SetupCommand : BaseCommand, ICommand
    {
        public SetupCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
        }

        public string Name
        {
            get { return "setup"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var gtd = note.AllNotebooks.FirstOrDefault(m => m.Name == gConfig.NotebookName);

            if (gtd == null)
            {
                console.WriteLine("Creating Notebook");
                note.CreateNotebook(new Notebook
                {
                    Name = gConfig.NotebookName
                });
            }

            var nextAct = note.CreateTagIfNeeded(gConfig.NextActionTagName);
            var waitingOn = note.CreateTagIfNeeded(gConfig.WaitingOnTagName);
            var someday = note.CreateTagIfNeeded(gConfig.SomedayTagName);
            var tickler = note.CreateTagIfNeeded(gConfig.TicklerTagName);
            var days = note.CreateTagIfNeeded(gConfig.TicklerDaysSubTagName, tickler.Guid);
            var months = note.CreateTagIfNeeded(gConfig.TicklerMonthsSubTagName, tickler.Guid);

            for (int day = 1; day < 32; day++)
            {
                note.CreateTagIfNeeded(string.Format("Day {0:00}", day), days.Guid);
            }

            var jan1 = DateTime.Parse("1/1/2000");
            for (int month = 0; month < 12; month++)
            {
                var dt = jan1.AddMonths(month);
                note.CreateTagIfNeeded(string.Format("{0:00}-{1:MMM}", month + 1, dt), months.Guid);
            }
        }
    }
}
