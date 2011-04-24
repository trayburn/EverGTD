using System;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public class AgendaListCommand : BaseCommand, ICommand, IAgendaList
    {
        public AgendaListCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
        }

        public string Name
        {
            get { return "a"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var aNotes = note.GetNotesByTags(gConfig.AgendaTagName);
            if (aNotes.Count > 0) OutputAgendas(aNotes);
        }

        private void OutputAgendas(IList<Note> notes)
        {
            console.WriteLine("Agendas");
            console.WriteLine("-------");
            int count = 0;
            foreach (var lNote in notes)
            {
                count++;
                console.WriteLine("{0}> {1}", count, lNote.Title);
            }
        }
    }
}
