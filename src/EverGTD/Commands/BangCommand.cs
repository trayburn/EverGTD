using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public class BangCommand : BaseCommand, ICommand
    {
        public BangCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("!", gConfig.NextActionTagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var allNotes = note.GetNotesByTags(tagName);
            var iGuid = note.AllTags.First(m => m.Name == gConfig.ImportantTagName).Guid;
            var appendNote = allNotes[noteNum - 1];

            if (appendNote.TagGuids.Contains(iGuid))
                appendNote.TagGuids.Remove(iGuid);
            else 
                appendNote.TagGuids.Add(iGuid);
            note.UpdateNote(appendNote);
        }
    }
}
