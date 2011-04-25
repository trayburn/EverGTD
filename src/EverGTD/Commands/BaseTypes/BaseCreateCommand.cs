using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseCreateCommand : BaseCommand, ICommand
    {
        public BaseCreateCommand(string cmdName, string tagName, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(cmdName, tagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var title = parameters.First();
            var tags = parameters.Skip(1).ToList();
            tags.Add(tagName);

            note.CreateNote(new Note() { Title = title, TagNames = tags });
        }
    }
}
