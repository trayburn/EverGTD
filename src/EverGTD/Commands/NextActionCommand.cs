using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public class NextActionCommand : BaseCommand, ICommand
    {
        public NextActionCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
        }

        public string Name
        {
            get { return "na"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var title = parameters.First();
            var tags = parameters.Skip(1).ToList();
            tags.Add(gConfig.NextActionTagName);

            note.CreateNote(new Note() { Title = title, TagNames = tags });
        }
    }
}
