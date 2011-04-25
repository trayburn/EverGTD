using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public class ImportCommand : BaseCommand, ICommand
    {
        public ImportCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("import", gConfig.NextActionTagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var notes = note.AllNotesForToday;
            var dayTag = string.Format("Day {0:00}", DateTime.Now.Day);
            var naGuid = note.AllTags.First(m => m.Name == gConfig.NextActionTagName).Guid;
            var importantGuid = note.AllTags.First(m => m.Name == gConfig.ImportantTagName).Guid;
            var tagGuid = note.AllTags.First(m => m.Name == dayTag).Guid;

            foreach (var lNote in notes)
            {
                lNote.TagGuids.Remove(tagGuid);
                lNote.TagGuids.Add(naGuid);
                lNote.TagGuids.Add(importantGuid);
                lNote.Title = String.Format("@{0} > {1}", dayTag, lNote.Title);
                note.UpdateNote(lNote);
            }
        }
    }
}
