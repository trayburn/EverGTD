using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseListCommand : BaseCommand, ICommand
    {
        public BaseListCommand(string cmdName, string tagName, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(cmdName, tagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var aNotes = note.GetNotesByTags(tagName);
            if (aNotes.Count > 0) Output(aNotes);
        }

        private void Output(IList<Note> notes)
        {
            int count = 0;
            foreach (var lNote in notes)
            {
                count++;
                if (note.AllImportantNotes.Any(m => m.Guid == lNote.Guid))
                    console.ForegroundColor = ConsoleColor.Yellow;
                console.WriteLine("{0}> {1}", count, lNote.Title);
                console.ResetColor();
            }
        }

    }
}
