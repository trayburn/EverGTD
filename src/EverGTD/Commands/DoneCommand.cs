using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public class DoneCommand : BaseCommand, ICommand
    {
        public DoneCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
        }

        public string Name
        {
            get { return "done"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var allNotes = note.GetNotesByTags(gConfig.NextActionTagName);
            var naGuid = note.AllTags.First(m => m.Name == gConfig.NextActionTagName).Guid;
            var iGuid = note.AllTags.First(m => m.Name == gConfig.ImportantTagName).Guid;
            var appendNote = allNotes[noteNum - 1];
            if (appendNote.TagGuids.Contains(iGuid)) appendNote.TagGuids.Remove(iGuid);
            appendNote.TagGuids.Remove(naGuid);
            note.UpdateNote(appendNote);
        }
    }
}
