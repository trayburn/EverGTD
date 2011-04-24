using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public class WaitingOnCommand : BaseCommand, ICommand
    {
        public WaitingOnCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
        }

        public string Name
        {
            get { return "wait"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var title = parameters.First();
            var tags = parameters.Skip(1).ToList();

            if (tags == null || tags.Count == 0 ||
                (!tags.Any(m => DayTagNames().Contains(m)) && !tags.Any(m => MonthTagNames().Contains(m))))
            {
                console.WriteLine("You must include a Day or Month tag when waiting, as a reminder of when to follow up");
                return;
            }
            tags.Add(gConfig.WaitingOnTagName);

            note.CreateNote(new Note() { Title = title, TagNames = tags });
        }
    }
}
