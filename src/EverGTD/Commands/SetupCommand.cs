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

            foreach (var day in DayTagNames())
            {
                note.CreateTagIfNeeded(day, days.Guid);
            }

            foreach (var month in MonthTagNames())
            {
                note.CreateTagIfNeeded(month, months.Guid);
            }
        }
    }
}
