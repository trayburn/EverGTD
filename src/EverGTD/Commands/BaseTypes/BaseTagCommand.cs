using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseTagCommand : BaseCommand, ICommand
    {
        public BaseTagCommand(string cmdName, string tagName, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(cmdName, tagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var tags = parameters.Skip(1);
            var allNotes = note.GetNotesByTags(tagName);
            var guids = note.AllTags.Where(m =>
                tags.Select(n => n.ToLower().Trim())
                .Contains(m.Name.ToLower().Trim()))
                    .Select(m => m.Guid);
            var selectedNote = allNotes[noteNum - 1];
            selectedNote.TagGuids.AddRange(guids);
            note.UpdateNote(selectedNote);
        }
    }
}
