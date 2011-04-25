using System;
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
            var aNotes = note.GetNotesByTags(gConfig.AgendaTagName);
            if (aNotes.Count > 0) OutputAgendas(aNotes);
        }

        private void OutputAgendas(IList<Note> notes)
        {
            int count = 0;
            foreach (var lNote in notes)
            {
                count++;
                console.WriteLine("{0}> {1}", count, lNote.Title);
            }
        }

    }
}
