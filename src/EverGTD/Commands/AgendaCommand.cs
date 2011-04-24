using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EverGTD
{
    public class AgendaCommand : BaseCommand, ICommand
    {
        private IAgendaList list;
        private IAgendaCreate create;

        public AgendaCommand(IAgendaList list, IAgendaCreate create, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
            this.list = list;
            this.create = create;
        }

        public string Name
        {
            get { return "agenda"; }
        }

        public void Execute(IEnumerable<string> parameters)
        {
            switch (parameters.Count())
            {
                case 0:
                    list.Execute(parameters);
                    break;
                default:
                    var firstParam = parameters.First().Trim().ToLower();
                    switch (firstParam)
                    {
                        case "+":
                            create.Execute(parameters.Skip(1));
                            break;
                        default:
                            EditAgenda(parameters);
                            break;
                    }
                    break;
            }
        }

        private void EditAgenda(IEnumerable<string> parameters)
        {
            var noteNum = Convert.ToInt32(parameters.First());
            var text = parameters.Skip(1).First();
            var allNotes = note.GetNotesByTags(gConfig.AgendaTagName);
            var appendNote = allNotes[noteNum - 1];
            appendNote = note.GetNote(appendNote.Guid, true);
            var xDoc = XDocument.Parse(appendNote.Content);
            XName name = XName.Get("div", "");
            XElement nElement = new XElement(name);
            nElement.Value = text;
            xDoc.Elements().First().Add(nElement);
            appendNote.Content = xDoc.ToString();
            note.UpdateNote(appendNote);
        }
    }
}
