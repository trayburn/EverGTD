using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EverGTD
{
    public class AgendaCommand : BaseCommand, ICommand
    {
        public AgendaCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(console, note, gConfig)
        {
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
                    ListAgenda();
                    break;
                default:
                    CreateOrEditAgenda(parameters);
                    break;
            }
        }

        private void ListAgenda()
        {
            var aNotes = note.GetNotesByTags(gConfig.AgendaTagName);
            if (aNotes.Count > 0) OutputAgendas(aNotes);
        }

        private void CreateOrEditAgenda(IEnumerable<string> parameters)
        {
            var firstParam = parameters.First().Trim().ToLower();
            switch (firstParam)
            {
                case "+":
                    CreateAgenda(parameters.Skip(1));
                    break;
                default:
                    EditAgenda(parameters);
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
        private void CreateAgenda(IEnumerable<string> parameters)
        {
            var title = parameters.First();
            var tags = parameters.Skip(1).ToList();
            tags.Add(gConfig.AgendaTagName);

            note.CreateNote(new Note() { Title = title, TagNames = tags });
        }
        private void OutputAgendas(IList<Note> notes)
        {
            console.WriteLine("Agendas");
            console.WriteLine("-------");
            int count = 0;
            foreach (var lNote in notes)
            {
                count++;
                console.WriteLine("{0}> {1}", count, lNote.Title);
            }
        }
    }
}
