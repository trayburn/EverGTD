using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public class DeleteCommand : BaseCommand, ICommand
    {
        public DeleteCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
        }

        public string Name
        {
            get { return "del"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var allNotes = note.GetNotesByTags(gConfig.NextActionTagName);
            var appendNote = allNotes[noteNum - 1];
            note.DeleteNote(appendNote);
        }
    }
}
