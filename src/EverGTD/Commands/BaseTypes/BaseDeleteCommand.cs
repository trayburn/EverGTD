using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseDeleteCommand : BaseCommand
    {
        public BaseDeleteCommand(string cmdName, string tagName, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(cmdName, tagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var allNotes = note.GetNotesByTags(tagName);
            var selectedNote = allNotes[noteNum - 1];
            note.DeleteNote(selectedNote);
        }
    }
}
