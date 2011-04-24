using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace EverGTD
{
    public class AppendCommand : BaseCommand, ICommand
    {
        public AppendCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
        }

        public string Name
        {
            get { return "append"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var text = parameters.Skip(1).First();
            var allNotes = note.GetNotesByTags(gConfig.NextActionTagName);
            var appendNote = allNotes[noteNum - 1];
            appendNote = note.GetNote(appendNote.Guid, true);
            var xDoc = XDocument.Parse(appendNote.Content);
            XName name = XName.Get("div","");
            XElement nElement = new XElement(name);
            nElement.Value = text;
            xDoc.Elements().First().Add(nElement);
            appendNote.Content = xDoc.ToString();
            note.UpdateNote(appendNote);
        }
    }
}
