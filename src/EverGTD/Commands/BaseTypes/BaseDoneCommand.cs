using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseDoneCommand : BaseCommand
    {
        public BaseDoneCommand(string cmdName, string tagName, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(cmdName, tagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var allNotes = note.GetNotesByTags(tagName);
            var naGuid = note.AllTags.First(m => m.Name == tagName).Guid;
            var iGuid = note.AllTags.First(m => m.Name == tagName).Guid;
            var appendNote = allNotes[noteNum - 1];
            if (appendNote.TagGuids.Contains(iGuid)) appendNote.TagGuids.Remove(iGuid);
            appendNote.TagGuids.Remove(naGuid);
            note.UpdateNote(appendNote);
        }
    }
}
