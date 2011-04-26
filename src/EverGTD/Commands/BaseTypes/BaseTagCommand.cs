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
            var allNotes = note.GetNotesByTags(tagName);
            var selectedNote = allNotes[noteNum - 1];

            var tags = parameters.Skip(1);
            foreach (var lTagName in tags)
            {
                string name = lTagName;
                bool add = true;

                if (name.StartsWith("-"))
                {
                    name = name.Substring(1);
                    add = false;
                }

                var fullTag = note.AllTags.FirstOrDefault(m => 
                    m.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

                if (fullTag == null)
                {
                    console.WriteLine("Unknown tag : {0}", name);
                    return;
                }

                var guid = fullTag.Guid;

                if (add)
                    selectedNote.TagGuids.Add(guid);
                else
                    selectedNote.TagGuids.Remove(guid);
            }

            note.UpdateNote(selectedNote);
        }
    }
}
