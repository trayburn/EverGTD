using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    /*
         * xBaseAppendCommand
         * xBaseCreateCommand
         * xBaseDeleteCommand
         * xBaseDoneCommand
         * xBaseListCommand
         * 
         * BaseBrokerCommand
         * 
         */

    public abstract class BaseAppendCommand : BaseCommand, ICommand
    {
        public BaseAppendCommand(string cmdName, string tagName, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(cmdName, tagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var text = parameters.Skip(1).First();

            var allNotes = note.GetNotesByTags(tagName);
            var selectedNote = allNotes[noteNum - 1];
            selectedNote = note.GetNote(selectedNote.Guid, true);

            using (var wrt = new ContentWriter(selectedNote))
            {
                wrt.WriteLine(text);
            }

            note.UpdateNote(selectedNote);
        }
    }
}
